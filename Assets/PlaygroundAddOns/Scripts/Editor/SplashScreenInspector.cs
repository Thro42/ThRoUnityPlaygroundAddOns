using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(SplashScreen))]
public class SplashScreenInspector : InspectorBase
{
    private string explanation = "Use this script show a Splash Screen at beginning of the game";
    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("_splashScreen"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("keyToStart"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("useAutoStart"));
        if (serializedObject.FindProperty("useAutoStart").boolValue)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("autoStartTime"));
        }
        // base.OnInspectorGUI();
        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

}
