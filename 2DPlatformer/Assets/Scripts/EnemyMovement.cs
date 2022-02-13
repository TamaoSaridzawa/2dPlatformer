using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _distanceGround = 2f;
    [SerializeField] private float _speed;

    private bool _moveRight = true;

    void Start()
    {
        StartCoroutine(Patrol());
    }

    private IEnumerator Patrol()
    {
        while (true)
        {
            transform.Translate(Vector2.right * _speed * Time.deltaTime);

            RaycastHit2D groundCheck = Physics2D.Raycast(_targetPosition.position, Vector2.down, _distanceGround);

            if (groundCheck.collider == false)
            {
                if (_moveRight)
                {
                    transform.eulerAngles = new Vector3(0, -180, 0);
                    _moveRight = false;
                }
                else
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                    _moveRight = true;
                }
            }
            yield return null;
        }
    }
}
