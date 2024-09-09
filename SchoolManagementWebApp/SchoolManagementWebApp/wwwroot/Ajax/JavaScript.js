$(document).ready(function () {
    GetSubjects();
    GetTeachers();
    GetGuardian();
    GetClass();
});

function GetSubjects() {
    $.ajax({
        url: '/Administrator/FetchSubjects', // Call the new action for data
        type: 'GET',
        dataType: 'json',
        success: function (result, status, xhr) {
            var options = '<option value="">Select Subject</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.subjectId + "'>" + item.subjectName + "</option>";
            });
            $("#GetSubjects").html(options); // Populate the dropdown
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }
    });
}

function GetTeachers() {
    $.ajax({
        url: '/Administrator/FetchTeachers',
        type: 'Get',
        dataType: 'json',
        success: function (result, status, xhr) {
            
            var options = '<option value="">Select Teacher</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.teacherUserId + "'>" + item.firstName + " "+item.lastName+ "</option>";
            });
            
            $("#FetchTeacherData").html(options);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }

    });
}

function GetGuardian() {
    $.ajax({
        url: '/Administrator/FetchGuardian',
        type: 'Get',
        dataType: 'json',
        success: function (result, status, xhr) {
            
            var options = '<option value="">Select Guardian</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.guardianId + "'>" + item.firstName + " " + item.lastName + "</option>";
            });

            $("#FetchGuardianData").html(options);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }

    });
}


function GetClass() {
    $.ajax({
        url: '/Administrator/FetchClass',
        type: 'Get',
        dataType: 'json',
        success: function (result, status, xhr) {
            
            var options = '<option value="">Select Guardian</option>';
            $.each(result, function (index, item) {
                options += "<option value='" + item.id + "'>" + item.className+ "</option>";
            });

            $("#FetchAllClasses").html(options);
        },
        error: function (xhr, status, error) {
            console.error("Error fetching data: ", error);
            alert("Failed to load subjects: " + xhr.status + " - " + error);
        }

    });
}