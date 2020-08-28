using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static int levelIndex { get; private set; } = 0;

    GameSettings gs;

    void Start()
    {
        gs = FindObjectOfType<GameSettings>();
    }

    public void NextLevel()
    {
        levelIndex = levelIndex >= gs.enemyCount.Length - 1 ? 0 : levelIndex + 1;
    }

    public void ResetLevel()
    {
        levelIndex = 0;
    }

}
