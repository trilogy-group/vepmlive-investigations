<%@ Page Title="Select data sources" Language="C#" MasterPageFile="~/Default.master" AutoEventWireup="true" CodeFile="DataSources.aspx.cs" Inherits="DataSources" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadPlaceHolder" Runat="Server">
	<link rel="stylesheet" href="./rs.aspx?css=ModernStyles.data-sources" type="text/css" />
	<link rel="stylesheet" href="./rs.aspx?css=ModernStyles.jquery.dataTables" type="text/css" />
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.json2"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.data-sources"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.data-sources-preview"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.jquery-ui-1.9.2.animations.min"></script>
	<link rel="stylesheet" type="text/css" href="./rs.aspx?css=ModernStyles.charts" />
	<link rel="stylesheet" type="text/css" href="./rs.aspx?css=ModernStyles.jquery-ui" />
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.jquery-ui-1.8.21.custom.min"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.jquery.scrollTo.min"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.jquery.dataTables.min"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.jquery.dataTables.colReorder"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.colResizable-1.3.source"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.charts"></script>
	<script type="text/javascript" src="./rs.aspx?js=ModernScripts.datasources-search"></script>
	<script type="text/javascript" src="./rs.aspx?js=jQuery.jq"></script>	
	<script type="text/javascript" src="./rs.aspx?js=Utility"></script>
	<script type="text/javascript" src="./rs.aspx?js=AdHocServer"></script>
	<script type="text/javascript" src="./rs.aspx?js=EditorBaseControl"></script>

	<script type="text/javascript">
		var previewWasVisible = false;

		function hideAllPreview() {
			previewWasVisible = false;
			var previews = $(".show-preview");
			if (previews.length > 0) {
				previewWasVisible = true;
				hideFieldsPreview();
			}
		}
	</script>
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="PlaceHolder" Runat="Server">
<div class="page" onclick="hideAllPreview();">
    <div class="row-fluid">

        <div class="span7" id="leftDiv">
            <div class="data-sources">
                <div class="data-sources-header css-only-clearfix">
	                <h6>Create a new report</h6>
	                <h1 style="float: left;">Select Data Sources</h1>
	                <div class="search-container">
		                <input type="text" class="" id="fieldSearch" title="Search" accesskey="f" value="">
		                <span id="fieldSearchMessage" class="search-wait hidden">Searching...</span>
		                <a id="fieldSearchClearBtn" class="clear" href="#clear"></a>
		                <a id="fieldSearchBtn" class="find" href="#find"></a>
		                <div id="fieldSearchAutoComplete" class="searchAutoComplete hidden"></div>
	                </div>
                </div>
	
                <div class="controls">
	                <a class="collapse" href="#collapseall"><img src="rs.aspx?image=ModernImages.collapse.png" alt="collapse" style="" />Collapse all</a> 
	                <a class="uncheck" href="#all"><img src="rs.aspx?image=ModernImages.remove-icon.png" alt="remove" style="" />Uncheck all</a>
                </div>

                <div class="database-description css-only-clearfix">
	                <div class="">Database</div>
	                <div class="">Table</div>
	                <div class="">Fields</div>
                </div>

                <div class="databases" id="databases"></div>
	            <div class="buttons">
		            <a class="button" href="#back">Back</a>
		            <a class="button" href="#design_report" onclick="DesignReportRequest(CollectReportData());">Design report</a> 
		            <a class="button default" href="#view_report" onclick="ViewReportRequest(CollectReportData());">View report</a> 
	            </div>
	            <div id="dottedSeparatorDiv" class="separator" style="position: absolute; width: 0; height: 100%; right: -28px; top: 0;"></div>
            </div>
        </div>

        <div class="span5" id="rootRightDiv" style="height:0px;">
            <div class="right-help" id="rightHelpDiv" style="margin-left: 0px; padding-top: 10px; padding-left: 10px; padding-right: 10px; padding-bottom: 10px;">
	            <!--
	            <h2>Help</h2>
	            <p>This help moves down on phones and other narrow screens.</p>
	            <a href="#" id="help_trigger">Open modal help</a>
	            <div id="help" title="Modal help">
		            <p>
			            Some help information goes here.
		            </p>
	            </div>
	            -->
            </div>

              <div id="data-source-field" title="Field name">
                    <div id="propertiesDiv" style="height: 340px;">
                        <table style="width:100%;">
                            <tr>
                                <td>
                                    <div id="titleDiv" style="width:392px; text-align:left;text-transform:capitalize;color:#000000;background-color:#CCEEFF;padding:6px;"></div>
                                    <table cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td style="vertical-align:top">
                                                <table cellpadding="0" cellspacing="0">
                                                    <tr><td style="padding-top:10px;">Description</td></tr>
                                                    <tr><td><input id="propDescription" onkeyup="PreviewFieldDelayed(1000);" type="text" value="" style="width:400px;margin:0px;" /></td></tr>
                                                    <tr><td style="padding-top:10px;">Format</td></tr>
                                                    <tr><td><select id="propFormats" onchange="PreviewFieldDelayed(1000);" style="margin:0px;width:406px;" ></select></td></tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align:top; padding:20px;">
                                                <table>
                                                    <tr><td><input id="propTotal" type="checkbox" onkeyup="PreviewFieldDelayed(1000);" onmouseup="PreviewFieldDelayed(1000);" /><label style="cursor:pointer;" for="propTotal">Total</label></td></tr>
                                                    <tr><td><input id="propVG" type="checkbox" onkeyup="PreviewFieldDelayed(1000);" onmouseup="PreviewFieldDelayed(1000);" /><label style="cursor:pointer;" for="propVG">Visually Group</label></td></tr>
                                                    <tr><td><input type="checkbox" onchange="javascript:this.checked = false;UpdateMSV('labelJ');" /><label msv="L" msvs="L,M,R" id="labelJ" onclick="javascript:UpdateMSV('labelJ');" style="font-family:Courier New, monospace;font-size:11px;cursor:pointer;position:relative;left:-14px;top:-3px;" for="labelJ">L</label><label onclick="javscript:UpdateMSV('labelJ');" style="cursor:pointer;position:relative;left:-6px;" for="labelJ">Label Justification</label></td></tr>
                                                    <tr><td><input type="checkbox" onchange="javascript:this.checked = false;UpdateMSV('valueJ');" /><label msv="&nbsp;" msvs="&nbsp;,L,M,R" id="valueJ" onclick="javascript:UpdateMSV('valueJ');" style="font-family:Courier New, monospace;font-size:11px;cursor:pointer;position:relative;left:-14px;top:-3px;" for="labelV">&nbsp;</label><label onclick="javascript:UpdateMSV('valueJ');" style="cursor:pointer;position:relative;left:-6px;" for="valueJ">Value Justification</label></td></tr>
                                                </table>
                                            </td>
                                            <td style="vertical-align:top">
                                                <div id="fieldSamplePreview" style="width:200px;"></div>
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </div>	
                </div>

	        </div>
    </div>
