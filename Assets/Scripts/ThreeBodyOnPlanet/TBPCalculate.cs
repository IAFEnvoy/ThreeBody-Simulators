using System;
using UnityEngine;
using UnityEngine.UI;

public class TBPCalculate : MonoBehaviour
{
  public Material red, blue, green, white, sun, planett;
  public Font font;
  private GameObject starA, starB, starC, planet;
  public static double time;
  private double r1, r2, r3, f1, f2, f3;
  private double r4, r5, r6, f4, f5, f6;
  public static bool run = true;
  public static bool reload = false;
  public struct Star
  {
    public float x, y, z;
    public float vx, vy, vz;
    public float m;
  }

  private double Temp()
  {
    double t1 = Math.Sqrt(Math.Sqrt(38.6 / ((s1.x - sp.x) * (s1.x - sp.x) + (s1.y - sp.y) * (s1.y - sp.y) + (s1.z - sp.z) * (s1.z - sp.z)))) * s1.m * 4;
    double t2 = Math.Sqrt(Math.Sqrt(38.6 / ((s2.x - sp.x) * (s2.x - sp.x) + (s2.y - sp.y) * (s2.y - sp.y) + (s2.z - sp.z) * (s2.z - sp.z)))) * s2.m * 4;
    double t3 = Math.Sqrt(Math.Sqrt(38.6 / ((s3.x - sp.x) * (s3.x - sp.x) + (s3.y - sp.y) * (s3.y - sp.y) + (s3.z - sp.z) * (s3.z - sp.z)))) * s3.m * 4;
    return (t1 + t2 + t3) / 3 - 273.15;
  }

  private Star s1, s2, s3, sp;

  private void Start()
  {
    init();
  }

