using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RoastSummoner : MonoBehaviour
{
    [SerializeField]
    Player player;

    [SerializeField]
    TeleportRandomly roastBase;

    [SerializeField]
    int burstCounter;

    [SerializeField]
    TextMeshProUGUI textBox;

    public int BurstCounter
    {
        get
        {
            return burstCounter;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Manager.OnBaseHealed.AddListener(() =>
        {
            burstCounter++;
            textBox.text = "x" + burstCounter;
        });
        textBox.text = "x" + burstCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Summon") && burstCounter > 0)
        {
            burstCounter--;
            roastBase.SetToPosition(player.transform.position);
            textBox.text = "x" + burstCounter;
        }
    }
}
