Feature: In order to provide Guardians 
  
  Scenario: Root Guardian
    Given an root context
    When Send a Stop Message
    When Send a Not Valid Message
    Then Verify it Handle the message
      
     


  Scenario: User Guardian
    Given an user context
    When Send a Stop Message
    When Send a Not Valid Message
    Then Verify it Handle the message
      
Scenario: User Guard