using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectionTrigger : MonoBehaviour
{
    [SerializeField] private CoinSpawner _spawner;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out PlayerManagement player))
        {
            gameObject.SetActive(false);
            _spawner.Show();
        }
    }
}
