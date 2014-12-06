using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyTracker : MonoBehaviour
{
    public static EnemyTracker Instance { get; private set; }

    private List<EnemyBase> enemies;
        
    void Start()
    {
        Instance = this;
    }
 
    public List<EnemyBase> GetAllEnemies()
    {
        return enemies;
    }
}
