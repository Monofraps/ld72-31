using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public List<LevelStateController> levelRoots;
    private int currentLevel = 0;

    private void Start()
    {
        Instance = this;

        foreach (var levelRoot in levelRoots)
        {
            levelRoot.gameObject.SetActive(false);
        }

        levelRoots[currentLevel].gameObject.SetActive(true);
    }

    public void PublishPlayerColorChangeEvent(ColorizationColors newPlayerColor)
    {
        levelRoots[currentLevel].PublishPlayerColorChangeEvent(newPlayerColor);
    }

    public void ProgressLevel()
    {
        levelRoots[currentLevel].gameObject.SetActive(false);
        levelRoots[++currentLevel].gameObject.SetActive(true);
    }
}
