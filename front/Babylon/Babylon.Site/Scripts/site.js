/// <reference path="jquery-1.5.1-vsdoc.js" />

$(document).ready(function () {

    $('#profile-photo').hover(
        function (e) {
            var photolink = $(this).attr('src');
            $('#preview').append('<img src="' + photolink + '" alt="Photo Preview" />');

            $('#preview')
                .css('top', e.pageY + 10)
                .css('left', e.pageX + 20);
        },
        function () {
            $('#preview').children().remove();
        }
    );
});
