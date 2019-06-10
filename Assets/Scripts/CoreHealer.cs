using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoreHealer : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D other)
    {
        BaseCore core = other.GetComponent<BaseCore>();
        if(core != null && !core.IsHealed)
        {
            core.Heal();
        }
    }
}
