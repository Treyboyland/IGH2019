using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    [SerializeField]
    Enemy enemy;

    [SerializeField]
    BaseCore core;

    [SerializeField]
    Color healColor;

    [SerializeField]
    Color hurtColor;

    [SerializeField]
    List<ParticleSystem> particles;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    float waitTime;

    [SerializeField]
    EnemySpawner spawner;

    public bool IsHealed
    {
        get
        {
            return enemy.IsHealed;
        }
    }

    public void Heal()
    {
        enemy.Heal();
        core.SetColor(true);
        spawner.StopSpawning();
        ChangeParticles();
        StartCoroutine(WaitThenDisable());
        GameManager.Manager.OnBaseHealed.Invoke();
    }

    void ChangeParticles()
    {
        foreach (ParticleSystem ps in particles)
        {
            ParticleSystem.MainModule mm = ps.main;
            mm.startColor = IsHealed ? healColor : hurtColor;
            ps.Clear();
            ps.Play();
        }
    }

    public void Hurt()
    {
        enemy.Hurt();
        core.SetColor(false);
        ChangeParticles();
    }

    IEnumerator WaitThenDisable()
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(waitTime))
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
