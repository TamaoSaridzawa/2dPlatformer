using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinInteracting : MonoBehaviour
{
    [SerializeField] private CoinSpawner _spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            gameObject.SetActive(false);
            _spawner.Generate();
        }
    }
}
