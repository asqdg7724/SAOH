using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class AmmoEvent : UnityEngine.Events.UnityEvent<int, int> { }
[System.Serializable]
public class MagazineEvent : UnityEngine.Events.UnityEvent<int> { }
public class WeaponRifle : MonoBehaviour
{
    [HideInInspector]
    public AmmoEvent onAmmoEvent = new AmmoEvent();
    [HideInInspector]
    public MagazineEvent onMagazineEvent = new MagazineEvent();

    [Header("Fire Effects")]
    [SerializeField]
    private GameObject muzzleFlashEffect; //�ѱ� ����Ʈ

    public Transform bulletSpawnPoint;//�Ѿ˻��� ��ġ

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip auclTakeOutWeapon; //���� ���� ����
    public AudioClip auclFire;  //���� ����
    public AudioClip auclReload; //������
    public GameObject Bullet;
    public Transform FirePos;

    [Header("Weapon Setting")]
    [SerializeField]
    public WeaponSetting weaponSetting; //���� ����

    private float lastAttckTime = 0; //������ �߻� �ð� Ȯ��
    private bool isReload = false; //������ Ȯ��

    private AudioSource audioSource;
    private PlayerAnimatorController animator;//�ִϸ��̼�
    private PlayerCol playerCol;
    

    //get property
    public WeaponName WeaponName => weaponSetting.weaponName;
    public int CurMagazine => weaponSetting.curMagazine;
    public int MaxMagazine => weaponSetting.maxMagazine;

   


    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        animator = GetComponentInParent<PlayerAnimatorController>();

        weaponSetting.currentAmmo = weaponSetting.maxAmmo;
        weaponSetting.curMagazine = 3;
    }
    private void OnEnable()
    {
        muzzleFlashEffect.SetActive(false);//�ѱ� ����Ʈ
        //���� Ȱ��ȭ�� ź�� ���� ����
        onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);
        onMagazineEvent.Invoke(weaponSetting.curMagazine);

    }

    public void StartWeaponAction(int type = 0)
    {
        if (isReload == true)
            return;

        if (type == 0)
        {
            if (weaponSetting.isAutoAttack == true)//���� ����
            {
                StartCoroutine("OnAttackLoop");

            }
            else //�ܹ߰���
            {
                OnAttack();
            }
        }
    }
   public void StopWeaponAction(int type = 0)
    {
        if (type == 0)
        {
            StopCoroutine("OnAttackLoop");
        }
    } 
    
    private IEnumerator OnAttackLoop()
    {
        while (true)
        {
            OnAttack();

            yield return null;
        }
    }
    public void StartReload()
    {
        Debug.Log("������");
        if(isReload == true || weaponSetting.curMagazine <=0)
            return ;

        StopWeaponAction();
        StartCoroutine("OnReload");
       
    }
public void OnAttack()
    {
        if (Time.time - lastAttckTime > weaponSetting.attackRate)
        {
            Debug.Log("�߻� ");
            lastAttckTime = Time.time;
            Instantiate(Bullet, FirePos.transform.position, FirePos.transform.rotation);
            if (weaponSetting.currentAmmo <= 0)
            {
                return;
            }
            weaponSetting.currentAmmo--;
            onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);
            PlaySound(auclFire);
            StartCoroutine("OnMuzzleFlashEffect");

        }
    }


    public IEnumerator OnReload()
    { 
        isReload = true;

        PlaySound(auclReload); 

        while (true)
        {
            if (audioSource.isPlaying == false)
            { 
                isReload =false;

                weaponSetting.curMagazine--;
                onMagazineEvent.Invoke(weaponSetting.curMagazine);

                weaponSetting.currentAmmo = weaponSetting.maxAmmo;
                onAmmoEvent.Invoke(weaponSetting.currentAmmo, weaponSetting.maxAmmo);

                yield break;
            }
            yield return null;
        }
        
        
        
    }

    private IEnumerator OnMuzzleFlashEffect()
    {
        muzzleFlashEffect.SetActive(true);
        yield return new WaitForSeconds(weaponSetting.attackRate * 0.3f);
        muzzleFlashEffect.SetActive(false);
    }


    private void PlaySound(AudioClip clip)
    {
        audioSource.Stop();
        audioSource.clip = clip;
        audioSource.Play();
    }


}
