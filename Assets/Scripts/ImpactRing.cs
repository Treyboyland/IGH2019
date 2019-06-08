using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactRing : MonoBehaviour, IImpact
{
    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    bool isHealing;

    [SerializeField]
    float elapsedTimeHeal;

    [SerializeField]
    float elapsedTimeHurt;

    Dictionary<string, Coroutine> healCoroutines = new Dictionary<string, Coroutine>();

    Dictionary<string, Coroutine> hurtCoroutines  = new Dictionary<string, Coroutine>();

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void StopHealing(string id)
    {
        if(healCoroutines.ContainsKey(id))
        {
            StopCoroutine(healCoroutines[id]);
        }
    }

    void AddCoroutine(Dictionary<string, Coroutine> dictionary, string id, Coroutine routine)
    {
        if(!dictionary.ContainsKey(id))
        {
            
        }
    }

    public void Affect(Enemy enemy)
    {
        if (isHealing && !enemy.IsHealed)
        {
            StartCoroutine(WaitForHealing(enemy));
        }
        else
        {
            StartCoroutine(WaitForDestruction(enemy));
        }
    }

    IEnumerator WaitForDestruction(Enemy enemy)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(elapsedTimeHurt))
        {
            yield return null;
        }

        enemy.Kill();
    }

    public void Cancel(Enemy enemy)
    {
        StopAllCoroutines();
    }

    IEnumerator WaitForHealing(Enemy enemy)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(elapsedTimeHeal))
        {
            yield return null;
        }

        enemy.Heal();
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
        if(enemy != null)
        {
            if(isHealing)
            {
                
            }
        }
    }
}
