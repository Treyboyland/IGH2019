using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillRing : MonoBehaviour, IImpact
{
    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    float elapsedTime;

    Dictionary<string, Coroutine> coroutineDictionary = new Dictionary<string, Coroutine>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void StopCoroutineOnEnemy(string id)
    {
        if (coroutineDictionary.ContainsKey(id))
        {
            StopCoroutine(coroutineDictionary[id]);
        }
    }

    void AddCoroutine(Dictionary<string, Coroutine> dictionary, string id, Coroutine routine)
    {
        if (!dictionary.ContainsKey(id))
        {
            dictionary.Add(id, routine);
        }
        else
        {
            dictionary[id] = routine;
        }
    }

    public void Affect(Enemy enemy)
    {
        AddCoroutine(coroutineDictionary, enemy.Id, StartCoroutine(WaitForDestruction(enemy)));
    }

    IEnumerator WaitForDestruction(Enemy enemy)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(elapsedTime))
        {
            yield return null;
        }

        enemy.Kill();
    }

    public void Cancel(Enemy enemy)
    {
        StopCoroutineOnEnemy(enemy.Id);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.LogWarning("Collider hit!!!");
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Affect(enemy);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            Cancel(enemy);
        }
    }
}
