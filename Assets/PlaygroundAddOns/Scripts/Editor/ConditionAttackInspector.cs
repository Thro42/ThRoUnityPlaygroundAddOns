using System.Collections;
using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(ConditionAttack))]
public class ConditionAttackInspector : ConditionInspectorBase
{
    private string explanation = "Perform actions when a Player Attack a GameObjekt.";

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        chosenTag = serializedObject.FindProperty("filterTag").stringValue;

        GUILayout.Space(10);
        EditorGUILayout.HelpBox(explanation, MessageType.Info);

        // Show a tag selector to then use for the public property filterTag
        GUILayout.Space(10);
        DrawTagsGroup();

        EditorGUILayout.PropertyField(serializedObject.FindProperty("player"));
        EditorGUILayout.PropertyField(serializedObject.FindProperty("enemy"));

        EditorGUILayout.PropertyField(serializedObject.FindProperty("keyToPress"));
        //discern the event type, and show the frequency if needed
        EditorGUILayout.PropertyField(serializedObject.FindProperty("eventType"));
        int eventType = serializedObject.FindProperty("eventType").intValue;
        if (eventType == 2)
        {
            EditorGUILayout.PropertyField(serializedObject.FindProperty("frequency"));
        }
        GUILayout.Space(10);

        DrawActionLists();

        CheckIfTrigger(true);


        if (GUI.changed)
        {
            serializedObject.FindProperty("filterTag").stringValue = chosenTag;
            serializedObject.ApplyModifiedProperties();
        }

    }

}
