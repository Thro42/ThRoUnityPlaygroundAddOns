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

        base.OnInspectorGUI();
    }

}
