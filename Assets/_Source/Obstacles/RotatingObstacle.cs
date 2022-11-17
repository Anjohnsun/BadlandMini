using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatingObstacle : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private bool _isKilling;

    private void FixedUpdate()
    {
        transform.Rotate(0, 0, _speed);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (_isKilling)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                PlayerController player = collision.gameObject.GetComponent<PlayerController>();
                player.Die();
                collision.gameObject.SetActive(false);
            }
        }
    }

}
