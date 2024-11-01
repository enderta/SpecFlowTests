Feature: Lab Automation Practice Website

Background:
  
    Given I login the page
    When I enter the following details to login form:
      | User Name   | Password   |
      |standard_user  | secret_sauce|
    
    @Lab
  Scenario: Search Product
    Given I am on the product listing page
    When I search for "<searchTerm>"
    Then I should see search results containing "<searchTerm>"