  private void init()//初始化
  {
    try { Destroy(GameObject.Find("Stars/starA").gameObject); } catch { }
    try { Destroy(GameObject.Find("Stars/starB").gameObject); } catch { }
    try { Destroy(GameObject.Find("Stars/starC").gameObject); } catch { }
    try { Destroy(GameObject.Find("Stars/planet").gameObject); } catch { }
    time = 0; run = true;

    starA = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starA.name = "starA";
    starA.transform.position = new Vector3((float)TBInit.x1, (float)TBInit.y1, (float)TBInit.z1);
    starA.transform.localScale = new Vector3(5, 5, 5);
    // starA.AddComponent<HighlightableObject>();
    // starA.AddComponent<HighLightControlYellow>();
    starA.AddComponent<TrailRenderer>();
    starA.GetComponent<TrailRenderer>().material = red;
    starA.GetComponent<Renderer>().material = sun;
    starA.AddComponent<Rigidbody>();
    starA.GetComponent<Rigidbody>().mass = (float)TBInit.m1;
    starA.GetComponent<Rigidbody>().drag = 0;
    starA.GetComponent<Rigidbody>().angularDrag = 0;
    starA.GetComponent<Rigidbody>().useGravity = false;
    starA.GetComponent<Rigidbody>().velocity = new Vector3((float)TBInit.vx1, (float)TBInit.vy1, (float)TBInit.vz1);
    starA.AddComponent<ConstantForce>();
    starA.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    s1.x = (float)TBInit.x1; s1.y = (float)TBInit.y1; s1.z = (float)TBInit.z1;
    s1.vx = (float)TBInit.vx1; s1.vy = (float)TBInit.vy1; s1.vz = (float)TBInit.vz1;
    s1.m = (float)TBInit.m1;

    starB = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starB.name = "starB";
    starB.transform.position = new Vector3((float)TBInit.x2, (float)TBInit.y2, (float)TBInit.z2);
    starB.transform.localScale = new Vector3(5, 5, 5);
    // starB.AddComponent<HighlightableObject>();
    // starB.AddComponent<HighLightControlYellow>();
    starB.AddComponent<TrailRenderer>();
    starB.GetComponent<TrailRenderer>().material = blue;
    starB.GetComponent<Renderer>().material = sun;
    starB.AddComponent<Rigidbody>();
    starB.GetComponent<Rigidbody>().mass = (float)TBInit.m2;
    starB.GetComponent<Rigidbody>().drag = 0;
    starB.GetComponent<Rigidbody>().angularDrag = 0;
    starB.GetComponent<Rigidbody>().useGravity = false;
    starB.GetComponent<Rigidbody>().velocity = new Vector3((float)TBInit.vx2, (float)TBInit.vy2, (float)TBInit.vz2);
    starB.AddComponent<ConstantForce>();
    starB.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    s2.x = (float)TBInit.x2; s2.y = (float)TBInit.y2; s2.z = (float)TBInit.z2;
    s2.vx = (float)TBInit.vx2; s2.vy = (float)TBInit.vy2; s2.vz = (float)TBInit.vz2;
    s2.m = (float)TBInit.m2;

    starC = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starC.name = "starC";
    starC.transform.position = new Vector3((float)TBInit.x3, (float)TBInit.y3, (float)TBInit.z3);
    starC.transform.localScale = new Vector3(5, 5, 5);
    // starC.AddComponent<HighlightableObject>();
    // starC.AddComponent<HighLightControlYellow>();
    starC.AddComponent<TrailRenderer>();
    starC.GetComponent<TrailRenderer>().material = green;
    starC.GetComponent<Renderer>().material = sun;
    starC.AddComponent<Rigidbody>();
    starC.GetComponent<Rigidbody>().mass = (float)TBInit.m3;
    starC.GetComponent<Rigidbody>().drag = 0;
    starC.GetComponent<Rigidbody>().angularDrag = 0;
    starC.GetComponent<Rigidbody>().useGravity = false;
    starC.GetComponent<Rigidbody>().velocity = new Vector3((float)TBInit.vx3, (float)TBInit.vy3, (float)TBInit.vz3);
    starC.AddComponent<ConstantForce>();
    starC.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    s3.x = (float)TBInit.x3; s3.y = (float)TBInit.y3; s3.z = (float)TBInit.z3;
    s3.vx = (float)TBInit.vx3; s3.vy = (float)TBInit.vy3; s3.vz = (float)TBInit.vz3;
    s3.m = (float)TBInit.m3;

    planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    planet.name = "planet";
    planet.transform.position = new Vector3((float)TBInit.xp, (float)TBInit.yp, (float)TBInit.zp);
    planet.transform.localScale = new Vector3(1, 1, 1);
    // planet.AddComponent<HighlightableObject>();
    // planet.AddComponent<HighLightControlYellow>();
    planet.AddComponent<TrailRenderer>();
    planet.GetComponent<TrailRenderer>().material = white;
    planet.GetComponent<Renderer>().material = planett;
    planet.AddComponent<Rigidbody>();
    planet.GetComponent<Rigidbody>().mass = (float)TBInit.mp;
    planet.GetComponent<Rigidbody>().drag = 0;
    planet.GetComponent<Rigidbody>().angularDrag = 0;
    planet.GetComponent<Rigidbody>().useGravity = false;
    planet.GetComponent<Rigidbody>().velocity = new Vector3((float)TBInit.vxp, (float)TBInit.vyp, (float)TBInit.vzp);
    planet.AddComponent<ConstantForce>();
    planet.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    sp.x = (float)TBInit.xp; sp.y = (float)TBInit.yp; sp.z = (float)TBInit.zp;
    sp.vx = (float)TBInit.vxp; sp.vy = (float)TBInit.vyp; sp.vz = (float)TBInit.vzp;
    sp.m = (float)TBInit.mp;
    planet.AddComponent<Rotate>();
    planet.GetComponent<Rotate>().rotate_delta = 22;

    TBPCamera.planet = planet;

    reload = false;
  }

