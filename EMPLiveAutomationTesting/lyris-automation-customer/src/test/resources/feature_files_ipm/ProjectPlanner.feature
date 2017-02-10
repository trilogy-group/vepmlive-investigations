Feature: Add, Edit and Delete Project

## C829527: Add, Edit and Delete Project
#  @Ready
#  Scenario: Add, Edit and Delete Project
#    Given execute before conditions
#    And I click on project panel
#    When I click on new item
#    And I enter a Project Name as "Test_EpmLive_Project"
#    And I select project status "(1) Proposed"
#    And I select Overall Health "(2) At Risk"
#    And I select Project Update "Schedule Driven"
#    And I enter a test as "testing"
#    And I click on save button
#    Then The project created must be saved
#    When I click on edit button
#    And I enter Project Work as "300"
#    And Project Actual Work as "40"
#    And I save after editing
#    Then The project created must be saved
#    And The values edited should be changed as "300" for Project Work  and "40" for Actual Work
#    When I click on delete button
#    And I accept delete popup
#    Then The project created must be deleted

#C829530: Add resources to project and assign tasks to them
  @Ready
  Scenario: Add resources to project and assign tasks to them
    Given execute before conditions
    And I click on project panel
    When I click on new item
    And I enter a Project Name as "Test_EpmLive_Project"
    And I select project status "(1) Proposed"
    And I enter a test as "testing"
    And I click on save button
    And I click on project panel
    And I am selecting any oneproject
    And I Click on Item menu
    And I Click on edit plan menu
    Then The Select Planner Page should be displayed
    And I Click on project planner
    And I click on Blank Plan
    When I Click on edit team
    Then The Page Build Team should be displayed
    When I am selecting the first user from the list
    And I Click on add user button
    And I Click on Save build team
    Then The tasks page should be displayed
    When I Click on add tasks
    And I enter task name "task name"
    And I Click on user cell
    And I select user for task
    And I save a task
    When I click on publish
    And I click on Close Tasks
    Then The project summary page should be displayed
    When I click on Tasks
    Then The Tasks Summary page should displayed
    And Task created should be saved

##C829770: Edit Resource plan
#  @Ready
#  Scenario: Edit Resource plan
#    Given execute before conditions
#    And I click on project panel
#    When I click on new item
#    And I enter a Project Name as "Test_EpmLive_Project"
#    And I select project status "(1) Proposed"
#    And I enter a test as "testing"
#    And I click on save button
#    And I click on project panel
#    And I am selecting any oneproject
#    And I Click on Item menu
#    When I Click on Edit Resource Planner
#    Then Resource Planner page should be displayed
#    When I select one user
#    And I click on add user in project planner
#    Then Resource should be added to top section
#    When I enter hours in grid "50"
#    And I click onResourse plannerSave button
#    Then Pop up should displayed asking the User if they want to "Make Private Rows Public?"
#    Then I click on set public ok button