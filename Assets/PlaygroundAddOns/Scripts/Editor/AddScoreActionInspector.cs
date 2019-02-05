using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(AddScoreAction))]
public class AddScoreActionInspector : InspectorBase
{
    private string explanation = "Use this script to add a point if the condition is true";
    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();

        CheckIfTrigger(true);

    }

}
