using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_List : MonoBehaviour
{
    AudioSource myAudio;

    //오디오 파일들
    public AudioClip[] BGM;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void BGM_SoundPlay(int SoundNumber)
    {
        //AudioSource에 있는 오디오 파일들을 넣는다
        myAudio.clip = BGM[SoundNumber];

        //사운드를 재생한다.
        myAudio.Play();
    }

    public void BGM_LoopOFF()
    {
        myAudio.loop = false;
    }

    public void BGM_SoundStop()
    {
        myAudio.Stop();
    }
}
