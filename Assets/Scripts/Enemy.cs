using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : IdentifiedCharacter
{
    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    List<Sprite> sprites;

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
        set
        {
            isHealed = value;
            UpdateValues();
        }
    }

    static List<Sprite> initialList;

    static bool spritesRun = false;

    static List<Sprite> availableSprites;



    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        UpdateValues();
    }

    public static List<Sprite> GetSprites()
    {
        if (!spritesRun)
        {
            spritesRun = true;
            availableSprites = initialList;
            Debug.Log("Possible Sprites: " + availableSprites.Count);
            availableSprites.Remove(Player.PlayerSprite);
        }
        return availableSprites;
    }


    void UpdateValues()
    {
        if (!spritesRun)
        {
            initialList = sprites;
        }

        healedRing.SetActive(isHealed);
        hurtRing.SetActive(!isHealed);
        SetColor(isHealed ? healedColor : normalColor);
        SetSprite(isHealed ? Player.PlayerSprite : GetRandomSprite());
        GameManager.Manager.OnCheckEnemyStatus.Invoke();
    }

    void SetColor(Color c)
    {
        //spriteRenderer.color = c;
        spriteRenderer.color = Color.white;
    }

    Sprite GetRandomSprite()
    {
        List<Sprite> possibleSprites = GetSprites();
        Sprite chosen = possibleSprites[UnityEngine.Random.Range(0, possibleSprites.Count)];
        return chosen;
    }

    void SetSprite(Sprite s)
    {
        spriteRenderer.sprite = s;
    }

    public void Heal()
    {
        isHealed = true;
        UpdateValues();
    }

    private void OnDestroy()
    {
        spritesRun = false;
    }

    public void Hurt()
    {
        isHealed = false;
        UpdateValues();
    }

    public void Kill()
    {
        Debug.Log("We are dead!");
        gameObject.SetActive(false);
    }
}
