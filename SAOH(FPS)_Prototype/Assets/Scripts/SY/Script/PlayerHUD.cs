using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class PlayerHUD : MonoBehaviour
{
    [Header("Components")]
    public WeaponRifle weapon; //현재 정보 출력

    [Header("Weapon Base")]
    public TextMeshProUGUI textWeaponName;//무기이름

    public Image imageWeaponIcon;//무기 아이콘

    [Header("Magazine")]
    [SerializeField]
    private GameObject magazineUI;//탄창 UI
    [SerializeField]
    private Transform magazinePanel;//탄창이 배치될 panel
    public List<GameObject> magazineList;//탄창 UI 리스트
    public GameObject clone;


    [Header("Ammo")]
    public TextMeshProUGUI textAmmo;// 현재/최대 탄수 출력

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
