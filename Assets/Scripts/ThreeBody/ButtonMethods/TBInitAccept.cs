using System;
using UnityEngine;
using UnityEngine.UI;

public class TBInitAccept : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        TBGlobal.m1 = Double.Parse(GameObject.Find("Starter/m1/Text").GetComponent<Text>().text);
        TBGlobal.x1 = Double.Parse(GameObject.Find("Starter/x1/Text").GetComponent<Text>().text);
        TBGlobal.y1 = Double.Parse(GameObject.Find("Starter/y1/Text").GetComponent<Text>().text);
        TBGlobal.z1 = Double.Parse(GameObject.Find("Starter/z1/Text").GetComponent<Text>().text);
        TBGlobal.vx1 = Double.Parse(GameObject.Find("Starter/vx1/Text").GetComponent<Text>().text);
        TBGlobal.vy1 = Double.Parse(GameObject.Find("Starter/vy1/Text").GetComponent<Text>().text);
        TBGlobal.vz1 = Double.Parse(GameObject.Find("Starter/vz1/Text").GetComponent<Text>().text);

        TBGlobal.m2 = Double.Parse(GameObject.Find("Starter/m2/Text").GetComponent<Text>().text);
        TBGlobal.x2 = Double.Parse(GameObject.Find("Starter/x2/Text").GetComponent<Text>().text);
        TBGlobal.y2 = Double.Parse(GameObject.Find("Starter/y2/Text").GetComponent<Text>().text);
        TBGlobal.z2 = Double.Parse(GameObject.Find("Starter/z2/Text").GetComponent<Text>().text);
        TBGlobal.vx2 = Double.Parse(GameObject.Find("Starter/vx2/Text").GetComponent<Text>().text);
        TBGlobal.vy2 = Double.Parse(GameObject.Find("Starter/vy2/Text").GetComponent<Text>().text);
        TBGlobal.vz2 = Double.Parse(GameObject.Find("Starter/vz2/Text").GetComponent<Text>().text);

        TBGlobal.m3 = Double.Parse(GameObject.Find("Starter/m3/Text").GetComponent<Text>().text);
        TBGlobal.x3 = Double.Parse(GameObject.Find("Starter/x3/Text").GetComponent<Text>().text);
        TBGlobal.y3 = Double.Parse(GameObject.Find("Starter/y3/Text").GetComponent<Text>().text);
        TBGlobal.z3 = Double.Parse(GameObject.Find("Starter/z3/Text").GetComponent<Text>().text);
        TBGlobal.vx3 = Double.Parse(GameObject.Find("Starter/vx3/Text").GetComponent<Text>().text);
        TBGlobal.vy3 = Double.Parse(GameObject.Find("Starter/vy3/Text").GetComponent<Text>().text);
        TBGlobal.vz3 = Double.Parse(GameObject.Find("Starter/vz3/Text").GetComponent<Text>().text);

        TBGlobal.xp = Double.Parse(GameObject.Find("Starter/xp/Text").GetComponent<Text>().text);
        TBGlobal.yp = Double.Parse(GameObject.Find("Starter/yp/Text").GetComponent<Text>().text);
        TBGlobal.zp = Double.Parse(GameObject.Find("Starter/zp/Text").GetComponent<Text>().text);
        TBGlobal.vxp = Double.Parse(GameObject.Find("Starter/vxp/Text").GetComponent<Text>().text);
        TBGlobal.vyp = Double.Parse(GameObject.Find("Starter/vyp/Text").GetComponent<Text>().text);
        TBGlobal.vzp = Double.Parse(GameObject.Find("Starter/vzp/Text").GetComponent<Text>().text);

        TBCalculate.time = 0; TBCalculate.reload = true;

        GameObject.Find("Starter").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Starter").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Starter").GetComponent<CanvasGroup>().blocksRaycasts = false;
        CameraMove.enable=true;
    }
}
