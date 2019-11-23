Dropzone.autoDiscover = false;
$(document).ready(function () {

    $("#zdrop").dropzone({
        url: "/file/post",
        maxFilesize: 20,
        autoQueue: false,
        dictCancelUpload: true,
    });

});