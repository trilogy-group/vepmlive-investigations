
// Remove the ugly blue box when mouseover of toolbar buttons
$( "td.izenda-toolbar" ).mouseover(function() {
  $(this).css("border","none");
    $(this).css("padding","1px");
});


$(".ReportTable tr td").each(function() {
if ($(this).text().indexOf(".GIF") >= 0) {
var img = $(this).text();
$(this).html("<img src='../images/" + img + "' />");
}    

});












