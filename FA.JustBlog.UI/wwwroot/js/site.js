$(document).ready(function () {
    var itemsPerPage = 3;
    var currentPage = 1;
    var totalPages = Math.ceil($('#imageGallery .col-md-4').length / itemsPerPage);

    displayPage(currentPage);

    // Tạo phân trang
    for (var i = 1; i <= totalPages; i++) {
        $('#pagination').append('<button class="btn btn-link page-link" data-page="' + i + '">' + i + '</button>');
    }

    // Xử lý sự kiện click trang
    $('.page-link').on('click', function () {
        var page = $(this).data('page');
        currentPage = page;
        displayPage(currentPage);
    });

    // Xử lý sự kiện click "Page Images"
    $('#pageImagesLink').on('click', function (e) {
        e.preventDefault();
        currentPage++;
        if (currentPage > totalPages) {
            currentPage = 1;
        }
        displayPage(currentPage);
    });

    // Xử lý sự kiện click vào ảnh
    $('#imageGallery').on('click', '.col-md-4 img', function () {
        $(this).toggleClass('active');
    });

    function displayPage(page) {
        var startIndex = (page - 1) * itemsPerPage;
        var endIndex = startIndex + itemsPerPage - 1;

        $('#imageGallery .col-md-4').hide();
        $('#imageGallery .col-md-4').slice(startIndex, endIndex + 1).show();

        $('.page-link').removeClass('active');
        $('.page-link[data-page="' + page + '"]').addClass('active');
    }
});