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
        LoadLevel();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }
    }

    public void PublishPlayerColorChangeEvent(ColorizationColors newPlayerColor)
    {
        currentLevel.PublishPlayerColorChangeEvent(newPlayerColor);
    }

    private void LoadLevel()
    {
        if (currentLevelIndex >= levelPrefabs.Count)
        {
            return;
        }

        currentLevel = ((GameObject)Instantiate(levelPrefabs[currentLevelIndex])).GetComponent<LevelStateController>();
        EnemyTracker.Instance.LoadEnemies(currentLevel.gameObject);

        // Find and set spawnpoint
        foreach (Transform t in currentLevel.transform)
        {
            if (t.tag == "SpawnPoint")
            {
                player.transform.position = t.position;
            }

        }

        if (currentLevelIndex == levelPrefabs.Count - 1)
        {
            player.SetActive(false);
        }
    }

    public void RestartLevel()
    {
        currentLevel.gameObject.SetActive(false);
        Destroy(currentLevel.gameObject);
        LoadLevel();
        player.GetComponent<PlayerColorController>().PlayerColor = ColorizationColors.White;
    }

    public void ProgressLevel()
    {
        currentLevel.gameObject.SetActive(false);
        Destroy(currentLevel.gameObject);
        ++currentLevelIndex;
        LoadLevel();
    }
}
