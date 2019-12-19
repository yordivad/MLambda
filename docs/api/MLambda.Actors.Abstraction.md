<a name='assembly'></a>
# MLambda.Actors.Abstraction

## Contents

- [Actor](#T-MLambda-Actors-Abstraction-Actor 'MLambda.Actors.Abstraction.Actor')
  - [Default](#P-MLambda-Actors-Abstraction-Actor-Default 'MLambda.Actors.Abstraction.Actor.Default')
  - [Done](#P-MLambda-Actors-Abstraction-Actor-Done 'MLambda.Actors.Abstraction.Actor.Done')
  - [Ignore](#P-MLambda-Actors-Abstraction-Actor-Ignore 'MLambda.Actors.Abstraction.Actor.Ignore')
  - [Supervisor](#P-MLambda-Actors-Abstraction-Actor-Supervisor 'MLambda.Actors.Abstraction.Actor.Supervisor')
  - [Behavior\`\`1(apply)](#M-MLambda-Actors-Abstraction-Actor-Behavior``1-System-Func{MLambda-Actors-Abstraction-IContext,System-IObservable{``0}}- 'MLambda.Actors.Abstraction.Actor.Behavior``1(System.Func{MLambda.Actors.Abstraction.IContext,System.IObservable{``0}})')
  - [Behavior\`\`1(apply)](#M-MLambda-Actors-Abstraction-Actor-Behavior``1-System-Func{System-IObservable{``0}}- 'MLambda.Actors.Abstraction.Actor.Behavior``1(System.Func{System.IObservable{``0}})')
  - [Behavior\`\`2(apply,a)](#M-MLambda-Actors-Abstraction-Actor-Behavior``2-System-Func{MLambda-Actors-Abstraction-IContext,``1,System-IObservable{``0}},``1- 'MLambda.Actors.Abstraction.Actor.Behavior``2(System.Func{MLambda.Actors.Abstraction.IContext,``1,System.IObservable{``0}},``1)')
  - [Behavior\`\`2(apply,a)](#M-MLambda-Actors-Abstraction-Actor-Behavior``2-System-Func{``1,System-IObservable{``0}},``1- 'MLambda.Actors.Abstraction.Actor.Behavior``2(System.Func{``1,System.IObservable{``0}},``1)')
  - [Behavior\`\`3(apply,a,b)](#M-MLambda-Actors-Abstraction-Actor-Behavior``3-System-Func{MLambda-Actors-Abstraction-IContext,``1,``2,System-IObservable{``0}},``1,``2- 'MLambda.Actors.Abstraction.Actor.Behavior``3(System.Func{MLambda.Actors.Abstraction.IContext,``1,``2,System.IObservable{``0}},``1,``2)')
  - [Behavior\`\`3(apply,a,b)](#M-MLambda-Actors-Abstraction-Actor-Behavior``3-System-Func{``1,``2,System-IObservable{``0}},``1,``2- 'MLambda.Actors.Abstraction.Actor.Behavior``3(System.Func{``1,``2,System.IObservable{``0}},``1,``2)')
  - [Behavior\`\`4(apply,a,b,c)](#M-MLambda-Actors-Abstraction-Actor-Behavior``4-System-Func{MLambda-Actors-Abstraction-IContext,``1,``2,``3,System-IObservable{``0}},``1,``2,``3- 'MLambda.Actors.Abstraction.Actor.Behavior``4(System.Func{MLambda.Actors.Abstraction.IContext,``1,``2,``3,System.IObservable{``0}},``1,``2,``3)')
  - [Behavior\`\`4(apply,a,b,c)](#M-MLambda-Actors-Abstraction-Actor-Behavior``4-System-Func{``1,``2,``3,System-IObservable{``0}},``1,``2,``3- 'MLambda.Actors.Abstraction.Actor.Behavior``4(System.Func{``1,``2,``3,System.IObservable{``0}},``1,``2,``3)')
  - [Behavior\`\`5(apply,a,b,c,d)](#M-MLambda-Actors-Abstraction-Actor-Behavior``5-System-Func{``1,``2,``3,``4,System-IObservable{``0}},``1,``2,``3,``4- 'MLambda.Actors.Abstraction.Actor.Behavior``5(System.Func{``1,``2,``3,``4,System.IObservable{``0}},``1,``2,``3,``4)')
  - [Behavior\`\`5(apply,a,b,c,d)](#M-MLambda-Actors-Abstraction-Actor-Behavior``5-System-Func{MLambda-Actors-Abstraction-IContext,``1,``2,``3,``4,System-IObservable{``0}},``1,``2,``3,``4- 'MLambda.Actors.Abstraction.Actor.Behavior``5(System.Func{MLambda.Actors.Abstraction.IContext,``1,``2,``3,``4,System.IObservable{``0}},``1,``2,``3,``4)')
  - [MLambda#Actors#Abstraction#IActor#Receive(data)](#M-MLambda-Actors-Abstraction-Actor-MLambda#Actors#Abstraction#IActor#Receive-System-Object- 'MLambda.Actors.Abstraction.Actor.MLambda#Actors#Abstraction#IActor#Receive(System.Object)')
  - [Receive(data)](#M-MLambda-Actors-Abstraction-Actor-Receive-System-Object- 'MLambda.Actors.Abstraction.Actor.Receive(System.Object)')
- [Behavior](#T-MLambda-Actors-Abstraction-Behavior 'MLambda.Actors.Abstraction.Behavior')
- [Directive](#T-MLambda-Actors-Abstraction-Supervision-Directive 'MLambda.Actors.Abstraction.Supervision.Directive')
  - [Escalate](#F-MLambda-Actors-Abstraction-Supervision-Directive-Escalate 'MLambda.Actors.Abstraction.Supervision.Directive.Escalate')
  - [Restart](#F-MLambda-Actors-Abstraction-Supervision-Directive-Restart 'MLambda.Actors.Abstraction.Supervision.Directive.Restart')
  - [Resume](#F-MLambda-Actors-Abstraction-Supervision-Directive-Resume 'MLambda.Actors.Abstraction.Supervision.Directive.Resume')
  - [Stop](#F-MLambda-Actors-Abstraction-Supervision-Directive-Stop 'MLambda.Actors.Abstraction.Supervision.Directive.Stop')
- [IActor](#T-MLambda-Actors-Abstraction-IActor 'MLambda.Actors.Abstraction.IActor')
  - [Supervisor](#P-MLambda-Actors-Abstraction-IActor-Supervisor 'MLambda.Actors.Abstraction.IActor.Supervisor')
  - [Receive(data)](#M-MLambda-Actors-Abstraction-IActor-Receive-System-Object- 'MLambda.Actors.Abstraction.IActor.Receive(System.Object)')
- [IBucket](#T-MLambda-Actors-Abstraction-IBucket 'MLambda.Actors.Abstraction.IBucket')
  - [Root](#P-MLambda-Actors-Abstraction-IBucket-Root 'MLambda.Actors.Abstraction.IBucket.Root')
  - [User](#P-MLambda-Actors-Abstraction-IBucket-User 'MLambda.Actors.Abstraction.IBucket.User')
  - [Count()](#M-MLambda-Actors-Abstraction-IBucket-Count 'MLambda.Actors.Abstraction.IBucket.Count')
  - [Filter(filter)](#M-MLambda-Actors-Abstraction-IBucket-Filter-System-Func{MLambda-Actors-Abstraction-IProcess,System-Boolean}- 'MLambda.Actors.Abstraction.IBucket.Filter(System.Func{MLambda.Actors.Abstraction.IProcess,System.Boolean})')
  - [Release(id)](#M-MLambda-Actors-Abstraction-IBucket-Release-System-Guid- 'MLambda.Actors.Abstraction.IBucket.Release(System.Guid)')
  - [Spawn\`\`1(parent)](#M-MLambda-Actors-Abstraction-IBucket-Spawn``1-MLambda-Actors-Abstraction-IProcess- 'MLambda.Actors.Abstraction.IBucket.Spawn``1(MLambda.Actors.Abstraction.IProcess)')
- [ICollector](#T-MLambda-Actors-Abstraction-ICollector 'MLambda.Actors.Abstraction.ICollector')
  - [Collect(id)](#M-MLambda-Actors-Abstraction-ICollector-Collect-System-Guid- 'MLambda.Actors.Abstraction.ICollector.Collect(System.Guid)')
- [IContext](#T-MLambda-Actors-Abstraction-IContext 'MLambda.Actors.Abstraction.IContext')
  - [Spawn\`\`1()](#M-MLambda-Actors-Abstraction-IContext-Spawn``1 'MLambda.Actors.Abstraction.IContext.Spawn``1')
- [IDecider](#T-MLambda-Actors-Abstraction-Supervision-IDecider 'MLambda.Actors.Abstraction.Supervision.IDecider')
  - [Decision(fail)](#M-MLambda-Actors-Abstraction-Supervision-IDecider-Decision-System-Exception- 'MLambda.Actors.Abstraction.Supervision.IDecider.Decision(System.Exception)')
- [IDependency](#T-MLambda-Actors-Abstraction-IDependency 'MLambda.Actors.Abstraction.IDependency')
  - [Resolve(type)](#M-MLambda-Actors-Abstraction-IDependency-Resolve-System-Type- 'MLambda.Actors.Abstraction.IDependency.Resolve(System.Type)')
  - [Resolve\`\`1()](#M-MLambda-Actors-Abstraction-IDependency-Resolve``1 'MLambda.Actors.Abstraction.IDependency.Resolve``1')
- [ILink](#T-MLambda-Actors-Abstraction-ILink 'MLambda.Actors.Abstraction.ILink')
  - [Send\`\`1(message)](#M-MLambda-Actors-Abstraction-ILink-Send``1-``0- 'MLambda.Actors.Abstraction.ILink.Send``1(``0)')
  - [Send\`\`2(message)](#M-MLambda-Actors-Abstraction-ILink-Send``2-``0- 'MLambda.Actors.Abstraction.ILink.Send``2(``0)')
- [IMailBox](#T-MLambda-Actors-Abstraction-IMailBox 'MLambda.Actors.Abstraction.IMailBox')
  - [Id](#P-MLambda-Actors-Abstraction-IMailBox-Id 'MLambda.Actors.Abstraction.IMailBox.Id')
  - [Add(message)](#M-MLambda-Actors-Abstraction-IMailBox-Add-MLambda-Actors-Abstraction-IMessage- 'MLambda.Actors.Abstraction.IMailBox.Add(MLambda.Actors.Abstraction.IMessage)')
  - [Take()](#M-MLambda-Actors-Abstraction-IMailBox-Take 'MLambda.Actors.Abstraction.IMailBox.Take')
- [IMainContext](#T-MLambda-Actors-Abstraction-IMainContext 'MLambda.Actors.Abstraction.IMainContext')
  - [SetProcess(pid)](#M-MLambda-Actors-Abstraction-IMainContext-SetProcess-MLambda-Actors-Abstraction-IProcess- 'MLambda.Actors.Abstraction.IMainContext.SetProcess(MLambda.Actors.Abstraction.IProcess)')
- [IMessage](#T-MLambda-Actors-Abstraction-IMessage 'MLambda.Actors.Abstraction.IMessage')
  - [Payload](#P-MLambda-Actors-Abstraction-IMessage-Payload 'MLambda.Actors.Abstraction.IMessage.Payload')
  - [Response(response)](#M-MLambda-Actors-Abstraction-IMessage-Response-System-Object- 'MLambda.Actors.Abstraction.IMessage.Response(System.Object)')
- [IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess')
  - [Child](#P-MLambda-Actors-Abstraction-IProcess-Child 'MLambda.Actors.Abstraction.IProcess.Child')
  - [Id](#P-MLambda-Actors-Abstraction-IProcess-Id 'MLambda.Actors.Abstraction.IProcess.Id')
  - [Link](#P-MLambda-Actors-Abstraction-IProcess-Link 'MLambda.Actors.Abstraction.IProcess.Link')
  - [Parent](#P-MLambda-Actors-Abstraction-IProcess-Parent 'MLambda.Actors.Abstraction.IProcess.Parent')
  - [Route](#P-MLambda-Actors-Abstraction-IProcess-Route 'MLambda.Actors.Abstraction.IProcess.Route')
  - [Status](#P-MLambda-Actors-Abstraction-IProcess-Status 'MLambda.Actors.Abstraction.IProcess.Status')
  - [Setup(process,childActor)](#M-MLambda-Actors-Abstraction-IProcess-Setup-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IActor- 'MLambda.Actors.Abstraction.IProcess.Setup(MLambda.Actors.Abstraction.IProcess,MLambda.Actors.Abstraction.IActor)')
  - [Stop()](#M-MLambda-Actors-Abstraction-IProcess-Stop 'MLambda.Actors.Abstraction.IProcess.Stop')
- [IRootActor](#T-MLambda-Actors-Abstraction-Guardian-IRootActor 'MLambda.Actors.Abstraction.Guardian.IRootActor')
- [IRootContext](#T-MLambda-Actors-Abstraction-IRootContext 'MLambda.Actors.Abstraction.IRootContext')
  - [Self](#P-MLambda-Actors-Abstraction-IRootContext-Self 'MLambda.Actors.Abstraction.IRootContext.Self')
  - [Spawn\`\`1()](#M-MLambda-Actors-Abstraction-IRootContext-Spawn``1 'MLambda.Actors.Abstraction.IRootContext.Spawn``1')
- [IScheduler](#T-MLambda-Actors-Abstraction-IScheduler 'MLambda.Actors.Abstraction.IScheduler')
  - [IsRunning](#P-MLambda-Actors-Abstraction-IScheduler-IsRunning 'MLambda.Actors.Abstraction.IScheduler.IsRunning')
  - [Start()](#M-MLambda-Actors-Abstraction-IScheduler-Start 'MLambda.Actors.Abstraction.IScheduler.Start')
  - [Stop()](#M-MLambda-Actors-Abstraction-IScheduler-Stop 'MLambda.Actors.Abstraction.IScheduler.Stop')
  - [Subscribe(notify)](#M-MLambda-Actors-Abstraction-IScheduler-Subscribe-System-Func{MLambda-Actors-Abstraction-IMessage,System-Threading-Tasks-Task}- 'MLambda.Actors.Abstraction.IScheduler.Subscribe(System.Func{MLambda.Actors.Abstraction.IMessage,System.Threading.Tasks.Task})')
- [ISupervisor](#T-MLambda-Actors-Abstraction-Supervision-ISupervisor 'MLambda.Actors.Abstraction.Supervision.ISupervisor')
  - [Compute(process,message)](#M-MLambda-Actors-Abstraction-Supervision-ISupervisor-Compute-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IMessage- 'MLambda.Actors.Abstraction.Supervision.ISupervisor.Compute(MLambda.Actors.Abstraction.IProcess,MLambda.Actors.Abstraction.IMessage)')
- [IUserActor](#T-MLambda-Actors-Abstraction-Guardian-IUserActor 'MLambda.Actors.Abstraction.Guardian.IUserActor')
- [IUserContext](#T-MLambda-Actors-Abstraction-IUserContext 'MLambda.Actors.Abstraction.IUserContext')
  - [Self](#P-MLambda-Actors-Abstraction-IUserContext-Self 'MLambda.Actors.Abstraction.IUserContext.Self')
  - [Spawn\`\`1()](#M-MLambda-Actors-Abstraction-IUserContext-Spawn``1 'MLambda.Actors.Abstraction.IUserContext.Spawn``1')
- [RouteAttribute](#T-MLambda-Actors-Abstraction-Annotation-RouteAttribute 'MLambda.Actors.Abstraction.Annotation.RouteAttribute')
  - [#ctor(name)](#M-MLambda-Actors-Abstraction-Annotation-RouteAttribute-#ctor-System-String- 'MLambda.Actors.Abstraction.Annotation.RouteAttribute.#ctor(System.String)')
  - [Name](#P-MLambda-Actors-Abstraction-Annotation-RouteAttribute-Name 'MLambda.Actors.Abstraction.Annotation.RouteAttribute.Name')

<a name='T-MLambda-Actors-Abstraction-Actor'></a>
## Actor `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor implementation.

<a name='P-MLambda-Actors-Abstraction-Actor-Default'></a>
### Default `property`

##### Summary

Gets The default value.

<a name='P-MLambda-Actors-Abstraction-Actor-Done'></a>
### Done `property`

##### Summary

Gets the done value.

<a name='P-MLambda-Actors-Abstraction-Actor-Ignore'></a>
### Ignore `property`

##### Summary

Gets The ignore behavior.

<a name='P-MLambda-Actors-Abstraction-Actor-Supervisor'></a>
### Supervisor `property`

##### Summary

Gets the supervisor strategy.

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``1-System-Func{MLambda-Actors-Abstraction-IContext,System-IObservable{``0}}-'></a>
### Behavior\`\`1(apply) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{MLambda.Actors.Abstraction.IContext,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IContext,System.IObservable{``0}}') | the lambda method. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``1-System-Func{System-IObservable{``0}}-'></a>
### Behavior\`\`1(apply) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{System.IObservable{``0}}') | the lambda method. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``2-System-Func{MLambda-Actors-Abstraction-IContext,``1,System-IObservable{``0}},``1-'></a>
### Behavior\`\`2(apply,a) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{MLambda.Actors.Abstraction.IContext,\`\`1,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IContext,``1,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``2-System-Func{``1,System-IObservable{``0}},``1-'></a>
### Behavior\`\`2(apply,a) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{\`\`1,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``1,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``3-System-Func{MLambda-Actors-Abstraction-IContext,``1,``2,System-IObservable{``0}},``1,``2-'></a>
### Behavior\`\`3(apply,a,b) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{MLambda.Actors.Abstraction.IContext,\`\`1,\`\`2,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IContext,``1,``2,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |
| b | [\`\`2](#T-``2 '``2') | the value b. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |
| Tb | The type of b. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``3-System-Func{``1,``2,System-IObservable{``0}},``1,``2-'></a>
### Behavior\`\`3(apply,a,b) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{\`\`1,\`\`2,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``1,``2,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |
| b | [\`\`2](#T-``2 '``2') | the value b. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |
| Tb | The type of b. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``4-System-Func{MLambda-Actors-Abstraction-IContext,``1,``2,``3,System-IObservable{``0}},``1,``2,``3-'></a>
### Behavior\`\`4(apply,a,b,c) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{MLambda.Actors.Abstraction.IContext,\`\`1,\`\`2,\`\`3,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IContext,``1,``2,``3,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |
| b | [\`\`2](#T-``2 '``2') | the value b. |
| c | [\`\`3](#T-``3 '``3') | the value c. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |
| Tb | The type of b. |
| Tc | The type of c. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``4-System-Func{``1,``2,``3,System-IObservable{``0}},``1,``2,``3-'></a>
### Behavior\`\`4(apply,a,b,c) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{\`\`1,\`\`2,\`\`3,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``1,``2,``3,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |
| b | [\`\`2](#T-``2 '``2') | the value b. |
| c | [\`\`3](#T-``3 '``3') | the value c. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |
| Tb | The type of b. |
| Tc | The type of c. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``5-System-Func{``1,``2,``3,``4,System-IObservable{``0}},``1,``2,``3,``4-'></a>
### Behavior\`\`5(apply,a,b,c,d) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{\`\`1,\`\`2,\`\`3,\`\`4,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{``1,``2,``3,``4,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |
| b | [\`\`2](#T-``2 '``2') | the value b. |
| c | [\`\`3](#T-``3 '``3') | the value c. |
| d | [\`\`4](#T-``4 '``4') | the value d. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |
| Tb | The type of b. |
| Tc | The type of c. |
| Td | The type of d. |

<a name='M-MLambda-Actors-Abstraction-Actor-Behavior``5-System-Func{MLambda-Actors-Abstraction-IContext,``1,``2,``3,``4,System-IObservable{``0}},``1,``2,``3,``4-'></a>
### Behavior\`\`5(apply,a,b,c,d) `method`

##### Summary

The Behavior handler for the message.

##### Returns

The behavior.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| apply | [System.Func{MLambda.Actors.Abstraction.IContext,\`\`1,\`\`2,\`\`3,\`\`4,System.IObservable{\`\`0}}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IContext,``1,``2,``3,``4,System.IObservable{``0}}') | the lambda method. |
| a | [\`\`1](#T-``1 '``1') | the value a. |
| b | [\`\`2](#T-``2 '``2') | the value b. |
| c | [\`\`3](#T-``3 '``3') | the value c. |
| d | [\`\`4](#T-``4 '``4') | the value d. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| To | The type of the response. |
| Ta | The type of a. |
| Tb | The type of b. |
| Tc | The type of c. |
| Td | The type of d. |

<a name='M-MLambda-Actors-Abstraction-Actor-MLambda#Actors#Abstraction#IActor#Receive-System-Object-'></a>
### MLambda#Actors#Abstraction#IActor#Receive(data) `method`

##### Summary

Receives the message.

##### Returns

The match rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the data. |

<a name='M-MLambda-Actors-Abstraction-Actor-Receive-System-Object-'></a>
### Receive(data) `method`

##### Summary

Receives the message.

##### Returns

The match rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the data. |

<a name='T-MLambda-Actors-Abstraction-Behavior'></a>
## Behavior `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The Behavior delegate.

##### Returns

The response.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| context | [T:MLambda.Actors.Abstraction.Behavior](#T-T-MLambda-Actors-Abstraction-Behavior 'T:MLambda.Actors.Abstraction.Behavior') | the context. |

<a name='T-MLambda-Actors-Abstraction-Supervision-Directive'></a>
## Directive `type`

##### Namespace

MLambda.Actors.Abstraction.Supervision

##### Summary

The supervision directive.

<a name='F-MLambda-Actors-Abstraction-Supervision-Directive-Escalate'></a>
### Escalate `constants`

##### Summary

Delegate the responsibility to the parent.

<a name='F-MLambda-Actors-Abstraction-Supervision-Directive-Restart'></a>
### Restart `constants`

##### Summary

Restart the actual actor.

<a name='F-MLambda-Actors-Abstraction-Supervision-Directive-Resume'></a>
### Resume `constants`

##### Summary

Resume the actual actor.

<a name='F-MLambda-Actors-Abstraction-Supervision-Directive-Stop'></a>
### Stop `constants`

##### Summary

Kill the actual actor.

<a name='T-MLambda-Actors-Abstraction-IActor'></a>
## IActor `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor interface.

<a name='P-MLambda-Actors-Abstraction-IActor-Supervisor'></a>
### Supervisor `property`

##### Summary

Gets the supervisor strategy.

<a name='M-MLambda-Actors-Abstraction-IActor-Receive-System-Object-'></a>
### Receive(data) `method`

##### Summary

Receives the message.

##### Returns

The match rules.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| data | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the data. |

<a name='T-MLambda-Actors-Abstraction-IBucket'></a>
## IBucket `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor container.

<a name='P-MLambda-Actors-Abstraction-IBucket-Root'></a>
### Root `property`

##### Summary

Gets the root address.

<a name='P-MLambda-Actors-Abstraction-IBucket-User'></a>
### User `property`

##### Summary

Gets the user address.

<a name='M-MLambda-Actors-Abstraction-IBucket-Count'></a>
### Count() `method`

##### Summary

Counts the actors.

##### Returns

The count of the actor.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Abstraction-IBucket-Filter-System-Func{MLambda-Actors-Abstraction-IProcess,System-Boolean}-'></a>
### Filter(filter) `method`

##### Summary

Process filter.

##### Returns

The collection of the process.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| filter | [System.Func{MLambda.Actors.Abstraction.IProcess,System.Boolean}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IProcess,System.Boolean}') | the filter. |

<a name='M-MLambda-Actors-Abstraction-IBucket-Release-System-Guid-'></a>
### Release(id) `method`

##### Summary

Releases the actor.

##### Returns

The response.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | the id. |

<a name='M-MLambda-Actors-Abstraction-IBucket-Spawn``1-MLambda-Actors-Abstraction-IProcess-'></a>
### Spawn\`\`1(parent) `method`

##### Summary

Creates the actor address.

##### Returns

The address of the actor.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| parent | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the parent process. |

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | the type of the actor. |

<a name='T-MLambda-Actors-Abstraction-ICollector'></a>
## ICollector `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor collectors interface.

<a name='M-MLambda-Actors-Abstraction-ICollector-Collect-System-Guid-'></a>
### Collect(id) `method`

##### Summary

Collects the actors that has the id.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| id | [System.Guid](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Guid 'System.Guid') | the actors identity. |

<a name='T-MLambda-Actors-Abstraction-IContext'></a>
## IContext `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor context interface.

<a name='M-MLambda-Actors-Abstraction-IContext-Spawn``1'></a>
### Spawn\`\`1() `method`

##### Summary

Creates the actor proxy.

##### Returns

The actor proxy.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the actor. |

<a name='T-MLambda-Actors-Abstraction-Supervision-IDecider'></a>
## IDecider `type`

##### Namespace

MLambda.Actors.Abstraction.Supervision

##### Summary

The decider interface.

<a name='M-MLambda-Actors-Abstraction-Supervision-IDecider-Decision-System-Exception-'></a>
### Decision(fail) `method`

##### Summary

The decision for the type of exception.

##### Returns

the directive.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| fail | [System.Exception](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Exception 'System.Exception') | the fail exception. |

<a name='T-MLambda-Actors-Abstraction-IDependency'></a>
## IDependency `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The dependency injection interface.

<a name='M-MLambda-Actors-Abstraction-IDependency-Resolve-System-Type-'></a>
### Resolve(type) `method`

##### Summary

Resolve the instance.

##### Returns

the instance.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| type | [System.Type](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Type 'System.Type') | the type of the instance. |

<a name='M-MLambda-Actors-Abstraction-IDependency-Resolve``1'></a>
### Resolve\`\`1() `method`

##### Summary

Resolve the instance of type T.

##### Returns

The instance.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The instance to resolve. |

<a name='T-MLambda-Actors-Abstraction-ILink'></a>
## ILink `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor proxy.

<a name='M-MLambda-Actors-Abstraction-ILink-Send``1-``0-'></a>
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

<a name='M-MLambda-Actors-Abstraction-ILink-Send``2-``0-'></a>
### Send\`\`2(message) `method`

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
| TI | the type in. |
| TO | the type out. |

<a name='T-MLambda-Actors-Abstraction-IMailBox'></a>
## IMailBox `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The mailbox of the actors.

<a name='P-MLambda-Actors-Abstraction-IMailBox-Id'></a>
### Id `property`

##### Summary

Gets the id.

<a name='M-MLambda-Actors-Abstraction-IMailBox-Add-MLambda-Actors-Abstraction-IMessage-'></a>
### Add(message) `method`

##### Summary

Push the message in the mail box.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| message | [MLambda.Actors.Abstraction.IMessage](#T-MLambda-Actors-Abstraction-IMessage 'MLambda.Actors.Abstraction.IMessage') | The future message. |

<a name='M-MLambda-Actors-Abstraction-IMailBox-Take'></a>
### Take() `method`

##### Summary

Pops the message.

##### Returns

The future message.

##### Parameters

This method has no parameters.

<a name='T-MLambda-Actors-Abstraction-IMainContext'></a>
## IMainContext `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The main context interface.

<a name='M-MLambda-Actors-Abstraction-IMainContext-SetProcess-MLambda-Actors-Abstraction-IProcess-'></a>
### SetProcess(pid) `method`

##### Summary

Sets the process.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| pid | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the process. |

<a name='T-MLambda-Actors-Abstraction-IMessage'></a>
## IMessage `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The message interface.

<a name='P-MLambda-Actors-Abstraction-IMessage-Payload'></a>
### Payload `property`

##### Summary

Gets the payload of the message.

<a name='M-MLambda-Actors-Abstraction-IMessage-Response-System-Object-'></a>
### Response(response) `method`

##### Summary

The response of the message.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| response | [System.Object](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Object 'System.Object') | the response. |

<a name='T-MLambda-Actors-Abstraction-IProcess'></a>
## IProcess `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The process interfaces.

<a name='P-MLambda-Actors-Abstraction-IProcess-Child'></a>
### Child `property`

##### Summary

Gets the child actor.

<a name='P-MLambda-Actors-Abstraction-IProcess-Id'></a>
### Id `property`

##### Summary

Gets the unique id.

<a name='P-MLambda-Actors-Abstraction-IProcess-Link'></a>
### Link `property`

##### Summary

Gets the address.

<a name='P-MLambda-Actors-Abstraction-IProcess-Parent'></a>
### Parent `property`

##### Summary

Gets the parent.

<a name='P-MLambda-Actors-Abstraction-IProcess-Route'></a>
### Route `property`

##### Summary

Gets the path.

<a name='P-MLambda-Actors-Abstraction-IProcess-Status'></a>
### Status `property`

##### Summary

Gets the status.

<a name='M-MLambda-Actors-Abstraction-IProcess-Setup-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IActor-'></a>
### Setup(process,childActor) `method`

##### Summary

Setups the actors.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| process | [MLambda.Actors.Abstraction.IProcess](#T-MLambda-Actors-Abstraction-IProcess 'MLambda.Actors.Abstraction.IProcess') | the parent actor. |
| childActor | [MLambda.Actors.Abstraction.IActor](#T-MLambda-Actors-Abstraction-IActor 'MLambda.Actors.Abstraction.IActor') | the child actor. |

<a name='M-MLambda-Actors-Abstraction-IProcess-Stop'></a>
### Stop() `method`

##### Summary

Stop the process.

##### Parameters

This method has no parameters.

<a name='T-MLambda-Actors-Abstraction-Guardian-IRootActor'></a>
## IRootActor `type`

##### Namespace

MLambda.Actors.Abstraction.Guardian

##### Summary

The root actor interface.

<a name='T-MLambda-Actors-Abstraction-IRootContext'></a>
## IRootContext `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The root context.

<a name='P-MLambda-Actors-Abstraction-IRootContext-Self'></a>
### Self `property`

##### Summary

Gets the root actor.

<a name='M-MLambda-Actors-Abstraction-IRootContext-Spawn``1'></a>
### Spawn\`\`1() `method`

##### Summary

Spawns actors.

##### Returns

The actor address.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | The type of the actor. |

<a name='T-MLambda-Actors-Abstraction-IScheduler'></a>
## IScheduler `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The dispatcher interface.

<a name='P-MLambda-Actors-Abstraction-IScheduler-IsRunning'></a>
### IsRunning `property`

##### Summary

Gets the running flag.

<a name='M-MLambda-Actors-Abstraction-IScheduler-Start'></a>
### Start() `method`

##### Summary

Starts the scheduler.

##### Returns

the result of the start.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Abstraction-IScheduler-Stop'></a>
### Stop() `method`

##### Summary

Stops the scheduler.

##### Returns

The result of the stop.

##### Parameters

This method has no parameters.

<a name='M-MLambda-Actors-Abstraction-IScheduler-Subscribe-System-Func{MLambda-Actors-Abstraction-IMessage,System-Threading-Tasks-Task}-'></a>
### Subscribe(notify) `method`

##### Summary

Subscribes the notification.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| notify | [System.Func{MLambda.Actors.Abstraction.IMessage,System.Threading.Tasks.Task}](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.Func 'System.Func{MLambda.Actors.Abstraction.IMessage,System.Threading.Tasks.Task}') | the method to notify. |

<a name='T-MLambda-Actors-Abstraction-Supervision-ISupervisor'></a>
## ISupervisor `type`

##### Namespace

MLambda.Actors.Abstraction.Supervision

##### Summary

The supervisor interface.

<a name='M-MLambda-Actors-Abstraction-Supervision-ISupervisor-Compute-MLambda-Actors-Abstraction-IProcess,MLambda-Actors-Abstraction-IMessage-'></a>
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

<a name='T-MLambda-Actors-Abstraction-Guardian-IUserActor'></a>
## IUserActor `type`

##### Namespace

MLambda.Actors.Abstraction.Guardian

##### Summary

The user actor interface.

<a name='T-MLambda-Actors-Abstraction-IUserContext'></a>
## IUserContext `type`

##### Namespace

MLambda.Actors.Abstraction

##### Summary

The actor bag interface.

<a name='P-MLambda-Actors-Abstraction-IUserContext-Self'></a>
### Self `property`

##### Summary

Gets the user.

<a name='M-MLambda-Actors-Abstraction-IUserContext-Spawn``1'></a>
### Spawn\`\`1() `method`

##### Summary

Gets the user context.

##### Returns

The actor address.

##### Parameters

This method has no parameters.

##### Generic Types

| Name | Description |
| ---- | ----------- |
| T | the type of the actor. |

<a name='T-MLambda-Actors-Abstraction-Annotation-RouteAttribute'></a>
## RouteAttribute `type`

##### Namespace

MLambda.Actors.Abstraction.Annotation

##### Summary

The address attribute.

<a name='M-MLambda-Actors-Abstraction-Annotation-RouteAttribute-#ctor-System-String-'></a>
### #ctor(name) `constructor`

##### Summary

Initializes a new instance of the [RouteAttribute](#T-MLambda-Actors-Abstraction-Annotation-RouteAttribute 'MLambda.Actors.Abstraction.Annotation.RouteAttribute') class.

##### Parameters

| Name | Type | Description |
| ---- | ---- | ----------- |
| name | [System.String](http://msdn.microsoft.com/query/dev14.query?appId=Dev14IDEF1&l=EN-US&k=k:System.String 'System.String') | The name. |

<a name='P-MLambda-Actors-Abstraction-Annotation-RouteAttribute-Name'></a>
### Name `property`

##### Summary

Gets the name.
