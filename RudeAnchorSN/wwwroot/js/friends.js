const hideElement = function (element) {
    element.style.display = 'none';
}

const showElement = function (element) {
    element.style.display = 'flex';
}

function filterUsers(input) {
    let users = document.querySelectorAll(".user");

    for (let i = 0; i < users.length; i++) {
        let name = users[i].getElementsByTagName('a')[0].innerText;

        if (name.toLowerCase().includes(input.value.toLowerCase()))
            showElement(users[i]);
        else
            hideElement(users[i])
    }
}