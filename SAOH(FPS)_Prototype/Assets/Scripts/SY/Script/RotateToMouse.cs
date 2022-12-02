using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateToMouse : MonoBehaviour
{
    [SerializeField]
    private float rotCamXSpeed = 5;
    [SerializeField]
    private float rotCamYSpeed = 3;

    private float limitMinX = -80;
    private float limitMaxX = 50;
    private float eulAngleX;
    private float eulAngleY;

    public void UpdateRotate(float mouseX, float mouseY)
    {
        eulAngleY += mouseX * rotCamYSpeed;
        eulAngleX -= mouseY * rotCamXSpeed;

        eulAngleX = ClampAngle(eulAngleX, limitMinX, limitMaxX);

        transform.rotation = Quaternion.Euler(eulAngleX, eulAngleY, 0);
    }

    private float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360)
            angle += 360;
        if (angle > 360) 
            angle -= 360;

        return Mathf.Clamp(angle, min, max);
    }



}
