using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public List<GameObject> levelPrefabs;

    private LevelStateController currentLevel;
    private int currentLevelIndex = 0;

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
    }

    public void ProgressLevel()
    {
        currentLevel.gameObject.SetActive(false);
        Destroy(Camera.current.gameObject);
        ++currentLevelIndex;
        LoadNextLevel();
    }
}
