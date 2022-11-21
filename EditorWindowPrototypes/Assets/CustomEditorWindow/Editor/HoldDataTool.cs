using UnityEditor;
using UnityEngine;

public class HoldDataTool : EditorWindow
{
    private Rigidbody2D rb;

    [MenuItem("Tools/Hold Data")]
    public static void ShowWindow()
    {
        HoldDataTool holdDataTool = GetWindow<HoldDataTool>();
        holdDataTool.minSize = new Vector2(400f, 250f);
    }

    private void OnGUI()
    {
        rb = EditorGUILayout.ObjectField("RigidBody 2D", rb, typeof(Rigidbody2D), true) as Rigidbody2D;

        EditorGUILayout.Space();


        if (rb != null)
        {
            EditorGUILayout.LabelField("OBJECT SPEED", EditorStyles.boldLabel);

            EditorGUILayout.Space();
            
            EditorGUILayout.LabelField("X speed of the Object", rb.velocity.x.ToString());
            EditorGUILayout.LabelField("Y speed of the Object", rb.velocity.y.ToString());
            this.Repaint();
        }

    }
}
