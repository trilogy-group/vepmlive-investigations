Feature: Work with ressources

#C829512: Add Resource
  @Ready
  Scenario: Add Ressource
    Given execute before conditions
    When I click on Ressources on left panel
    Then The ressource page should be opned
    When I click on 'Invite'
    Then The 'Add Ressource' page should be displayed
    When I enter required fields and click on save button
    Then Ressource should be added