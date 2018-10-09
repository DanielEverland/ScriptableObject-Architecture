using UnityEngine;

/// <summary>
/// Base class for SOArchitecture assets
/// Implements developer descriptions
/// </summary>
public abstract class SOArchitectureBaseMonobehaviour : MonoBehaviour
{
#if UNITY_EDITOR
    [SerializeField]
    private DeveloperDescription DeveloperDescription = new DeveloperDescription();
#endif
}