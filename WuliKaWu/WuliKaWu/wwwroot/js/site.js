// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

// 顯示 SweetAlert 2 訊息
function showEorror(msg) {
    Swal.fire({
        icon: 'success',
        title: '成功',
        text: msg,
        timer: 2000
    })
}

function tgm103ShowSuccess(msg) {
    Swal.fire({
        icon: 'success',
        title: '成功',
        text: msg,
        timer: 3000,
        timerProgressBar: true,
        showConfirmButton: false
    })
}

function tgm103ShowError(msg) {
    Swal.fire({
        icon: 'error',
        title: '失敗',
        text: msg,
        timer: 5000,
    })
}

function jumpOkTo(msg, page) {
    Swal.fire({
        icon: "success",
        title: "恭喜您",
        text: msg,
    }).then((result) => {
        if (result.value) {
            window.location = page
        }
    });
}

function jumpErrTo(msg, page) {
    Swal.fire({
        icon: "error",
        title: "Ohoo",
        text: msg,
    }).then((result) => {
        if (result.value) {
            window.location = page
        }
    });
}

function jumpTo(status, msg, page) {
    Swal.fire({
        icon: status ? "success" : "error",
        title: status ? "恭喜您" : "Oops...",
        text: msg,
    }).then((result) => {
        if (result.value) {
            window.location = page
        }
    });
}