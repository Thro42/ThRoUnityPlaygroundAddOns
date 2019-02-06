using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(FleeFromTarget))]
public class FleeFromTargetInspector : InspectorBase
{
    private string explanation = "This Script defines, that a 'Enemy' is move away from the 'Player', when he is to close to them.";
    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("target"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("speed"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("movementType"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("fleeDistance"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("lookAtMoving"), new GUIContent("Look at Moving"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("_walkSprite"));

        //base.OnInspectorGUI();
        if (GUI.changed)
        {
            serializedObject.ApplyModifiedProperties();
        }
    }

}
