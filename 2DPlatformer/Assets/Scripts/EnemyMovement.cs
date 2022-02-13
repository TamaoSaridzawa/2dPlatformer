using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private Transform _targetPosition;
    [SerializeField] private float _distanceGround = 2f;
    [SerializeField] private float _speed;

    private void Start()
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
                if (transform.rotation.y == 0)
                {
                    transform.localRotation = Quaternion.Euler(0, 180, 0);
                }
                else
                {
                    transform.localRotation = Quaternion.Euler(0, 0, 0);
                }
            }
            yield return null;
        }
    }

}
