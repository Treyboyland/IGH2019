using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHurtRing : MonoBehaviour
{
    [SerializeField]
    IdentifiedCharacter self;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    float elapsedTime;

    Dictionary<string, Coroutine> coroutineDictionary = new Dictionary<string, Coroutine>();

    // Start is called before the first frame update
    void Start()
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
        AddCoroutine(coroutineDictionary, enemy.Id, StartCoroutine(WaitForHurt(enemy)));
    }

    IEnumerator WaitForHurt(Enemy enemy)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(elapsedTime))
        {
            yield return null;
        }

        enemy.Hurt();
        GameManager.Manager.OnEnemyHurt.Invoke(self.Id);
    }

    public void Cancel(Enemy enemy)
    {
        StopCoroutineOnEnemy(enemy.Id);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null && enemy.IsHealed && enemy.Id != self.Id)
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
