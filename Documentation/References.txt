## Introduction
References are how we expose fields in MonoBehaviour scripts that allow us to assign a variable ScriptableObject. They're wrapped in a separate class because you can also choose not to use a ScriptableObject at all, and instead write a constant value in the inspector.

## Script Reference
To create a Reference field in your MonoBehaviour script, simply declare it like you would any other field

public BoolReference boolValue;

Or use the [SerializeField] attribute if it's not public

[SerializeField]
private BoolReference boolValue;

You don't have to care whether the Reference is using a constant or a variable, simply reference the Value property

T Value { get; set; }