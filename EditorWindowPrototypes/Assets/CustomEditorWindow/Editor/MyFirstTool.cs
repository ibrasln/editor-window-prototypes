using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class MyFirstTool : EditorWindow
{

    private string objectName;
    private float objectSize;
    private Color objectColor = new(1f, 1f, 1f, 1f);
    private GameObject objectToSpawn;
    private TestSO scriptableObjectOfObject;

    [MenuItem("Tools/My First Tool")]
    public static void ShowWindow()
    {
        GetWindow<MyFirstTool>();
    }

    public void OnGUI()
    {
        GUILayout.Label("FIRST TOOL", EditorStyles.boldLabel);
        GUILayout.Space(5);
        
        scriptableObjectOfObject = EditorGUILayout.ObjectField("Object SO", scriptableObjectOfObject, typeof(TestSO), false) as TestSO;

        if (scriptableObjectOfObject != null )
        {
            objectName = EditorGUILayout.TextField("Object Name", scriptableObjectOfObject.objectName);
            objectSize = EditorGUILayout.Slider("Object Scale", scriptableObjectOfObject.objectSize, 10f, 15f);
            objectColor = EditorGUILayout.ColorField("Object Color", scriptableObjectOfObject.objectColor);
            objectToSpawn = EditorGUILayout.ObjectField("Object Prefab", objectToSpawn, typeof(GameObject), false) as GameObject;

            if (GUILayout.Button("Spawn Object"))
            {
                SpawnObject();
            }
        }
    }

    private void SpawnObject()
    {
        if (objectToSpawn == null)
        {
            Debug.LogError("Please assign an object to be spawned");
            return;
        }
        else if (objectName == string.Empty)
        {
            Debug.LogError("Please assign a name for the object");
            return;
        }

        Vector2 spawnCircle = Random.insideUnitCircle * Random.Range(1f, 4f);
        Vector3 spawnPos = new Vector3(spawnCircle.x, spawnCircle.y, 0f);

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity);
        newObject.name = objectName;
        newObject.transform.localScale = new Vector3(objectSize, objectSize, 1f);
        newObject.GetComponent<SpriteRenderer>().color = objectColor;
    }
}
