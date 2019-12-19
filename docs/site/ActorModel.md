# Actor Model

Actor models is a mathematical computational model that allow create distributed, concurrent and parallel computational.
“Actors” as the universal primitives of concurrent digital computation [Hewitt, Bishop, and Steiger 1973; Hewitt 1977]


## Axioms

When an actor receive a message 

1. Create a finite numbers actors.
2. Send a finite number of messages to other actors.
3. Handle the behavior for the next message.


### Order
 
The actors are units of concurrence, that means that there is not order in the process of the actions
 
### Decoupling

The actor is decoupling for the sender (Link) it allows asynchronous communication.  
Messages in the Actor model are decoupled from the sender and are delivered by the system.

A natural development of the Actor model was to allow Actor addresses in messages. A computation might need to send a message to a recipient from which it would later
receive a response. The way to do this is to send a communication which has the message along with the address of another Actor called the customer along with
the message. The recipient could then cause a response message to be sent to the customer.

### Indeterminacy
The actor models supports the indeterminacy, there is not order in the arrival of the message
so it can affect the future behavior. that means it is a quasi-commutative aspect of the actor
the order can affect the future behavior.