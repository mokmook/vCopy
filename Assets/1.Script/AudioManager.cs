using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    Transform mainCamera;
    [SerializeField] GameObject audioSourcePrefab;
    [SerializeField] int increaseCount;
    List<GameObject> mp;

    void Start()
    {
        instance = this;
        mp = new List<GameObject>();
        CreateNewMemory();
        mainCamera = Camera.main.transform;
        
    }


    void Update()
    {

    }
    void CreateNewMemory()
    {
        for (int i = 0; i < increaseCount; i++)
        {
            GameObject gameObject = Instantiate(audioSourcePrefab, transform);
            gameObject.GetComponent<AudioSourceController>().Init(transform);
            mp.Add(gameObject);
            gameObject.SetActive(false);
        }
    }
    GameObject GetObj()
    {
        for (int i = 0; i < mp.Count; i++)
        {
            if (!mp[i].activeSelf)
                return mp[i];
        }
        CreateNewMemory();
        return GetObj();
    }
    public void PlayAudioClip(AudioClip clip, Transform tr = null)
    {
        if (clip == null) return;
        tr = (tr == null ?  mainCamera : tr);

        GameObject game = GetObj();
        game.GetComponent<AudioSourceController>().SetAudio(clip, tr);        
    }
   
}
