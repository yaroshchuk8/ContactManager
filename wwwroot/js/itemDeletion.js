function Delete(id) {
    Swal.fire({
        title: "Are you sure?",
        text: "You won't be able to revert this!",
        icon: "warning",
        showCancelButton: true,
        confirmButtonColor: "#3085d6",
        cancelButtonColor: "#d33",
        confirmButtonText: "Yes, delete it!"
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: '/Home/Delete?id=' + id,
                type: 'DELETE',
                success: function (data) {
                    if (data.success) {
                        // Successfully deleted, now remove the row from the table
                        var row = $('tr[id="row-' + id + '"]');
                        row.fadeOut(500, function () { // Smooth fade out animation
                            $(this).remove(); // Completely remove the row after the animation
                        });
                        Swal.fire("Deleted!", data.message, "success");
                    } else {
                        Swal.fire("Error!", data.message, "error");
                    }
                },
                error: function () {
                    Swal.fire("Error!", "An error occurred while trying to delete the contact.", "error");
                }
            });
        }
    });
}