
import { html } from 'https://cdn.jsdelivr.net/npm/lit@3/+esm';

export async function initEventGrid(gridElement, gridId, rowKeyProperty, dotNetRef, columns) {

    await customElements.whenDefined("wa-data-grid");
    await gridElement.updateComplete;

    const cacheContainerId = `portal-cache-${gridId}`;

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

        console.log(colConfig);
        return colConfig;
    });

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

            // Request data slice from Blazor via Interop
            const response = await dotNetRef.invokeMethodAsync('HandleDataRequest', {
                page: requestDetails.page,
                pageSize: requestDetails.pageSize,
                sort: requestDetails.sort || []
            });

            // Provide items and total count back to Web Awesome Data Grid
            gridElement.data = response.items;
            gridElement.total = response.total;

            // After Lit updates elements in DOM, swap Blazor nodes into Web Awesome cells
            requestAnimationFrame(() => projectBlazorPortals(gridElement));

            gridElement.loading = false;
        });


        // Initial load trigger
        gridElement.reload();
    }
}

function projectBlazorPortals(gridElement) {
    const slots = gridElement.shadowRoot.querySelectorAll('.wa-blazor-portal-slot');
    slots.forEach(slot => {
        const portalId = slot.getAttribute('data-portal-id');
        if (!portalId) return;

        const blazorNode = document.getElementById(portalId);
        if (blazorNode && !slot.contains(blazorNode)) {
            slot.appendChild(blazorNode);
        }
    });
}

function returnBlazorNodeToCache(slot, cacheContainerId) {
    const blazorNode = slot.firstElementChild;
    const cacheContainer = document.getElementById(cacheContainerId);

    if (blazorNode && cacheContainer) {
        cacheContainer.appendChild(blazorNode);
    }
}

export function setData(gridElement, data) {
    gridElement.data = data;
}
function getPageCount(gridElement) {
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

        