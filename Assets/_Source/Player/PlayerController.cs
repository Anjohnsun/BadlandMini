using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidBody;
    [SerializeField] private UIControl _uiControl;
    [SerializeField] private float _boost;
    [SerializeField] private float _speedLimit;
    [SerializeField] private float _verticalBoost;
    [SerializeField] private bool _canMove;

    public bool CanMove { get => _canMove; set => _canMove = value; }

    public void Constructor(InputManager inputSystem)
    {
        inputSystem._onSpacePressed.AddListener(Fly);
    }

    private void Fly()
    {
        if (_canMove)
        {
            if (_rigidBody.velocity.x < _speedLimit)
            {
                _rigidBody.AddForce(new Vector2(_boost, _verticalBoost), ForceMode2D.Force);
            }
            else
            {
                _rigidBody.AddForce(Vector2.up * _verticalBoost, ForceMode2D.Force);
            }
        }
    }

    public void Die()
    {
        _canMove = false;
        _uiControl.ShowEndPanel(true);
    }
}
