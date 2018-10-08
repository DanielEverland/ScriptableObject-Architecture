using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealer : MonoBehaviour
{
    [SerializeField]
    private FloatReference _damageAmount;

    private void OnTriggerEnter(Collider other)
    {
        UnitHealth targetHealth = other.gameObject.GetComponent<UnitHealth>();

        if (targetHealth != null)
            DealDamage(targetHealth);        
    }
    protected virtual void DealDamage(UnitHealth target)
    {
        target.Health.Value -= _damageAmount.Value;
    }
}