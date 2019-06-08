using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeHelper : MonoBehaviour
{
    bool isTrackingTime = false;

    float elapsedSeconds = 0.0f;

    public float ElapsedSeconds
    {
        get
        {
            return elapsedSeconds;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isTrackingTime)
        {
            elapsedSeconds += Time.deltaTime;
        }
    }

    public void ResetTime()
    {
        isTrackingTime = false;
        elapsedSeconds = 0;
    }

    public void StartTime()
    {
        isTrackingTime = true;
    }

    public void RestartTime()
    {
        ResetTime();
        StartTime();
    }

    public void PauseTime()
    {
        isTrackingTime = false;
    }

    public bool HasPassedTime(float seconds)
    {
        return seconds <= elapsedSeconds;
    }
}
