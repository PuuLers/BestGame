using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{

    [SerializeField] private Joystick JoystickGun;
    private float offset = 90;
    static public float rotZ;
    private float JoystickFireDistance = 0.7f;

    void Start()
    {

    }

    void Update()
    {
        //Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;    äëÿ ÏÊ
        if (Mathf.Abs(JoystickGun.Horizontal) > 0.3f || Mathf.Abs(JoystickGun.Vertical) > 0.3f)
        {
            rotZ = Mathf.Atan2(JoystickGun.Horizontal, JoystickGun.Vertical) * Mathf.Rad2Deg;
        }

        transform.rotation = Quaternion.Euler(0f, 0f, -rotZ + offset);

        Vector3 LocalScale = Vector3.one;
        if (rotZ < 0 || rotZ > 180)
        {
            LocalScale.y = LocalScale.y * -1f;
        }
        else
        {
            LocalScale.y = LocalScale.y * +1f;
        }
        transform.localScale = LocalScale;

        if (JoystickGun.Horizontal > JoystickFireDistance || JoystickGun.Horizontal < -JoystickFireDistance || JoystickGun.Vertical > JoystickFireDistance || JoystickGun.Vertical < -JoystickFireDistance)
        {
            Player.ShootingMode = true;
        }
        else
        {
            Player.ShootingMode = false;
        }

    }
}
