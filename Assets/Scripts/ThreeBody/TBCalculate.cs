using System;
using UnityEngine;
using UnityEngine.UI;

public class TBCalculate : MonoBehaviour
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
    starA.transform.position = new Vector3((float)TBGlobal.x1, (float)TBGlobal.y1, (float)TBGlobal.z1);
    starA.transform.localScale = new Vector3(5, 5, 5);
    // starA.AddComponent<HighlightableObject>();
    // starA.AddComponent<HighLightControlYellow>();
    starA.AddComponent<TrailRenderer>();
    starA.GetComponent<TrailRenderer>().material = red;
    starA.GetComponent<Renderer>().material = sun;
    starA.AddComponent<Rigidbody>();
    starA.GetComponent<Rigidbody>().mass = (float)TBGlobal.m1;
    starA.GetComponent<Rigidbody>().drag = 0;
    starA.GetComponent<Rigidbody>().angularDrag = 0;
    starA.GetComponent<Rigidbody>().useGravity = false;
    starA.GetComponent<Rigidbody>().velocity = new Vector3((float)TBGlobal.vx1, (float)TBGlobal.vy1, (float)TBGlobal.vz1);
    starA.AddComponent<ConstantForce>();
    starA.AddComponent<BoomControl>();
    starA.GetComponent<BoomControl>().mainCamera=GameObject.Find("Main Camera").GetComponent<Camera>();
    starA.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    s1.x = (float)TBGlobal.x1; s1.y = (float)TBGlobal.y1; s1.z = (float)TBGlobal.z1;
    s1.vx = (float)TBGlobal.vx1; s1.vy = (float)TBGlobal.vy1; s1.vz = (float)TBGlobal.vz1;
    s1.m = (float)TBGlobal.m1;
    GameObject ta = new GameObject();
    ta.AddComponent<SeeCamera>();
    ta.name = "Text";
    ta.transform.parent = starA.transform;
    ta.transform.localPosition = new Vector3(0, 0, 0);
    GameObject texta = new GameObject();
    texta.name = "_Text";
    texta.AddComponent<TextMesh>();
    texta.GetComponent<TextMesh>().text = "恒星A";
    texta.GetComponent<TextMesh>().fontSize = 20;
    texta.AddComponent<FontControl>();
    texta.transform.parent = ta.transform;
    texta.transform.localPosition = new Vector3(5, 0, 0);

    starB = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starB.name = "starB";
    starB.transform.position = new Vector3((float)TBGlobal.x2, (float)TBGlobal.y2, (float)TBGlobal.z2);
    starB.transform.localScale = new Vector3(5, 5, 5);
    // starB.AddComponent<HighlightableObject>();
    // starB.AddComponent<HighLightControlYellow>();
    starB.AddComponent<TrailRenderer>();
    starB.GetComponent<TrailRenderer>().material = blue;
    starB.GetComponent<Renderer>().material = sun;
    starB.AddComponent<Rigidbody>();
    starB.GetComponent<Rigidbody>().mass = (float)TBGlobal.m2;
    starB.GetComponent<Rigidbody>().drag = 0;
    starB.GetComponent<Rigidbody>().angularDrag = 0;
    starB.GetComponent<Rigidbody>().useGravity = false;
    starB.GetComponent<Rigidbody>().velocity = new Vector3((float)TBGlobal.vx2, (float)TBGlobal.vy2, (float)TBGlobal.vz2);
    starB.AddComponent<ConstantForce>();
    starB.AddComponent<BoomControl>();
    starB.GetComponent<BoomControl>().mainCamera=GameObject.Find("Main Camera").GetComponent<Camera>();
    starB.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    s2.x = (float)TBGlobal.x2; s2.y = (float)TBGlobal.y2; s2.z = (float)TBGlobal.z2;
    s2.vx = (float)TBGlobal.vx2; s2.vy = (float)TBGlobal.vy2; s2.vz = (float)TBGlobal.vz2;
    s2.m = (float)TBGlobal.m2;
    GameObject tb = new GameObject();
    tb.AddComponent<SeeCamera>();
    tb.name = "Text";
    tb.transform.parent = starB.transform;
    tb.transform.localPosition = new Vector3(0, 0, 0);
    GameObject textb = new GameObject();
    textb.name = "_Text";
    textb.AddComponent<TextMesh>();
    textb.GetComponent<TextMesh>().text = "恒星B";
    textb.GetComponent<TextMesh>().fontSize = 20;
    textb.AddComponent<FontControl>();
    textb.transform.parent = tb.transform;
    textb.transform.localPosition = new Vector3(5, 0, 0);

    starC = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starC.name = "starC";
    starC.transform.position = new Vector3((float)TBGlobal.x3, (float)TBGlobal.y3, (float)TBGlobal.z3);
    starC.transform.localScale = new Vector3(5, 5, 5);
    // starC.AddComponent<HighlightableObject>();
    // starC.AddComponent<HighLightControlYellow>();
    starC.AddComponent<TrailRenderer>();
    starC.GetComponent<TrailRenderer>().material = green;
    starC.GetComponent<Renderer>().material = sun;
    starC.AddComponent<Rigidbody>();
    starC.GetComponent<Rigidbody>().mass = (float)TBGlobal.m3;
    starC.GetComponent<Rigidbody>().drag = 0;
    starC.GetComponent<Rigidbody>().angularDrag = 0;
    starC.GetComponent<Rigidbody>().useGravity = false;
    starC.GetComponent<Rigidbody>().velocity = new Vector3((float)TBGlobal.vx3, (float)TBGlobal.vy3, (float)TBGlobal.vz3);
    starC.AddComponent<ConstantForce>();
    starC.AddComponent<BoomControl>();
    starC.GetComponent<BoomControl>().mainCamera=GameObject.Find("Main Camera").GetComponent<Camera>();
    starC.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    s3.x = (float)TBGlobal.x3; s3.y = (float)TBGlobal.y3; s3.z = (float)TBGlobal.z3;
    s3.vx = (float)TBGlobal.vx3; s3.vy = (float)TBGlobal.vy3; s3.vz = (float)TBGlobal.vz3;
    s3.m = (float)TBGlobal.m3;
    GameObject tc = new GameObject();
    tc.AddComponent<SeeCamera>();
    tc.name = "Text";
    tc.transform.parent = starC.transform;
    tc.transform.localPosition = new Vector3(0, 0, 0);
    GameObject textc = new GameObject();
    textc.name = "_Text";
    textc.AddComponent<TextMesh>();
    textc.GetComponent<TextMesh>().text = "恒星C";
    textc.GetComponent<TextMesh>().fontSize = 20;
    textc.AddComponent<FontControl>();
    textc.transform.parent = tc.transform;
    textc.transform.localPosition = new Vector3(5, 0, 0);

    if (!TBGlobal.enablep)
      return;

    planet = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    planet.name = "planet";
    planet.transform.position = new Vector3((float)TBGlobal.xp, (float)TBGlobal.yp, (float)TBGlobal.zp);
    planet.transform.localScale = new Vector3(1, 1, 1);
    // planet.AddComponent<HighlightableObject>();
    // planet.AddComponent<HighLightControlYellow>();
    planet.AddComponent<TrailRenderer>();
    planet.GetComponent<TrailRenderer>().material = white;
    planet.GetComponent<Renderer>().material = planett;
    planet.AddComponent<Rigidbody>();
    planet.GetComponent<Rigidbody>().mass = (float)TBGlobal.mp;
    planet.GetComponent<Rigidbody>().drag = 0;
    planet.GetComponent<Rigidbody>().angularDrag = 0;
    planet.GetComponent<Rigidbody>().useGravity = false;
    planet.GetComponent<Rigidbody>().velocity = new Vector3((float)TBGlobal.vxp, (float)TBGlobal.vyp, (float)TBGlobal.vzp);
    planet.AddComponent<ConstantForce>();
    planet.AddComponent<BoomControl>();
    planet.GetComponent<BoomControl>().mainCamera=GameObject.Find("Main Camera").GetComponent<Camera>();
    planet.GetComponent<Transform>().parent = GameObject.Find("Stars").GetComponent<Transform>().transform;
    sp.x = (float)TBGlobal.xp; sp.y = (float)TBGlobal.yp; sp.z = (float)TBGlobal.zp;
    sp.vx = (float)TBGlobal.vxp; sp.vy = (float)TBGlobal.vyp; sp.vz = (float)TBGlobal.vzp;
    sp.m = (float)TBGlobal.mp;
    GameObject tp = new GameObject();
    tp.AddComponent<SeeCamera>();
    tp.name = "Text";
    tp.transform.parent = planet.transform;
    tp.transform.localPosition = new Vector3(0, 0, 0);
    GameObject textp = new GameObject();
    textp.name = "_Text";
    textp.AddComponent<TextMesh>();
    textp.GetComponent<TextMesh>().text = "行星";
    textp.GetComponent<TextMesh>().fontSize = 20;
    textp.AddComponent<FontControl>();
    textp.transform.parent = tp.transform;
    textp.transform.localPosition = new Vector3(5, 0, 0);

    Land.planet = planet;

    reload = false;
  }

  private string bettershow(string in1)
  {
    string out1 = in1;
    if (out1.Contains("."))
      for (int i = in1.Split('.')[1].Length; i < 2; i++)
        out1 += "0";
    else
      out1 += ".00";
    for (int i = out1.Length; i <= 7; i++)
      out1 = " " + out1;
    return out1;
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
      if (TBGlobal.enablep)
        try { planet.GetComponent<ConstantForce>().force = new Vector3(0, 0, 0); } catch { }
      return;
    }

    time += 0.1;
    GameObject.Find("UI/Time").GetComponent<Text>().text = bettershow(Math.Round(time, 1).ToString()) + "年";

    GameObject.Find("UI/Info").GetComponent<Text>().text
        = "摄像机距离:" + CameraMove.distance.ToString() + "  FPS:" + Math.Round((1.0 / Time.deltaTime)).ToString() + "\n"
        + "<color=#FF0000>恒星A:m=" + bettershow(Math.Round(TBGlobal.m1, 1).ToString()) + " x=" + bettershow(Math.Round(s1.x, 2).ToString())
            + " y=" + bettershow(Math.Round(s1.y, 2).ToString()) + " z=" + bettershow(Math.Round(s1.z, 2).ToString())
            + " v=" + bettershow(Math.Round(Math.Sqrt(s1.vx * s1.vx + s1.vy * s1.vy + s1.vz * s1.vz), 2).ToString()) + "</color>\n"
        + "<color=#00BFFF>恒星B:m=" + bettershow(Math.Round(TBGlobal.m2, 1).ToString()) + " x=" + bettershow(Math.Round(s2.x, 2).ToString())
            + " y=" + bettershow(Math.Round(s2.y, 2).ToString()) + " z=" + bettershow(Math.Round(s2.z, 2).ToString())
            + " v=" + bettershow(Math.Round(Math.Sqrt(s2.vx * s2.vx + s2.vy * s2.vy + s2.vz * s2.vz), 2).ToString()) + "</color>\n"
        + "<color=#00FF00>恒星C:m=" + bettershow(Math.Round(TBGlobal.m3, 1).ToString()) + " x=" + bettershow(Math.Round(s3.x, 2).ToString())
            + " y=" + bettershow(Math.Round(s3.y, 2).ToString()) + " z=" + bettershow(Math.Round(s3.z, 2).ToString())
            + " v=" + bettershow(Math.Round(Math.Sqrt(s3.vx * s3.vx + s3.vy * s3.vy + s3.vz * s3.vz), 2).ToString()) + "</color>\n";
    if (TBGlobal.enablep)
    {
      double t = Temp();
      GameObject.Find("UI/Info").GetComponent<Text>().text
      += "<color=#FFFFFF>行星: m=" + bettershow(Math.Round(TBGlobal.mp, 1).ToString()) + " x=" + bettershow(Math.Round(sp.x, 2).ToString())
          + " y=" + bettershow(Math.Round(sp.y, 2).ToString()) + " z=" + bettershow(Math.Round(sp.z, 2).ToString())
          + " v=" + bettershow(Math.Round(Math.Sqrt(sp.vx * sp.vx + sp.vy * sp.vy + sp.vz * sp.vz), 2).ToString()) + "</color>\n"
      + (t > TBGlobal.maxtemp ? "<color=#FF0000>" : t < TBGlobal.mintemp ? "<color=#00BFFF>" : "<color=#00FF00>")
          + "行星表面温度:" + bettershow(Math.Round(t, 2).ToString()) + "℃</color>";
    }

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
    if (TBGlobal.enablep)
    {
      sp.x = planet.GetComponent<Transform>().position.x; sp.y = planet.GetComponent<Transform>().position.y; sp.z = planet.GetComponent<Transform>().position.z;
      sp.vx = planet.GetComponent<Rigidbody>().velocity.x; sp.vy = planet.GetComponent<Rigidbody>().velocity.y; sp.vz = planet.GetComponent<Rigidbody>().velocity.z;
      sp.m = planet.GetComponent<Rigidbody>().mass;
    }

    //距离计算
    r1 = Math.Sqrt((s1.x - s2.x) * (s1.x - s2.x) + (s1.y - s2.y) * (s1.y - s2.y) + (s1.z - s2.z) * (s1.z - s2.z));//1,2
    r2 = Math.Sqrt((s3.x - s2.x) * (s3.x - s2.x) + (s3.y - s2.y) * (s3.y - s2.y) + (s3.z - s2.z) * (s3.z - s2.z));//2,3
    r3 = Math.Sqrt((s1.x - s3.x) * (s1.x - s3.x) + (s1.y - s3.y) * (s1.y - s3.y) + (s1.z - s3.z) * (s1.z - s3.z));//3,1
    if (TBGlobal.enablep)
    {
      r4 = Math.Sqrt((s1.x - sp.x) * (s1.x - sp.x) + (s1.y - sp.y) * (s1.y - sp.y) + (s1.z - sp.z) * (s1.z - sp.z));//1
      r5 = Math.Sqrt((sp.x - s2.x) * (sp.x - s2.x) + (sp.y - s2.y) * (sp.y - s2.y) + (sp.z - s2.z) * (sp.z - s2.z));//2
      r6 = Math.Sqrt((sp.x - s3.x) * (sp.x - s3.x) + (sp.y - s3.y) * (sp.y - s3.y) + (sp.z - s3.z) * (sp.z - s3.z));//3
    }

    //引力公式：F=G*M*m/R
    f1 = TBGlobal.g * s1.m * s2.m / r1;
    f2 = TBGlobal.g * s3.m * s2.m / r2;
    f3 = TBGlobal.g * s1.m * s3.m / r3;
    if (TBGlobal.enablep)
    {
      f4 = TBGlobal.g * s1.m * sp.m / r4;
      f5 = TBGlobal.g * s2.m * sp.m / r5;
      f6 = TBGlobal.g * s3.m * sp.m / r6;
    }

    //计算每个星体在x,y,z方向上受到的引力并回写，力的空间正交分解
    starA.GetComponent<ConstantForce>().force = new Vector3((float)(f1 / r1 * (s2.x - s1.x) + f3 / r3 * (s3.x - s1.x)),
        (float)(f1 / r1 * (s2.y - s1.y) + f3 / r3 * (s3.y - s1.y)), (float)(f1 / r1 * (s2.z - s1.z) + f3 / r3 * (s3.z - s1.z)));
    starB.GetComponent<ConstantForce>().force = new Vector3((float)(f1 / r1 * (s1.x - s2.x) + f2 / r2 * (s3.x - s2.x)),
        (float)(f1 / r1 * (s1.y - s2.y) + f2 / r2 * (s3.y - s2.y)), (float)(f1 / r1 * (s1.z - s2.z) + f2 / r2 * (s3.z - s2.z)));
    starC.GetComponent<ConstantForce>().force = new Vector3((float)(f2 / r2 * (s2.x - s3.x) + f3 / r3 * (s1.x - s3.x)),
        (float)(f2 / r2 * (s2.y - s3.y) + f3 / r3 * (s1.y - s3.y)), (float)(f2 / r2 * (s2.z - s3.z) + f3 / r3 * (s1.z - s3.z)));
    if (TBGlobal.enablep)
      planet.GetComponent<ConstantForce>().force = new Vector3(
          (float)(f4 / r4 * (s1.x - sp.x) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.x - sp.x)),
          (float)(f4 / r4 * (s1.y - sp.y) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.y - sp.y)),
          (float)(f4 / r4 * (s1.z - sp.z) + f5 / r5 * (s2.x - sp.x) + f6 / r6 * (s3.z - sp.z)));
  }
}
