## Introduction
Variable ScriptableObject's share a lot of similarities with C# variables. They can be named and contain values of different types. Since they're embedded into a ScriptableObject, which exists as an asset within Unity, modifying both the name and value is very simple and intuitive.

## Script Reference
Variables have a single property and a couple of functions we can use to modify its value.

Value { get; set; }

SetValue(T)
SetValue(BaseVariable<T>)

Variables also have a single operator

implicit operator T(BaseVariable<T>)

The reason why you can't implicitly or explicitly assign any value, is because Variables are objects themselves, so it must be clear whether you're changing the reference or the value.