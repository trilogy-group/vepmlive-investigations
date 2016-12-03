Feature: Add, Edit and Delete Project

Background:
	When execute before conditions
    
	Scenario: Add, Edit and Delete Project
	Given I Open project planer url
	Then I click on new item
	Then I enter ProjectName "Test003"
	Then I select project status "(2) Proposed"
	Then I select overAll status "(2) At Risk"
	Then I select Project Update "(2) At Risk"
	Then I click on save button
	Then I click on delete button
	Then I accept delete popup

Scenario: Add resources to project and assign tasks to them

    Given I Open project planer url
	Then I am selecting any oneproject
	Then I Click on Item menu
	Then I Click on edit plan menu
	Then I Click on project planner
	Then I Click on edit team
	Then I am selecting fist user from list
	Then I Click on add user button
	Then I Click on Save build team
	Then I Click on add tasks
	Then I enter task name "task name"
	Then I Click on user cell
	Then I select user for task
	Then I save a task
	Then I close Task Window

	Scenario: Edit project cost
	Given I Open project planer url
	Then I click on new item
	Then I enter ProjectName "Test003"
	Then I select project status "(2) Proposed"
	Then I select overAll status "(2) At Risk"
	Then I select Project Update "(2) At Risk"
	Then I click on save button
	Then I click on edit button
	Then I enter project cost "50"
	Then Save edited project
	
	@QA04  @Ready
	Scenario: Edit Resource plan
	Then I create project with defaultvalues and selectproject in projectsfolder "epmlive test"
	Then I Click on Edit Resource Planner
	Then I select user "newuser"
	Then I click on add user in project planner
	Then I enter hours in grid "50"
	Then I click onResourse plannerSave button 
	Then I click on set public ok button 
	Then I click on Resource planner Close button 
	 
    	
	