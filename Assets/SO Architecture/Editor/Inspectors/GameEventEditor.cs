using System.Linq;
using UnityEngine;
using UnityEditor;
using UnityEditor.AnimatedValues;

[CustomEditor(typeof(GameEventBase), true)]
public class GameEventEditor : Editor
{
    private GameEventBase Target { get { return target as GameEventBase; } }
    
    private const float PADDING = 30;
    private const float HEADER_HEIGHT = 18;
    private const float BACKGROUND_HEIGHT = 400;
    private const float LINE_HEIGHT = 18;
    private const string STACK_TRACE_WINDOW_KEY = "StackTraceWindow";

    private const float CLEAR_LEFT_PADDING = 6;
    private const float CLEAR_WIDTH = 45;

    private const float RESIZE_MARGIN = 0.2f;
    private const float RESIZE_HEIGHT = 5;

    private Rect _stackTraceRect;
    private Rect _listRect;
    private Rect _contentRect;
    private Vector2 _listScrollPosition;
    private Vector2 _contentScrollPosition;
    private GameEventStackTrace _selectedTrace;
    private float _subWindowValue = 0.6f;
    private float _splitHeight;
    private bool _resizeMouseDown;

    private void OnEnable()
    {
        Deselect();
    }
    public override void OnInspectorGUI()
    {
        DrawRaiseButton();

        EditorGUILayout.Space();

        DrawStackTrace();

        Target.DeveloperDescription = SOArchitectureBaseObjectEditor.DrawDescription(Target.DeveloperDescription);
    }
    private void DrawRaiseButton()
    {
        EditorGUI.BeginDisabledGroup(!Application.isPlaying);

        if (GUILayout.Button("Raise"))
        {
            Target.Raise();
        }

        EditorGUI.EndDisabledGroup();
    }
    private void DrawStackTrace()
    {
        Rect rect = GUILayoutUtility.GetRect(GUIContent.none, Styles.Box);
        rect.height = BACKGROUND_HEIGHT;
        
        if (Event.current.type == EventType.Repaint)
        {
            //This is necessary due to Unity's retarded handling of events - https://answers.unity.com/questions/515197/how-to-use-guilayoututilitygetrect-properly.html
            _stackTraceRect = rect;

            Rect boxRect = _stackTraceRect;

            boxRect.x--;
            boxRect.y--;

            boxRect.width++;
            boxRect.height++;

            Styles.Box.Draw(boxRect, GUIContent.none, 0);
        }


        _subWindowValue = Mathf.Clamp(_subWindowValue, RESIZE_MARGIN, 1 - RESIZE_MARGIN);

        _splitHeight = _stackTraceRect.height * _subWindowValue;
        _contentRect = new Rect(-1, _splitHeight, _stackTraceRect.width + 1, _stackTraceRect.height - _splitHeight);
        _listRect = new Rect()
        {
            y = HEADER_HEIGHT,
            height = (_stackTraceRect.height - HEADER_HEIGHT) - _contentRect.height,
            width = _stackTraceRect.width,
        };
        
        GUILayout.BeginArea(_stackTraceRect);

        DrawStackTraceHeader();
        DrawList();
        DrawSelecteContent();

        GUILayout.EndArea();

        //Not sure why the layout hasn't reserved the bottom 100 pixels of the stack trace
        //Oh boy, here I go hacking again
        EditorGUILayout.GetControlRect(false, 100);
    }
    private void DrawSelecteContent()
    {
        Rect cursorRect = new Rect(0, _splitHeight - (RESIZE_HEIGHT / 2), _stackTraceRect.width, RESIZE_HEIGHT);
        Event currentEvent = Event.current;
        
        EditorGUIUtility.AddCursorRect(cursorRect, MouseCursor.ResizeVertical);
        
        if(currentEvent.type == EventType.Repaint)
        {
            Styles.Box.Draw(_contentRect, GUIContent.none, 0);                           
        }
        else if(currentEvent.type == EventType.MouseDown && cursorRect.Contains(currentEvent.mousePosition))
        {
            _resizeMouseDown = true;
        }
        else if(currentEvent.type == EventType.MouseUp && _resizeMouseDown)
        {
            _resizeMouseDown = false;
        }
        else if(_resizeMouseDown)
        {
            _subWindowValue = currentEvent.mousePosition.y / _stackTraceRect.height;

            Repaint();
        }

        if (_selectedTrace != null)
        {
            Rect scrollViewRect = new Rect()
            {
                y = _contentRect.y,
                height = _contentRect.height,
                width = _contentRect.width,
            };

            Vector2 textSize = Styles.MessageStyle.CalcSize(new GUIContent(_selectedTrace));

            Rect position = new Rect(Vector2.zero, textSize);

            _contentScrollPosition = GUI.BeginScrollView(scrollViewRect, _contentScrollPosition, position);

            EditorGUI.SelectableLabel(position, _selectedTrace, Styles.MessageStyle);

            GUI.EndScrollView();
        }
    }
    private void DrawList()
    {
        Rect scrollViewRect = new Rect()
        {
            y = _listRect.y,
            height = _listRect.height,
            width = _listRect.width,
        };
        Rect position = new Rect()
        {
            height = Target.StackTraces.Count * LINE_HEIGHT,
            width = scrollViewRect.width - 20,
        };

        _listScrollPosition = GUI.BeginScrollView(scrollViewRect, _listScrollPosition, position);

        for (int i = 0; i < Target.StackTraces.Count; i++)
        {
            GameEventStackTrace currentTrace = Target.StackTraces[i];
            string currentText = GetFirstLine(currentTrace);

            Rect elementRect = new Rect()
            {
                width = _listRect.width,
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
            width = _stackTraceRect.width,
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
            MessageStyle = new GUIStyle("CN Message");

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
        public static GUIStyle MessageStyle;
    }
}
