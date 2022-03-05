using System;
using UnityEngine;

public class TBPCamera : MonoBehaviour
{
  enum RotationAxes { MouseXAndY, MouseX, MouseY }
  RotationAxes axes = RotationAxes.MouseXAndY;
  float sensitivityX = 15, sensitivityY = 15;
  float minimumY = -80, maximumY = 80;
  private float rotationY = 0;
  public static GameObject planet = null;

  void Update()
  {
    if (Input.GetMouseButton(0))
    {
      if (axes == RotationAxes.MouseXAndY)
      {
        float rotationX = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
      }
      else if (axes == RotationAxes.MouseX)
        transform.Rotate(0, Input.GetAxis("Mouse X") * sensitivityX, 0);
      else
      {
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(-rotationY, transform.localEulerAngles.y, 0);
      }
    }
    transform.position = new Vector3(1, 0, 0) + planet.transform.position;
  }
}
