using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainLoader : MonoBehaviour
{
    [SerializeField]
    string sceneName;

    private void Update()
    {
        if (Input.anyKey)
        {
            if (!Input.GetButton("Exit"))
            {
                SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
            }
            else
            {
                Application.Quit();
            }

        }
    }
}
