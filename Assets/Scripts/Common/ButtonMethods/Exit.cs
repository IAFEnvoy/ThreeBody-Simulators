using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
  public GameObject menu;
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        if (menu.GetComponent<CanvasGroup>().alpha == 0)
            return;
        UnityEngine.Application.Quit();
        if (Application.platform == RuntimePlatform.WindowsEditor)
            Debug.Log("检测到为编辑器环境，将不执行快速关闭代码");
        else
            System.Diagnostics.Process.GetCurrentProcess().Kill();
    }
}
