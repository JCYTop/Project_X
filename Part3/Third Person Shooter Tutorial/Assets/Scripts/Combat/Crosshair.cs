using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D image;
    [SerializeField] private int size;

    private void OnGUI()
    {
        if (GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMING ||
            GameManager.Instance.LocalPlayer.PlayerState.WeaponState == PlayerState.EWeaponState.AIMEDFIRING)
        {
            var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
            screenPosition.y = Screen.height - screenPosition.y;
            GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y, size, size), image);
        }
    }
}