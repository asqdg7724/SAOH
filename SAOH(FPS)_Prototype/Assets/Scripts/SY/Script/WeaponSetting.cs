using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponName { Rifle =0}
[System.Serializable]
public struct WeaponSetting
{
    public WeaponName weaponName;   //�����̸�
    public int maxMagazine;         //�ִ� źâ
    public int curMagazine;         //���� źâ
    public int damage;              //���ݷ�
    public int currentAmmo;         //���� ź�� ��
    public int maxAmmo;             //�ִ� ź�� ��
    public float attackRate;        //���� �ӵ�
    public float attackDistance;    //���� ��Ÿ�
    public bool isAutoAttack;       

    public int _Magazine
    {
        set { curMagazine = value; }
        get { return curMagazine; }
    }

}
