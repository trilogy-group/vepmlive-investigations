<%@ Control Language="C#" Debug="true" %>
<%@ Register Assembly="System.Web.Extensions, Version=3.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35"
    Namespace="System.Web.UI" TagPrefix="asp" %>
<%@ Assembly Name="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Import Namespace="Microsoft.SharePoint" %>
<%@ Register TagPrefix="SharePoint" Assembly="Microsoft.SharePoint, Version=12.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" Namespace="Microsoft.SharePoint.WebControls" %>

<SharePoint:RenderingTemplate ID="DaysHoursBreakdownFieldControl" runat="server">
    <Template>
        
        <asp:Panel ID="DaysHoursBreakdownGridPanel" runat="server">
            <asp:TextBox ID="DaysHoursBreakdownStartDateTextBox" title="DaysHoursBreakdownStartDate" style="display: none" runat="server" AutoPostBack="True" />
            <asp:TextBox ID="DaysHoursBreakdownFinishDateTextBox" title="DaysHoursBreakdownFinishDate" style="display: none" runat="server" AutoPostBack="True" />
            <asp:TextBox ID="DaysHoursBreakdownPostBackMarkerTextBox" title="DaysHoursBreakdownPostBackMarker" style="display: none" runat="server" Text="false" />
            <asp:TextBox ID="DaysHoursBreakdownFirstLoadTextBox" title="DaysHoursBreakdownFirstLoad" style="display: none" runat="server" />
            <asp:TextBox ID="DaysHoursBreakdownValueTextBox" title="DaysHoursBreakdownValue" style="display: none" runat="server" />
            <asp:TextBox ID="DaysHoursBreakdownInfoTextBox" title="DaysHoursBreakdownInfo" style="display: none" runat="server" />

            <asp:UpdatePanel ID="DaysHoursBreakdownUpdatePanel" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                
                    <asp:Panel ID="DaysHoursBreakdownPanel" title="DaysHoursBreakdownPanel" runat="server" ScrollBars="Auto">
                        <SharePoint:SPGridView ID="DaysHoursBreakdownGridView" runat="server" AutoGenerateColumns="False" RowStyle-HorizontalAlign="Center" 
                            EmptyDataText="Please select a valid Start and Finish date.">
                            <RowStyle HorizontalAlign="Center" />
                        </SharePoint:SPGridView>
                    </asp:Panel>

                    <asp:TextBox ID="DaysHoursBreakdownTotalHoursTextBox" title="DaysHoursBreakdownTotalHours" style="display: none" runat="server" Text="0" />
                    
                    <asp:Panel ID="DHBErrorPanel" title="DHBErrorPanel" runat="server">
                        <asp:Label ID="DHBErrorLabel" runat="server" Font-Size="11px" ForeColor="#CC0000"></asp:Label>
                    </asp:Panel>
                </ContentTemplate> 
                <Triggers>
                    <asp:AsyncPostBackTrigger ControlID="DaysHoursBreakdownStartDateTextBox" EventName="TextChanged" />
                    <asp:AsyncPostBackTrigger ControlID="DaysHoursBreakdownFinishDateTextBox" EventName="TextChanged" />
                </Triggers>      
            </asp:UpdatePanel>

            <script type="text/javascript">
                (function () {

                    function initializeDaysHoursBreakdownField() {
                        $(function () {
                            var infoTextBox = $('input[title=DaysHoursBreakdownInfo]').first();
                            var info = infoTextBox.val().split('|');

                            var startDateTextBox = $('input[title=DaysHoursBreakdownStartDate]').first();
                            var finishDateTextBox = $('input[title=DaysHoursBreakdownFinishDate]').first();

                            var postBackMarkerTextBox = $('input[title=DaysHoursBreakdownPostBackMarker]').first();

                            var startDateField = $('input[id$=DateTimeField_DateTimeFieldDate][title=' + info[0] + ']').first();
                            var finishDateField = $('input[id$=DateTimeField_DateTimeFieldDate][title=' + info[1] + ']').first();

                            $('input[id$=TextField][title=' + info[2] + ']').first().attr('disabled', 'disabled');

                            startDateField.change(function () {
                                startDateTextBox.val($(this).val());
                                postBackMarkerTextBox.val('true');
                                startDateTextBox.change();
                            });

                            finishDateField.change(function () {
                                finishDateTextBox.val($(this).val());
                                postBackMarkerTextBox.val('true');
                                finishDateTextBox.change();
                            });

                            startDateField.get(0).onvaluesetfrompicker = function () {
                                startDateField.change();
                            };

                            finishDateField.get(0).onvaluesetfrompicker = function () {
                                finishDateField.change();
                            };
                        });
                    }

                    window.ExecuteOrDelayUntilScriptLoaded(initializeDaysHoursBreakdownField, 'jquery.min.js');
                })();

