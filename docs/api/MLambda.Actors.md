# MLambda.Actors

## Contents

- [Asynchronous](#T-MLambda-Actors-Communication-Asynchronous 'MLambda.Actors.Communication.Asynchronous')
  - [#ctor(payload)](#M-MLambda-Actors-Communication-Asynchronous-#ctor-System-Object- 'MLambda.Actors.Communication.Asynchronous.#ctor(System.Object)')
  - [Payload](#P-MLambda-Actors-Communication-Asynchronous-Payload 'MLambda.Actors.Communication.Asynchronous.Payload')
  - [Response(response)](#M-MLambda-Actors-Communication-Asynchronous-Response-System-Object- 'MLambda.Actors.Communication.Asynchronous.Response(System.Object)')
- [Bucket](#T-MLambda-Actors-Bucket 'MLambda.Actors.Bucket')
  - [#ctor(dependency)](#M-MLambda-Actors-Bucket-#ctor-MLambda-Actors-Abstraction-IDependency- 'MLambda.Actors.Bucket.#ctor(MLambda.Actors.Abstraction.IDependency)')
  - [MLambda#Actors#Abstraction#IRootContext#Self](#P-MLambda-Actors-Bucket-MLambda#Actors#Abstraction#IRootContext#Self 'MLambda.Actors.Bucket.MLambda#Actors#Abstraction#IRootContext#Self')
  - [MLambda#Actors#Abstraction#IUserContext#Self](#P-MLambda-Actors-Bucket-MLambda#Actors#Abstraction#IUserContext#Self 'MLambda.Actors.Bucket.MLambda#Actors#Abstraction#IUserContext#Self')
  - [Root](#P-MLambda-Actors-Bucket-Root 'MLambda.Actors.Bucket.Root')
  - [User](#P-MLambda-Actors-Bucket-User 'MLambda.Actors.Bucket.User')
  - [Filter(filter)](#M-MLambda-Actors-Bucket-Filter-System-Func{MLambda-Actors-Abstraction-IProcess,System-Boolean}- 'MLambda.Actors.Bucket.Filter(System.Func{MLambda.Actors.Abstraction.IProcess,System.Boolean})')
  - [Release(id)](#M-MLambda-Actors-Bucket-Release-System-Guid- 'MLambda.Actors.Bucket.Release(System.Guid)')
  - [Spawn\`\`1(parent)](#M-MLambda-Actors-Bucket-Spawn``1-MLambda-Actors-Abstraction-IProcess- 'MLambda.Actors.Bucket.Spawn``1(MLambda.Actors.Abstraction.IProcess)')
- [Collector](#T-MLambda-Actors-Collector 'MLambda.Actors.Collector')
  - [#ctor(root)](#M-MLambda-Actors-Collector-#ctor-MLambda-Actors-Abstraction-IRootContext- 'MLambda.Actors.Collector.#ctor(MLambda.Actors.Abstraction.IRootContext)')
  - [Collect(id)](#M-MLambda-Actors-Collector-Collect-System-Guid- 'MLambda.Actors.Collector.Collect(System.Guid)')
- [Context](#T-MLambda-Actors-Context 'MLambda.Actors.Context')
  - [#ctor(container)](#M-MLambda-Actors-Context-#ctor-MLambda-Actors-Abstraction-IBucket- 'MLambda.Actors.Context.#ctor(MLambda.Actors.Abstraction.IBucket)')
  - [SetProcess(pid)](#M-MLambda-Actors-Context-SetProcess-MLambda-Actors-Abstraction-IProcess- 'MLambda.Actors.Context.SetProcess(MLambda.Actors.Abstraction.IProcess)')
  - [Spawn\`\`1()](#M-MLambda-Actors-Context-Spawn``1 'MLambda.Actors.Context.Spawn``1')
- [Decider](#T-MLambda-Actors-Supervision-Decider 'MLambda.Actors.Supervision.Decider')
  - [#ctor()](#M-MLambda-Actors-Supervision-Decider-#ctor 'MLambda.Actors.Supervision.Decider.#ctor')
  - [Decision(fail)](#M-MLambda-Actors-Supervision-Decider-Decision-System-Exception- 'MLambda.Actors.Supervision.Decider.Decision(System.Exception)')
  - [Default(directive)](#M-MLambda-Actors-Supervision-Decider-Default-MLambda-Actors-Abstraction-Supervision-Directive- 'MLambda.Actors.Supervision.Decider.Default(MLambda.Actors.Abstraction.Supervision.Directive)')
  - [When\`\`1(directive)](#M-MLambda-Actors-Supervision-Decider-When``1-MLambda-Actors-Abstraction-Supervision-Directive- 'MLambda.Actors.Supervision.Decider.When``1(MLambda.Actors.Abstraction.Supervision.Directive)')
- [Kill](#T-MLambda-Actors-Guardian-Messages-Kill 'MLambda.Actors.Guardian.Messages.Kill')
  - [#ctor()](#M-MLambda-Actors-Guardian-Messages-Kill-#ctor-System-Guid- 'MLambda.Actors.Guardian.Messages.Kill.#ctor(System.Guid)')
  - [Id](#P-MLambda-Actors-Guardian-Messages-Kill-Id 'MLambda.Actors.Guardian.Messages.Kill.Id')
- [LifeCycle](#T-MLambda-Actors-Process-LifeCycle 'MLambda.Actors.Process.LifeCycle')
  - [Receiving](#F-MLambda-Actors-Process-LifeCycle-Receiving 'MLambda.Actors.Process.LifeCycle.Receiving')
  - [Restarting](#F-MLambda-Actors-Process-LifeCycle-Restarting 'MLambda.Actors.Process.LifeCycle.Restarting')
  - [Starting](#F-MLambda-Actors-Process-LifeCycle-Starting 'MLambda.Actors.Process.LifeCycle.Starting')
  - [Stopping](#F-MLambda-Actors-Process-LifeCycle-Stopping 'MLambda.Actors.Process.LifeCycle.Stopping')
  - [Terminated](#F-MLambda-Actors-Process-LifeCycle-Terminated 'MLambda.Actors.Process.LifeCycle.Terminated')
- [LifeCycleHandler](#T-MLambda-Actors-Process-LifeCycleHandler 'MLambda.Actors.Process.LifeCycleHandler')
- [Link](#T-MLambda-Actors-Link 'MLambda.Actors.Link')
  - [#ctor(mailBox,collector)](#M-MLambda-Actors-Link-#ctor-MLambda-Actors-Abstraction-IMailBox,MLambda-Actors-Abstraction-ICollector- 'MLambda.Actors.Link.#ctor(MLambda.Actors.Abstraction.IMailBox,MLambda.Actors.Abstraction.ICollector)')
  - [Dispose()](#M-MLambda-Actors-Link-Dispose 'MLambda.Actors.Link.Dispose')
  - [Dispose(disposing)](#M-MLambda-Actors-Link-Dispose-System-Boolean- 'MLambda.Actors.Link.Dispose(System.Boolean)')
  - [Finalize()](#M-MLambda-Actors-Link-Finalize 'MLambda.Actors.Link.Finalize')
  - [Send\`\`1(message)](#M-MLambda-Actors-Link-Send``1-``0- 'MLambda.Actors.Link.Send``1(``0)')
  - [Send\`\`2(message)](#M-MLambda-Actors-Link-Send``2-``0- 'MLambda.Actors.Link.Send``2(``0)')
- [OneForOne](#T-MLambda-Actors-Supervision-OneForOne 'MLambda.Actors.Supervision.OneForOne')
  - [#ctor(decider)](#M-MLambda-Actors-Supervision-OneForOne-#ctor-MLambda-Actors-Abstraction-Supervision-IDecider- 'MLambda.Actors.Supervision.OneForOne.#ctor(MLambda.Actors.Abstraction.Supervision.IDecider)')
  - [Compute(process,message)](#M-MLambda-Actors-Supervision-OneForOne-Compute-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IMessage- 'MLambda.Actors.Supervision.OneForOne.Compute(MLambda.Actors.Abstraction.IProcess,MLambda.Actors.Abstraction.IMessage)')
- [Pid](#T-MLambda-Actors-Guardian-Messages-Pid 'MLambda.Actors.Guardian.Messages.Pid')
  - [#ctor(id,route,status)](#M-MLambda-Actors-Guardian-Messages-Pid-#ctor-System-Guid,System-String,System-String- 'MLambda.Actors.Guardian.Messages.Pid.#ctor(System.Guid,System.String,System.String)')
  - [Id](#P-MLambda-Actors-Guardian-Messages-Pid-Id 'MLambda.Actors.Guardian.Messages.Pid.Id')
  - [Route](#P-MLambda-Actors-Guardian-Messages-Pid-Route 'MLambda.Actors.Guardian.Messages.Pid.Route')
  - [Status](#P-MLambda-Actors-Guardian-Messages-Pid-Status 'MLambda.Actors.Guardian.Messages.Pid.Status')
- [Process](#T-MLambda-Actors-Process 'MLambda.Actors.Process')
  - [#ctor(dependency)](#M-MLambda-Actors-Process-#ctor-MLambda-Actors-Abstraction-IDependency- 'MLambda.Actors.Process.#ctor(MLambda.Actors.Abstraction.IDependency)')
  - [Child](#P-MLambda-Actors-Process-Child 'MLambda.Actors.Process.Child')
  - [Id](#P-MLambda-Actors-Process-Id 'MLambda.Actors.Process.Id')
  - [Link](#P-MLambda-Actors-Process-Link 'MLambda.Actors.Process.Link')
  - [Parent](#P-MLambda-Actors-Process-Parent 'MLambda.Actors.Process.Parent')
  - [Route](#P-MLambda-Actors-Process-Route 'MLambda.Actors.Process.Route')
  - [Status](#P-MLambda-Actors-Process-Status 'MLambda.Actors.Process.Status')
  - [Setup(process,childActor)](#M-MLambda-Actors-Process-Setup-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IActor- 'MLambda.Actors.Process.Setup(MLambda.Actors.Abstraction.IProcess,MLambda.Actors.Abstraction.IActor)')
  - [Stop()](#M-MLambda-Actors-Process-Stop 'MLambda.Actors.Process.Stop')
- [ProcessCount](#T-MLambda-Actors-Guardian-Messages-ProcessCount 'MLambda.Actors.Guardian.Messages.ProcessCount')
- [ProcessFilter](#T-MLambda-Actors-Guardian-Messages-ProcessFilter 'MLambda.Actors.Guardian.Messages.ProcessFilter')
  - [#ctor(route)](#M-MLambda-Actors-Guardian-Messages-ProcessFilter-#ctor-System-String- 'MLambda.Actors.Guardian.Messages.ProcessFilter.#ctor(System.String)')
  - [Route](#P-MLambda-Actors-Guardian-Messages-ProcessFilter-Route 'MLambda.Actors.Guardian.Messages.ProcessFilter.Route')
- [RootActor](#T-MLambda-Actors-Guardian-RootActor 'MLambda.Actors.Guardian.RootActor')
  - [#ctor(bucket)](#M-MLambda-Actors-Guardian-RootActor-#ctor-MLambda-Actors-Abstraction-IBucket- 'MLambda.Actors.Guardian.RootActor.#ctor(MLambda.Actors.Abstraction.IBucket)')
  - [Receive(data)](#M-MLambda-Actors-Guardian-RootActor-Receive-System-Object- 'MLambda.Actors.Guardian.RootActor.Receive(System.Object)')
- [Scheduler](#T-MLambda-Actors-Scheduler 'MLambda.Actors.Scheduler')
  - [#ctor(mailBox)](#M-MLambda-Actors-Scheduler-#ctor-MLambda-Actors-Abstraction-IMailBox- 'MLambda.Actors.Scheduler.#ctor(MLambda.Actors.Abstraction.IMailBox)')
  - [IsRunning](#P-MLambda-Actors-Scheduler-IsRunning 'MLambda.Actors.Scheduler.IsRunning')
  - [Start()](#M-MLambda-Actors-Scheduler-Start 'MLambda.Actors.Scheduler.Start')
  - [Stop()](#M-MLambda-Actors-Scheduler-Stop 'MLambda.Actors.Scheduler.Stop')
  - [Subscribe(notify)](#M-MLambda-Actors-Scheduler-Subscribe-System-Func{MLambda-Actors-Abstraction-IMessage,System-Threading-Tasks-Task}- 'MLambda.Actors.Scheduler.Subscribe(System.Func{MLambda.Actors.Abstraction.IMessage,System.Threading.Tasks.Task})')
- [Synchronous](#T-MLambda-Actors-Communication-Synchronous 'MLambda.Actors.Communication.Synchronous')
  - [#ctor(message)](#M-MLambda-Actors-Communication-Synchronous-#ctor-System-Object- 'MLambda.Actors.Communication.Synchronous.#ctor(System.Object)')
  - [Payload](#P-MLambda-Actors-Communication-Synchronous-Payload 'MLambda.Actors.Communication.Synchronous.Payload')
  - [Response(response)](#M-MLambda-Actors-Communication-Synchronous-Response-System-Object- 'MLambda.Actors.Communication.Synchronous.Response(System.Object)')
  - [ToObservable\`\`1()](#M-MLambda-Actors-Communication-Synchronous-ToObservable``1 'MLambda.Actors.Communication.Synchronous.ToObservable``1')
- [UserActor](#T-MLambda-Actors-Guardian-UserActor 'MLambda.Actors.Guardian.UserActor')
  - [Receive(data)](#M-MLambda-Actors-Guardian-UserActor-Receive-System-Object- 'MLambda.Actors.Guardian.UserActor.Receive(System.Object)')

<a name='T-MLambda-Actors-Communication-Asynchronous'></a>
## Asynchronous `type`

##### Namespace

MLambda.Actors.Communication

##### Summary

The Asynchronous message.

<a name='M-MLambda-Actors-Communication-Asynchronous-#ctor-System-Object-'></a>
### #ctor(payload) `constructor`

##### Summary

Initializes a new instance of the [Asynchronous](#T-MLambda-Actors-Communication-Asynchronous 'MLambda.Actors.Communication.Asynchronous') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| payload | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | The payload. |

<a name='P-MLambda-Actors-Communication-Asynchronous-Payload'></a>
### Payload `property`

##### Summary

Gets the message.

<a name='M-MLambda-Actors-Communication-Asynchronous-Response-System-Object-'></a>
### Response(response) `method`

##### Summary

Responses to the observable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the response. |

<a name='T-MLambda-Actors-Bucket'></a>
## Bucket `type`

##### Namespace

MLambda.Actors

##### Summary

The actor container class.

<a name='M-MLambda-Actors-Bucket-#ctor-MLambda-Actors-Abstraction-IDependency-'></a>
### #ctor(dependency) `constructor`

##### Summary

Initializes a new instance of the [Bucket](#T-MLambda-Actors-Bucket 'MLambda.Actors.Bucket') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dependency | [MLambda.Actors.Abstraction.IDependency](#T-MLambda-Actors-Abstraction-IDependency 'MLambda.Actors.Abstraction.IDependency') | the dependency. |

<a name='P-MLambda-Actors-Bucket-MLambda#Actors#Abstraction#IRootContext#Self'></a>
### MLambda#Actors#Abstraction#IRootContext#Self `property`

##### Summary

Gets the root.

<a name='P-MLambda-Actors-Bucket-MLambda#Actors#Abstraction#IUserContext#Self'></a>
### MLambda#Actors#Abstraction#IUserContext#Self `property`

##### Summary

Gets the user.

<a name='P-MLambda-Actors-Bucket-Root'></a>
### Root `property`

##### Summary

Gets the root address.

<a name='P-MLambda-Actors-Bucket-User'></a>
### User `property`

##### Summary

Gets the user address.

<a name='M-MLambda-Actors-Bucket-Filter-System-Func{MLambda-Actors-Abstraction-IProcess,System-Boolean}-'></a>
### Filter(filter) `method`

##### Summary

Filters the process.

##### Returns

The list of process.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Func{MLambda.Actors.Abstraction.IProcess,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IProcess,System.Boolean}') | the filter. |

<a name='M-MLambda-Actors-Bucket-Release-System-Guid-'></a>
### Release(id) `method`

##### Summary

Releases the process.

##### Returns

The unit.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | the process id. |

<a name='M-MLambda-Actors-Bucket-Spawn``1-MLambda-Actors-Abstraction-IProcess-'></a>
### Spawn\`\`1(parent) `method`

##### Summary

Spawns the new actor address.

##### Returns

The address actor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the parent process. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | the type of the actor. |

<a name='T-MLambda-Actors-Collector'></a>
## Collector `type`

##### Namespace

MLambda.Actors

##### Summary

The collector class.

<a name='M-MLambda-Actors-Collector-#ctor-MLambda-Actors-Abstraction-IRootContext-'></a>
### #ctor(root) `constructor`

##### Summary

Initializes a new instance of the [Collector](#T-MLambda-Actors-Collector 'MLambda.Actors.Collector') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| root | [MLambda.Actors.Abstraction.IRootContext](#T-MLambda-Actors-Abstraction-IRootContext 'MLambda.Actors.Abstraction.IRootContext') | the root context. |

<a name='M-MLambda-Actors-Collector-Collect-System-Guid-'></a>
### Collect(id) `method`

##### Summary

Collects the actors.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | the id. |

<a name='T-MLambda-Actors-Context'></a>
## Context `type`

##### Namespace

MLambda.Actors

##### Summary

The actor context task.

<a name='M-MLambda-Actors-Context-#ctor-MLambda-Actors-Abstraction-IBucket-'></a>
### #ctor(container) `constructor`

##### Summary

Initializes a new instance of the [Context](#T-MLambda-Actors-Context 'MLambda.Actors.Context') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| container | [MLambda.Actors.Abstraction.IBucket](#T-MLambda-Actors-Abstraction-IBucket 'MLambda.Actors.Abstraction.IBucket') | the container. |

<a name='M-MLambda-Actors-Context-SetProcess-MLambda-Actors-Abstraction-IProcess-'></a>
### SetProcess(pid) `method`

##### Summary

Setups the process.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pid | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the process. |

<a name='M-MLambda-Actors-Context-Spawn``1'></a>
### Spawn\`\`1() `method`

##### Summary

Spawns a new actor.

##### Returns

The address.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | the type of the actor. |

<a name='T-MLambda-Actors-Supervision-Decider'></a>
## Decider `type`

##### Namespace

MLambda.Actors.Supervision

##### Summary

The decider class.

<a name='M-MLambda-Actors-Supervision-Decider-#ctor'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [Decider](#T-MLambda-Actors-Supervision-Decider 'MLambda.Actors.Supervision.Decider') class.

##### Parameters

This constructor has no parameters.

<a name='M-MLambda-Actors-Supervision-Decider-Decision-System-Exception-'></a>
### Decision(fail) `method`

##### Summary

The decision for the type of exception.

##### Returns

the directive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fail | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | the fail exception. |

<a name='M-MLambda-Actors-Supervision-Decider-Default-MLambda-Actors-Abstraction-Supervision-Directive-'></a>
### Default(directive) `method`

##### Summary

Sets the default value for any exception

##### Returns

the actual decider.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directive | [MLambda.Actors.Abstraction.Supervision.Directive](#T-MLambda-Actors-Abstraction-Supervision-Directive 'MLambda.Actors.Abstraction.Supervision.Directive') | The directive |

<a name='M-MLambda-Actors-Supervision-Decider-When``1-MLambda-Actors-Abstraction-Supervision-Directive-'></a>
### When\`\`1(directive) `method`

##### Summary

Match the type of the exception to the directive.

##### Returns

The actual decider.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| directive | [MLambda.Actors.Abstraction.Supervision.Directive](#T-MLambda-Actors-Abstraction-Supervision-Directive 'MLambda.Actors.Abstraction.Supervision.Directive') | The directive. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the exception. |

<a name='T-MLambda-Actors-Guardian-Messages-Kill'></a>
## Kill `type`

##### Namespace

MLambda.Actors.Guardian.Messages

##### Summary

The kill message class.

<a name='M-MLambda-Actors-Guardian-Messages-Kill-#ctor-System-Guid-'></a>
### #ctor() `constructor`

##### Summary

Initializes a new instance of the [Kill](#T-MLambda-Actors-Guardian-Messages-Kill 'MLambda.Actors.Guardian.Messages.Kill') class.

##### Parameters

This constructor has no parameters.

<a name='P-MLambda-Actors-Guardian-Messages-Kill-Id'></a>
### Id `property`

##### Summary

Gets the id.

<a name='T-MLambda-Actors-Process-LifeCycle'></a>
## LifeCycle `type`

##### Namespace

MLambda.Actors.Process

##### Summary

The lifecycle of the process.

<a name='F-MLambda-Actors-Process-LifeCycle-Receiving'></a>
### Receiving `constants`

##### Summary

The process can receiving the message.

<a name='F-MLambda-Actors-Process-LifeCycle-Restarting'></a>
### Restarting `constants`

##### Summary

The process is going to restart and assign new schedulers.

<a name='F-MLambda-Actors-Process-LifeCycle-Starting'></a>
### Starting `constants`

##### Summary

The process is initializes.

<a name='F-MLambda-Actors-Process-LifeCycle-Stopping'></a>
### Stopping `constants`

##### Summary

The process cleans up the actual state.

<a name='F-MLambda-Actors-Process-LifeCycle-Terminated'></a>
### Terminated `constants`

##### Summary

The process is dead.

<a name='T-MLambda-Actors-Process-LifeCycleHandler'></a>
## LifeCycleHandler `type`

##### Namespace

MLambda.Actors.Process

##### Summary

The lifecycle event.

<a name='T-MLambda-Actors-Link'></a>
## Link `type`

##### Namespace

MLambda.Actors

##### Summary

The actor proxy implementation.

<a name='M-MLambda-Actors-Link-#ctor-MLambda-Actors-Abstraction-IMailBox,MLambda-Actors-Abstraction-ICollector-'></a>
### #ctor(mailBox,collector) `constructor`

##### Summary

Initializes a new instance of the [Link](#T-MLambda-Actors-Link 'MLambda.Actors.Link') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mailBox | [MLambda.Actors.Abstraction.IMailBox](#T-MLambda-Actors-Abstraction-IMailBox 'MLambda.Actors.Abstraction.IMailBox') | the mail box. |
| collector | [MLambda.Actors.Abstraction.ICollector](#T-MLambda-Actors-Abstraction-ICollector 'MLambda.Actors.Abstraction.ICollector') | the actor collector. |

<a name='M-MLambda-Actors-Link-Dispose'></a>
### Dispose() `method`

##### Summary

Disposed the actor.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Link-Dispose-System-Boolean-'></a>
### Dispose(disposing) `method`

##### Summary

Disposed the actor model.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| disposing | [System.Boolean](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Boolean 'System.Boolean') | disposing the actor. |

<a name='M-MLambda-Actors-Link-Finalize'></a>
### Finalize() `method`

##### Summary

Finalizes an instance of the [Link](#T-MLambda-Actors-Link 'MLambda.Actors.Link') class.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Link-Send``1-``0-'></a>
### Send\`\`1(message) `method`

##### Summary

Tells the message to the actor.

##### Returns

The response of the the actor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [\`\`0](#T-``0 '``0') | the message. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the message. |

<a name='M-MLambda-Actors-Link-Send``2-``0-'></a>
### Send\`\`2(message) `method`

##### Summary

Tells to the actor the message.

##### Returns

The response of the object.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [\`\`0](#T-``0 '``0') | The emit message. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TI | The in type. |
| TO | The out type. |

<a name='T-MLambda-Actors-Supervision-OneForOne'></a>
## OneForOne `type`

##### Namespace

MLambda.Actors.Supervision

##### Summary

One for one strategy.

<a name='M-MLambda-Actors-Supervision-OneForOne-#ctor-MLambda-Actors-Abstraction-Supervision-IDecider-'></a>
### #ctor(decider) `constructor`

##### Summary

Initializes a new instance of the [OneForOne](#T-MLambda-Actors-Supervision-OneForOne 'MLambda.Actors.Supervision.OneForOne') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| decider | [MLambda.Actors.Abstraction.Supervision.IDecider](#T-MLambda-Actors-Abstraction-Supervision-IDecider 'MLambda.Actors.Abstraction.Supervision.IDecider') | the decider. |

<a name='M-MLambda-Actors-Supervision-OneForOne-Compute-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IMessage-'></a>
### Compute(process,message) `method`

##### Summary

Computes the message.

##### Returns

The context function.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| process | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the process. |
| message | [MLambda.Actors.Abstraction.IMessage](#T-MLambda-Actors-Abstraction-IMessage 'MLambda.Actors.Abstraction.IMessage') | the message. |

<a name='T-MLambda-Actors-Guardian-Messages-Pid'></a>
## Pid `type`

##### Namespace

MLambda.Actors.Guardian.Messages

##### Summary

The process id.

<a name='M-MLambda-Actors-Guardian-Messages-Pid-#ctor-System-Guid,System-String,System-String-'></a>
### #ctor(id,route,status) `constructor`

##### Summary

Initializes a new instance of the [Pid](#T-MLambda-Actors-Guardian-Messages-Pid 'MLambda.Actors.Guardian.Messages.Pid') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | the id. |
| route | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | the route. |
| status | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | the status. |

<a name='P-MLambda-Actors-Guardian-Messages-Pid-Id'></a>
### Id `property`

##### Summary

Gets the id.

<a name='P-MLambda-Actors-Guardian-Messages-Pid-Route'></a>
### Route `property`

##### Summary

Gets the route.

<a name='P-MLambda-Actors-Guardian-Messages-Pid-Status'></a>
### Status `property`

##### Summary

Gets the status.

<a name='T-MLambda-Actors-Process'></a>
## Process `type`

##### Namespace

MLambda.Actors

##### Summary

The process class.

<a name='M-MLambda-Actors-Process-#ctor-MLambda-Actors-Abstraction-IDependency-'></a>
### #ctor(dependency) `constructor`

##### Summary

Initializes a new instance of the [Process](#T-MLambda-Actors-Process 'MLambda.Actors.Process') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| dependency | [MLambda.Actors.Abstraction.IDependency](#T-MLambda-Actors-Abstraction-IDependency 'MLambda.Actors.Abstraction.IDependency') | The dependency. |

<a name='P-MLambda-Actors-Process-Child'></a>
### Child `property`

##### Summary

Gets the child actor.

<a name='P-MLambda-Actors-Process-Id'></a>
### Id `property`

##### Summary

Gets the id.

<a name='P-MLambda-Actors-Process-Link'></a>
### Link `property`

##### Summary

Gets the address.

<a name='P-MLambda-Actors-Process-Parent'></a>
### Parent `property`

##### Summary

Gets the parent actor.

<a name='P-MLambda-Actors-Process-Route'></a>
### Route `property`

##### Summary

Gets the path.

<a name='P-MLambda-Actors-Process-Status'></a>
### Status `property`

##### Summary

Gets the status.

<a name='M-MLambda-Actors-Process-Setup-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IActor-'></a>
### Setup(process,childActor) `method`

##### Summary

Setups the actors.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| process | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the parent actor. |
| childActor | [MLambda.Actors.Abstraction.IActor](#T-MLambda-Actors-Abstraction-IActor 'MLambda.Actors.Abstraction.IActor') | the child actor. |

<a name='M-MLambda-Actors-Process-Stop'></a>
### Stop() `method`

##### Summary

Stops the scheduler.

##### Parameters

This method has no parameters.

<a name='T-MLambda-Actors-Guardian-Messages-ProcessCount'></a>
## ProcessCount `type`

##### Namespace

MLambda.Actors.Guardian.Messages

##### Summary

The process count class.

<a name='T-MLambda-Actors-Guardian-Messages-ProcessFilter'></a>
## ProcessFilter `type`

##### Namespace

MLambda.Actors.Guardian.Messages

##### Summary

Process Filter class.

<a name='M-MLambda-Actors-Guardian-Messages-ProcessFilter-#ctor-System-String-'></a>
### #ctor(route) `constructor`

##### Summary

Initializes a new instance of the [ProcessFilter](#T-MLambda-Actors-Guardian-Messages-ProcessFilter 'MLambda.Actors.Guardian.Messages.ProcessFilter') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| route | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The filter. |

<a name='P-MLambda-Actors-Guardian-Messages-ProcessFilter-Route'></a>
### Route `property`

##### Summary

Gets the filter.

<a name='T-MLambda-Actors-Guardian-RootActor'></a>
## RootActor `type`

##### Namespace

MLambda.Actors.Guardian

##### Summary

The system actor class.

<a name='M-MLambda-Actors-Guardian-RootActor-#ctor-MLambda-Actors-Abstraction-IBucket-'></a>
### #ctor(bucket) `constructor`

##### Summary

Initializes a new instance of the [RootActor](#T-MLambda-Actors-Guardian-RootActor 'MLambda.Actors.Guardian.RootActor') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| bucket | [MLambda.Actors.Abstraction.IBucket](#T-MLambda-Actors-Abstraction-IBucket 'MLambda.Actors.Abstraction.IBucket') | the bucket. |

<a name='M-MLambda-Actors-Guardian-RootActor-Receive-System-Object-'></a>
### Receive(data) `method`

##### Summary

Receives the message.

##### Returns

the behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the data. |

<a name='T-MLambda-Actors-Scheduler'></a>
## Scheduler `type`

##### Namespace

MLambda.Actors

##### Summary

The dispatcher of the Actor.

<a name='M-MLambda-Actors-Scheduler-#ctor-MLambda-Actors-Abstraction-IMailBox-'></a>
### #ctor(mailBox) `constructor`

##### Summary

Initializes a new instance of the [Scheduler](#T-MLambda-Actors-Scheduler 'MLambda.Actors.Scheduler') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| mailBox | [MLambda.Actors.Abstraction.IMailBox](#T-MLambda-Actors-Abstraction-IMailBox 'MLambda.Actors.Abstraction.IMailBox') | the mailbox. |

<a name='P-MLambda-Actors-Scheduler-IsRunning'></a>
### IsRunning `property`

##### Summary

Gets a value indicating whether gets the running flag.

<a name='M-MLambda-Actors-Scheduler-Start'></a>
### Start() `method`

##### Summary

Starts the mailbox dispatcher.

##### Returns

The response.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Scheduler-Stop'></a>
### Stop() `method`

##### Summary

Stops the mailbox dispatcher.

##### Returns

The response.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Scheduler-Subscribe-System-Func{MLambda-Actors-Abstraction-IMessage,System-Threading-Tasks-Task}-'></a>
### Subscribe(notify) `method`

##### Summary

Subscribes the notification.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| notify | [System.Func{MLambda.Actors.Abstraction.IMessage,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IMessage,System.Threading.Tasks.Task}') | the observer. |

<a name='T-MLambda-Actors-Communication-Synchronous'></a>
## Synchronous `type`

##### Namespace

MLambda.Actors.Communication

##### Summary

The feature class.

<a name='M-MLambda-Actors-Communication-Synchronous-#ctor-System-Object-'></a>
### #ctor(message) `constructor`

##### Summary

Initializes a new instance of the [Synchronous](#T-MLambda-Actors-Communication-Synchronous 'MLambda.Actors.Communication.Synchronous') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the message to propagate. |

<a name='P-MLambda-Actors-Communication-Synchronous-Payload'></a>
### Payload `property`

##### Summary

Gets the message.

<a name='M-MLambda-Actors-Communication-Synchronous-Response-System-Object-'></a>
### Response(response) `method`

##### Summary

Responses to the observable.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the response. |

<a name='M-MLambda-Actors-Communication-Synchronous-ToObservable``1'></a>
### ToObservable\`\`1() `method`

##### Summary

Change the feature to a observable.

##### Returns

The response.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| TO | The type of the response. |

<a name='T-MLambda-Actors-Guardian-UserActor'></a>
## UserActor `type`

##### Namespace

MLambda.Actors.Guardian

##### Summary

The user actor class.

<a name='M-MLambda-Actors-Guardian-UserActor-Receive-System-Object-'></a>
### Receive(data) `method`

##### Summary

Receives the message.

##### Returns

the behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the data. |
