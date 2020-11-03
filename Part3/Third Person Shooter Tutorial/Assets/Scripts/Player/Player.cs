using System;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
[RequireComponent(typeof(PlayerState))]
public class Player : MonoBehaviour
{
    [Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
        public bool LockMouse;
    }

    [SerializeField] private float runSpeed;
    [SerializeField] private float walkSpeed;
    [SerializeField] private float crouchSpeed;
    [SerializeField] private float sprintSpeed;
    [SerializeField] private MouseInput MouseControl;
    [SerializeField] private AudioController footSteps;
    [SerializeField] private float minimumMoveTreshold;
    public PlayerAim PlayerAim;
    private Vector3 previousPosition;
    private MoveController m_MoveController;
    private PlayerShoot playerShoot;

    public PlayerShoot PlayerShoot
    {
        get
        {
            if (playerShoot == null)
            {
                playerShoot = GetComponent<PlayerShoot>();
            }

            return playerShoot;
        }
    }

    public MoveController MoveController
    {
        get
        {
            if (m_MoveController == null)
            {
                m_MoveController = GetComponent<MoveController>();
            }

            return m_MoveController;
        }
    }

    private PlayerState m_PlayerState;

    public PlayerState PlayerState
    {
        get
        {
            if (m_PlayerState == null)
                m_PlayerState = GetComponentInChildren<PlayerState>();
            return m_PlayerState;
        }
    }

    private InputController playerInput;
    private Vector2 mouseInput;

    private void Start()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
        if (MouseControl.LockMouse)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }
    }

    private void Update()
    {
        Move();
        LookAround();
    }

    private void Move()
    {
        var moveSpeed = runSpeed;
        if (playerInput.IsWalking)
            moveSpeed = walkSpeed;
        if (playerInput.IsSprinting)
            moveSpeed = sprintSpeed;
        if (playerInput.IsCrouched)
            moveSpeed = crouchSpeed;
        var direction = new Vector2(playerInput.Vertical * moveSpeed, playerInput.Horizontal * moveSpeed);
        MoveController.Move(direction);
        if (Vector3.Distance(transform.position, previousPosition) > minimumMoveTreshold)
            footSteps.Play();
        previousPosition = transform.position;
    }

    private void LookAround()
    {
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        mouseInput.y = Mathf.Lerp(mouseInput.y, playerInput.MouseInput.y, 1f / MouseControl.Damping.y);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
        // Crosshair.LookHeight(mouseInput.y * MouseControl.Sensitivity.y);
        PlayerAim.SetRotation(mouseInput.y * MouseControl.Sensitivity.y);
    }
}