Feature: Login on Practice Site

    Scenario: Successful login with valid credentials
        Given I open "https://practicetestautomation.com/practice-test-login/"
        When I type "student" into the username box with id "username"
        And I type "Password123" into the password box with id "password"
        And I click the submit button with id "submit"
        Then The new page URL should contain "practicetestautomation.com/logged-in-successfully/"
        And The page should contain text "successfully logged in"
        And The logout button should be visible
        
    Scenario: Login fails with invalid username
        Given I open "https://practicetestautomation.com/practice-test-login/"
        When I type "incorrectUser" into the username box with id "username"
        And I type "Password123" into the password box with id "password"
        And I click the submit button with id "submit"
        Then The message with id "error" is displayed
        Then The message with id "error" should contain "username is invalid"
        
    Scenario: Login fails with invalid password
        Given I open "https://practicetestautomation.com/practice-test-login/"
        When I type "student" into the username box with id "username"
        And I type "incoreectPassword" into the password box with id "password"
        And I click the submit button with id "submit"
        Then The message with id "error" is displayed
        Then The message with id "error" should contain "password is invalid"
        
        