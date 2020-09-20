using System;
using UnityEngine;

public class IKSnap : MonoBehaviour
{
    public bool useIK;
    public bool leftHandIK;
    public bool rightHandIK;
    private Animator anim;
    public Vector3 leftHandPos;
    public Vector3 rightHandPos;
    public Quaternion leftHandRot;
    public Quaternion rightHandRot;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit lHit;
        RaycastHit rHit;
        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(-0.5f, 0.0f, 0.0f), out lHit, 1f))
        {
            leftHandIK = true;
            leftHandPos = lHit.point;
        }
        else
            leftHandIK = false;

        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), out rHit, 1f))
        {
            rightHandIK = true;
            rightHandPos = rHit.point;
        }
        else
            rightHandIK = false;
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(-0.5f, 0.0f, 0.0f), Color.green);
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), Color.green);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (useIK)
        {
            if (leftHandIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPos);
            }

            if (rightHandIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPos);
            }
        }
    }
}