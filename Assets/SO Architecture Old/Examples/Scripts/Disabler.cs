using UnityEngine;

namespace ScriptableObjectArchitecture.Examples
{
    public class Disabler : MonoBehaviour
    {
        [SerializeField]
        private GameObjectCollection _targetSet = default(GameObjectCollection);

        public void DisableRandom()
        {
            if (_targetSet.Count > 0)
            {
                int index = Random.Range(0, _targetSet.Count);

                GameObject objToDisable = _targetSet[index];
                objToDisable.SetActive(false);
            }
        }
    }
}