using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Text;

public class TitleScript : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    Vector2 randomTime;

    [SerializeField]
    Vector2Int randomNum;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ChangeRandomly());
    }

    IEnumerator Wait(float seconds)
    {
        helper.RestartTime();

        while (!helper.HasPassedTime(seconds))
        {
            yield return null;
        }
    }

    string GetSprite()
    {
        int randomEmoji = UnityEngine.Random.Range(0, 9);
        return "<size=200%><sprite=\"emoji\" name=\"emoji_" + randomEmoji + "\"></size>";
    }

    void ChangeTitle(int numEmoji)
    {
        StringBuilder sb = new StringBuilder();

        for (int i = 0; i < numEmoji; i++)
        {
            sb.Append(GetSprite());
        }

        textBox.text = sb.ToString();
    }


    IEnumerator ChangeRandomly()
    {
        while (true)
        {
            int num = UnityEngine.Random.Range(randomNum.x, randomNum.y + 1);
            ChangeTitle(num);

            float time = UnityEngine.Random.Range(randomTime.x, randomTime.y);
            yield return StartCoroutine(Wait(time));
        }
    }
}
