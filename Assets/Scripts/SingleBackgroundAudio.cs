using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleBackgroundAudio : MonoBehaviour
{
    static SingleBackgroundAudio _instance;

    // Start is called before the first frame update
    void Start()
    {
        if (_instance != null && this != _instance)
        {
            Destroy(gameObject);
            return;
        }
        _instance = this;
    }
}
