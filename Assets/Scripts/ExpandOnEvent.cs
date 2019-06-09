using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExpandOnEvent : MonoBehaviour
{
    [SerializeField]
    IdentifiedCharacter character;

    [SerializeField]
    float expansionFactor;

    [SerializeField]
    GameManager.EnemyEffect effect;

    [SerializeField]
    bool isRestricted;

    [SerializeField]
    float maxExpansion;


    // Start is called before the first frame update
    void Start()
    {
        switch (effect)
        {
            case GameManager.EnemyEffect.HEALED:
                GameManager.Manager.OnEnemyHealed.AddListener(ExpandIfThisOne);
                break;
            case GameManager.EnemyEffect.HURT:
                GameManager.Manager.OnEnemyHurt.AddListener(ExpandIfThisOne);
                break;
            case GameManager.EnemyEffect.KILLED:
                GameManager.Manager.OnEnemyKilled.AddListener(ExpandIfThisOne);
                break;
        }
    }

    void ExpandIfThisOne(string id)
    {
        if (id == character.Id)
        {
            Expand();
        }
    }

    void Expand()
    {
        Vector3 currentScale = transform.localScale;
        currentScale += currentScale * expansionFactor;
        currentScale.x = isRestricted ? (currentScale.x > maxExpansion ? maxExpansion :  currentScale.x) : currentScale.x;
        currentScale.y = isRestricted ? (currentScale.y > maxExpansion ? maxExpansion :  currentScale.y) : currentScale.y;
        currentScale.z = isRestricted ? (currentScale.z > maxExpansion ? maxExpansion :  currentScale.z) : currentScale.z;
        transform.localScale = currentScale;
    }
}
