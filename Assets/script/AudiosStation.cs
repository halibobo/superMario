using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/**
*游戏音效集合
 * 
* */

public class AudiosStation : MonoBehaviour
{
    public AudioClip[] mAudio;
    public AudioSource[] mAudioSource;
    // Use this for initialization

    void Awake()
    {
        mAudioSource = new AudioSource[mAudio.Length];
    }

    void Start()
    {
        //mAudio = new AudioClip[15];
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void playAudio(int index)
    {
        if (index >= mAudio.Length || index > mAudioSource.Length)
        {
            Debug.Log("数组越界！");
            return;
        }

        if (mAudioSource[index] == null)
        {
            mAudioSource[index] = PlayAudioClip(mAudio[index], Camera.main.transform.position, 2);
        }
        else
        {
            if (mAudioSource[index].isPlaying)
                return;
            mAudioSource[index].Play();
        }
    }

    AudioSource PlayAudioClip(AudioClip clip, Vector3 position, float volume)
    {
        GameObject go = new GameObject("One shot audio");
        go.transform.parent = Camera.main.transform;
        //go.tag = "OneShotAudio";
        AudioSource source = go.AddComponent<AudioSource>();
        source.clip = clip;
        source.loop = false;
        source.volume = volume;
        source.Play();
        return source;
    }
}
