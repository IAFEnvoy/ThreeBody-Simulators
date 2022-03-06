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
    GetComponent<Button>().onClick.AddListener(Click);
  }

  private void Click()
  {
    menu.GetComponent<CanvasGroup>().alpha = 1 - menu.GetComponent<CanvasGroup>().alpha;
    menu.GetComponent<CanvasGroup>().interactable ^= true;
    menu.GetComponent<CanvasGroup>().blocksRaycasts ^= true;
    CameraMove.enable ^= true;
  }
}
