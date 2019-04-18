using UnityEngine;

namespace ScriptableObjectArchitecture.Examples
{
    public class KeyboardMover : MonoBehaviour
    {
        [SerializeField]
        private FloatReference _moveSpeed = default(FloatReference);

        private void Update()
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
                transform.position += Vector3.up * _moveSpeed.Value;

            if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
                transform.position += Vector3.down * _moveSpeed.Value;

            if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
                transform.position += Vector3.right * _moveSpeed.Value;

            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
                transform.position += Vector3.left * _moveSpeed.Value;
        }
    }
}