Feature: Testing Exceptions
    
    Scenario: NoSuchElement Exception
        Given I open exception site "https://practicetestautomation.com/practice-test-exceptions/"
        When I click the add button with id "add_btn"
        Then There should be a second row with id "row2"
        
    Scenario: ElementNotInteractable Exception
        Given I open exception site "https://practicetestautomation.com/practice-test-exceptions/" 
        When I click the add button with id "add_btn"
        And I click on the text box on row with id "row2" and type "hi"
        And I click on the save button with name "Save"
       