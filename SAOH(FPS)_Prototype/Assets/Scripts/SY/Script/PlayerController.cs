using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Input keyCodes")]
    [SerializeField]
    private KeyCode keyCodeRun = KeyCode.LeftShift;//�޸���
    [SerializeField]
    private KeyCode keyCodeJump = KeyCode.Space;//����
    [SerializeField]
    private KeyCode keyCodeReload = KeyCode.R; //������
    [SerializeField]
    private KeyCode keyCodeBack = KeyCode.F;// �ڷ� ����

    [Header("Audio Clips")]
    [SerializeField]
    private AudioClip audioClipWalk;//�ȱ� ����
    [SerializeField]
    private AudioClip audioClipRun;//�޸��� ����


    private RotateToMouse rotateToMouse;//���콺�� ī�޶� ȸ��
    private MovementCharacterController movement;//�÷��̾� �̵�, ����
    public Status status;//�÷��̾� ����
    private PlayerAnimatorController animator;//�ִϸ��̼�
    private AudioSource audioSource;//����
    private WeaponRifle weapon;//����

    int dir = 0;

    private void Awake()
    {

        rotateToMouse = GetComponent<RotateToMouse>();
        movement = GetComponent<MovementCharacterController>();
        status = GetComponent<Status>();
        animator = GetComponent<PlayerAnimatorController>();
        audioSource = GetComponent<AudioSource>();
        weapon = GetComponentInChildren<WeaponRifle>();
    }

    private void Update()
    {
        UpdateRotate();
        UpdateMove();
        UpdateJump();
        UpdateWeaponAction();
    }

    private void UpdateRotate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        rotateToMouse.UpdateRotate(mouseX, mouseY);
        if (Input.GetKeyDown(keyCodeBack))
        {
            if (dir == 1)
                dir = 0;
            else if (dir == 0)
                dir = 1;
        }
        rotateToMouse.transform.eulerAngles = new Vector3(rotateToMouse.transform.eulerAngles.x, rotateToMouse.transform.eulerAngles.y + (180 * dir), rotateToMouse.transform.eulerAngles.z);

    }

    private void UpdateMove()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (x != 0 || z != 0)
        {
            bool isRun = false;

            if (z > 0)
                isRun = Input.GetKey(keyCodeRun);

            movement.MoveSpeed = isRun == true ? status.RunSpeed : status.WalkSpeed;
            audioSource.clip = isRun == true ? audioClipRun : audioClipWalk;

            if (audioSource.isPlaying == false)
            {
                movement.MoveSpeed = 0;
                audioSource.loop = true;
                audioSource.Play();
            }
        }
        else
        {
            movement.MoveSpeed = 0;

            if (audioSource.isPlaying == true)
            {
                audioSource.Stop();
            }
        }

        movement.MoveTo(new Vector3(x, 0, z));
    }

    private void UpdateJump()
    {
        if (Input.GetKeyDown(keyCodeJump))
        {
            movement.Jump();
        }
    }

    private void UpdateWeaponAction()
    {
        if (Input.GetMouseButtonDown(0))
        {
            weapon.StartWeaponAction();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            weapon.StopWeaponAction();
        }

        if (Input.GetKeyDown(keyCodeReload))
        {
            weapon.StartReload();
        }

    }


}
