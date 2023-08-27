$(document).ready(function () {
    var table = $("#example1").DataTable({
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    });

    var tableRows = table.rows({ search: "applied" }).nodes();
    var tableLength = tableRows.length;
    var pageSize = 5;
    var totalPages = Math.ceil(tableLength / pageSize);

    if (totalPages > 1) {
        var pagination = $("#pagination");
        var prevButton = $("<button>").addClass("btn btn-primary").text("Previous");
        var nextButton = $("<button>").addClass("btn btn-primary").text("Next");
        var currentPage = 1;

        pagination.append(prevButton);

        for (var i = 1; i <= totalPages; i++) {
            var pageButton = $("<button>").addClass("btn btn-primary").text(i);
            pagination.append(pageButton);
        }

        pagination.append(nextButton);

        function showPage(page) {
            var startIndex = (page - 1) * pageSize;
            var endIndex = startIndex + pageSize;

            tableRows.each(function (index) {
                var row = $(this);
                if (index >= startIndex && index < endIndex) {
                    row.show();
                } else {
                    row.hide();
                }
            });
        }

        function updateButtons() {
            prevButton.prop("disabled", currentPage === 1);
            nextButton.prop("disabled", currentPage === totalPages);

            pagination.find("button").removeClass("active");
            pagination.find("button").eq(currentPage).addClass("active");
        }

        showPage(currentPage);
        updateButtons();

        pagination.on("click", "button", function () {
            var buttonText = $(this).text();

            if (buttonText === "Previous" && currentPage > 1) {
                currentPage--;
            } else if (buttonText === "Next" && currentPage < totalPages) {
                currentPage++;
            } else {
                var pageNumber = parseInt(buttonText);
                if (!isNaN(pageNumber)) {
                    currentPage = pageNumber;
                }
            }

            showPage(currentPage);
            updateButtons();
        });
    }
});