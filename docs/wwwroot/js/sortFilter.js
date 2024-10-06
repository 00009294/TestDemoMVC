document.getElementById('searchInput').addEventListener('keyup', function () {
    const searchTerm = this.value.toLowerCase();
    const rows = document.querySelectorAll('#employeeTable tbody tr');

    rows.forEach(row => {
        const cells = row.getElementsByTagName('td');
        const rowText = Array.from(cells).map(cell => cell.textContent.toLowerCase()).join(' ');
        row.style.display = rowText.includes(searchTerm) ? '' : 'none';
    });
});

function sortTable(columnIndex) {
    const table = document.getElementById("employeeTable");
    const tbody = table.tBodies[0];
    const rows = Array.from(tbody.rows);
    const isAscending = !tbody.dataset.sortOrder || tbody.dataset.sortOrder === "desc";

    // Sort the rows based on the specified column index
    rows.sort((a, b) => {
        const aText = a.cells[columnIndex].textContent.trim();
        const bText = b.cells[columnIndex].textContent.trim();

        return (isAscending ? aText.localeCompare(bText) : bText.localeCompare(aText));
    });

    // Remove all existing rows
    while (tbody.firstChild) {
        tbody.removeChild(tbody.firstChild);
    }

    // Re-add the newly sorted rows
    rows.forEach(row => tbody.appendChild(row));

    // Update sort order
    tbody.dataset.sortOrder = isAscending ? "asc" : "desc";
}