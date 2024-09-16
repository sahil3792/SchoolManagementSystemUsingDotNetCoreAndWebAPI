$(document).ready(function () {
    // Fetch Books
    GetBooks();

    // Fetch Users
    GetUsers();

    // On form submit
    $("#reservationForm").submit(function (e) {
        e.preventDefault();
        ReserveBook();
    });
});

function GetBooks() {
    $.ajax({
        url: '/Librarian/GetBooks',
        type: 'GET',
        success: function (result) {
            var options = '<option value="">Select Book</option>';
            $.each(result, function (index, book) {
                options += '<option value="' + book.id + '">'  + book.title+ '</option>';
            });
            $('#FetchBooks').html(options);
        }
    });
}

function GetUsers() {
    $.ajax({
        url: '/Librarian/GetUsers',
        type: 'GET',
        success: function (result) {
            var options = '<option value="">Select User</option>';
            $.each(result, function (index, user) {
                options += '<option value="' + user.userId + '">' + user.urole + '</option>';
            });
            $('#FetchUser').html(options);
        }
    });
}

function ReserveBook() {
    var bookId = $("#FetchBooks").val();
    var userId = $("#FetchUser").val();

    $.ajax({
        url: '/Librarian/ReserveBook?bookId=' + Id + '&userId=' + userId,
        type: 'POST',
        success: function (response) {
            alert("this is error");
        },
        error: function () {
            alert("Failed to reserve book");
        }
    });
}
