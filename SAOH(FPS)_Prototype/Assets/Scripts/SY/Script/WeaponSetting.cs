using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName { Rifle =0}
[System.Serializable]
public struct WeaponSetting
{
    public WeaponName weaponName;   //무기이름
    public int maxMagazine;         //최대 탄창
    public int curMagazine;         //현재 탄창
    public int damage;              //공격력
    public int currentAmmo;         //현재 탄약 수
    public int maxAmmo;             //최대 탄약 수
    public float attackRate;        //공격 속도
    public float attackDistance;    //공격 사거리
    public bool isAutoAttack;       

    public int _Magazine
    {
        set { curMagazine = value; }
        get { return curMagazine; }
    }

}
