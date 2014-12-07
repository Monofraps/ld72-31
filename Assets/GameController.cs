using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public GameObject player;
    public List<GameObject> levelPrefabs;

    private LevelStateController currentLevel;
    private int currentLevelIndex = 0;

    private void Awake()
    {
        (GameObject.Find("__LevelRoots")).SetActive(false);
    }

    private void Start()
    {
        Instance = this;
        LoadNextLevel();
    }

    public void PublishPlayerColorChangeEvent(ColorizationColors newPlayerColor)
    {
        currentLevel.PublishPlayerColorChangeEvent(newPlayerColor);
    }

    private void LoadNextLevel()
    {
        currentLevel = ((GameObject)Instantiate(levelPrefabs[currentLevelIndex])).GetComponent<LevelStateController>();
        EnemyTracker.Instance.LoadEnemies(currentLevel.gameObject);
        // Find and set spawnpoint
        foreach (Transform t in currentLevel.transform)
        {
            if(t.tag == "SpawnPoint")
            {
                player.transform.position = t.position;
            }

        }
    }

    public void RestartLevel()
    {
        currentLevel.gameObject.SetActive(false);
        Destroy(currentLevel.gameObject);
        LoadNextLevel();
    }

    public void ProgressLevel()
    {
        currentLevel.gameObject.SetActive(false);
//      Destroy(Camera.current.gameObject);
        Destroy(currentLevel.gameObject);
        ++currentLevelIndex;
        LoadNextLevel();
    }
}
