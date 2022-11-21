using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Test_", menuName = "Scriptable Objects/Test")]
public class TestSO : ScriptableObject
{
    public string objectName;
    public float objectSize;
    public Color objectColor = new Color(1f, 1f, 1f, 1f);
}
