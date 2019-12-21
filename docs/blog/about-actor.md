
![banner](assets/blog-01.png)

# Actor Computational Model

## Abstract

In this paper, we are going to cover the concepts about Actor Computational Model and Reactive Programming,
 as you know there are many computational models, as Turing Machines, Von Neumann Architectures that 
 helps us to write interactive programming, Actor model break the way that we think in computational. 
 Actors Model is base on physical properties, that allow us to think differently.   

## Motivation

We want to modelling intelligence in terms of a society of communication knowledge- base problem-solving experts. In turn, each of the experts can be viewed as a society that can be further decomposed in the same way until the primitive actors of the system are reached [Hewitt, 1976]

This is the motivation to study actor, it is a completely different way to understand computational, in order to provide smart agents that are interacting between them resolving problems. as today we are building Microservices architectures but it is not more than actors interacting between them.

# What is an actor:

An actor is a computational mathematical model for concurrent, distributed, parallel primitive units of computation. That means is the model of computation.

Actors differ from other models because it is base on physical properties, some of the actual models as Procedimental, Lambda Calculus, Turing Machines, Petri Nets has sequential, or global states in order to compute an operation. The actors break with previous models because of asynchronous communication and the order of the arrival messages cannot be logically inferred.

The actors are a closed system that allows some mathematical aspects as the Quasi-Commutativity and the representation theorem, locality, indeterminacy.

**Quasi-Commutativity**: it is guaranteed because of the order of receiving a message don't matter in the order that was created.

**Computational representation theorem**: the actors are closed in the sense that they do not receive communication from outside. In this way, the behaviour of an actor S can be mathematically characterized in terms of all its possible behaviours, S = U(Bi)

**Locality**: In response to a message received an Actor can change only its local storage that can include address only of Actors provided when it was created.

**Indeterminacy**: Robert Kowalsky develops the thesis that "computation could be subsumed by deduction [Kowalsky 1988]" that means Computational = controlled deduction [Hayes 1973], but in the way, that order of the message are not the same of the execution the actor model break this concept of controlled deduction.

So as we see, the Actor model is a unit of concurrent, distributed, parallelism unit of the computation that can be persisted, allow to create resilient, robustness, fail tolerance, asynchronous, indeterminacy programs. it is base on mathematical models.

The behaviours are algebraic design models that combine a set of the operations as a co-product that do not share global states.

All of the messages are processing using pattern matching, so in all of my years as a developer, I need to say that the Actor model is the most beautiful style of programming it combines everything: indeterminacy, pattern matching, algebras, co-algebras, recursion, closed system, locality.


```csharp

 protected override Behavior Receive(object data) =>
        data switch
        {   
            string message when messsage == "call" => Actor.Behavior(this.Call)
            string message => Actor.Behavior(this.Show, message),
            (int a, int b) => Actor.Behavior(this.Add, a, b)
            _ => Actor.Ignore
        };

```

