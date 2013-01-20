var groupId;

var baseUrl = window.location.origin;

$(function () {

    groupId = groupId == undefined ? $('.id').attr('id') : groupId;

    $("#Id").hide();
    $("label[for='Id']").hide();

    $("#GroupId").hide();
    $("label[for='GroupId']").hide();

    $('.block-list-grup span div').live('click', function () {
        window.grup = $(this).parent('span').text();
        window.a = confirm("Точно удалить группу: " + grup);

        if (a == true) {
            alert("Группа '" + grup + "' была удалена");
            window.open(baseUrl + '/Groups/Delete/' + $(this).parent('span').attr('id'), '_self', null, false);
        }
    });
    
    $('.add-grup-block span').live('click', function () {
        $('#add_gr').trigger('click');
    });

    $('.line-field.schedule').live('click', function () {
        window.open(baseUrl + '/Groups/EditItem/' + $(this).attr('id') + '&groupId=' + groupId, '_self', null, false);
    });
    
    $('.groop .button').live('click', function () {
        window.open(baseUrl + '/Groups/AddItem/' + $(this).attr('id') + '&groupId=' + groupId, '_self', null, false);
    });

    $('#add_student').live('click', function () {
        window.open(baseUrl + '/Groups/AddStudent/' + groupId, '_self', null, false);
    });

    $('.control-students .line-field').live('click', function () {
        window.open(baseUrl + '/Groups/EditStudent/' + $(this).attr('id'), '_self', null, false);
    });

    $('.block-list-grup span').live('click', function () {
        $('.block-list-grup div').removeClass('selected');
        $(this).addClass('selected');
        groupId = $(this).attr('id');
    });

    $("#slide_1").live('click', function () {
        if (!$("#slide_1").hasClass('active')) {
            window.open(baseUrl + '/Groups/Schedule/' + groupId, '_self', null, false);
        }
    });

    $("#slide_0").live('click', function () {
        if (!$("#slide_0").hasClass('active')) {
            window.open(baseUrl + '/Groups/Index/' + groupId, '_self', null, false);
        }
    });

    $("#slide_2").live('click', function () {
        if (!$("#slide_2").hasClass('active')) {
            window.open(baseUrl + '/Groups/Students/' + groupId, '_self', null, false);
        }
    });
});
