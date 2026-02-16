Feature: Example site
  Scenario: Visit example.com
    Given I open example.com
    Then the title contains "Example Domain"
    