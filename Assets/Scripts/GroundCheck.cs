using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        player.GetOnGround();
        player.SetOnGround(true);
        player.GetHasJumped();
        player.SetHasJumped(false);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        player.GetOnGround();
        player.SetOnGround(false);
        player.GetHasJumped();
        player.SetHasJumped(true);
    }
}
