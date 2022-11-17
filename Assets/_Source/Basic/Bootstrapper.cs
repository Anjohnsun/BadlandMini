using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bootstrapper : MonoBehaviour
{
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private InputManager _inputManager;
    [SerializeField] private UIControl _uiControl;
    [SerializeField] private CameraMoving _cameraMoving;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private FinishLine _finishLine;
    private Game _game;
    void Start()
    {
        _game = new Game(_uiControl, _cameraMoving, _playerController, _levelGenerator);
        _playerController.Constructor(_inputManager);
        _uiControl.Game = _game;
        _game.FirstLoadMainMenu();
        _finishLine.Game = _game;
    }

    static public void LoadScene(int sceneNumber)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneNumber);
    }

}
