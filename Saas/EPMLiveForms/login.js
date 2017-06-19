
$(function() {

if ($(".ie8").length == 1) {
   $('input').placeholder();   
}



$('#ctl00_PlaceHolderMain_signInControl_UserName').focus();
$('#ctl00_PlaceHolderMain_signInControl_UserName').css('transition','all 0.4s ease-out 0s');
$('#ctl00_PlaceHolderMain_signInControl_UserName').css('border','1px solid #3498DB');
$('#ctl00_PlaceHolderMain_signInControl_UserName').css('border-left','none');
$('.username-img').css('transition','all 0.4s ease-out 0s');
$('.username-img').css('border','1px solid #3498DB');
$('.username-img').css('border-right','none');
$('.username-img').find('span').css('color','#3498DB');


$('#ctl00_PlaceHolderMain_signInControl_FailureText').addClass('callout left');


if($('#ctl00_PlaceHolderMain_signInControl_FailureText').text())
{
	var unOffset = $('#ctl00_PlaceHolderMain_signInControl_UserName').offset();
	var offsetLeft = unOffset.left - 320;
        var offsetTop = unOffset.top - 18;
        $('#ctl00_PlaceHolderMain_signInControl_FailureText').css('left',offsetLeft);
        $('#ctl00_PlaceHolderMain_signInControl_FailureText').css('top',offsetTop);
	$('#ctl00_PlaceHolderMain_signInControl_FailureText').show();

	$('#ctl00_PlaceHolderMain_signInControl_UserName').keyup(function () { 
		$('#ctl00_PlaceHolderMain_signInControl_FailureText').hide();
	});
		

	$('#ctl00_PlaceHolderMain_signInControl_password').keyup(function () { 
		$('#ctl00_PlaceHolderMain_signInControl_FailureText').hide();
	});
	
}


$('#ctl00_PlaceHolderMain_signInControl_UserName').focus(function() {
    $(this).css('border','1px solid #3498DB');
    $(this).css('border-left','none');
    $('.username-img').css('transition','all 0.4s ease-out 0s');
    $('.username-img').css('border','1px solid #3498DB');
    $('.username-img').css('border-right','none');
    $('.username-img').find('span').css('color','#3498DB');
});


$('input[name="ctl00$PlaceHolderMain$signInControl$password"]').focus(function() {
    $('#ctl00_PlaceHolderMain_signInControl_password').css('border','1px solid #3498DB');
    $('#ctl00_PlaceHolderMain_signInControl_password').css('border-left','none');
    $('.password-img').css('transition','all 0.4s ease-out 0s');
    $('.password-img').css('border','1px solid #3498DB');
    $('.password-img').css('border-right','none');
    $('.password-img').find('span').css('color','#3498DB');
});


$('#ctl00_PlaceHolderMain_signInControl_UserName').blur(function() {
    $(this).css('border','1px solid #DDDDDD');
    $(this).css('border-left','none');
    $('.username-img').css('transition','all 0.4s ease-out 0s');
    $('.username-img').css('border','1px solid #DDDDDD');
    $('.username-img').css('border-right','none');
    $('.username-img').find('span').css('color','#dddddd');
});

$('input[name="ctl00$PlaceHolderMain$signInControl$password"]').blur(function() {
    $('#ctl00_PlaceHolderMain_signInControl_password').css('border','1px solid #DDDDDD');
    $('#ctl00_PlaceHolderMain_signInControl_password').css('border-left','none');
    $('.password-img').css('transition','all 0.4s ease-out 0s');
    $('.password-img').css('border','1px solid #DDDDDD');
    $('.password-img').css('border-right','none');
    $('.password-img').find('span').css('color','#dddddd');
});

$("#ad-text-wrapper").fadeIn(1500);

});