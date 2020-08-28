using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    public GameObject gameOverScreen;
    public GameObject winScreen;
    public GameObject joystick;

    GameManager gm;

    private void Start()
    {
        gm = FindObjectOfType<GameManager>();
        gm.gameOverEvent += OnGameOver;
        gm.winEvent += OnWin;
    }

    void OnGameOver()
    {
        joystick.SetActive(false);
        gameOverScreen.SetActive(true);
    }

    void OnWin()
    {
        joystick.SetActive(false);
        winScreen.SetActive(true);
    }

    public void RestartButton()
    {
        gm.Restart();
    }

    public void ContinueButton()
    {
        gm.Continue();
    }

}
