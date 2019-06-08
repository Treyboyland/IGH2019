using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    GameObject healedRing;

    [SerializeField]
    GameObject hurtRing;

    [SerializeField]
    Color healedColor;

    [SerializeField]
    Color normalColor;

    bool isHealed = false;

    public bool IsHealed
    {
        get
        {
            return isHealed;
        }
    }

    string id;

    public string Id
    {
        get
        {
            return id;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        UpdateValues();
        GenerateIdentifier();
    }

    void GenerateIdentifier()
    {
        id = System.Guid.NewGuid().ToString();
    }

    void UpdateValues()
    {
        healedRing.SetActive(isHealed);
        hurtRing.SetActive(!isHealed);
        SetColor(isHealed ? healedColor : normalColor);
    }

    void SetColor(Color c)
    {
        spriteRenderer.color = c;
    }

    public void Heal()
    {
        isHealed = true;
        UpdateValues();
    }

    public void Kill()
    {
        Debug.Log("We are dead!");
        gameObject.SetActive(false);
    }
}
