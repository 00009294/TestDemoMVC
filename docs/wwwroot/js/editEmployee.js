function openEditModal(id, column1, column2, column3, column4, column5) {
    document.getElementById('editEmployeeId').value = id;
    document.getElementById('editColumn1').value = column1;
    document.getElementById('editColumn2').value = column2;
    document.getElementById('editColumn3').value = column3;
    document.getElementById('editColumn4').value = column4;
    document.getElementById('editColumn5').value = column5;
    document.getElementById('editModal').style.display = 'block';
}

function closeEditModal() {
    document.getElementById('editModal').style.display = 'none';
}

async function updateEmployee(event) {
    event.preventDefault();
    const id = document.getElementById('editEmployeeId').value;
    const column1 = document.getElementById('editColumn1').value;
    const column2 = document.getElementById('editColumn2').value;
    const column3 = document.getElementById('editColumn3').value;
    const column4 = document.getElementById('editColumn4').value;
    const column5 = document.getElementById('editColumn5').value;

    const response = await fetch(`Employee/Update`, {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            Id: id,
            Column1: column1,
            Column2: column2,
            Column3: column3,
            Column4: column4,
            Column5: column5
        })
    });

    if (response.ok) {
        closeEditModal(); 
        location.reload();
    } else {
        alert('Error updating employee: ' + response.statusText);
    }
}
