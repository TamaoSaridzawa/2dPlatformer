using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [SerializeField] private Transform _path;
    [SerializeField] private GameObject _coin;

    private List<GameObject> _coins = new List<GameObject>();
    private Transform[] _points;

    private void Start()
    {
        _points = new Transform[_path.childCount];

        for (int i = 0; i < _path.childCount; i++)
        {
            _points[i] = _path.GetChild(i);

            GameObject newCoin = Instantiate(_coin, new Vector3(0, 0, 0), Quaternion.identity);
            newCoin.transform.position = _points[i].position;
            _coins.Add(newCoin);
        }

        _coins[Random.Range(0, _coins.Count)].SetActive(true);
    }

    public void Generate()
    {
        _coins[Random.Range(0, _coins.Count)].SetActive(true);
    }
}
