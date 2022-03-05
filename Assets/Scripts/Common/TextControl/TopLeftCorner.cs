using UnityEngine;

public class TopLeftCorner : MonoBehaviour
{
    private int width, height;

    private void Update()
    {
        width = Screen.width;
        height = Screen.height;
        transform.localPosition = new Vector3(-width / 2 + GetComponent<RectTransform>().rect.width / 2, height / 2 - GetComponent<RectTransform>().rect.height / 2, 0);
    }
}
