using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    private int coins = 0;

    public int Coins
    {
        get { return coins; }
        set
        {
            coins = value;
            coinCounterText.SetCoinCount(coins);
        }
    }

    public GameObject player;
    public List<GameObject> levelPrefabs;
    public TimerText timerText;
    public CoinCounterText coinCounterText;
    public PointsText pointsText;

    private LevelStateController currentLevel;
    private int currentLevelIndex = 0;

    private double timer = 0;

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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.R) && !IsLastLevel())
        {
            RestartLevel();
        }

        timer += Time.deltaTime;

        timerText.SetTimeInSeconds((float)timer);
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
        currentLevel.gameObject.SetActive(true);
        EnemyTracker.Instance.LoadEnemies(currentLevel.gameObject);
        player.GetComponentInChildren<PlayerColorController>().PlayerColor = ColorizationColors.White;


        // Find and set spawnpoint
        foreach (Transform t in currentLevel.transform)
        {
            if (t.tag == "SpawnPoint")
            {
                player.transform.position = t.position;
            }

        }

        if (IsLastLevel())
        {
            LoadLastLevel();
        }
    }

    private void LoadLastLevel()
    {
        player.SetActive(false);
        timerText.IsVisible = false;
        coinCounterText.IsVisible = false;

        pointsText.IsVisible = true;
        pointsText.SetPoints(123456);
    }

    private bool IsLastLevel()
    {
        return currentLevelIndex == levelPrefabs.Count - 1;
    }

    public void RestartLevel()
    {
				currentLevel.gameObject.SetActive (false);
				Destroy (currentLevel.gameObject);
				LoadLevel ();
				player.GetComponentInChildren<PlayerColorController> ().PlayerColor = ColorizationColors.White;
				player.GetComponent<PowerupController> ().CurrentItem = null;
		}

    public void ProgressLevel()
    {
        currentLevel.gameObject.SetActive(false);
        Destroy(currentLevel.gameObject);
        ++currentLevelIndex;
        LoadLevel();
    }
}
