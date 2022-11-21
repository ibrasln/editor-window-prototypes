using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class ListTool : EditorWindow
{
    public string[] names = {"jack", "john"};

    [MenuItem("Tools/List Tool")]
    public static void ShowWindow()
    {
        ListTool window = GetWindow<ListTool>(true, "LIST");
        window.minSize = new Vector2(100, 150);
    }

    private void OnGUI()
    {
        ScriptableObject target = this;
        SerializedObject so = new SerializedObject(target);
        SerializedProperty stringsProperty = so.FindProperty("names");

        EditorGUILayout.PropertyField(stringsProperty, true); // True means show children
        so.ApplyModifiedProperties();
    }
}
