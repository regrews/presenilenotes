// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


$(document).on("click", "#addCategory", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Create Category :',
        showCancelButton: true,
        html:
            '<input id="categoryName" placeholder="Category Name" class="swal2-input">',
        focusConfirm: false,
        preConfirm: () => {
            return [
                document.getElementById('categoryName').value
            ]
        }
    })
    $.ajax({
        url: '../../Home/CreateCategory',
        type: 'POST',
        dataType: 'json',
        data: { categoryName: formValues[0] },
        success: function (data) {
            Swal.fire({
                icon:'success',
                type: 'success',
                title: 'OK',
                text: 'Category has been created.'
            })
            setTimeout(function () {

                window.location.href = data;
            }, 2000);
        }
    });
});
$(document).on("click", "#addNote", function (e) {
    var categoryId = $(e.target).attr('name');
    $.ajax({
        url: '../../Home/CreateNote',
        type: 'GET',
        dataType: 'json',
        data: { id: categoryId },
        success: function (data) {
            if (data != null) {
                Swal.fire({
                    icon: "success",
                    type: 'success',
                    title: 'OK',
                    text: 'Note has been created.'
                })
                setTimeout(function () {

                    window.location.href = data;
                }, 2000);
            }
            else {
                Swal.fire({
                    icon: "warning",
                    type: 'warning',
                    title: 'OK',
                    text: 'Note has been created.'
                })
            }
        }
    });
});
$(document).on("click", "#addWorkspace", async function () {
    const { value: formValues } = await Swal.fire({
        title: 'Create Workspace :',
        showCancelButton: true,
        html:
            '<input id="workspaceName" placeholder="Workspace Name" class="swal2-input">',
        focusConfirm: false,
        preConfirm: () => {
            return [
                document.getElementById('workspaceName').value
            ]
        }
    })
    $.ajax({
        url: '../../Home/CreateWorkspace',
        type: 'POST',
        dataType: 'json',
        data: { workspaceName: formValues[0] },
        success: function (data) {
            Swal.fire({
                icon:'success',
                type: 'success',
                title: 'OK',
                text: 'Category has been created.'
            })
            setTimeout(function () {

                window.location.href = data;
            }, 2000);
        }
    });
});