using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealRing : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Player p = other.GetComponent<Player>();
        if(p != null)
        {
            p.Heal();
        }
    }
}
