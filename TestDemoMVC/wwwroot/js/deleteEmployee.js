async function deleteEmployee(id) {
    const response = await fetch(`/Employee/Delete?id=${id}`, {
        method: 'DELETE',
        headers: {
            'Content-Type': 'application/json'
        }
    });

    if (response.ok) {
        location.reload(); // Refresh the page to see changes
    } else {
        alert("Error deleting employee: " + response.statusText);
    }
}
