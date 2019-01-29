using UnityEditor;
using UnityEngine;

public class MidiEditorWindow : EditorWindow
{
    [MenuItem("Window/Midi files editor")]
    
    public static void  ShowWindow () 
    {
        GetWindow(typeof(MidiEditorWindow));
    }
    private void OnGUI()
    {
        GUILayout.Label("Base Settings", EditorStyles.boldLabel);
        GUILayout.Button("Click me");
    }
}
