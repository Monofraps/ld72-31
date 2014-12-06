using UnityEngine;
using System.Collections;

public class EnemyFreezePickup : ItemBase
{
    public double duration = 2;

    private EnemyTracker enemyTracker;
    private double elapsedTime = 0;

    void Start()
    {
        enemyTracker = EnemyTracker.Instance;
        if (enemyTracker == null)
        {
            throw new UnityException("No EnemyTracker in scene");
        }

        foreach (EnemyBase enemy in enemyTracker.GetAllEnemies())
        {
            enemy.IsStunned = true;
        }
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= duration)
        {
            foreach (EnemyBase enemy in enemyTracker.GetAllEnemies())
            {
                enemy.IsStunned = false;
            }

            Destroy(gameObject);
        }
    }
}
