export function getFiles(elementId) {
    const element = document.getElementById(elementId);
    if (!element) return;

    return Array.from(element.files).map((f, index) => ({
        index: index,
        name: f.name,
        size: f.size,
        type: f.type,
        lastModified: f.lastModified
    }));
}

export async function openReadStream(elementId, index, chunkSize) {
    const element = document.getElementById(elementId);
    if (!element) return;

    const file = element.files[index];
    const stream = file.stream();
    const reader = stream.getReader();

    return {
        async read() {
            const { done, value } = await reader.read();
            if (done) return null;
            return value;
        }
    };
}