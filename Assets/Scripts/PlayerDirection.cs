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

        return chosen != null ? chosen.transform.position : new Vector3();
    }




    void SetRotation()
    {
        Vector3 rotation = transform.eulerAngles;
        rotation.z = Vector3.Angle(player.transform.position, GetClosestBase()) + 90;
        Debug.Log("Rotation: " + rotation.z);
        transform.eulerAngles = rotation;
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
