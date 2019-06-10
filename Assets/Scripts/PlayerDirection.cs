using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirection : MonoBehaviour
{
    [SerializeField]
    Player player;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Turn());
    }

    Vector3 GetClosestBase()
    {
        GameObject[] bases = GameObject.FindGameObjectsWithTag("Base");
        float distance = float.PositiveInfinity;
        GameObject chosen = null;

        for (int i = 0; i < bases.Length; i++)
        {
            float dist = Mathf.Abs(Vector3.Distance(player.transform.position, bases[i].transform.position));
            if (dist < distance)
            {
                chosen = bases[i];
                distance = dist;
            }
        }

        return chosen != null ? chosen.transform.position - player.transform.position : new Vector3();
    }




    void SetRotation()
    {
        //I LOATHE QUATERNIONS!!!!
        Vector3 dir = GetClosestBase();
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90; //I don't understand this, but this is what the tutorial said to do
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }


    IEnumerator Turn()
    {
        while (true)
        {
            SetRotation();
            yield return new WaitForSeconds(0.2f);
        }

    }
}
