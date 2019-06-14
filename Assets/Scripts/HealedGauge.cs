using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealedGauge : MonoBehaviour
{
    [SerializeField]
    Image gauge;

    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        CheckCounts();
        GameManager.Manager.OnCheckEnemyStatus.AddListener(CheckCounts);
    }

    void CheckCounts()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        List<Enemy> enemyScripts = new List<Enemy>(enemies.Length);
        int total = enemies.Length;
        int healed = 0;

        for (int i = 0; i < enemies.Length; i++)
        {
            Enemy enemy = enemies[i].GetComponent<Enemy>();
            if (enemy != null && enemy.IsHealed)
            {
                healed++;
            }
        }

        healed = player.IsPlayerControlled ? healed + 1 : healed;

        float fill = 1.0f * healed / total;
        gauge.fillAmount = fill;
        //Debug.Log("Fill amount: " + fill);
    }
}
