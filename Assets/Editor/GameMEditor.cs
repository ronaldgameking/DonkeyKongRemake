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

        if (Application.isPlaying && GameManager.Instance == null)
        {
            GUILayout.Space(5f);
            GUILayout.Label("Reference to GameManager instance lost!");
            GUILayout.Space(5f);
        }
        else if (!Application.isPlaying)
        {
            GUILayout.Space(5f);
            GUILayout.Label("Enter play mode to edit score");
            GUILayout.Space(5f);
        }
        EditorGUILayout.BeginHorizontal();
        GUILayout.Label("Modify score");
        if (!Application.isPlaying || GameManager.Instance == null) GUI.enabled = false;
        scoreInput = EditorGUILayout.IntField(scoreInput);
        //if (!Application.isPlaying) GUI.enabled = false;
        if (GUILayout.Button("Apply score"))
        {
            GameManager.Instance.ChangeScoreD(scoreInput);
        }
        GUI.enabled = true;
        EditorGUILayout.EndHorizontal();    
    }
}
