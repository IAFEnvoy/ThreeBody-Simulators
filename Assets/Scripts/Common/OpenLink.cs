using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
  public string LinkURL = "";

  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    if (Application.platform == RuntimePlatform.Android)
    {
      AndroidJavaClass jc = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
      AndroidJavaObject jo = jc.GetStatic<AndroidJavaObject>("currentActivity");
      jo.Call("openURL", LinkURL);
    }
    else
      Process.Start(LinkURL);
  }
}
