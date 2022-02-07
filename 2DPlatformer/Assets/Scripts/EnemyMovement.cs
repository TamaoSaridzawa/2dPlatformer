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
        //while (true)
        //{
        //    if (true)
        //    {

        //    }
        //    transform.position = Vector3.MoveTowards(transform.position, _targetPosition.position, 1f * Time.deltaTime);

        //    if (transform.position == _targetPosition.position)
        //    {
        //        Debug.Log("РАзворот");
        //        _goalAchieved = true;
        //    }

        //yield return null;
        //}

        //while (_goalAchieved)
        //{
        //    transform.position = Vector3.MoveTowards(transform.position, _startPosition.position, 1f * Time.deltaTime);

        //    //if (transform.position == _startPosition.position)
        //    //{
        //    //    Debug.Log("Все сгачада");
        //    //    _goalAchieved = false;
        //    //}

        //    yield return null;
        //}
    }
}
