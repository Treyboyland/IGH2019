using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillRing : MonoBehaviour
{
    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    float time;


    private void OnTriggerEnter2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            StartCoroutine(PrepareToKillPlayer(player));
        }
    }


    IEnumerator PrepareToKillPlayer(Player player)
    {
        helper.RestartTime();

        while(!helper.HasPassedTime(time))
        {
            yield return null;
        }
        Destroy(player.gameObject);
    }



    private void OnTriggerExit2D(Collider2D other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            StopAllCoroutines();
        }
    }
}
