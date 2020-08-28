using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSettings : MonoBehaviour
{
    public int[] enemyCount;
    public int[] bulletDamage;

    public int GetEnemyCount()
    {
        return enemyCount[LevelManager.levelIndex];
    }

}
