Feature: Work with Tasks, Issues and Risks

#C829718: Add, Edit and Delete Task
  @Ready
  Scenario: Add, Edit and Delete Task
    Given execute before conditions
    When I click on Tasks on the left panel
    Then Task center page should be displayed
    When I click on 'New Item'
    Then New Item page should be displayed
    When I provide required value and I click on save button
    Then Task should be created
    When I click on 'Edit Item' button
    Then Edit Task page should be displayed
    When I make some changes and I click on save button
    Then Change should be saved
    When I click on 'Delete' button
    And accept delete popup for task issu risk
    Then Task should be deleted

#C829719: Add, Edit and Delete Risk
  @Ready
  Scenario: Add, Edit and Delete Risk
    Given execute before conditions
    When I click on Risks on the left panel
    Then Risk center page should be displayed
    When I click on 'New Item' in Risk page
    Then Risk New Item page should be displayed
    When I provide required value for new risk and I click on save button
    Then Risk should be created
    When I click on 'Edit Item' button
    Then Edit Risk page should be displayed
    When I make some changes on risk item and I click on save button
    Then Risk Changes should be saved
    When I click on 'Delete' button
    And accept delete popup for task issu risk
    Then Risk should be deleted

#C829740: Add, Edit and Delete Issue
  @Ready
  Scenario: Add, Edit and Delete Issue
    Given execute before conditions
    When I click on Issues on the left panel
    Then Issue center page should be displayed
    When I click on 'New Item' in Issue page
    Then Issue New Item page should be displayed
    When I provide required value for new Issue and I click on save button
    Then Issue should be created
    When I click on 'Edit Item' button
    Then Edit Issue page should be displayed
    When I make some changes on Issue item and I click on save button
    Then Issue Changes should be saved
    When I click on 'Delete' button
    And accept delete popup for task issu risk
    Then Issue should be deleted