using UnityEngine;

public class IKSnap : MonoBehaviour
{
    public bool useIK;
    public bool leftHandIK;
    public bool rightHandIK;
    private Animator anim;
    public Vector3 leftHandPos;
    public Vector3 rightHandPos;
    public Vector3 leftHandOffset;
    public Vector3 rightHandOffset;
    public Quaternion leftHandRot;
    public Quaternion rightHandRot;
    public Vector3 leftHandOriginalPos;
    public Vector3 rightHandOriginalPos;

    public bool leftFootIK;
    public bool rightFootIK;
    public Vector3 leftFootPos;
    public Vector3 rightFootPos;
    public Vector3 leftFootOffset;
    public Vector3 rightFootOffset;
    public Quaternion leftFootRot;
    public Quaternion rightFootRot;
    public Quaternion leftFootRotOffset;
    public Quaternion rightFootRotOffset;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        RaycastHit lHit;
        RaycastHit rHit;
        RaycastHit lfHit;
        RaycastHit rfHit;

        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(-0.5f, 0.0f, 0.0f), out lHit, 1f))
        {
            leftHandIK = true;
            leftHandPos = lHit.point - leftHandOffset;
            leftHandPos.x = leftHandOriginalPos.x;
            leftHandPos.z = leftFootPos.z - leftHandOffset.z;
            leftHandRot = Quaternion.FromToRotation(Vector3.forward, lHit.normal);
        }
        else
        {
            leftHandIK = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), out rHit, 1f))
        {
            rightHandIK = true;
            rightHandPos = rHit.point - rightHandOffset;
            rightHandPos.x = rightHandOriginalPos.x;
            rightHandPos.z = rightFootPos.z - rightHandOffset.z;
            rightHandRot = Quaternion.FromToRotation(Vector3.forward, rHit.normal);
        }
        else
        {
            rightHandIK = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(-0.3f, 0.75f, 0.0f), transform.forward, out lfHit, 1f))
        {
            leftFootIK = true;
            leftFootPos = lfHit.point - leftFootOffset;
            leftFootRot = (Quaternion.FromToRotation(Vector3.up, lfHit.normal)) * leftFootRotOffset;
        }
        else
        {
            leftFootIK = false;
        }

        if (Physics.Raycast(transform.position + new Vector3(0.2f, 0.8f, 0.0f), transform.forward, out rfHit, 1f))
        {
            rightFootIK = true;
            rightFootPos = rfHit.point - rightFootOffset;
            rightFootRot = (Quaternion.FromToRotation(Vector3.up, rfHit.normal)) * rightFootRotOffset;
        }
        else
        {
            rightFootIK = false;
        }
    }

    private void Update()
    {
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(-0.5f, 0.0f, 0.0f), Color.green);
        Debug.DrawRay(transform.position + new Vector3(0.0f, 2.0f, 0.5f), -transform.up + new Vector3(0.5f, 0.0f, 0.0f), Color.green);
        Debug.DrawRay(transform.position + new Vector3(-0.3f, 0.75f, 0.0f), transform.forward, Color.red);
        Debug.DrawRay(transform.position + new Vector3(0.2f, 0.8f, 0.0f), transform.forward, Color.red);
    }

    private void OnAnimatorIK(int layerIndex)
    {
        if (useIK)
        {
            leftHandOriginalPos = anim.GetIKPosition(AvatarIKGoal.LeftHand);
            rightHandOriginalPos = anim.GetIKPosition(AvatarIKGoal.RightHand);
            if (leftHandIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHandPos);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1f);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHandRot);
            }

            if (rightHandIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, 1f);
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHandPos);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, 1f);
                anim.SetIKRotation(AvatarIKGoal.RightHand, rightHandRot);
            }

            if (leftFootIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
                anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftFootPos);
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1f);
                anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftFootRot);
            }

            if (rightFootIK)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
                anim.SetIKPosition(AvatarIKGoal.RightFoot, rightFootPos);
                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1f);
                anim.SetIKRotation(AvatarIKGoal.RightFoot, rightFootRot);
            }
        }
    }
}