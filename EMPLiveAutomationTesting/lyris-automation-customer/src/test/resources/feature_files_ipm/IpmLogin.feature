Feature: Check IPM Login functionality 
In order to access IPM application
As a user I should login to application

Background:
    Given user navigates to URL : "${ipm.url}" application

@QA02  @Ready
Scenario: Validate valid login 
    When I enter "${user}" and "${user.password}" in login panel
    And I click login button
	Then I should land on home page
