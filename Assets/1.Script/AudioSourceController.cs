using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSourceController : MonoBehaviour
{
    AudioSource audioSource;
    Transform audioManagerTr;
    
    public  AudioSourceController Init(Transform tr)
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioManagerTr = tr;
        return this;
    }
    public void SetAudio(AudioClip a,Transform tr)
    {
        audioSource.clip = a;
        gameObject.transform.SetParent(tr);
        gameObject.SetActive(true);
        audioSource.Play();


        Invoke("ActiveFalse", a.length);

        
    }
    void ActiveFalse()
    {
        audioSource.clip = null;
        gameObject.transform.SetParent(audioManagerTr);
        gameObject.SetActive(false);
    }
}
