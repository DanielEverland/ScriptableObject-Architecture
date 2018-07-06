using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class GameEventListener : MonoBehaviour
{
    [Tooltip("Event to register with."), SerializeField]
    private GameEvent _event;

#if UNITY_EDITOR
    [Tooltip("Debug color to use when debugging events"), SerializeField]
    private Color _debugColor = Color.cyan;

    
#endif

    [Space()]
    
    [Tooltip("Response to invoke when Event is raised."), SerializeField]
    private UnityEvent _response;

    private void OnEnable()
    {
        if(_event != null)
            _event.RegisterListener(this);
    }
    private void OnDisable()
    {
        if (_event != null)
            _event.UnregisterListener(this);
    }
    public void OnEventRaised()
    {
        _response.Invoke();

#if UNITY_EDITOR
        for (int i = 0; i < _response.GetPersistentEventCount(); i++)
        {
            GameObject gameObjectTarget = GetGameObject(_response.GetPersistentTarget(i));
            string functionName = string.Format("{0} ({1})", gameObjectTarget.name, _response.GetPersistentMethodName(i));

            _debugEntries.Add(new DebugEvent(gameObjectTarget, functionName));
        }
#endif
    }

#if UNITY_EDITOR
    private const float DOTTED_LINE_LENGTH = 5;
    private const float DOT_LENGTH = 0.5f;
    private const float DOT_WIDTH = 3;
    private const float EVENT_MOVEMENT_SPEED = 3;

    private List<DebugEvent> _debugEntries = new List<DebugEvent>();

    private static class Styles
    {
        static Styles()
        {
            TextStyle = new GUIStyle();
            TextStyle.alignment = TextAnchor.UpperCenter;
        }

        public static GUIStyle TextStyle;
    }

    private void OnDrawGizmos()
    {
        if(Application.isPlaying)
            UpdateDebugInfo();
    }
    private void UpdateDebugInfo()
    {
        Handles.color = _debugColor;
        Styles.TextStyle.normal.textColor = _debugColor;

        DrawLine();
        DrawEvents();
    }
    private void DrawEvents()
    {
        for (int i = _debugEntries.Count - 1; i >= 0; i--)
        {
            DrawEvent(i);
        }
    }
    private void DrawEvent(int index)
    {
        DebugEvent debugEvent = _debugEntries[index];
        
        debugEvent.Offset += EVENT_MOVEMENT_SPEED * Time.deltaTime;

        Vector3 delta = (debugEvent.Target.transform.position - gameObject.transform.position).normalized;
        Vector3 position = gameObject.transform.position + (delta * debugEvent.Offset);

        DrawPoint(position, delta);
        DrawText(position, debugEvent);
        
        if (debugEvent.Offset >= Vector3.Distance(gameObject.transform.position, debugEvent.Target.transform.position))
        {
            _debugEntries.RemoveAt(index);
        }
    }
    private void DrawText(Vector3 position, DebugEvent debugEvent)
    {
        string text = string.Join("\n", new string[] { _event.name, debugEvent.FunctionName });
        
        Handles.Label(position, text, Styles.TextStyle);
    }
    private void DrawLine()
    {
        List<GameObject> listeningObjects = new List<GameObject>();

        for (int i = 0; i < _response.GetPersistentEventCount(); i++)
        {
            AddObject(listeningObjects, _response.GetPersistentTarget(i));
        }

        foreach (GameObject obj in listeningObjects)
        {
            if (gameObject == obj)
                continue;
            
            Handles.DrawDottedLine(transform.position, obj.transform.position, DOTTED_LINE_LENGTH);
        }
    }
    private void DrawPoint(Vector3 position, Vector3 direction)
    {        
        Handles.DrawAAPolyLine(DOT_WIDTH, position, position + (direction.normalized * DOT_LENGTH));
    }
    private void AddObject(List<GameObject> listeningObjects, Object obj)
    {
        GameObject toAdd = GetGameObject(obj);

        if (!listeningObjects.Contains(toAdd))
        {
            listeningObjects.Add(toAdd);
        }
    }
    private GameObject GetGameObject(Object obj)
    {
        if (obj is Component)
        {
            Component component = obj as Component;

            return component.gameObject;
        }
        else if (obj is GameObject)
        {
            return obj as GameObject;
        }
        else
        {
            return null;
        }
    }
    private class DebugEvent
    {
        public DebugEvent(GameObject target, string methodName)
        {
            FunctionName = methodName;
            Target = target;
            Offset = 0;
        }

        public float Offset;
        public GameObject Target;
        public string FunctionName;
    }
#endif
}
