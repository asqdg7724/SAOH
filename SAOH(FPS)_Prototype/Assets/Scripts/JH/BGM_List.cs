using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_List : MonoBehaviour
{
    AudioSource myAudio;

    //����� ���ϵ�
    public AudioClip[] BGM;

    // Use this for initialization
    void Start()
    {
        myAudio = GetComponent<AudioSource>();
    }

    public void BGM_SoundPlay(int SoundNumber)
    {
        //AudioSource�� �ִ� ����� ���ϵ��� �ִ´�
        myAudio.clip = BGM[SoundNumber];

        //���带 ����Ѵ�.
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
