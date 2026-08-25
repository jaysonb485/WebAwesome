
import { html } from 'https://cdn.jsdelivr.net/npm/lit@3/+esm';

export async function initEventGrid(gridElement, gridId, rowKeyProperty, dotNetRef, columnsJson, hasRowDetails) {

    await customElements.whenDefined("wa-data-grid");
    await gridElement.updateComplete;

    const cacheContainerId = `portal-cache-${gridId}`;

    const columns = JSON.parse(columnsJson);
    console.log(columns);
    // Identify columns that have templates and set up the formatter to render a placeholder
    gridElement.columns = columns.map(col => {
        const colConfig = { ...col };

        if (col.hasTemplate) {
            colConfig.formatter = (_value, row) => {

                const rowId = row[rowKeyProperty];
                const colId = col.id;
                const portalId = `cell-portal-${gridId}-${rowId}-${colId}`;

                return html`<div class="wa-blazor-portal-slot" data-portal-id="${portalId}"></div>`;
            };
        }

        return colConfig;
    });

    if (hasRowDetails) {
        gridElement.rowDetail = row => html`<div class="wa-row-detail-placeholder" data-row-id="${row[rowKeyProperty]}">
        </div>`

        gridElement.addEventListener('wa-row-expand', async (event) => {

            await gridElement.updateComplete;

            const row = event.detail.row;
            const rowId = row[rowKeyProperty];

            // Find the row's detail container (checking both shadow DOM and light DOM)
            const root = gridElement.shadowRoot || gridElement;
            const placeholder = root.querySelector(`.wa-row-detail-placeholder[data-row-id="${rowId}"]`);
            if (placeholder) {
                // Request Blazor to render the RenderFragment using HtmlRenderer
                const htmlContent = await dotNetRef.invokeMethodAsync('RenderRowDetail', rowId.toString());

                placeholder.innerHTML = htmlContent;
                placeholder.dataset.loaded = "true"; // Cache so collapsing/re-expanding is instant
            }
        });
    }

    // Monitor scrolling and DOM changes to allow for dynamic swapping of Blazor nodes into the correct slots
    const observer = new MutationObserver((mutations) => {
        // A. Move Blazor nodes back to Cache -> Avoid Lit destroying them when they are no longer visible
        mutations.forEach(mutation => {
            mutation.removedNodes.forEach(node => {
                if (node.nodeType === Node.ELEMENT_NODE) {
                    // Find any portal slots or nested slots that are being destroyed by Lit
                    const slots = node.classList?.contains('wa-blazor-portal-slot')
                        ? [node]
                        : node.querySelectorAll?.('.wa-blazor-portal-slot') || [];

                    slots.forEach(slot => returnBlazorNodeToCache(slot, cacheContainerId));
                }
            });
        });

        // B. Handle New Visible Slots -> Borrow Blazor nodes from Cache
        projectBlazorPortals(gridElement);
    });

    // Watch for DOM changes in both light and shadow DOM
    const target = gridElement.shadowRoot || gridElement;
    observer.observe(target, { childList: true, subtree: true });

    // Handle server-side data if the server attribute is set.
    if (gridElement.hasAttribute('server') && gridElement.getAttribute('server') !== 'false') { 
        // Get data from Blazor
        gridElement.addEventListener('wa-data-request', async (event) => {

            gridElement.loading = true;

            const requestDetails = event.detail; // Contains page, pageSize, sort array, etc.
            console.log('requestDetails', requestDetails);
            // Request data slice from Blazor via Interop
            const normalizedFilters = requestDetails.filters.map(f => ({
                ...f,
                value: (f.value ?? []).map(v =>
                    v === undefined ? null : v
                )
            }));

            console.log('normalizedFilters', normalizedFilters);

            const responseJson = await dotNetRef.invokeMethodAsync('HandleDataRequest', {
                page: requestDetails.page,
                pageSize: requestDetails.pageSize,
                sort: requestDetails.sort || [],
                search: requestDetails.search,
                filters: normalizedFilters
            });

            // Provide items and total count back to Web Awesome Data Grid
            
            const response = JSON.parse(responseJson);

            gridElement.data = response.items;
            gridElement.total = response.total;

            await gridElement.updateComplete;
            // After Lit updates elements in DOM, swap Blazor nodes into Web Awesome cells
            requestAnimationFrame(() => projectBlazorPortals(gridElement));

            gridElement.loading = false;
        });


        // Initial load trigger
        gridElement.reload();
    }
}

