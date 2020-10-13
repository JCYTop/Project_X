using UnityEngine;

public class Crosshair : MonoBehaviour
{
    [SerializeField] private Texture2D image;
    [SerializeField] private int size;
    [SerializeField] private float maxAngle;
    [SerializeField] private float minAngle;
    private float lookHeight;

    public void LookHeight(float value)
    {
        // lookHeight += value;
        // if (lookHeight > maxAngle || lookHeight < minAngle)
        //     lookHeight -= value;
    }

    private void OnGUI()
    {
        var screenPosition = Camera.main.WorldToScreenPoint(transform.position);
        screenPosition.y = Screen.height - screenPosition.y;
        GUI.DrawTexture(new Rect(screenPosition.x, screenPosition.y - lookHeight, size, size), image);
    }
}