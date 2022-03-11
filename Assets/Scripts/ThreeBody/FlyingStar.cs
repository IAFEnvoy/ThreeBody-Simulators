using UnityEngine;

public class FlyingStar : MonoBehaviour
{
  public Material white, sun;

  void Update()
  {
    if (!Land.enable){
      GetComponent<Renderer>().material = sun;
      transform.localScale = new Vector3(5, 5, 5);
      return;
    }
    Vector3 vec = Land.planet.transform.position - transform.position;
    if (vec.x * vec.x + vec.y * vec.y + vec.z * vec.z > TBGlobal.flyingStarDistance * TBGlobal.flyingStarDistance)
    {
      GetComponent<Renderer>().material = white;
      transform.localScale = new Vector3(1, 1, 1);
    }
    else
    {
      GetComponent<Renderer>().material = sun;
      transform.localScale = new Vector3(5, 5, 5);
    }
  }
}
