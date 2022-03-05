using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class DFCalculate : MonoBehaviour
{
  public Material red, yellow, green, white, blue;
  public Material redl, yellowl, greenl;
  static Material reds, yellows, greens, blues, whites;
  static Material redls, yellowls, greenls;
  public static bool reload = false;
  public static bool execute = true, sortscore = false;
  static int time = 0;
  static List<Stars> stars = new List<Stars>(); static int deathcnt = 0;
  static List<Biaxial_foil> bfs = new List<Biaxial_foil>();
  System.Random rd = new System.Random();
  
  public static void savefile(string path)
  {
    StreamWriter sw = new StreamWriter(path);
    sw.WriteLine(Encoding.ASCII.GetString(Binary.SerializeBinary(new Datas(stars, bfs))));
    sw.Close();
    sw.Dispose();
  }

  public static void loadfile(string path)
  {
    StreamReader sr = new StreamReader(path);
    Datas datas = (Datas)Binary.DeserializeBinary(Encoding.ASCII.GetBytes(sr.ReadToEnd()));

    time = 0;
    MessageControl.message1 = "初始化完毕";
    for (int i = 0; i < stars.Count; i++)
      if (stars[i].life)
        Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
    stars.Clear(); deathcnt = 0;
    for (int i = 0; i < bfs.Count; i++)
      if (bfs[i].life)
        Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
    bfs.Clear();

    stars = datas.stars;

    for (int i = 0; i < stars.Count; i++)
      if (stars[i].life)
      {
        GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        star.transform.position = new Vector3(stars[i].x, stars[i].y, stars[i].z);
        star.name = "Star" + i.ToString();
        star.transform.localScale = new Vector3(5, 5, 5);
        star.AddComponent<HighlightableObject>();

        if (stars[i].type != 1 && stars[i].type != 0) stars[i].type = -1;

        switch (stars[i].type)
        {
          case 1: { star.AddComponent<HighLightControlRed>(); star.GetComponent<Renderer>().material = reds; break; }
          case -1: { star.AddComponent<HighLightControlGreen>(); star.GetComponent<Renderer>().material = greens; break; }
          case 0: { star.AddComponent<HighLightControlYellow>(); star.GetComponent<Renderer>().material = yellows; break; }
        }
        star.AddComponent<TrailRenderer>();
        star.GetComponent<TrailRenderer>().time = 2;
        star.GetComponent<TrailRenderer>().material = blues;
        star.transform.parent = GameObject.Find("Stars").GetComponent<Transform>();

        stars[i].havetarget = false; stars[i].ship = null;
        if (stars[i].havetarget)
        {
          GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
          _ship.transform.position = new Vector3(stars[i].ship.nowx, stars[i].ship.nowy, stars[i].ship.nowz);
          _ship.name = "Ship";
          _ship.transform.localScale = new Vector3(2, 2, 2);
          _ship.AddComponent<TrailRenderer>();
          _ship.GetComponent<TrailRenderer>().time = 1;
          switch (stars[i].ship.type)
          {
            case 1: { _ship.GetComponent<Renderer>().material = reds; _ship.GetComponent<TrailRenderer>().material = redls; break; }
            case -1: { _ship.GetComponent<Renderer>().material = yellows; _ship.GetComponent<TrailRenderer>().material = yellowls; break; }
            case 0: { _ship.GetComponent<Renderer>().material = greens; _ship.GetComponent<TrailRenderer>().material = greenls; break; }
          }
          _ship.transform.parent = GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>();
        }
      }
  }
  
  void Start()
  {
    reds = red; yellows = yellow; greens = green; blues = blue; whites = white;
    redls = redl; yellowls = yellowl; greenls = greenl;

    Load();
    ReadGlobal();
  }

  public void Load()
  {
    time = 0;
    GameObject.Find("Canvas/UI/Message").GetComponent<Text>().text = "初始化完毕";
    for (int i = 0; i < stars.Count; i++)
      if (stars[i].life)
        Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
    stars.Clear(); deathcnt = 0;
    for (int i = 0; i < bfs.Count; i++)
      if (bfs[i].life)
        Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
    bfs.Clear();

    for (int i = 0; i < global.startcnt; i++)
      spawnstar();
  }

  static void ReadGlobal()
  {
    if (File.Exists(Application.dataPath + @"\start_up_parameter.txt"))
    {
      MessageControl.message2 = "自定义参数读取失败，将使用默认值。";
      StreamReader sr = new StreamReader(Application.dataPath + @"\start_up_parameter.txt");
      global.startcnt = int.Parse(sr.ReadLine());
      global.startscore = int.Parse(sr.ReadLine());
      global.travel_speed = double.Parse(sr.ReadLine());
      global.develop = int.Parse(sr.ReadLine());
      global.cooperation = int.Parse(sr.ReadLine());
      global.attack = int.Parse(sr.ReadLine());
      global.allowspawn = bool.Parse(sr.ReadLine());
      global.spawnprobability = int.Parse(sr.ReadLine());
      global.cooldowntime = int.Parse(sr.ReadLine());
      global.rangex = double.Parse(sr.ReadLine());
      global.rangey = double.Parse(sr.ReadLine());
      global.rangez = double.Parse(sr.ReadLine());
      global.defensetimes = int.Parse(sr.ReadLine());
      global.peace = int.Parse(sr.ReadLine());
      global.middle = int.Parse(sr.ReadLine());
      global.attacks = int.Parse(sr.ReadLine());
      global.allowtechboom = bool.Parse(sr.ReadLine());
      global.techboommax = int.Parse(sr.ReadLine());
      global.techboom_addon = int.Parse(sr.ReadLine());
      global.techboom_probability = int.Parse(sr.ReadLine());
      global.allow2d = bool.Parse(sr.ReadLine());
      global.score2d = int.Parse(sr.ReadLine());
      global.speed2d = double.Parse(sr.ReadLine());
      global.cooldown2d = int.Parse(sr.ReadLine());
      global.allow_attack_help = bool.Parse(sr.ReadLine());
      sr.Close();
      MessageControl.message2 = "自定义参数读取成功！";
    }
    else
      MessageControl.message2 = "没有找到自定义参数文件，将使用默认值。";
  }

  bool isattack(int start, int target)
  {
    if (stars[start].type == 1) return true;
    if (stars[start].type == -1)
    {
      if (stars[target].type == 1) if (global.allow_attack_help) return false; else return true;
      return false;
    }
    if (stars[start].type == 0)
    {
      if (stars[target].type == 1) return true;
      return false;
    }
    return false;
  }

  void spawnstar()
  {
    int num = rd.Next() % (global.peace + global.middle + global.attacks), asd;
    if (num < global.peace) asd = -1;
    else if (global.peace <= num && num < global.peace + global.middle) asd = 0;
    else asd = 1;

    stars.Add(new Stars(stars.Count + 1, (float)((rd.NextDouble() - 0.5) * 2 * global.rangex), (float)((rd.NextDouble() - 0.5) * 2 * global.rangey),
        (float)((rd.NextDouble() - 0.5) * 2 * global.rangez), asd, rd.Next() % 2 == 1, time));

    GameObject star = GameObject.CreatePrimitive(PrimitiveType.Sphere), starl = GameObject.CreatePrimitive(PrimitiveType.Sphere);
    starl.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
    star.transform.position = new Vector3(stars[stars.Count - 1].x, stars[stars.Count - 1].y, stars[stars.Count - 1].z);
    starl.name = "Star" + (stars.Count - 1).ToString();
    star.name = "Star";
    starl.transform.localScale = new Vector3(1, 1, 1);
    star.transform.localScale = new Vector3(5, 5, 5);
    star.AddComponent<HighlightableObject>();
    switch (asd)
    {
      case 1: { star.AddComponent<HighLightControlRed>(); star.GetComponent<Renderer>().material = red; break; }
      case -1: { star.AddComponent<HighLightControlGreen>(); star.GetComponent<Renderer>().material = green; break; }
      case 0: { star.AddComponent<HighLightControlYellow>(); star.GetComponent<Renderer>().material = yellow; break; }
    }
    starl.AddComponent<TrailRenderer>();
    starl.GetComponent<TrailRenderer>().time = 2;
    starl.GetComponent<TrailRenderer>().material = blue;
    star.AddComponent<Rotate>();
    starl.transform.parent = GameObject.Find("Stars").GetComponent<Transform>();
    star.transform.parent = starl.transform;
  }

  bool checkhelplist(List<int> helplist, int number)
  {
    foreach (int l in helplist)
      if (number == l) return false;
    return true;
  }
  
  void Update()
  {
    if (reload) { reload = false; Load(); }
    // if (!execute)
    // {
    //     for (int i = 0; i < stars.Count; i++)
    //         if (stars[i].life && stars[i].havetarget)
    //             GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<TrailRenderer>().time += Time.deltaTime;
    //     return;
    // }

    // for (int j = 0; j < stars.Count; j++)
    //     if (stars[j].life && stars[j].havetarget)
    //         if (GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time > 1)
    //             GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time -= Time.deltaTime;
    //         else GameObject.Find("Stars/Star" + j.ToString() + "/Ship").GetComponent<TrailRenderer>().time = 1;

    GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text = "";
    time += 1;//加一年
    GameObject.Find("Canvas/UI/Time").GetComponent<Text>().text = time.ToString() + "年";

    //生成新文明
    if (global.allowspawn)
      if (rd.Next() % global.spawnprobability == 0)
        spawnstar();

    for (int i = 0; i < bfs.Count; i++)//二向箔计算
    {
      if (!bfs[i].life) continue;
      if (!stars[bfs[i].target].life)
      {
        bfs[i].life = false;
        Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
        continue;
      }
      GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().position += new Vector3(bfs[i].directionx, bfs[i].directiony, bfs[i].directionz);
      bfs[i].distance += global.speed2d;
      bfs[i].nowx += bfs[i].directionx;
      bfs[i].nowy += bfs[i].directiony;
      bfs[i].nowz += bfs[i].directionz;

      if (bfs[i].distance >= bfs[i].total)//到达目的地
      {
        bfs[i].life = false;
        Destroy(GameObject.Find("Biaxial_foil/bf" + i.ToString()).GetComponent<Transform>().gameObject);
        if (stars[bfs[i].target].helpcnt > 0 && stars[bfs[i].target].type != 1)//欸，我溜了（当有文明帮助）
        {
          stars[bfs[i].target].x = (float)((rd.NextDouble() - 0.5) * 2 * global.rangex);
          stars[bfs[i].target].y = (float)((rd.NextDouble() - 0.5) * 2 * global.rangey);
          stars[bfs[i].target].z = (float)((rd.NextDouble() - 0.5) * 2 * global.rangez);
          GameObject.Find("Stars/Star" + bfs[i].target.ToString()).GetComponent<Transform>().position
              = new Vector3(stars[bfs[i].target].x, stars[bfs[i].target].y, stars[bfs[i].target].z);
          if (stars[bfs[i].target].havetarget)
          {
            stars[bfs[i].target].havetarget = false;
            Destroy(GameObject.Find("Stars/Star" + bfs[i].target.ToString() + "/Ship").GetComponent<Transform>().gameObject);
          }
          MessageControl.message2 = bfs[i].target.ToString() + "号文明受到降维打击，已经迁移位置";
        }
        else//awsl
        {
          stars[bfs[i].target].life = false;

          MessageControl.message2 = (bfs[i].target + 1).ToString() + "号文明受到降维打击，存活了" + (time - stars[bfs[i].target].lifetime).ToString() + "年";
          Destroy(GameObject.Find("Stars/Star" + bfs[i].target.ToString()).GetComponent<Transform>().gameObject);
          deathcnt += 1;
        }
      }
    }

    for (int i = 0; i < stars.Count; i++)
    {
      if (!stars[i].life) continue;//死亡判断
      stars[i].scorelast = stars[i].score;

      if (stars[i].score < 0)
      {
        stars[i].life = false;
        foreach (int it in stars[i].helplist)
        {
          stars[it].helpcnt -= 1;
        }
        MessageControl.message2 = (i + 1).ToString() + "号文明被消灭，存活了" + (time - stars[i].lifetime).ToString() + "年";
        Destroy(GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>().gameObject);
        deathcnt += 1;
        continue;
      }

      stars[i].score += global.develop + stars[i].helpcnt * global.cooperation + stars[i].techboomcnt * global.techboom_addon;//加分
      if (global.allowtechboom)//技术爆炸代码
      {
        if (stars[i].techboomcnt < global.techboommax)
          if (rd.Next() % global.techboom_probability == 0)
          {
            stars[i].techboomcnt += 1;
            MessageControl.message2 = (i + 1).ToString() + "号文明发生第" + stars[i].techboomcnt.ToString() + "次技术爆炸";
          }
      }
      if (stars[i].isout)
      {
        if (stars[i].havetarget)//飞船计算代码
        {
          if (GameObject.Find("Stars/Star" + i.ToString() + "/Ship") == null) { }//DO NOTHING
          //execute ships
          else if (!stars[stars[i].ship.target].life)//判断目标是否死亡
          {
            Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
            stars[i].havetarget = false;
          }
          else if (stars[i].ship.stats == 0)//飞行状态
          {
            stars[i].ship.nowx += stars[i].ship.directionx;
            stars[i].ship.nowy += stars[i].ship.directiony;
            stars[i].ship.nowz += stars[i].ship.directionz;
            GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().position=new Vector3(stars[i].ship.nowx,stars[i].ship.nowy,stars[i].ship.nowz);
            stars[i].ship.distance += global.travel_speed;
            if (stars[i].ship.distance >= stars[i].ship.total)//到达目的地
              stars[i].ship.stats = 1;
          }
          else
          {
            if (stars[i].ship.targetv_x != stars[stars[i].ship.target].x || stars[i].ship.targetv_y != stars[stars[i].ship.target].y || stars[i].ship.targetv_z != stars[stars[i].ship.target].z)
            {
              Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
              stars[i].havetarget = false;
            }
            else if (stars[i].ship.type == -1)//没有效果，直接返回
            {
              Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
              stars[i].havetarget = false;
            }
            else if (stars[i].ship.type == 0)//加入合作列表
            {
              Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
              stars[i].havetarget = false;
              bool flag = false;
              for (int j = 0; j < stars[i].helplist.Count; j++)
                if (stars[i].helplist[j] == stars[i].ship.target) flag = true;
              if (!flag)
              {
                stars[i].helplist.Add(stars[i].ship.target);
                stars[stars[i].ship.target].helpcnt += 1;
              }
            }
            else if (stars[i].ship.type == 1)//打起来了。。。
            {
              if (stars[i].ship.defense <= 0)
              {
                Destroy(GameObject.Find("Stars/Star" + i.ToString() + "/Ship").GetComponent<Transform>().gameObject);
                stars[i].havetarget = false;
              }
              else
              {
                stars[stars[i].ship.target].score += global.attack;
                stars[i].ship.defense += global.attack;
              }
            }
          }
        }
        else//新建飞船实体
        {
          if (stars.Count == 1) continue;//欸，人呢？
          if (stars[i].score < global.cooldowntime) continue;//发展不足，同志仍需努力(～￣▽￣)～

          int target = rd.Next() % stars.Count;

          if (global.allow2d && stars[i].score >= global.score2d)//二向箔启用判断
            if (stars[target].score > stars[i].score && isattack(i, target) && time - stars[i].time2d >= global.cooldown2d / 2)//二向箔，条件：目标文明得分大于发出者得分一半
            {
              stars[i].time2d = time;

              Biaxial_foil bf = new Biaxial_foil(bfs.Count, i, target, stars[i], stars[target]);
              bfs.Add(bf);

              GameObject _bf = GameObject.CreatePrimitive(PrimitiveType.Sphere);
              _bf.transform.position = new Vector3(stars[i].x, stars[i].y, stars[i].z);
              _bf.name = "bf" + (bfs.Count - 1).ToString();
              _bf.transform.localScale = new Vector3(2, 2, 2);
              _bf.AddComponent<TrailRenderer>();
              _bf.GetComponent<TrailRenderer>().time = 1;
              _bf.GetComponent<TrailRenderer>().material = white;
              _bf.GetComponent<Renderer>().material = white;
              _bf.transform.parent = GameObject.Find("Biaxial_foil").GetComponent<Transform>();

              MessageControl.message3 = (i + 1).ToString() + "号文明发出二向箔，目标" + (target + 1).ToString() + "号文明";
              continue;
            }

          Ships ship = new Ships(i, target, stars[i].score / global.defensetimes, stars[i], stars[target]);
          stars[i].havetarget = true;
          stars[i].ship = ship;

          MessageControl.message1 = (i + 1).ToString() + "号文明发出飞船，目标" + (target + 1).ToString() + "号文明";

          GameObject _ship = GameObject.CreatePrimitive(PrimitiveType.Sphere);
          _ship.transform.position = new Vector3(stars[i].x, stars[i].y, stars[i].z);
          _ship.name = "Ship";
          _ship.transform.localScale = new Vector3(2, 2, 2);
          _ship.AddComponent<TrailRenderer>();
          _ship.GetComponent<TrailRenderer>().time = 1;
          switch (ship.type)
          {
            case 1: { _ship.GetComponent<Renderer>().material = red; _ship.GetComponent<TrailRenderer>().material = redl; break; }
            case -1: { _ship.GetComponent<Renderer>().material = yellow; _ship.GetComponent<TrailRenderer>().material = yellowl; break; }
            case 0: { _ship.GetComponent<Renderer>().material = green; _ship.GetComponent<TrailRenderer>().material = greenl; break; }
          }
          _ship.transform.parent = GameObject.Find("Stars/Star" + i.ToString()).GetComponent<Transform>();
          _ship.transform.localPosition = new Vector3(0, 0, 0);
        }
      }
    }

    GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text = "文明总数：" + (stars.Count - deathcnt).ToString()
        + ",fps:" + Math.Round(1.0 / Time.deltaTime).ToString() + "\n";
    if (sortscore)
    {
      Stars[] temp = new Stars[stars.Count + 10];
      for (int i = 0; i < stars.Count; i++)
        temp[i] = stars[i];
      for (int i = 0; i < stars.Count; i++)
        for (int j = 0; j < i; j++)
          if (temp[i].score > temp[j].score)
          {
            Stars l = temp[i];
            temp[i] = temp[j];
            temp[j] = l;
          }
      GC.Collect();
      for (int i = 0; i < stars.Count; i++)
        if (temp[i].life)
        {
          switch (temp[i].type)
          {
            case 1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
            case -1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
            case 0: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
            default: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFFFF>"; break; }
          }
          GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += (temp[i].score > temp[i].scorelast ? "↑" : "↓") + temp[i].num.ToString() + "号文明得分：" + temp[i].score.ToString()
              + ",文明类型:" + (temp[i].isout ? "外向型" : "内向型") + "</color>\n";
        }
      GC.Collect();
    }
    else
      for (int i = 0; i < stars.Count; i++)
        if (stars[i].life)
        {
          switch (stars[i].type)
          {
            case 1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FF0000>"; break; }
            case -1: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#00FF00>"; break; }
            case 0: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFF00>"; break; }
            default: { GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += "<color=#FFFFFF>"; break; }
          }
          GameObject.Find("Canvas/UI/ScoreBoard").GetComponent<Text>().text += (stars[i].score > stars[i].scorelast ? "↑" : "↓") + stars[i].num.ToString() + "号文明得分：" + stars[i].score.ToString()
              + ",文明类型:" + (stars[i].isout ? "外向型" : "内向型") + "</color>\n";
        }
  }
}
