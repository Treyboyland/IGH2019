using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportRandomly : MonoBehaviour
{
    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    Vector2 posRange;

    [SerializeField]
    Vector2 waitTime;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Teleport());
    }

    IEnumerator Wait(float time)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(time))
        {
            yield return null;
        }
    }

    void GetRandomPosition()
    {
        Vector3 pos;
        pos.x = UnityEngine.Random.Range(posRange.x, posRange.y);
        pos.y = UnityEngine.Random.Range(posRange.x, posRange.y);
        pos.z = transform.position.z;

        transform.position = pos;
    }

    public void SetToPosition(Vector3 position)
    {
        helper.RestartTime();
        transform.position = position;
    }


    IEnumerator Teleport()
    {
        while (true)
        {
            float time = UnityEngine.Random.Range(waitTime.x, waitTime.y);
            yield return StartCoroutine(Wait(time));
            GetRandomPosition();
        }
    }
}
