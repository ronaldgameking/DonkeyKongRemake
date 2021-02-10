using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ladder : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetCanClimb();
        player.SetCanClimb(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetCanClimb();
        player.SetCanClimb(false);
    }
}
