using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackPlayer : MonoBehaviour
{
    [SerializeField]
    GameObject obj;


    // Start is called before the first frame update
    void Start()
    {
        UpdatePosition();
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePosition();
    }

    void UpdatePosition()
    {
        if (obj != null)
        {
            Vector3 objPos = obj.transform.position;
            Vector3 thisPos = transform.position;
            thisPos.x = objPos.x;
            thisPos.y = objPos.y;

            transform.position = thisPos;
        }

    }
}
