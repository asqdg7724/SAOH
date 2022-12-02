using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hpbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hpText;
    public float maxHp = 100.0f;
    public float currenthp;

    public Image hpBar;


    public PlayerCol player;
    void Update()
    {
        hpText.text = "HP : " + player.currHP;
        hpBar.fillAmount = player.currHP / 100.0f;

        if (currenthp > maxHp)
        { 
            currenthp = maxHp; 
        }
        
    }
}
