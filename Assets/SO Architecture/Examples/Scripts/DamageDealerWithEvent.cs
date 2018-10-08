using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerWithEvent : DamageDealer
{
    [SerializeField]
    private GameEvent _onDamagedEvent;

    protected override void DealDamage(UnitHealth target)
    {
        base.DealDamage(target);

        _onDamagedEvent.Raise();
    }
}