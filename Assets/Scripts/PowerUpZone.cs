using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpZone : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Barrel"))
        {
            Destroy(collision.gameObject);
        }
    }
}
