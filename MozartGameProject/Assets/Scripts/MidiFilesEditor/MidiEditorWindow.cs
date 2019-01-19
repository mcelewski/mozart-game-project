using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MidiEditorWindow : EditorWindow
{
    [MenuItem("Window/Midi files editor")]
    private void OnGUI()
    {
        EditorGUILayout.HelpBox("ajtam",MessageType.None);
    }
}
