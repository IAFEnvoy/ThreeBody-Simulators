using System;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
  public static double a, b, distance;
  public static bool enable = true;

  private void Start()
  {
    distance = 200;
    setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
    transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0) - transform.position), 10);
  }

  public void setplace(float x, float y, float z)
  {
    Vector3 vec = new Vector3(x, y, z);
    if (transform.parent == null)
      transform.position = vec;
    else
      transform.position = vec + transform.parent.position;
  }

  private Vector2 now = new Vector2();
  private float touchDistance = -1;

  private void Update()
  {
    if (!enable) return;
    if (Input.GetMouseButtonDown(0))
    {
      now = Input.mousePosition;
      return;
    }
    if (Input.GetMouseButton(0))
    {
      Vector2 new1 = Input.mousePosition;
      a -= (new1.x - now.x) * 0.01;
      b -= (new1.y - now.y) * 0.004;
      if (b <= -Math.PI / 2)
        b = -Math.PI / 2 + 0.04;
      if (b >= Math.PI / 2)
        b = Math.PI / 2 - 0.04;
      setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
      if (transform.parent == null)
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(new Vector3(0, 0, 0) - transform.position), 10);
      else
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(transform.parent.position - transform.position), 10);
      now = new1;
      return;
    }
    if (Input.GetAxis("Mouse ScrollWheel") != 0)
    {
      distance -= Input.mouseScrollDelta.y * 50;
      if (distance < 50)
        distance = 50;
    }
    if ((Input.touchCount == 2) && (Input.GetTouch(0).phase == TouchPhase.Moved || Input.GetTouch(1).phase == TouchPhase.Moved))
      if (touchDistance == -1)
        touchDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
      else
      {
        float newDistance = Vector2.Distance(Input.GetTouch(0).position, Input.GetTouch(1).position);
        distance -= (newDistance - touchDistance) * 20;
        touchDistance = newDistance;
      }
    else
      touchDistance = -1;
    setplace((float)Math.Cos(a) * (float)Math.Cos(b) * (float)distance, (float)Math.Sin(b) * (float)distance, (float)Math.Sin(a) * (float)Math.Cos(b) * (float)distance);
  }
}
