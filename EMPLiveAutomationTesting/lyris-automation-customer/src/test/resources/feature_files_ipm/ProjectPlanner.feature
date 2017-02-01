Feature: Add, Edit and Delete Project

  Background:
    Given execute before conditions

# C829527: Add, Edit and Delete Project
  @Ready
  Scenario: Add, Edit and Delete Project
    Given I Open project planer url
    When I click on new item
    And I enter a Project Name as "Test_EpmLive_Project"
    And I select project status "(2) Proposed"
    And I select overAll status "(2) At Risk"
    And I select Project Update "(2) At Risk"
    And I click on save button
    Then The project created must be saved
    And I click on delete button
    And I accept delete popup
    Then The project created must be deleted
    And Close all browsers

#C829530: Add resources to project and assign tasks to them
  @Ready
  Scenario: Add resources to project and assign tasks to them
    Given I Open project planer url
    And I am selecting any oneproject
    And I Click on Item menu
    And I Click on edit plan menu
    Then The Select Planner Page should be displayed
    And I Click on project planner
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
    And Close all browsers