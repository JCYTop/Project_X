using UnityEngine;

public class InputController : MonoBehaviour
{
    public float Vertical;
    public float Horizontal;
    public Vector2 MouseInput;
    public bool Fire1;

    private void Update()
    {
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");
        MouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        Fire1 = Input.GetButton("Fire1");
    }
}