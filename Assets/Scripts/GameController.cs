using System;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController Instance { get; private set; }

    public int Coins { get; set; }

    public GameObject player;
    public List<GameObject> levelPrefabs;
    public Text timerText;
    public Text coinCounterText;

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
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.R))
        {
            RestartLevel();
        }

        timer += Time.deltaTime;

        int minutes = Mathf.FloorToInt((float) (timer/60f));
        timerText.text = String.Format("{0}:{1:00.0}", minutes, (timer - minutes * 60f));

        coinCounterText.text = String.Format("{0}", Coins);
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
				currentLevel.gameObject.SetActive (false);
				Destroy (currentLevel.gameObject);
				LoadLevel ();
				player.GetComponent<PlayerColorController> ().PlayerColor = ColorizationColors.White;
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
