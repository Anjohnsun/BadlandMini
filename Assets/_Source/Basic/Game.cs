using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.IO;

public class Game
{
    private UIControl _uiControl;
    private CameraMoving _cameraMoving;
    private PlayerController _playerController;
    private LevelGenerator _levelGenerator;
    private int _level;

    public Game(UIControl uiControl, CameraMoving cameraMoving, PlayerController playerController, LevelGenerator generator)
    {
        _uiControl = uiControl;
        _cameraMoving = cameraMoving;
        _playerController = playerController;
        _levelGenerator = generator;
        _level = 5;
    }

    public void StartLevel()
    {
        _levelGenerator.GenerateLevel(_level);
        _uiControl.ShowMenuButtons(false);
        _playerController.CanMove = true;
        _cameraMoving.StartCameraMoving();
    }

    public void LoadMainMenu()
    {
        Bootstrapper.LoadScene(0);
        _uiControl.ShowMenuButtons(true);
        _uiControl.HideJustBlackPanel();
    }

    public void FirstLoadMainMenu()
    {
        _uiControl.HideJustBlackPanel();
        _uiControl.ShowMenuButtons(true);
    }

    public void LevelPassed()
    {
        _level += 1;
        LoadMainMenu();
    }

    public void ResetLevel()
    {
        _level = 3;
    }

    ~Game()
    {
        using (StreamWriter writer = new StreamWriter("Resources/level", false))
        {
            writer.WriteLineAsync(_level.ToString());
        }
    }
}
