
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


htmlChartColors = ['#2ecc71','#0090CA','#e74c3c','#C06FE2','#FFC000','#7c7c7c','#27ae60','#00668E','#9E480E','#5E0089','#d35400','#555555','#1abc9c','#26C6F4','#c0392b','#8e44ad','#e67e22','#A5A5A5','#73E2CA','#82E3FF','#E57A70','#CC9FE0','#FFE18E','#e2e2e2'];













