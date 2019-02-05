using UnityEngine;
using System.Collections;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(MoveBackgroundParallax))]
public class MoveBackgroundParallaxInspector : InspectorBase
{
    private string explanation = "Use this script to define the Paralax Moving base.";
    public override void OnInspectorGUI()
    {
        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        base.OnInspectorGUI();
    }

}
