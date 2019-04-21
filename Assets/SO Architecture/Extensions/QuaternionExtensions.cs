using UnityEngine;

namespace ScriptableObjectArchitecture
{
    /// <summary>
    /// Internal extension methods for <see cref="Quaternion"/>.
    /// </summary>
    internal static class QuaternionExtensions
    {
        /// <summary>
        /// Returns a <see cref="Vector4"/> instance where the component values are equal to this
        /// <see cref="Quaternion"/>'s components.
        /// </summary>
        /// <param name="quaternion"></param>
        /// <returns></returns>
        public static Vector4 ToVector4(this Quaternion quaternion)
        {
            return new Vector4(quaternion.x, quaternion.y, quaternion.z, quaternion.w);
        }
    }
}