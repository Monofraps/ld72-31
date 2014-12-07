using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour
{
    public static EnemyTracker Instance { get; private set; }


    private EnemyControler[] enemies;

    private void Awake()
    {
        Instance = this;
    }

    public void LoadEnemies(GameObject levelRoot)
    {
        enemies = levelRoot.GetComponentsInChildren<EnemyControler>();
    }
        
    public void FreezeAllEnemies(float duration)
    {
        foreach(EnemyControler ec in enemies)
        {
            ec.Frozen = true;
        }
        Invoke("UnfreezeAllEnemies", duration);
    }

    private void UnfreezeAllEnemies()
    {
        foreach(EnemyControler ec in enemies)
        {
            ec.Frozen = false;
        }
    }
 

    /*public void SpawnEnemy(Vector3 spawnPoint, Quaternion initialRotation)
    {
        GameObject enemyType = enemyTypes[Random.Range(0, enemyTypes.Count)];

        GameObject enemyInstance = (GameObject)Instantiate(enemyType, spawnPoint, initialRotation);
        EnemyBase enemy = enemyInstance.GetComponent<EnemyBase>();

        if (enemy == null)
        {
            throw new UnityException("Found enemy type with missing EnemyBase");
        }

        enemies.Add(enemy);
    }*/
}
