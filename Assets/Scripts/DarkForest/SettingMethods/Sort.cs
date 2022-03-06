using UnityEngine;
using UnityEngine.UI;

public class Sort : MonoBehaviour
{
  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    DFCalculate.sortscore ^= true;
  }
}
