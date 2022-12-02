using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{
    public Text hpText;
    public Text dpText;
    public float maxHp = 100;
    public float maxDp = 100;

    public float currenthp;
    public float currentdp;


    public Image hpBar;
    public Image dpBar;

    public PlayerCol player;

    void Update()
    {
        currenthp = player.currHP;
        hpText.text = "" + currenthp;
        hpBar.fillAmount = currenthp / maxHp;

        currentdp = player.currDP;
        dpText.text = "" + currentdp;
        dpBar.fillAmount = currentdp / maxDp;
    }
}
