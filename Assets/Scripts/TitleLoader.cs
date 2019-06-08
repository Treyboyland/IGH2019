using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TitleLoader : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textBox;

    [SerializeField]
    string sceneName;

    [SerializeField]
    TimeHelper helper;

    [SerializeField]
    float secondsToWait;

    bool objectShown = false;

    // Start is called before the first frame update
    void Start()
    {
        textBox.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Exit"))
        {
            if(objectShown)
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
            else
            {
                StartCoroutine(ShowObject());
            }
        }
    }


    IEnumerator ShowObject()
    {
        objectShown = true;
        textBox.gameObject.SetActive(true);
        helper.RestartTime();

        while (!helper.HasPassedTime(secondsToWait))
        {
            yield return null;
        }

        textBox.gameObject.SetActive(false);
        objectShown = false;
    }
}
