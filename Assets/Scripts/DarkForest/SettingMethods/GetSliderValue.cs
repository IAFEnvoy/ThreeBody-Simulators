using System;
using UnityEngine;
using UnityEngine.UI;

public class GetSliderValue : MonoBehaviour
{
  public int RoundDigit = 0;
  public bool ToBoolValue = false;

  void Update()
  {
    if (GameObject.Find("Setting/"+name+"/Slider") == null) return;
    if (GameObject.Find("Setting/"+name+"/Value") == null) return;
    if (ToBoolValue) GameObject.Find("Setting/"+name+"/Value").GetComponent<Text>().text = GameObject.Find("Setting/"+name+"/Slider").GetComponent<Slider>().value == 0 ? "否" : "是";
    else GameObject.Find("Setting/"+name+"/Value").GetComponent<Text>().text = Math.Round(GameObject.Find("Setting/"+name+"/Slider").GetComponent<Slider>().value, RoundDigit).ToString();
  }
}
