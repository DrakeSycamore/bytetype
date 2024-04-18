using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(AreaDetails))]
[CanEditMultipleObjects] // Add this attribute
public class AreaDetailsEditor : Editor
{
    private SerializedProperty areas;

    private void OnEnable()
    {
        areas = serializedObject.FindProperty("areas");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(areas, true);

        serializedObject.ApplyModifiedProperties();
    }
}




[CustomEditor(typeof(Characters))]
[CanEditMultipleObjects]
public class CharactersEditor : Editor
{
    private SerializedProperty characters;

    private void OnEnable()
    {
        characters = serializedObject.FindProperty("characters");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(characters, true);

        serializedObject.ApplyModifiedProperties();
    }
}


[CustomEditor(typeof(PlayerInfo))]
[CanEditMultipleObjects]
public class PlayerInfoEditor : Editor
{
    private SerializedProperty playerInfo;

    private void OnEnable()
    {
        playerInfo = serializedObject.FindProperty("playerInfo");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(playerInfo, true);

        serializedObject.ApplyModifiedProperties();
    }
}


[CustomEditor(typeof(BGMBanks))]
[CanEditMultipleObjects]
public class BGMBanks : Editor
{
    private SerializedProperty bgmBanks;

    private void OnEnable()
    {
        bgmBanks = serializedObject.FindProperty("BGMBanks");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.PropertyField(bgmBanks, true);

        serializedObject.ApplyModifiedProperties();
    }
}

//288148
