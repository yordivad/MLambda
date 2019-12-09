Feature: Root Actor feature
    
    In order to provide a mechanism of control the root actor should handle the control of the user actor
    and also can provide the mechanism to kill process.
    
    Scenario: Kill A process
        Given a demo actor
        When Kill the process
        Then the Actor is removed from the bucket