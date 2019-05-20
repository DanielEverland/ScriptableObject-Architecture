using UnityEngine;

namespace ScriptableObjectArchitecture.Examples
{
    public class DamageDealer : MonoBehaviour
    {
        [SerializeField]
        private FloatReference _damageAmount = default(FloatReference);

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
}