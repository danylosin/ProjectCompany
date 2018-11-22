'use strict';

function createEmployee(e) {
    e.preventDefault();
    fetch('/employee/createfromjson', {
        method: "POST", 
        headers: {
            "Accept": "application/json",
            "Content-Type": "application/json"
        },
        body: JSON.stringify({"Name": `${e.target[0].value}`})
    })
    .then(r => {
        if (r.status == 422) {
            alert("Invalid entity");
            reject();
        } else if (r.status == 200) {
            return r.json()
        }
    })
    .then((response) => {
        appendNewEmployee(response);
    })
}

function appendNewEmployee(r) {
    let table = document.getElementById("employee-table");
    let row = table.insertRow(0);

    let id = row.insertCell(0);
    let name = row.insertCell(1);

    id.innerHTML = r.id;
    name.innerHTML = r.name;
    table.appendChild(row);
}