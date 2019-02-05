using System.Collections;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ExplowAction))]
public class ExplowActionInspector : ConditionInspectorBase
{
    private string explanation = "Show sprite sequence from a list to simulate explosion";

    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();
        CheckIfTrigger(true);
    }
}
