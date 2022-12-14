using UnityEditor;
using UnityEngine;

public class BasicObjectSpawner : EditorWindow
{
    string objectBaseName = "";
    int objectID = 1;
    GameObject objectToSpawn;
    Transform objectContainer;
    float objectScale;
    bool appendID;
    float spawnRadius = 5f;

    float minScaleVal = 1f;
    float maxScaleVal = 5f;
    float minScaleLimit = .5f;
    float maxScaleLimit = 5f;

    [MenuItem("Tools/Basic Object Spawner")]
    public static void ShowWindow()
    {
        GetWindow(typeof(BasicObjectSpawner));      //GetWindow is a method inherited from the EditorWindow class
    }

    private void OnGUI()
    {
        GUILayout.Label("Spawn New Object", EditorStyles.boldLabel);
        
        objectToSpawn = EditorGUILayout.ObjectField("Prefab to Spawn", objectToSpawn, typeof(GameObject), false) as GameObject;
        objectContainer = EditorGUILayout.ObjectField("Object Container", objectContainer, typeof(Transform), true) as Transform;
        EditorGUILayout.HelpBox("Object container not required.", MessageType.None, false);

        EditorGUILayout.Space();
        
        objectBaseName = EditorGUILayout.TextField("Base Name", objectBaseName);
        appendID = EditorGUILayout.BeginToggleGroup("Append Numerical ID", appendID);
        EditorGUI.indentLevel++;
        objectID = EditorGUILayout.IntField("Object ID", objectID);
        EditorGUI.indentLevel--;
        EditorGUILayout.EndToggleGroup();

        EditorGUILayout.Space();

        spawnRadius = EditorGUILayout.FloatField("Spawn Radius", spawnRadius);

        EditorGUILayout.Space();

        GUILayout.Label("Object Scale");
        
        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.PrefixLabel("Min Limit: " + minScaleLimit);
        EditorGUILayout.MinMaxSlider(ref minScaleVal, ref maxScaleVal, minScaleLimit, maxScaleLimit);
        EditorGUILayout.PrefixLabel("Max Limit: " + maxScaleLimit);
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.BeginHorizontal();
        EditorGUILayout.LabelField("Min Value: " + minScaleVal.ToString());
        EditorGUILayout.LabelField("Max Value: " + maxScaleVal.ToString());
        EditorGUILayout.EndHorizontal();

        EditorGUI.BeginDisabledGroup(objectToSpawn == null || objectBaseName == string.Empty || objectContainer != null && EditorUtility.IsPersistent(objectContainer));

        if (GUILayout.Button("Spawn Object"))
        {
            SpawnObject();
        }

        EditorGUI.EndDisabledGroup();

        EditorGUILayout.Space();

        if (objectToSpawn == null)
        {
            EditorGUILayout.HelpBox("Place a GameObject in the 'Prefab To Spawn' field", MessageType.Warning);
        }

        if (objectBaseName == string.Empty)
        {
            EditorGUILayout.HelpBox("Assign a base name to the object to be spawned", MessageType.Warning);
        }

        if (objectContainer != null && EditorUtility.IsPersistent(objectContainer))
        {
            EditorGUILayout.HelpBox("Object Container must be a scene object", MessageType.Warning);
        }

    }

    private void SpawnObject()
    {

        Vector2 spawnCircle = Random.insideUnitCircle * spawnRadius;
        Vector3 spawnPos = new Vector3(spawnCircle.x, spawnCircle.y, 0f);
        objectScale = Random.Range(minScaleVal, maxScaleVal);

        string objName = objectBaseName;
        if (appendID)
        {
            objName += objectID.ToString();
            objectID++;
        }

        GameObject newObject = Instantiate(objectToSpawn, spawnPos, Quaternion.identity, objectContainer);
        newObject.name = objName;
        newObject.transform.localScale = Vector2.one * objectScale;
    }
}
