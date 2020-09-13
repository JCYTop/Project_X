using UnityEngine;

public class Player : MonoBehaviour
{
    private InputController inputController;

    private void Start()
    {
        inputController = GameManager.Instance.InputController;
    }

    private void Update()
    {
        Debug.Log($"Horizontal : {inputController.Horizontal}");
        Debug.Log($"Mouse : {inputController.MouseInput}");
    }
}