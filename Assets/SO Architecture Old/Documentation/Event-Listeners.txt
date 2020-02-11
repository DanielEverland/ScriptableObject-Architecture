## Introduction
Event Listeners are components that listen to a specific Event and then provides a response in the form on a UnityEvent. Note that the type of event listener must match the event type, so if a bool event is expected, you must use an EventListener of type bool as well. Typed events listeners also supports forwarding the raise parameter as a dynamic response

Event listeners are also fully debuggable through a variety of features. A fully featured stacktrace window is available. You can also simulate an incoming event through the inspector, and even select a debug value if the listener is typed. When an event is raised, a gizmo is also drawn to visualize responses

## Script Reference
The class has a singular function for responding to an event. It differs depending on if a type is expected or not

void OnEventRaised(T)
void OnEventRaised()