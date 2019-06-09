using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstaKill : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        Enemy enemy = other.GetComponent<Enemy>();

        if (player != null)
        {
            player.Harm();
        }
        else if(enemy != null)
        {
            enemy.gameObject.SetActive(false);
        }
    }
}
