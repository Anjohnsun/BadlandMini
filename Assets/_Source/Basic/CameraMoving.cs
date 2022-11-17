using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoving : MonoBehaviour
{
    [SerializeField] private Transform _player;
    [SerializeField] private float _normalCameraSpeed;
    [SerializeField] private float _currentCameraSpeed;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private bool _playerAlive;

    public float CurrentCameraSpeed { get => _currentCameraSpeed; set => _currentCameraSpeed = value; }
    public float NormalCameraSpeed => _normalCameraSpeed;

    
    public void StartCameraMoving()
    {
        StartCoroutine(StartMovingCoroutine(true));
    }

    private void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + _currentCameraSpeed, transform.position.y, -10);
        if (_playerAlive)
        {
            if (transform.position.x - _player.position.x < 2.5)
            {
                transform.position = new Vector3(transform.position.x + (2.5f - (transform.position.x - _player.position.x)) / 10, transform.position.y, -10);
            }
            if (transform.position.x - _player.position.x >= 9)
            {
                _playerAlive = false;
                StartCoroutine(StartMovingCoroutine(false));
            }
        }
    }

    private IEnumerator StartMovingCoroutine(bool value)
    {
        float minusValue = _normalCameraSpeed / 15;
        if (value)
        {
            while (_currentCameraSpeed <= _normalCameraSpeed)
            {
                _currentCameraSpeed += minusValue;
                yield return new WaitForSeconds(0.25f);
            }
        } else
        {
            while (_currentCameraSpeed > 0)
            {
                _currentCameraSpeed -= minusValue;
                yield return new WaitForSeconds(0.25f);
            }
            _playerController.Die();
        }
        yield return null;
    }

}
