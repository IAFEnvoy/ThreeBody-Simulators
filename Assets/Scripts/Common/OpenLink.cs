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
    Process.Start(LinkURL);
  }
}
