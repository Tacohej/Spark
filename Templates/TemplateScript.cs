
using System.IO;
using System.Reflection;
using UnityEditor;
using UnityEngine;

static class TemplateScript
{
    private static MethodInfo createScriptMethod = typeof(ProjectWindowUtil)
        .GetMethod("CreateScriptAsset", BindingFlags.Static | BindingFlags.NonPublic);

    static void CreateScriptAsset(string templatePath, string destName)
    {
        createScriptMethod.Invoke(null, new object[] { templatePath, destName });
    }

    private static string GetCurrentPath ()
    {
        string path = AssetDatabase.GetAssetPath(Selection.activeObject);

        if (path == "")
        {
            path = "Assets";
        }
        else if (Path.GetExtension(path) != "")
        {
            path = path.Replace(Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
        }

        return path;
    }

    [MenuItem("Assets/Create/Spark/Create StatType Script")]
    public static void CreateStatTypeScript()
    {
        CreateScriptAsset("Assets/Spark/Templates/StatType.cs.txt", GetCurrentPath() + "/StatType.cs");
    }

    [MenuItem("Assets/Create/Spark/Create Trigger Script")]
    public static void CreateTriggerScript()
    {
        CreateScriptAsset("Assets/Spark/Templates/Trigger.cs.txt", GetCurrentPath() + "/Trigger.cs");
    }
}
