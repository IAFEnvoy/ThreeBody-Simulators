using UnityEngine;
using UnityEngine.UI;

public class Resume : MonoBehaviour
{
    public GameObject Object;

    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        Object.GetComponent<CanvasGroup>().alpha = 0;
        Object.GetComponent<CanvasGroup>().interactable = false;
        Object.GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
