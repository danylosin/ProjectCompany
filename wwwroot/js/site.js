'use strict';

function deleteProject(id) {
    console.log(id);
    fetch(`/project/${id}`, {method: "DELETE"})
        .then((response) => {
            createNotify();
        })
        .catch((e) => {
            alert("Cannot delete this item " + e);
        })
}

function createNotify() {
    let p = document.createElement('p');
    p.className = "alert alert-success";
    p.innerHTML = "Good job";
    let card = document.getElementById("card");
    card.appendChild(p);
}