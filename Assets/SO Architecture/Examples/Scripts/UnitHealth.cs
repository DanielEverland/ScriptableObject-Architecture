using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitHealth : MonoBehaviour
{
    public FloatReference Health;

    [SerializeField]
    private bool _resetOnStartup = true;
    [SerializeField]
    private FloatReference _startingHealth = default(FloatReference);

    private void Start()
    {
        if (_resetOnStartup)
            Health.Value = _startingHealth.Value;
    }
}