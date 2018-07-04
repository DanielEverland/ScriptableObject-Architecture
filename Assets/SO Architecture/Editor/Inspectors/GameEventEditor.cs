using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(GameEvent))]
public class GameEventEditor : Editor
{
    private GameEvent Target { get { return target as GameEvent; } }

    private const float PADDING = 30;
    private const float HEADER_HEIGHT = 18;
    private const float BACKGROUND_HEIGHT = 250;
    private const float LINE_HEIGHT = 20;
    private const string STACK_TRACE_WINDOW_KEY = "StackTraceWindow";

    private const float CLEAR_LEFT_PADDING = 3;
    private const float CLEAR_WIDTH = 45;

    private Rect _rect;
    private Vector2 _scrollPosition;
    private GameEventStackTrace _selectedTrace;

    private void OnEnable()
    {
        Deselect();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        DrawRaiseButton();

        EditorGUILayout.Space();

        DrawStackTrace();
    }
    private void DrawRaiseButton()
    {
        if (GUILayout.Button("Raise"))
        {
            Target.Raise();
        }
    }
    private void DrawStackTrace()
    {
        Rect rect = GUILayoutUtility.GetRect(GUIContent.none, Styles.Box);
        rect.height = BACKGROUND_HEIGHT;
        
        if (Event.current.type == EventType.Repaint)
        {
            //This is necessary due to Unity's retarded handling of events - https://answers.unity.com/questions/515197/how-to-use-guilayoututilitygetrect-properly.html
            _rect = rect;

            Rect boxRect = _rect;

            boxRect.x--;
            boxRect.y--;

            boxRect.width++;
            boxRect.height++;

            Styles.Box.Draw(boxRect, GUIContent.none, 0);
        }            

        GUILayout.BeginArea(_rect);

        DrawStackTraceHeader();
        DrawElements();

        GUILayout.EndArea();
    }
    private void DrawElements()
    {
        Rect elementsRect = new Rect()
        {
            y = HEADER_HEIGHT,
            height = _rect.height - HEADER_HEIGHT,
            width = _rect.width,
        };
        
        Rect scrollViewRect = new Rect()
        {
            y = elementsRect.y,
            height = elementsRect.height,
            width = elementsRect.width,
        };
        Rect position = new Rect()
        {
            height = Target.StackTraces.Count * LINE_HEIGHT,
            width = scrollViewRect.width - 20,
        };

        _scrollPosition = GUI.BeginScrollView(scrollViewRect, _scrollPosition, position);

        for (int i = 0; i < Target.StackTraces.Count; i++)
        {
            GameEventStackTrace currentTrace = Target.StackTraces[i];
            string currentText = GetFirstLine(currentTrace);

            Rect elementRect = new Rect()
            {
                width = elementsRect.width,
                height = LINE_HEIGHT,
                y = i * LINE_HEIGHT,
            };

            if(Event.current.type == EventType.MouseDown && elementRect.Contains(Event.current.mousePosition))
            {
                _selectedTrace = currentTrace;

                Repaint();
            }
            else if (Event.current.type == EventType.Repaint)
            {
                bool isSelected = _selectedTrace == currentTrace;
                GUIStyle backgroundStyle = i % 2 == 0 ? Styles.EvenBackground : Styles.OddBackground;
                
                backgroundStyle.Draw(elementRect, false, false, isSelected, false);
                Styles.Text.Draw(elementRect, new GUIContent(currentText), 0);
            }
        }
        
        GUI.EndScrollView();
    }
    private void DrawStackTraceHeader()
    {
        Rect rect = new Rect()
        {
            width = _rect.width,
            height = HEADER_HEIGHT,
        };

        if(Event.current.type == EventType.Repaint)
        {
            Styles.Header.Draw(rect, new GUIContent("Stack Trace"), 0);
        }

        rect.x += CLEAR_LEFT_PADDING;
        rect.width = CLEAR_WIDTH;

        if (GUI.Button(rect, new GUIContent("Clear"), Styles.HeaderButton))
        {
            Target.StackTraces.Clear();
            Deselect();
        }
    }
    private void Deselect()
    {
        _selectedTrace = null;
    }
    private string GetFirstLine(string value)
    {
        return value.Split(new[] { '\r', '\n' }).FirstOrDefault();
    }

    private static class Styles
    {
        static Styles()
        {
            Box = new GUIStyle("CN Box");            
            EvenBackground = new GUIStyle("CN EntryBackEven");
            OddBackground = new GUIStyle("CN EntryBackodd");
            HeaderButton = new GUIStyle("ToolbarButton");

            Header = new GUIStyle("Toolbar");
            Header.alignment = TextAnchor.MiddleCenter;

            Text = new GUIStyle("CN EntryInfo");
            Text.padding = new RectOffset(0, 0, 3, 0);
        }

        public static GUIStyle HeaderButton;
        public static GUIStyle Text;
        public static GUIStyle Box;
        public static GUIStyle Header;
        public static GUIStyle EvenBackground;
        public static GUIStyle OddBackground;
    }
}
