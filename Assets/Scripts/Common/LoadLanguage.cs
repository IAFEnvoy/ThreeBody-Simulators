using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class LoadLanguage : MonoBehaviour
{
  public static string lang = "zh_cn";
  public string nameSpace;
  void Start()
  {
    StreamReader reader = new StreamReader(Application.dataPath + "/Lang/" + nameSpace + "_" + lang + ".txt");
    string line = reader.ReadLine();
    while (line != null)
    {
      string[] strs = line.Split('=');
      if (strs.Length == 2)
        GameObject.Find(strs[0]).GetComponent<Text>().text = strs[1];
      line = reader.ReadLine();
    }
  }
}