using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCol : MonoBehaviour
{
    public float initHP = 100.0f;
    public float currHP;
    public float initDP = 0.0f;
    public float currDP;
    public Image bloodImage;
    public WeaponSetting weapon;
    public PlayerHUD playerHUD;
    private WeaponRifle weaponRifle;
    private PlayerController playerController;
    private MovementCharacterController moveCh;
    public bool boolmagazine;
    public int CurMagazine => weapon.curMagazine;
    public Bullet bullet;
    public GameObject topSecret;
    public GameObject missionComplete;

    public bool secret;
    public bool safe;

    private void Start()
    {
        currHP = initHP;
        boolmagazine = false;

    }

    private void OnTriggerEnter(Collider coll)
    {
        if (coll.tag == "EnemyAttack")
        {
            Destroy(coll.gameObject);

            currHP -= 5f;
            Debug.Log("Player HP = " + currHP.ToString());
            StartCoroutine(ShowBloodImage());

            if (currHP <= 0.0f)
            {
                PlayerDie();
            }
        }

        else if (coll.tag == "Sword")
        {
            currHP -= 2.5f;
            Debug.Log("Player HP = " + currHP.ToString());
            StartCoroutine(ShowBloodImage());

            if (currHP <= 0.0f)
            {
                PlayerDie();
            }
        }

        else if (coll.tag == "BossAttack")
        {
            currHP -= 10f;
            Debug.Log("Player HP = " + currHP.ToString());
            StartCoroutine(ShowBloodImage());

            if (currHP <= 0.0f)
            {
                PlayerDie();
            }
        }

        if (coll.tag == "magazine")
        {

            Destroy(coll.gameObject);

            FindObjectOfType<WeaponRifle>().weaponSetting.curMagazine++;

            playerHUD.clone.SetActive(true);

            Debug.Log(playerHUD.weapon.CurMagazine);
        }
        else if (coll.tag == "hp")
        {
            Destroy(coll.gameObject);
            currHP += 30f;
            Debug.Log("Player HP = " + currHP.ToString());
            if (currHP >= initHP)
            {
                currHP = initHP;
            }
        }
        else if (coll.tag == "hp")
        {
            Destroy(coll.gameObject);
            currHP += 5.0f;
            if (currHP >= initHP)
            {
                currHP = initHP;
            }
            Debug.Log("Player HP = " + currHP.ToString());
        }
        else if (coll.tag == "speed")
        {
            Destroy(coll.gameObject);
            Debug.Log(FindObjectOfType<PlayerController>().status.walkSpeed);
            FindObjectOfType<PlayerController>().status.walkSpeed += 3;
            Invoke("MinusWalkSpeed", 2);
            Debug.Log(FindObjectOfType<PlayerController>().status.walkSpeed);

        }
        else if (coll.tag == "damage")
        {
            Destroy(coll.gameObject);
            bullet.damage += 3;
        }
        else if (coll.tag == "secret")
        {
            Destroy(coll.gameObject);
            topSecret.SetActive(true);
            secret = true;
        }

        else if (coll.tag == "safe" && secret == true)
        {
            topSecret.SetActive(false);
            //safe.SetActive(true);
            safe = true;
            Debug.Log("safe´Â " + safe);
            topSecret.SetActive(false);
            missionComplete.SetActive(true);

        }


    }

    public void PlayerDie()
    {
        Debug.Log("Player Die!!");
    }

    IEnumerator ShowBloodImage()
    {
        bloodImage.color = new Color(1, 0, 0 , UnityEngine.Random.Range(0.2f,0.3f));
        yield return new WaitForSeconds(0.2f);
        bloodImage.color = Color.clear;
    }
}
