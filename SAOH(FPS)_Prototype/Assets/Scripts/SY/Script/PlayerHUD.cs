using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [Header("Components")]
    public WeaponRifle weapon; //���� ���� ���

    [Header("Weapon Base")]
    public TextMeshProUGUI textWeaponName;//�����̸�

    public Image imageWeaponIcon;//���� ������

    [Header("Magazine")]
    [SerializeField]
    private GameObject magazineUI;//źâ UI
    [SerializeField]
    private Transform magazinePanel;//źâ�� ��ġ�� panel
    public List<GameObject> magazineList;//źâ UI ����Ʈ
    public GameObject clone;


    [Header("Ammo")]
    public TextMeshProUGUI textAmmo;// ����/�ִ� ź�� ���

    private void Awake()
    {
        SetupWeapon();
        SetUpMagazine();

        weapon.onAmmoEvent.AddListener(UpdateAmmoHUD);
        weapon.onMagazineEvent.AddListener(UpdateMagazineHUD);
    }
    private void Update()
    {
        weapon.onAmmoEvent.AddListener(UpdateAmmoHUD);
    }
    private void SetUpMagazine()
    { 
        magazineList = new List<GameObject>();
        for (int i = 0; i < weapon.MaxMagazine; i++)
        {

            clone = Instantiate(magazineUI);
            clone.transform.SetParent(magazinePanel);
            clone.SetActive(false);

            magazineList.Add(clone);
        }

        for (int i = 0; i < weapon.CurMagazine; i++)
        {
            magazineList[i].SetActive(true);
        }

    }

    private void UpdateMagazineHUD(int currentMagazine)
    {
        for (int i = 0; i < magazineList.Count; i++)
        {
            magazineList[i].SetActive(false);
        }

        for (int i = 0; i < currentMagazine; i++)
        {
            magazineList[i].SetActive(true);
        }

    }

    private void SetupWeapon()
    { 
        textWeaponName.text = weapon.WeaponName.ToString();
    }

    private void UpdateAmmoHUD(int currentAmmo, int MaxAmmo)
    { 
        textAmmo.text = $"<size=40>{currentAmmo}/</size>{MaxAmmo}";
    }

}
