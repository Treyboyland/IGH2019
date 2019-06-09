using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealRing : MonoBehaviour, IImpact
{
    [SerializeField]
    IdentifiedCharacter self;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    float elapsedTime;



    Dictionary<string, Coroutine> coroutineDictionary = new Dictionary<string, Coroutine>();

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
        AddCoroutine(coroutineDictionary, enemy.Id, StartCoroutine(WaitForHealing(enemy)));
    }

    IEnumerator WaitForHealing(Enemy enemy)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(elapsedTime))
        {
            yield return null;
        }

        enemy.Heal();
        GameManager.Manager.OnEnemyHealed.Invoke(self.Id);
    }

    public void Cancel(Enemy enemy)
    {
        StopCoroutineOnEnemy(enemy.Id);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && !enemy.IsHealed && enemy.Id != self.Id)
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
