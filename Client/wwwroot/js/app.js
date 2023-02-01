
//
/********************* Page Load js ************************/
function loader() {
    setTimeout(() => {
    }, 350);
};
function getLocation() {
    return new Promise((resolve, reject) => {
        navigator.geolocation.getCurrentPosition((position) => {
            resolve(position.coords.latitude + ', ' + position.coords.longitude);
        }, () => {
            reject('Unable to retrieve location');
        });
    });
}




    function BlazorScrollToId(id) {
        const element = document.getElementById(id);
    if (element instanceof HTMLElement) {
        element.scrollIntoView({
            behavior: "smooth",
            block: "start",
            inline: "nearest"
        });
        }
}

function showError(title,msg,button) {
    swal({
        title: title,
        text: msg,
        icon: "error",
        button: button
    });
}

function showSuccess(title,msg,button) {
    swal({
        title: title,
        text: msg,
        icon: "success",
        button: button
    });
}
