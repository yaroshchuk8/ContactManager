function editRow(id) {
    var row = document.getElementById('row-' + id);
    row.querySelectorAll('.view-mode').forEach(function (el) { el.style.display = 'none'; });
    row.querySelectorAll('.edit-mode').forEach(function (el) { el.style.display = ''; });
    row.querySelector('.edit-btn').style.display = 'none';
    row.querySelector('.save-btn').style.display = '';
    row.querySelector('.cancel-btn').style.display = '';
}

function cancelEdit(id) {
    var row = document.getElementById('row-' + id);
    row.querySelectorAll('.view-mode').forEach(function (el) { el.style.display = ''; });
    row.querySelectorAll('.edit-mode').forEach(function (el) { el.style.display = 'none'; });
    row.querySelector('.edit-btn').style.display = '';
    row.querySelector('.save-btn').style.display = 'none';
    row.querySelector('.cancel-btn').style.display = 'none';
}

function saveRow(id) {
    var row = document.getElementById('row-' + id);
    var name = row.querySelector('input[id="name-edit"]').value;
    var dateOfBirth = row.querySelector('input[id="dateofbirth-edit"]').value;
    var married = row.querySelector('input[id="married-edit"]').checked;
    var phone = row.querySelector('input[id="phone-edit"]').value;
    var salary = row.querySelector('input[id="salary-edit"]').value;

    // Send the updated values via AJAX
    fetch('/Home/Edit', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'X-CSRF-TOKEN': '@Html.AntiForgeryToken()'
        },
        body: JSON.stringify({
            Id: id,
            Name: name,
            DateOfBirth: dateOfBirth,
            Married: married,
            Phone: phone,
            Salary: salary
        })
    }).then(response => response.json())
        .then((data, body) => {
            if (data.success) {
                // Update the row to view mode with the new data
                row.querySelectorAll('.view-mode').forEach(function (el) { el.style.display = ''; });
                row.querySelectorAll('.edit-mode').forEach(function (el) { el.style.display = 'none'; });

                // Update buttons' state
                row.querySelector('.edit-btn').style.display = '';
                row.querySelector('.save-btn').style.display = 'none';
                row.querySelector('.cancel-btn').style.display = 'none';

                // Update the text content with the new values
                row.querySelector('span[id="name-view"]').textContent = name;
                row.querySelector('span[id="dateofbirth-view"]').textContent = new Date(dateOfBirth).toLocaleDateString();
                row.querySelector('span[id="married-view"]').textContent = married ? 'True' : 'False';
                row.querySelector('span[id="phone-view"]').textContent = phone;
                row.querySelector('span[id="salary-view"]').textContent = salary;
            } else {
                alert('Error saving data');
            }
        });
}