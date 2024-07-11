const input = document.getElementById("profile-pic-input");

input.addEventListener("change", UploadFile, false);

function UploadFile()
{
    const form = document.createElement("form");

    form.appendChild(input);

    let xhr = new XMLHttpRequest();

    xhr.onload = function (e) {
        document.getElementById("profile-pic-hidden").value = xhr.responseText;
        document.getElementById("profile-picture-placeholder").style.backgroundImage = `url(${xhr.responseText})`;
        document.getElementsByClassName("profile-pic-fallback")[0].remove();
    }
    xhr.open("POST", "/File/Upload");
    xhr.send(new FormData(form));
}