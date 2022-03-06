using UnityEngine;
using UnityEngine.UI;

public class LandPlanet : MonoBehaviour
{
  void Start()
  {
    GetComponent<Button>().onClick.AddListener(Click);
  }

  void Click()
  {
    Land.enable ^= true;
  }
}
