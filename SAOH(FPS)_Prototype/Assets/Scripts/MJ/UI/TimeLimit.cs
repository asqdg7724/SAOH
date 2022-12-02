using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TimeLimit : MonoBehaviour
{
    // Start is called before the first frame update

    public float limitTime;
    public Text textTimer;
    int min;
    float sec;


    void Start()
    {
        //limitTime = 180;
    }

    // Update is called once per frame
    void Update()
    {

      
        limitTime -= Time.deltaTime;
        if (limitTime >= 60f)
        {
            min = (int)limitTime / 60;
            sec = (int)limitTime % 60;
            textTimer.text = min + ":" + (int)sec; 
        }
       
        if (limitTime < 60f)
        {
            textTimer.text ="<color=red>"+"00:"+(int)limitTime+"</color>";
        }

        if(limitTime <= 0)
        {
            textTimer.text = "<b><color=red>TimeOver</color></b>";
            //게임오버 화면으로 가도록
        }

    }
}