</div>

<script type="text/javascript">
	var oldLeftHeight = 0;
	var leftDiv;
	var pdiv;
	var whiteHeader;
	var blueHeader;
	var fieldPopup;

	function checkLeftHeight() {
		var newLeftHeight = leftDiv.clientHeight;
		if (newLeftHeight != oldLeftHeight) {
			oldLeftHeight = newLeftHeight;
		}
	}


	function updatePreviewPosition(event) {
		if (whiteHeader == null || blueHeader == null)
		  return;
		var y = $(this).scrollTop();
		var rhdLeft = pdiv.offsetLeft;
		var pdtop = whiteHeader.clientHeight + blueHeader.clientHeight;
		if (rhdLeft > 100) {
		  document.getElementById('dottedSeparatorDiv').style.display = '';
		  pdiv.style.borderTop = '';
			pdiv.style.width = 'auto';
			if (y >= pdtop) {
				var newPos = y - pdtop;
				if (newPos < 0)
					newPos = 0;
				if (newPos > oldLeftHeight - 400)
					newPos = oldLeftHeight - 400;
				pdiv.style.top = newPos + "px";
			} else {
				pdiv.style.top = "0px";
			}
		}
		else {
		  document.getElementById('dottedSeparatorDiv').style.display = 'none';
		  pdiv.style.borderTop = '3px dotted #CCCCCC';
			pdiv.style.width = '100%';
			var newPosB = window.innerHeight + y - (212 + pdtop);
			if (newPosB > oldLeftHeight)
				newPosB = oldLeftHeight;
			pdiv.style.top = newPosB + "px";
		}
	}
	
	function initializeTables(database$) {
		if (database$.length > 0) {
			var hId = database$[0].id;
			hId = hId.substr(4);
			var contentDiv = document.getElementById('rdb' + hId);
			var currHtml = contentDiv.innerHTML;
			if (currHtml != 'Loading...')
			  return;
			var html = renderTables(databaseSchema[hId].tables, hId);
			contentDiv.innerHTML = html;

			//begin some app
			initDraggable();
			$(".database-header a, .table-header a, a.field, .table-header a .checkbox-container, a.uncheck, a.collapse").click(function (event) {
				event.preventDefault();
			});
			var triggersHtml = "<span class='f-trigger' data-view='fields-view'> \
							<img src='rs.aspx?image=ModernImages.fields-icon.png' alt='' /> <span class='text'>Fields</span> \
						</span> \
						<span class='p-trigger' data-view='preview-view'>Preview</span> \
						<span class='v-trigger' data-view='visuals-view'>Visuals</span> \
						<span class='b-trigger' data-view='relationships-view'>Relationships</span> \ ";
			$(".table-view-triggers").filter(function (index) {
				var shouldBeReturned = false;
				var npAttr;
				try {
					npAttr = this.getAttribute('notProcessed1');
				}
				catch (e) {
					npAttr = '0';
				}
				if (npAttr == '1') {
					shouldBeReturned = true;
					this.setAttribute('notProcessed1', '0');
				}
				return shouldBeReturned;
			}).append(triggersHtml);

			$(".table").each(function () {
				setView($(this), "fields-view");
			});

			$(".field-popup-trigger").mouseup(function (event) {
				event.stopPropagation();
				var parent = this.parentElement;
				var fieldSqlName = parent.getAttribute('fieldid');
				if (fieldSqlName != null && fieldSqlName != '') {
					ShowFieldProperties(fieldSqlName, parent.children[2].innerHTML, parent.getAttribute('id'));
				}
				var fieldName = $(this).parent().find(".field-name").text();

				fieldPopup.dialog("option", "title", fieldName);
				fieldPopup.dialog("open");
				return false;
			});
		}
	}

	$(document).ready(function() {
	  $(".database-header a, .table-header a, a.field, .table-header a .checkbox-container, a.uncheck, a.collapse").click(function(event) {
	    event.preventDefault();
	  });

	  var triggersHTML = "<span class='f-trigger' data-view='fields-view'> \
							<img src='rs.aspx?image=ModernImages.fields-icon.png' alt='' /> <span class='text'>Fields</span> \
						</span> \
						<span class='p-trigger' data-view='preview-view'>Preview</span> \
						<span class='v-trigger' data-view='visuals-view'>Visuals</span> \
						<span class='b-trigger' data-view='relationships-view'>Relationships</span> \ ";
	  $(triggersHTML).appendTo(".table-view-triggers");

	  $(".table-header a .table-view-triggers span").live("click", function(event) {
	    event.preventDefault();
	    event.stopPropagation();

	    var trigger = $(this);
	    var table = $(this).closest(".table");
	    var view = trigger.attr("data-view");
	    setView(table, view);
	    if (!table.hasClass('opened')) {
	      collapseTables();
	      table.addClass("opened", animationTime);
	    }
	  });

	  $(".table").each(function() {
	    setView($(this), "fields-view");
	  });

	  leftDiv = document.getElementById('leftDiv');
	  pdiv = document.getElementById('rightHelpDiv');
	  whiteHeader = document.getElementById('whiteHeader');
	  blueHeader = document.getElementById('blueHeader');
	  setInterval(checkLeftHeight, 100);

	  $(window).resize(function(event) {
	    checkLeftHeight();
	    updatePreviewPosition(event);
	  });
	  $(window).scroll(function(event) {
	    updatePreviewPosition(event);
	  });
	  checkLeftHeight();
	  updatePreviewPosition(null);
	});
	
	$(".database-header a").live("click", function () {
		var dbh = $(this).parent().parent();
		initializeTables(dbh);
		dbh.toggleClass("opened", animationTime);
		setTimeout(DsDomChanged, animationTime + 100);
	});

	$(".table-header a").live("click", function() {
	  initFieldsDsp(this);
		var dsh = $(this).parent().parent();
		dsh.toggleClass("opened", animationTime);
		setTimeout(DsDomChanged, animationTime + 100);
	});

	$("a.field .preview").live("click", function (event) {
		event.stopPropagation();
		if (previewWasVisible)
			return;
		var field = $(this).closest(".field");
		var isShown = field.hasClass("show-preview");
		hideFieldsPreview();
		if (!field.find('.preview-image').html())
			PreviewField($(this).attr("fieldId"), field.find('.preview-image'));
		if (!isShown)
			field.addClass("show-preview");
		//	if (!isShown) field.addClass("show-preview", animationTime/2);
	});

	$(".table-header a .checkbox-container").live("click", function (event) {
		event.stopPropagation();
	});

	$("a.field").live("click", function () {
		hideFieldsPreview();
	});

	$("a.uncheck").live("click", function () {
		NDS_UnckeckAllDs();
	});

	$("a.collapse").live("click", function () {
		collapseAll();
	});

	function collapseAll() {
		$(".database-header a, .table-header a").parent().parent().removeClass("opened", animationTime);
	}

	function collapseTables() {
		var tables = $(".table-header a");
		for (var tCnt = 0; tCnt < tables.length; tCnt++)
			if (tables[tCnt].children[0].getAttribute('sorder') == '-1')
				$(tables[tCnt]).closest(".table").removeClass("opened", animationTime);
	}

	function checkUsedTables() {
		$(".table").each(function (i, el) {
			el = $(el);
			if (el.find(".field.checked").length) {
				el.addClass("checked");
			} else {
				el.removeClass("checked");
			};
		});
	}

	function clearView(table) {
		table.each(function () {
			var arrayClasses = $(this).attr("class").split(" ");
			for (var i = 0; i < arrayClasses.length; i++) {
				if (arrayClasses[i].indexOf('-view') != -1) $(this).removeClass(arrayClasses[i]);
			}
		});
	}

	function setView(table, view) {
		clearView(table);
		table.addClass(view);
		table.attr('data-view', view);
		var trigger = table.find("span[data-view=" + view + "]");
		selectTrigger(trigger);
	}

	function selectTrigger(trigger) {
		trigger.parent().children().removeClass("selected");
		trigger.addClass("selected");
	}

	function restoreViews() {
		$(".table.fields-view .table-view-triggers span[data-view='fields-view']").addClass("selected");
	}

	function hideFieldsPreview() {
		var fields = $(".field");
		fields.removeClass("show-preview");
	}

	checkUsedTables();
	InitEmptyPreviewArea('#rightHelpDiv');
	var animationTime = 200; // Animation animationTime

