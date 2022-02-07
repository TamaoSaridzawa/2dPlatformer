using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent<PlayerManagement>(out PlayerManagement player))
        {
            player.gameObject.SetActive(false);
        }
    }
}
