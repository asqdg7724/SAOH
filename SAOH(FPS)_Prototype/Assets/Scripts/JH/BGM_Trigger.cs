using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGM_Trigger : MonoBehaviour
{
    public BGM_List BGMPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            BGMPlayer.BGM_SoundPlay(0);
            Destroy(this.gameObject, 0.5f);
        }
    }
}
