using UnityEngine;
using UnityEngine.UI;

public class ShowMenu : MonoBehaviour
{
    public GameObject menu;

    private void Start()
    {
        menu.GetComponent<CanvasGroup>().alpha = 0;
        menu.GetComponent<CanvasGroup>().interactable = false;
        menu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        this.GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        menu.GetComponent<CanvasGroup>().alpha = 1 - menu.GetComponent<CanvasGroup>().alpha;
        menu.GetComponent<CanvasGroup>().interactable = !menu.GetComponent<CanvasGroup>().interactable;
        menu.GetComponent<CanvasGroup>().blocksRaycasts = !menu.GetComponent<CanvasGroup>().blocksRaycasts;
    }
}
