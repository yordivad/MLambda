# MLambda Actors
MLambda Actors is one of the implementation of the actor models for 
**DotNet Core** and **Kotlin** technology.

There are many implementations of the actor model as AKKA.net, Orleans and Proto Actor.
But all of these implementations are hard to understand, and don't provide a a clean architecture.
Our vision is create a simple, light way library for compute the actors models, designing it
using Solid Principles.

![Actor](site/assets/actor.png)

See the [architecture](site/architecture.md)

The mission of this framework is to provide a base to define **Hexagonal Architecture**.

In the development of the microservices, there are many paradigms about how it is implemented,
we know that a Microservice has the own database and the code should be small that allow to 
refactor the code in at least two weeks

These are some pragmatical criteria, but there is not a unification theory about microservices, but
for my perspective the close architecture that can helps us to define a precise microservices is based
on *agile* methodology and clean architectures.


Some design principles that can help us to governs the structure is Domain Driven Design.

The principles are:

1. There are bounded context, it is a bunch of entities aggregations.
2. There are entities and value objects, Entities has a unique identity, the value objects are
types that don't have a identity, it is base in the internal state.
3. The Domain core don't have any access to the persistence.
4. The state is persisted using the repository pattern.

 
![Hexagonal](site/assets/hexagonal.png)

In order to provide a solid Microservices architecture, the actor model is going to handle the applications layer,
Using actor allow to design a resilient, robustness handles message. An actor model has a mailbox and for some exceptions the actor
use supervision that helps to recover for failure scenarios. 


![Deployment](site/assets/deployment.png)
