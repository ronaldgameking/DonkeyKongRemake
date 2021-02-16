using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    private Player player;
    private BoxCollider2D boxCol;

    void Start()
    {
        player = FindObjectOfType<Player>();
        boxCol = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        if (player.canGoTrough == true && player.hasJumped == false)
        {
            boxCol.enabled = false;
        }
        else
        {
            boxCol.enabled = true;
        }
    }
}
