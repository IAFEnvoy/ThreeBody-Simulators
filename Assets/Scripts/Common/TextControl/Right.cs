using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Right : MonoBehaviour
{
  private int width, height;

  void Update()
  {
    width = Screen.width;
    height = Screen.height;
    transform.position = new Vector3(width - GetComponent<RectTransform>().rect.width / 2 - 20, transform.position.y, 0);
  }
}
