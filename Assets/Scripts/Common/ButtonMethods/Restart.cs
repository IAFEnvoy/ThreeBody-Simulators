using UnityEngine;
using UnityEngine.UI;

public class Restart : MonoBehaviour
{
  public GameObject starter, menu;

  private void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
    starter.GetComponent<CanvasGroup>().alpha = 0;
    starter.GetComponent<CanvasGroup>().interactable = false;
    starter.GetComponent<CanvasGroup>().blocksRaycasts = false;
  }

  private void Click()
  {
    if (menu.GetComponent<CanvasGroup>().alpha == 0)
      return;
    menu.GetComponent<CanvasGroup>().alpha = 0;
    menu.GetComponent<CanvasGroup>().interactable = false;
    menu.GetComponent<CanvasGroup>().blocksRaycasts = false;
    starter.GetComponent<CanvasGroup>().alpha = 1;
    starter.GetComponent<CanvasGroup>().interactable = true;
    starter.GetComponent<CanvasGroup>().blocksRaycasts = true;
  }
}
