# Features/Login.feature


Feature: Login

    Background: Successful login
        Given the application is launched
        When I enter the username "standard_user"
        And I enter the password "secret_sauce"
        And I click the login button
        Then I should be logged in successfully
    @log
   Scenario: Check out the product
        Given I am logged in
        When I click on the product
        And I click on the add to cart button
        Then I should see the product in the cart
        Then I click on the checkout button
        Then I fill in the details
        | First Name | Last Name | Zip Code |
        | John       | Doe       | 12345    |