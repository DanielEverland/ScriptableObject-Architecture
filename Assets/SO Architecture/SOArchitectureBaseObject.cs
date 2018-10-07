using UnityEngine;

/// <summary>
/// Base class for SOArchitecture assets
/// Implements developer descriptions
/// </summary>
public abstract class SOArchitectureBaseObject : ScriptableObject
{
#if UNITY_EDITOR
    public string DeveloperDescription = string.Empty;
#endif
}