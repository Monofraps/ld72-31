using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour
{
    public static EnemyTracker Instance { get; private set; }

    public List<GameObject> enemyTypes; 

    private List<EnemyBase> enemies;
        
    void Start()
    {
        Instance = this;
    }
 
    public List<EnemyBase> GetAllEnemies()
    {
        return enemies;
    }

    public void SpawnEnemy(Vector3 spawnPoint, Quaternion initialRotation)
    {
        GameObject enemyType = enemyTypes[Random.RandomRange(0, enemyTypes.Count)];

        GameObject enemyInstance = (GameObject)Instantiate(enemyType, spawnPoint, initialRotation);
        EnemyBase enemy = enemyInstance.GetComponent<EnemyBase>();

        if (enemy == null)
        {
            throw new UnityException("Found enemy type with missing EnemyBase");
        }

        enemies.Add(enemy);
    }
}
