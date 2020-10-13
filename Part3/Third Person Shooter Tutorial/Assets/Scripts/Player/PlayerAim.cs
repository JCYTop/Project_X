using System;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public void SetRotation(float amount)
    {
        transform.eulerAngles = new Vector3(transform.eulerAngles.x - amount, transform.eulerAngles.y, transform.eulerAngles.z);
    }

    public float GetAngele()
    {
        return checked(transform.eulerAngles.x);
    }

    public float CheckAngle(float value)
    {
        var angle = value - 180;
        if (angle > 0)
            return angle - 180;
        return angle + 180;
    }
}