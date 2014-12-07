using UnityEngine;
using System.Collections;

public class EnemyFreezePickup : ItemBase
{
    public float duration = 2.0f;

    private EnemyTracker enemyTracker;

    void Start()
    {
        enemyTracker = EnemyTracker.Instance;
        if (enemyTracker == null)
        {
            throw new UnityException("No EnemyTracker in scene");
        }

        enemyTracker.FreezeAllEnemies(duration);
        Destroy(gameObject);
    }
}
