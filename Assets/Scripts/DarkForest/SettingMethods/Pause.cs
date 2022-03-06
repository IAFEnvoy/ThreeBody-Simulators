using UnityEngine;
using UnityEngine.UI;

public class Pause : MonoBehaviour
{
  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
  }
  void Click()
  {
    DFCalculate.execute ^= true;
  }
}