</script>


<script type="text/javascript">
	$(function () {
		$("#help").dialog({
			autoOpen: false,
			width: 960,
			height: "auto", height: 640,
			modal: true,
			buttons: {
				"Continue": function () {
					$(this).dialog("close");
				}
			},
			show: { effect: "fade", duration: 200, },
			hide: { effect: "fade", duration: 200, }
		});
		$("#help_trigger").click(function () {
			$("#help").dialog("open");
			return false;
		});

		fieldPopup = $("#data-source-field").dialog({
			autoOpen: false,
			width: 860,
			height: "auto",
			modal: true,
			buttons: {
				"OK": function () {
					StoreFieldProps();
					$(this).dialog("close");
					PreviewReportDelayed(2000);
				},
				"Cancel": function () {
					$(this).dialog("close");
				}
			},
			open: function () {
				$(this).parents(".ui-dialog-buttonpane button:eq(0)").focus();
			},
			show: { effect: "fade", duration: 200, },
			hide: { effect: "fade", duration: 200, }
		});

		$(".field-popup-trigger").mouseup(function (event) {
			event.stopPropagation();
			var parent = this.parentElement;
			var fieldSqlName = parent.getAttribute('fieldid');
			if (fieldSqlName != null && fieldSqlName != '') {
				ShowFieldProperties(fieldSqlName, parent.children[2].innerHTML, parent.getAttribute('id'));
			}
			var fieldName = $(this).parent().find(".field-name").text();

			fieldPopup.dialog("option", "title", fieldName);
			fieldPopup.dialog("open");
			return false;
		});

		$(".ui-widget-overlay").live("click", function () {
			$("#help").dialog("close");
			$("#data-source-field").dialog("close");
		});

	});
</script>


<script type="text/javascript">
	initDataSources("rs.aspx?wscmd=getjsonschema");
</script>
</asp:Content>

<asp:Content ID="Content3" ContentPlaceHolderID="TrackerPlaceHolder" Runat="Server">
</asp:Content>

