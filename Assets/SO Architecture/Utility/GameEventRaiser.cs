using UnityEngine;
using ScriptableObjectArchitecture;

public class GameEventRaiser : MonoBehaviour
{
    public GameEvent Event;

    public void Raise()
    {
        Event.Raise();
    }
}
