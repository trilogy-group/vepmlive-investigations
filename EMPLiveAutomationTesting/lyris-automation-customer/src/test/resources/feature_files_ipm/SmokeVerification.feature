Feature: Smoke Tests

##C829742: Add, Edit and Delete Change
#  @Ready
#  Scenario: Add, Edit and Delete Change
#    Given execute before conditions
#    When I click on Changes on the left panel
#    Then Change center page should be displayed
#    When I click on 'New Item' in Change page
#    Then Change New Item page should be displayed
#    When I provide required value for new Change and I click on save button
#    Then Change should be created
#    When I click on 'Edit Item' button
#    Then Edit Change page should be displayed
#    When I make some changes on Change item and I click on save button
#    Then Changes in change item should be saved
#    When I click on 'Delete' button in change item
#    And I accept delete popup
#    Then Change should be deleted
#
##C829754: View Reports
#  @Ready
#  Scenario: View Reports
#    Given execute before conditions
#    When I click on Reports on the left panel
#    Then Reporting page should be displayed
#    When I click on 'Classic Reporting'
#    Then Report page should be displayed
#    When I click on project List from the 'Report List'
#    And I Select 'Project Health' from the list
#    Then Project health view should get displayed
#
##C829790: Add an Item from Social Stream
#  @Ready
#  Scenario: Add an Item from Social Stream
#    Given execute before conditions
#    When Click on 'More' option to view all available options in social stream
#    And Click on any of the link say : Project
#    Then A new item page form should be displayed
#    When I Provide value in required fields and I click on save button
#    Then An Item will create and will get display in social stream
#
##C829751: Create and Remove Workspace
#  @Ready
#  Scenario: Create and Remove Workspace
#    Given execute before conditions
#    When I click on 'My Workspace' from left panel
#    And I click on 'New Workspace'
#    Then The 'Create Workspace' popup should be displayed
#    When I  provide Workspace name and description
#    And I select Permission as Private or Open
#    And I select any of the Online Template Like: Blank, Collaborative, PPM, Project
#    And I click on 'Create Workspace'
#    Then newly added workspace name would be displayed under 'Workspaces' panel