/**
 * Projects pre-rendered Blazor DOM nodes into matching portal slots.
 * Cleans up any mismatched/recycled nodes automatically.
 */
/**
 * Projects pre-rendered Blazor DOM nodes into matching portal slots.
 */
function projectBlazorPortals(gridElement, cacheContainerId) {
    const root = gridElement.shadowRoot || gridElement;
    const slots = root.querySelectorAll('.wa-blazor-portal-slot');
    const cacheContainer = document.getElementById(cacheContainerId);

    slots.forEach(slot => {
        const targetPortalId = slot.getAttribute('data-portal-id');
        if (!targetPortalId) return;

        // 1. If slot already contains the single correct node, skip it
        if (slot.children.length === 1 && slot.firstElementChild.id === targetPortalId) {
            return;
        }

        // 2. Evict any mismatched nodes currently inside this slot back to cache
        if (cacheContainer) {
            Array.from(slot.children).forEach(child => {
                if (child.id !== targetPortalId) {
                    cacheContainer.appendChild(child);
                }
            });
        }

        // 3. Find the target node wherever it currently lives (cache container, global doc, or shadow root)
        let targetNode = document.getElementById(targetPortalId);
        if (!targetNode && cacheContainer) {
            targetNode = cacheContainer.querySelector(`[id="${targetPortalId}"]`);
        }
        if (!targetNode) {
            targetNode = root.querySelector(`[id="${targetPortalId}"]`);
        }

        // 4. Attach the matching node
        if (targetNode && !slot.contains(targetNode)) {
            slot.appendChild(targetNode);
        }
    });
}

/**
 * Rescues all child nodes from a slot before destruction/recycling
 */
function returnBlazorNodeToCache(slot, cacheContainerId) {
    const cacheContainer = document.getElementById(cacheContainerId);
    if (!cacheContainer) return;

    while (slot.firstElementChild) {
        cacheContainer.appendChild(slot.firstElementChild);
    }
}

/**
 * Evacuates all active slots back to cache container before data reloads/filters
 */
function evacuateAllPortals(gridElement, cacheContainerId) {
    const root = gridElement.shadowRoot || gridElement;
    const slots = root.querySelectorAll('.wa-blazor-portal-slot');
    slots.forEach(slot => returnBlazorNodeToCache(slot, cacheContainerId));
}

export function setData(gridElement, dataJson) {
    console.log(dataJson);
    const data = JSON.parse(dataJson);
    gridElement.data = data;
}
export function getPageCount(gridElement) {
    return gridElement.pageCount;
}

export function setPageSizeOptions(gridElement, pageSizeOptions) {
    gridElement.pageSizeOptions = pageSizeOptions;
}

export function getSelectedRows(gridElement) {
    return gridElement.selectedKeys;
}

export function sortColumn(gridElement, columnId, direction) {
    gridElement.sort({ id: columnId, desc: direction === 'desc' });
}

export function copySelectedRows(gridElement, columnIds, includeHeaders, dataGridCopyFormat, escapeFormulas) {
    return gridElement.copySelectedRows(columnIds, includeHeaders, dataGridCopyFormat, escapeFormulas);
}

export function expandAllRows(gridElement) {
    gridElement.expandAllRows();
}

export function expandRow(gridElement, rowKey)
{
    gridElement.expandRow(rowKey);
}

export function exportDataAsCsv(gridElement, fileName, columnIds, includeHeaders, delimiter, escapeFormulas) {
    gridElement.exportDataAsCsv(fileName, columnIds, includeHeaders, delimiter, escapeFormulas);
}

export function setColumnFilterOptions(gridElement, columnId, filterOptions) {
    gridElement.columns.find(c => c.id === columnId).filterOptions = filterOptions;
}

        