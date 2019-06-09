using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseSpawner : MonoBehaviour
{
    [SerializeField]
    BasePool pool;

    [SerializeField]
    Vector2 spawnRange;

    [SerializeField]
    int maxNumBases;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    Player player;

    [SerializeField]
    List<GameObject> spawnLocations;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    void SpawnBase()
    {
        EnemyBase enemyBase = pool.GetObject();
        enemyBase.Hurt();

        Vector3 pos = enemyBase.transform.position;
        do
        {
            pos = spawnLocations[UnityEngine.Random.Range(0, spawnLocations.Count)].transform.position;
            Debug.Log(pos);
        }
        while (Vector3.Distance(pos, player.transform.position) < 10);

        enemyBase.transform.position = pos;

        enemyBase.gameObject.SetActive(true);
    }

    IEnumerator Wait(float time)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(time))
        {
            yield return null;
        }
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            int numActive = pool.GetActiveObjects();
            if (numActive < maxNumBases)
            {
                int diff = maxNumBases - numActive;
                for (int i = 0; i < diff; i++)
                {
                    SpawnBase();
                }
            }
            yield return StartCoroutine(Wait(20));
        }
    }
}
