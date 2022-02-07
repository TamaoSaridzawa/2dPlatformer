using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _coin;

    private List<GameObject> _gameObjects = new List<GameObject>();
    private Transform[] _points;

    void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);

            GameObject newCoin = Instantiate(_coin, new Vector3(0, 0, 0), Quaternion.identity);
            newCoin.transform.position = _points[i].position;
            _gameObjects.Add(newCoin);
        }

        _gameObjects[Random.Range(0, _gameObjects.Count)].SetActive(true);
    }

    public IReadOnlyList<GameObject> GetObjects()
    {
        return _gameObjects;
    }
}
