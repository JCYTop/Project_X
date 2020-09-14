using System;
using UnityEngine;

[RequireComponent(typeof(MoveController))]
public class Player : MonoBehaviour
{
    [Serializable]
    public class MouseInput
    {
        public Vector2 Damping;
        public Vector2 Sensitivity;
    }

    [SerializeField] private float speed;

    [SerializeField] private MouseInput MouseControl;

    private MoveController m_MoveController;

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

    private InputController playerInput;
    private Vector2 mouseInput;

    private void Start()
    {
        playerInput = GameManager.Instance.InputController;
        GameManager.Instance.LocalPlayer = this;
    }

    private void Update()
    {
        var direction = new Vector2(playerInput.Vertical * speed, playerInput.Horizontal * speed);
        MoveController.Move(direction);
        mouseInput.x = Mathf.Lerp(mouseInput.x, playerInput.MouseInput.x, 1f / MouseControl.Damping.x);
        transform.Rotate(Vector3.up * mouseInput.x * MouseControl.Sensitivity.x);
    }
}