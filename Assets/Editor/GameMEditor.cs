using System;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(GameManager))]
public class GameMEditor : Editor
{
    public Int32 scoreInput;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Modify score");
        scoreInput = EditorGUILayout.IntField(scoreInput);
        if (!Application.isPlaying) GUI.enabled = false;
        if (GUILayout.Button("Apply score"))
        {
            GameManager.Instance.ChangeScoreD(scoreInput);
        }
        GUI.enabled = true;
        EditorGUILayout.EndHorizontal();
    }
}
