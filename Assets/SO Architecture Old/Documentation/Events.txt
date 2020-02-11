## Introduction

Events also exist as ScriptableObjects in your project. They can contain any single parameter when raising or none. Events are also fully debuggable through the editor using the stacktrace window and the raise button functionality, which also supports the ability to raise events with parameters. If a parameter is specified, a field will be present which allows you to select which value will be passed.

## Script Reference
Note that you must provide an Event Listener in order to subscribe to events

The base class differs depending on whether an argument is expected or not

void Raise(T)
void RegisterListener(IGameEventListener<T>)
void UnregisterListener(IGameEventListener<T>)

void Raise()
void RegisterListener(IGameEventListener)
void UnregisterListener(IGameEventListener)