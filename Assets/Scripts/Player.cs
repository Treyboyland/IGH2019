using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : IdentifiedCharacter
{
    [SerializeField]
    float speed;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    List<Sprite> sprites;

    [SerializeField]
    GameObject goodStuff;

    [SerializeField]
    GameObject badStuff;

    static Sprite playerSprite;

    public static Sprite PlayerSprite
    {
        get
        {
            return playerSprite;
        }
        set
        {
            playerSprite = value;
        }
    }

    [SerializeField]
    bool isPlayerControlled;

    public bool IsPlayerControlled
    {
        get
        {
            return isPlayerControlled;
        }
    }

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        PlayerSprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        spriteRenderer.sprite = PlayerSprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerControlled)
        {
            UpdatePosition();
        }

    }

    void UpdatePosition()
    {
        Vector3 pos = transform.position;
        pos.x += Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        pos.y += Input.GetAxis("Vertical") * speed * Time.deltaTime;
        transform.position = pos;
    }

    public void Harm()
    {
        isPlayerControlled = false;
        badStuff.SetActive(true);
        goodStuff.SetActive(false);
        List<Sprite> sprites = Enemy.GetSprites();
        spriteRenderer.sprite = sprites[UnityEngine.Random.Range(0, sprites.Count)];
        GameManager.Manager.OnCheckEnemyStatus.Invoke();
    }

    public void Heal()
    {
        isPlayerControlled = true;
        badStuff.SetActive(false);
        goodStuff.SetActive(true);
        spriteRenderer.sprite = PlayerSprite;
        GameManager.Manager.OnCheckEnemyStatus.Invoke();
    }

}
