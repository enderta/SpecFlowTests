# Features/Login.feature

@log
Feature: Login

    Scenario: Successful login
        Given the application is launched
        When I enter the username "user"
        And I enter the password "password"
        And I click the login button
        Then I should be logged in successfully