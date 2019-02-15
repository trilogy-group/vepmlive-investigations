namespace EPMLiveCore
{
    public partial class ListDisplayPage
    {
        private const string OptionChangeScript = @"function OptionChange(senderPartialId) 
                                        {
                                            var control = document.getElementById('Option' + senderPartialId);
                                            var selectedValue = control.options[control.selectedIndex].value;
                                            var controlToChange = document.getElementById('RowOptionPanel' + senderPartialId);

                                            var controlToChange2 = document.getElementById('Editable' + senderPartialId);
                                            if(controlToChange2 != null)
                                            {
                                                if(selectedValue == 'never')
                                                {
                                                    controlToChange2.style.display = 'none';
                                                }
                                                else
                                                {
                                                    controlToChange2.style.display = '';
                                                }
                                            }

                                            if(selectedValue == 'where')
                                            {
                                                controlToChange.style.display = 'inline';
                                            }
                                            else
                                            {
                                                controlToChange.style.display = 'none';
                                            }
                                        }";
        private const string OptionFieldWhereChangeScript = @"function OptionFieldWhereChange(senderPartialId)
                                                    {
                                                        var fieldControl = document.getElementById('OptionFieldWhere' + senderPartialId);
                                                        var conditionControl = document.getElementById('OptionConditionWhere' + senderPartialId);
                                                        var selectedValue =  fieldControl.options[fieldControl.selectedIndex].value;
                                                        
                                                        if(selectedValue == '[Me]') {
                                                            FillConditionForUser(conditionControl);
                                                            document.getElementById('OptionValueFieldWhere' + senderPartialId).style.display = 'none';
                                                            document.getElementById('OptionFieldNameWhere' + senderPartialId).style.display = 'none';
                                                            document.getElementById('OptionValueUserWhere' + senderPartialId).style.display = 'inline';
                                                        }
                                                        else {
                                                            FillConditionForField(conditionControl);
                                                            document.getElementById('OptionFieldNameWhere' + senderPartialId).style.display = 'inline';
                                                            document.getElementById('OptionValueUserWhere' + senderPartialId).style.display = 'none';
                                                            document.getElementById('OptionValueFieldWhere' + senderPartialId).style.display = 'inline';
                                                        }
                                                    }";
        private const string FillConditionForFieldScript = @"function FillConditionForField(conditionControl) 
                                                {
                                                    conditionControl.options.length = 9                
                                                    conditionControl.options[0].value = 'IsEqualTo';
                                                    conditionControl.options[0].text = 'Is equal to';
                                                    conditionControl.options[1].value = 'IsNotEqualTo';
                                                    conditionControl.options[1].text = 'Is not equal to';
                                                    conditionControl.options[2].value = 'IsGreaterThan';
                                                    conditionControl.options[2].text = 'Is greater than';
                                                    conditionControl.options[3].value = 'IsLessThan';
                                                    conditionControl.options[3].text = 'Is less than';
                                                    conditionControl.options[4].value = 'IsGreaterThanOrEqual';
                                                    conditionControl.options[4].text = 'Is greater than or equal to';
                                                    conditionControl.options[5].value = 'IsLessThanOrEqual';
                                                    conditionControl.options[5].text = 'Is less than or equal to';
                                                    conditionControl.options[6].value = 'BeginWith';
                                                    conditionControl.options[6].text = 'Begins with';
                                                    conditionControl.options[7].value = 'EndWith';
                                                    conditionControl.options[7].text = 'Ends with';
                                                    conditionControl.options[8].value = 'Contains';
                                                    conditionControl.options[8].text = 'Contains';
                                                    conditionControl.selectedIndex = 0;        
                                                }";
        private const string ComputeFieldScript = @"function ComputeField(senderPartialId) 
                                        {
                                            var hiddenField = document.getElementById('Hidden' + senderPartialId);
                                            var option = document.getElementById('Option' + senderPartialId);
                                            var optionFieldWhere = document.getElementById('OptionFieldWhere' + senderPartialId);
                                            var optionFieldNameWhere = document.getElementById('OptionFieldNameWhere' + senderPartialId);
                                            var optionConditionWhere = document.getElementById('OptionConditionWhere' + senderPartialId);
                                            var optionValueUserWhere = document.getElementById('OptionValueUserWhere' + senderPartialId);
                                            var optionValueFieldWhere = document.getElementById('OptionValueFieldWhere' + senderPartialId);
                                            
                                            var optionValue = '';
                                            if(option.type != 'checkbox')
                                            {
                                                if (option != null) optionValue = option.options[option.selectedIndex].value;
                                                var optionFieldWhereValue = '';
                                                if (optionValue == 'where') if (optionFieldWhere != null) optionFieldWhereValue = optionFieldWhere.options[optionFieldWhere.selectedIndex].value;
                                                var optionFieldNameWhereValue = '';
                                                if (optionValue == 'where') if (optionFieldNameWhere != null) optionFieldNameWhereValue = optionFieldNameWhere.options[optionFieldNameWhere.selectedIndex].value;
                                                var optionConditionWhereValue = '';
                                                if (optionValue == 'where') if (optionConditionWhere != null) optionConditionWhereValue = optionConditionWhere.options[optionConditionWhere.selectedIndex].value;
                                                var optionValueUserWhereValue = '';
                                                if (optionValue == 'where') if (optionValueUserWhere != null) optionValueUserWhereValue = optionValueUserWhere.options[optionValueUserWhere.selectedIndex].value;
                                                var optionValueFieldWhereValue = '';
                                                if (optionValue == 'where') if (optionValueFieldWhere != null) optionValueFieldWhereValue = optionValueFieldWhere.value;
                                                
                                                if (optionFieldWhereValue == '[Me]')
                                                {
                                                    hiddenField.value = optionValue + ';' + optionFieldWhereValue + ';' + optionConditionWhereValue + ';' + optionValueUserWhereValue;
                                                }
                                                else
                                                {
                                                    hiddenField.value = optionValue + ';' + optionFieldWhereValue + ';' + optionFieldNameWhereValue + ';' + optionConditionWhereValue + ';' + optionValueFieldWhereValue;
                                                }
                                            }
                                            else
                                            {
                                                hiddenField.value = option.checked;
                                            }
                                            
                                          
                                         }";
        private const string FillConditionForUserScript = @"function FillConditionForUser(conditionControl) 
                                                {
                                                    conditionControl.options.length = 2                
                                                    conditionControl.options[0].value = 'InGroup';
                                                    conditionControl.options[0].text = 'Is in group';
                                                    conditionControl.options[1].value = 'NotInGroup';
                                                    conditionControl.options[1].text = 'Is not in group';
                                                    conditionControl.selectedIndex = 0;        
                                                }";

        private void RegisterScript()
        {
            _computeFieldsScript.Insert(0, "function ComputeFields(){");
            _computeFieldsScript.Append("}");
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "ComputeFields", _computeFieldsScript.ToString(), true);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "OptionChange", OptionChangeScript, true);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "OptionFieldWhereChange", OptionFieldWhereChangeScript, true);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "FillConditionForUser", FillConditionForUserScript, true);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "FillConditionForField", FillConditionForFieldScript, true);
            Page.ClientScript.RegisterClientScriptBlock(GetType(), "ComputeField", ComputeFieldScript, true);
        }
    }
}