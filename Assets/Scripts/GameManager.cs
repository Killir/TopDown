using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public delegate void SimpleDelegate();
    public event SimpleDelegate gameOverEvent;
    public event SimpleDelegate winEvent;

    ScenesManager sm;
    LevelManager lm;

    private void Start()
    {
        sm = FindObjectOfType<ScenesManager>();
        lm = FindObjectOfType<LevelManager>();
    }

    public void OnGameOver()
    {
        gameOverEvent?.Invoke();
    }

    public void OnWin()
    {
        winEvent?.Invoke();
    }

    public void Restart()
    {
        lm.ResetLevel();
        sm.ReloadScene();
    }

    public void Continue()
    {
        lm.NextLevel();
        sm.ReloadScene();
    }

}
