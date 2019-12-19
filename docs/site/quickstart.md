# Quick start

To define an actor inheritance of Actor class and override the method **Receive**

> The receive method use pattern matching to apply the behaviors.

In the receive assign the behavior all of the response for the actor are
reactive observable objects.

## Defining an actor.


```csharp
  public class HelloWorld : Actor
  {
    protected override Behavior Receive(object data) =>
        data switch
        {
            string message => Actor.Behavior(this.Show, message),
            _ => Actor.Ignore
        };
    
    private IObservable<Unit> Show(string message)
    {
        Console.WriteLine(message);
        return Actor.Done;
    }

  }
```


## Spawn an actor (Link)

```csharp

public class HelloController {
  
    private IUserContext user;
    
    public HelloController(IUserContext user) {
       this.user = user;
    }
    
    [HttpPost]
    public IObservable<Unit> Hello(string message) {
        var link = this.user.Spawn<HelloWorld>();
        return link.Send(message);
    }
}

```