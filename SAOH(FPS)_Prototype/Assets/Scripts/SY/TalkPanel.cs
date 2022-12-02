using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkPanel : MonoBehaviour
{
    public GameObject talkPanel;
    public Text text;
    int clinckCount = 0;

    // Update is called once per frame
    void Update()
    {

        
            Invoke("Talk", 5);
        
        
    }

    void Talk()
    { 
        talkPanel.SetActive(false);
    }
}
