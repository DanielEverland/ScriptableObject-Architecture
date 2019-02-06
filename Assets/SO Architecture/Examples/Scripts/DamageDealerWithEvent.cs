using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageDealerWithEvent : DamageDealer
{
    [SerializeField]
    private GameEvent _onDamagedEvent = default(GameEvent);

    protected override void DealDamage(UnitHealth target)
    {
        base.DealDamage(target);

        _onDamagedEvent.Raise();
    }
}