using UnityEditor;
using UnityEngine;

public class Tools
{
    [MenuItem("Tools/ClearData")]

    public static void ClearData() =>
        PlayerPrefs.DeleteAll();
}
