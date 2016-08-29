function Filter(Obj,ind) {
    var searchString = Obj.value.toUpperCase();
    $("#gridMyFragments tr:has(td)").each(function () {
        var gridRowVal = $(this).find("td:eq("+ind+")").text().toUpperCase();
        if (gridRowVal.indexOf(searchString) != -1) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    });

    $("#gridPublicFragments tr:has(td)").each(function () {
        var gridRowVal = $(this).find("td:eq("+ind+")").text().toUpperCase();
        if (gridRowVal.indexOf(searchString) != -1) {
            $(this).show();
        }
        else {
            $(this).hide();
        }
    });
}

$(document).ready(function () {
    $('.myfragments tr').hover(function () {
        $(this).find(".icon-wrapper").css("visibility", "visible");
    }, function () {
        $(this).find(".icon-wrapper").css("visibility", "hidden");
    });

    $('.myfragments .modal-icon').hover(function () {
        $(this).css("color", "#777777");
    }, function () {
        $(this).css("color", "#cccccc");
    });


    $(".row-select tr").hover(
      function () {
          if (!$(this).hasClass("highlight")) {
              $(this).css("background-color", "#f5f5f5");
          }
      },
      function () {
          $(this).css("background-color", "transparent");
      }
    );
});

