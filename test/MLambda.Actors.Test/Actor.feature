Feature: In order to provide the actor model a actor has a root actor that handle the creation of actors.
  an actor has a mailbox
  an actor has a state
  an actor has persistence
  
  Scenario: An actor context can create a actor.
    Given a context
    When Create the actor
    