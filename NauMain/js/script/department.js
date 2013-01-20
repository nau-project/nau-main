var baseUrl = window.location.origin;
var teacherId;
$(function () {
    teacherId = teacherId == undefined ? $('.id').attr('id') : teacherId;
    $("#slide_1").live('click', function () {
        if (!$(this).hasClass('active')) {
            window.open(baseUrl + '/DepartmentAdmin/Schedule/' + teacherId, '_self', null, false);
        }
    });

    $("#slide_0").live('click', function () {
        if (!$("this").hasClass('active')) {
            window.open(baseUrl + '/DepartmentManager/Index/' + teacherId, '_self', null, false);
        }
    });
    
    $('.line-field.schedule').live('click', function () {
        window.open(baseUrl + '/DepartmentAdmin/EditItem/' + $(this).attr('id') + '&teacherId=' + teacherId, '_self', null, false);
    });

    $('.groop .button').live('click', function () {
        window.open(baseUrl + '/DepartmentAdmin/AddItem/' + $(this).attr('id') + '&teacherId=' + teacherId, '_self', null, false);
    });

    $('#add_teacher').live('click', function () {
        window.open(baseUrl + '/departmentadmin/AddTeacher', '_self', null, false);
    });
    
    $('.teacher').live('click', function () {
        $('#edit_teacher').show();
        teacherId = $(this).attr('id');
    });
    $('#edit_teacher').live('click', function () {
        window.open(baseUrl + '/departmentadmin/EditTeacher/' + teacherId, '_self', null, false);
    });
    $('.department #slide_1').live('click', function () {
        window.open(baseUrl + '/departmentadmin/Schedule/' + teacherId, '_self', null, false);
    });
});