using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    Transform origin;

    [SerializeField]
    EnemyPool pool;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    Vector2 randXMins;

    [SerializeField]
    Vector2 randXMaxes;

    [SerializeField]
    Vector2 randYMins;

    [SerializeField]
    Vector2 randYMaxes;

    [SerializeField]
    Vector2 timeBetweenSpawns;

    [SerializeField]
    Vector2Int numSpawns;

    [SerializeField]
    int initialSpawns;

    bool isRunning = true;

    // Start is called before the first frame update
    void Start()
    {
        InitialSpawn();
        StartCoroutine(SpawnRandomly());
    }

    private void OnEnable()
    {
        StartCoroutine(SpawnRandomly());
    }

    public void StopSpawning()
    {
        StopAllCoroutines();
        isRunning = false;
    }

    private void OnDisable()
    {
        isRunning = false;
    }

    void InitialSpawn()
    {
        for (int i = 0; i < initialSpawns; i++)
        {
            InstantiateEnemy();
        }
    }

    void SpawnEnemies(int count)
    {
        for (int i = 0; i < count; i++)
        {
            InstantiateEnemy();
        }
    }

    void InstantiateEnemy()
    {
        Enemy e = pool.GetObject();
        if (e != null)
        {
            e.IsHealed = false;
            e.transform.position = GetRandomPosition() + (Vector2)origin.position;
            e.gameObject.SetActive(true);
        }
    }

    Vector2 GetRandomPosition()
    {
        bool minX = UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f;
        bool miny = UnityEngine.Random.Range(0.0f, 1.0f) < 0.5f;

        Vector2 x = minX ? randXMins : randXMaxes;
        Vector2 y = miny ? randYMins : randYMaxes;

        float posX = UnityEngine.Random.Range(x.x, x.y);
        float posY = UnityEngine.Random.Range(y.x, y.y);

        return new Vector2(posX, posY);
    }

    IEnumerator Wait(float time)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(time))
        {
            yield return null;
        }
    }

    IEnumerator SpawnRandomly()
    {
        if (isRunning)
        {
            yield break;
        }
        isRunning = true;
        while (true)
        {
            yield return StartCoroutine(Wait(UnityEngine.Random.Range(timeBetweenSpawns.x, timeBetweenSpawns.y)));
            SpawnEnemies(UnityEngine.Random.Range(numSpawns.x, numSpawns.y + 1));

        }
    }
}