//               ---------------
//                SCRIPT IN USE
//               ---------------
//
//                (function () {
//                    $(function () {
//                        var infoTextBox = $('input[title=DaysHoursBreakdownInfo]').first();
//                        var info = infoTextBox.val().split('|');
//
//                        var totalHoursField = $('input[id$=TextField][title=' + info[2] + ']').first();
//                        var gridHourFields = $('input[dhbcontrol=true]');
//
//                        $('input[title=DaysHoursBreakdownPostBackMarker]').first().val('false');
//                        $('input[title=DaysHoursBreakdownFirstLoad]').first().val('false');
//
//                        function calculateTotalHours() {
//                            var hours = [];
//                            var hourDetails = [];
//
//                            gridHourFields.each(function () {
//                                hours.push(parseFloat($(this).val()));
//                                hourDetails.push($(this).attr('dhbdate') + ':' + parseFloat($(this).val()));
//                            });
//
//                            totalHoursField.val(eval(hours.join('+')));
//                            $('input[title=DaysHoursBreakdownValue]').first().val(hourDetails.join(','));
//                        }
//
//                        function setData(key, element) {
//                            $(element).data(key, $(element).val());
//                        }
//
//                        gridHourFields.each(function () {
//                            $(this).change(function () {
//                                var errors = false;
//
//                                var oldVal = $(this).data('oldVal');
//                                var oriVal = $(this).val();
//                                var newVal = parseFloat(oriVal);
//                                var maxVal = parseFloat($(this).attr('dhbmaxhours'));
//                                var day = $(this).attr('title');
//
//                                if (newVal) {
//                                    if (newVal < 0) {
//                                        alert('Hours cannot be less than 0.');
//                                        errors = true;
//                                    } else if (newVal > maxVal) {
//                                        alert('The maximum working hours defined in the Work Hours list for ' + day + ' are: ' + maxVal + '.');
//                                        errors = true;
//                                    }
//                                } else {
//                                    alert(oriVal + ' is not a valid number.');
//                                    errors = true;
//                                }
//
//                                if (!errors) {
//                                    setData('oldVal', this);
//                                    calculateTotalHours();
//                                } else {
//                                    $(this).val(oldVal);
//                                }
//                            }).focus(function () {
//                                setData('oldVal', this);
//                            });
//                        });
//
//                        calculateTotalHours();
//                    });
//                })();

            </script>
        </asp:Panel>
        
        <asp:Panel ID="DaysHoursBreakdownErrorPanel" runat="server">
            <asp:TextBox ID="DaysHoursBreakdownErrorTextBox" title="DaysHoursBreakdownErrorTextBox" style="display: none" runat="server" />
            <asp:Label ID="DaysHoursBreakdownGridErrorLabel" runat="server"></asp:Label>
            
            <script type="text/javascript">
                (function () {
                    function displayDhbError() {
                        $(function () {
                            window.setTimeout(function () {
                                alert($('input[title=DaysHoursBreakdownErrorTextBox]').first().val());
                                SP.SOD.execute('SP.UI.Dialog.js', 'SP.UI.ModalDialog.commonModalDialogClose', window.SP.UI.DialogResult.cancel);
                            }, 500);
                        });
                    }
                    window.ExecuteOrDelayUntilScriptLoaded(displayDhbError, 'jquery.min.js');
                })();
            </script>

        </asp:Panel>

    </Template>
</SharePoint:RenderingTemplate>
