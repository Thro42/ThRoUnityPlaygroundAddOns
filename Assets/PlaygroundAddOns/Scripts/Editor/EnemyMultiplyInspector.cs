using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(EnemyMultiply))]
public class EnemyMultiplyInspector : InspectorBase
{
    private string explanation = "Use this to generate multible enemy's in Game";
    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemy"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("anzEnemys"));
        GUILayout.Space(10);
        float rangeMinX = serializedObject.FindProperty("rangeMinX").floatValue;
        float rangeMaxX = serializedObject.FindProperty("rangeMaxX").floatValue;
        float minLimit = serializedObject.FindProperty("minLimit").floatValue;
        float maxLimit = serializedObject.FindProperty("maxLimit").floatValue;
        EditorGUILayout.LabelField("Min X Val:", rangeMinX.ToString()); 
        EditorGUILayout.LabelField("Max X Val:", rangeMaxX.ToString());
        EditorGUILayout.MinMaxSlider(ref rangeMinX, ref rangeMaxX, minLimit, maxLimit);

        if (GUI.changed)
        {
            serializedObject.FindProperty("rangeMinX").floatValue = rangeMinX;
            serializedObject.FindProperty("rangeMaxX").floatValue = rangeMaxX;
            serializedObject.ApplyModifiedProperties();
        }
    }
}
