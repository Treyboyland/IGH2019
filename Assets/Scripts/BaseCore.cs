using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCore : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    EnemyBase enemyBase;

    [SerializeField]
    Color hurt;

    [SerializeField]
    Color heal;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void SetColor(bool isHealed)
    {
        spriteRenderer.color = isHealed ? heal : hurt;
    }

    public void Hurt()
    {
        enemyBase.Hurt();
    }

    public void Heal()
    {
        enemyBase.Heal();
    }

}
