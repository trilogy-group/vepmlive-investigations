Feature:  create Invite only with required fealds and save

Background:
    When Resource execute before conditions
	
@Ready
Scenario: Verify that the resend notification page have the list of all users of the org that never have logged in to LHQ
	Then I click on left panel
	Then I click on resources
	Then I click on invite button 
	Then I enter role "Employee ;"
	Then I enter holidayschedule "US Holidays ;"
	Then I enter workhours "US Work Hours ;"
	Then I enter availablefrom "06/11/2017"
	Then I clcick onn permissions button
	Then I select permissionype "Administrators"
	Then Click on save Invite button
	