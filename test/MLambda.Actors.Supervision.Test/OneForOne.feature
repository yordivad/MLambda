Feature: One for one strategy
    If a child process terminates, only that process is decider.
    where you restart / stop / resume only the failed actor. This is what you’d mostly.
    
Scenario: Restart
    Restart the child actor i.e. kill the current child actor that failed and create a new one in its place.
    
    Given a actor with one to one strategy
    When the actor send a restart message
    Then Create a new actor and replace it.
    
    

Scenario: Resume
    Let the child actor keep its current state and continue processing new messages like nothing happened.
    
Scenario: Stop
    Shut down the child actor permanently.

Scenario: Escalate
    Let the supervisor’s supervisor handle this error.