  private void Update()
  {
    if (reload)
      init();

    if (!run)
    {
      try { starA.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0); } catch { }
      try { starB.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0); } catch { }
      try { starC.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0); } catch { }
      try { planet.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0); } catch { }
      return;
    }

    time += 0.1;
    double t = Temp();
    GameObject.Find("Canvas/Temp").GetComponent<Text>().text =
      (t > TBInit.maxtemp ? "<color=#FF0000>" : t < TBInit.mintemp ? "<color=#00BFFF>" : "<color=#00FF00>")
      + "行星表面温度:" + Math.Round(t, 2).ToString() + "℃</color>";

    //读取数据
    s1.x = starA.GetComponent<Transform>().position.x; s1.y = starA.GetComponent<Transform>().position.y; s1.z = starA.GetComponent<Transform>().position.z;
    s1.vx = starA.GetComponent<Rigidbody>().velocity.x; s1.vy = starA.GetComponent<Rigidbody>().velocity.y; s1.vz = starA.GetComponent<Rigidbody>().velocity.z;
    s1.m = starA.GetComponent<Rigidbody>().mass;
    s2.x = starB.GetComponent<Transform>().position.x; s2.y = starB.GetComponent<Transform>().position.y; s2.z = starB.GetComponent<Transform>().position.z;
    s2.vx = starB.GetComponent<Rigidbody>().velocity.x; s2.vy = starB.GetComponent<Rigidbody>().velocity.y; s2.vz = starB.GetComponent<Rigidbody>().velocity.z;
    s2.m = starB.GetComponent<Rigidbody>().mass;
    s3.x = starC.GetComponent<Transform>().position.x; s3.y = starC.GetComponent<Transform>().position.y; s3.z = starC.GetComponent<Transform>().position.z;
    s3.vx = starC.GetComponent<Rigidbody>().velocity.x; s3.vy = starC.GetComponent<Rigidbody>().velocity.y; s3.vz = starC.GetComponent<Rigidbody>().velocity.z;
    s3.m = starC.GetComponent<Rigidbody>().mass;
    sp.x = planet.GetComponent<Transform>().position.x; sp.y = planet.GetComponent<Transform>().position.y; sp.z = planet.GetComponent<Transform>().position.z;
    sp.vx = planet.GetComponent<Rigidbody>().velocity.x; sp.vy = planet.GetComponent<Rigidbody>().velocity.y; sp.vz = planet.GetComponent<Rigidbody>().velocity.z;
    sp.m = planet.GetComponent<Rigidbody>().mass;

    //距离计算
    r1 = Math.Sqrt((s1.x - s2.x) * (s1.x - s2.x) + (s1.y - s2.y) * (s1.y - s2.y) + (s1.z - s2.z) * (s1.z - s2.z));//1,2
    r2 = Math.Sqrt((s3.x - s2.x) * (s3.x - s2.x) + (s3.y - s2.y) * (s3.y - s2.y) + (s3.z - s2.z) * (s3.z - s2.z));//2,3
    r3 = Math.Sqrt((s1.x - s3.x) * (s1.x - s3.x) + (s1.y - s3.y) * (s1.y - s3.y) + (s1.z - s3.z) * (s1.z - s3.z));//3,1
    r4 = Math.Sqrt((s1.x - sp.x) * (s1.x - sp.x) + (s1.y - sp.y) * (s1.y - sp.y) + (s1.z - sp.z) * (s1.z - sp.z));//1
    r5 = Math.Sqrt((sp.x - s2.x) * (sp.x - s2.x) + (sp.y - s2.y) * (sp.y - s2.y) + (sp.z - s2.z) * (sp.z - s2.z));//2
    r6 = Math.Sqrt((sp.x - s3.x) * (sp.x - s3.x) + (sp.y - s3.y) * (sp.y - s3.y) + (sp.z - s3.z) * (sp.z - s3.z));//3

    //引力公式：F=G*M*m/R
    f1 = TBInit.g * s1.m * s2.m / r1;
    f2 = TBInit.g * s3.m * s2.m / r2;
    f3 = TBInit.g * s1.m * s3.m / r3;
    f4 = TBInit.g * s1.m * sp.m / r4;
    f5 = TBInit.g * s2.m * sp.m / r5;
    f6 = TBInit.g * s3.m * sp.m / r6;

    //计算每个星体在x,y,z方向上受到的引力并回写，力的空间正交分解
    starA.GetComponent<ConstantForce>().force = new Vector3((float)(f1 / r1 * (s2.x - s1.x) + f3 / r3 * (s3.x - s1.x)),
        (float)(f1 / r1 * (s2.y - s1.y) + f3 / r3 * (s3.y - s1.y)), (float)(f1 / r1 * (s2.z - s1.z) + f3 / r3 * (s3.z - s1.z)));
    starB.GetComponent<ConstantForce>().force = new Vector3((float)(f1 / r1 * (s1.x - s2.x) + f2 / r2 * (s3.x - s2.x)),
        (float)(f1 / r1 * (s1.y - s2.y) + f2 / r2 * (s3.y - s2.y)), (float)(f1 / r1 * (s1.z - s2.z) + f2 / r2 * (s3.z - s2.z)));
    starC.GetComponent<ConstantForce>().force = new Vector3((float)(f2 / r2 * (s2.x - s3.x) + f3 / r3 * (s1.x - s3.x)),
        (float)(f2 / r2 * (s2.y - s3.y) + f3 / r3 * (s1.y - s3.y)), (float)(f2 / r2 * (s2.z - s3.z) + f3 / r3 * (s1.z - s3.z)));
    planet.GetComponent<ConstantForce>().force = new Vector3(
        (float)(f4 / r4 * (s1.x - sp.x) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.x - sp.x)),
        (float)(f4 / r4 * (s1.y - sp.y) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.y - sp.y)),
        (float)(f4 / r4 * (s1.z - sp.z) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.z - sp.z)));
  }
}
