Feature: Smoke Tests

#C829742: Add, Edit and Delete Change
#  @Ready
  Scenario: Add, Edit and Delete Change
    Given execute before conditions
    When I click on Changes on the left panel
    Then Change center page should be displayed
    When I click on 'New Item' in Change page
    Then Change New Item page should be displayed
    When I provide required value for new Change and I click on save button
    Then Change should be created
    When I click on 'Edit Item' button
    Then Edit Change page should be displayed
    When I make some changes on Change item and I click on save button
    Then Changes in change item should be saved
    When I click on 'Delete' button in change item
    And I accept delete popup
    Then Change should be deleted

#C829754: View Reports
#  @Ready
  Scenario: View Reports
    Given execute before conditions
    When I click on Reports on the left panel
    Then Reporting page should be displayed
    When I click on 'Classic Reporting'
    Then Report page should be displayed
    When I click on project List from the 'Report List'
    And I Select 'Project Health' from the list
    Then Project health view should get displayed

#C829743: Submit Timesheet
  #@Ready
  Scenario: Submit Timesheet
    Given execute before conditions
    When I click on 'My Workplace' from left panel
    And Click on 'My Timesheet'
    Then The 'My Timesheet' page should be displayed
    And Click on 'Add Work'
    Then Tasks assigned to user will be displayed
    When I Select tasks and click on 'Add'
    Then Selected task should be displayed in Timesheet page
    When I click on 'Save' button
#    And Click on 'Submit' button
#    Then Timesheet should be submitted