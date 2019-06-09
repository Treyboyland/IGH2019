using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleSoundPlayer : MonoBehaviour
{
    [SerializeField]
    AudioClip clip;

    public AudioClip Clip
    {
        get
        {
            return clip;
        }
        set
        {
            clip = value;
            audioSource.clip = clip;
        }
    }

    [SerializeField]
    AudioSource audioSource;

    private void OnEnable()
    {
        StartCoroutine(DisableWhenNotPlaying());
    }

    public void StopPlaying()
    {
        audioSource.Stop();
    }

    IEnumerator DisableWhenNotPlaying()
    {
        audioSource.Play();

        while (audioSource.isPlaying)
        {
            yield return null;
        }

        gameObject.SetActive(false);
    }
}
