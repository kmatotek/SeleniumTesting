Feature: HappyLang TextBox
  
  Scenario: Enter text and check output
    Given I open "https://happy-lang.live/"
    When I click the button with id "run-btn"
    Then The output should contain "Hello World!"
    