Feature: collect actors.
    In order to disposed actors, the actors are persisted in a bucket, the code only has access to the 
    address, the actors do not interact in the logic, because of that the collector should release 
    the actor if it is disposed.
    
Scenario: release actors
    Given an user actor
    When the console actor is called
    Then verify that console actor was relased
    