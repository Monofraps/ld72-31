using UnityEditor;
using UnityEngine;
using System.Collections;

class LevelImporterWindow : EditorWindow
{
    public string levelText;
    public GameObject wallPrefab;
    public GameObject coloredWallPrefab;
    public GameObject colorizerPrefab;
	public GameObject powerupPrefab;
    public GameObject levelRoot;

    [MenuItem("LD31/Import Level")]
    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(LevelImporterWindow));
    }

    private LevelGenerator levelgen;

    void OnGUI()
    {
        levelText = EditorGUILayout.TextArea(levelText, GUILayout.Height(200));

        if (GUILayout.Button("Import"))
        {
         levelgen = new LevelGenerator(levelText, wallPrefab, coloredWallPrefab, colorizerPrefab, powerupPrefab, levelRoot);  
            levelgen.readLevel();
        }

        if (GUILayout.Button("Set Wall Prefab"))
        {
            wallPrefab = (GameObject) PrefabUtility.GetPrefabParent(Selection.activeObject);
        }

        if (GUILayout.Button("Set Colored Wall Prefab"))
        {
            coloredWallPrefab = (GameObject)PrefabUtility.GetPrefabParent(Selection.activeObject);
        }


        if (GUILayout.Button("Set Colorizer Prefab"))
        {
            colorizerPrefab = (GameObject)PrefabUtility.GetPrefabParent(Selection.activeObject);
        }

		if (GUILayout.Button("Set Powerup Field Prefab"))
		{
			powerupPrefab = (GameObject)PrefabUtility.GetPrefabParent(Selection.activeObject);
		}


        if (GUILayout.Button("Set Level Root"))
        {
            levelRoot = Selection.activeGameObject;
        }
    }
}
