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
        TBInit.m1 = Double.Parse(GameObject.Find("Canvas/Starter/m1/Text").GetComponent<Text>().text);
        TBInit.x1 = Double.Parse(GameObject.Find("Canvas/Starter/x1/Text").GetComponent<Text>().text);
        TBInit.y1 = Double.Parse(GameObject.Find("Canvas/Starter/y1/Text").GetComponent<Text>().text);
        TBInit.z1 = Double.Parse(GameObject.Find("Canvas/Starter/z1/Text").GetComponent<Text>().text);
        TBInit.vx1 = Double.Parse(GameObject.Find("Canvas/Starter/vx1/Text").GetComponent<Text>().text);
        TBInit.vy1 = Double.Parse(GameObject.Find("Canvas/Starter/vy1/Text").GetComponent<Text>().text);
        TBInit.vz1 = Double.Parse(GameObject.Find("Canvas/Starter/vz1/Text").GetComponent<Text>().text);

        TBInit.m2 = Double.Parse(GameObject.Find("Canvas/Starter/m2/Text").GetComponent<Text>().text);
        TBInit.x2 = Double.Parse(GameObject.Find("Canvas/Starter/x2/Text").GetComponent<Text>().text);
        TBInit.y2 = Double.Parse(GameObject.Find("Canvas/Starter/y2/Text").GetComponent<Text>().text);
        TBInit.z2 = Double.Parse(GameObject.Find("Canvas/Starter/z2/Text").GetComponent<Text>().text);
        TBInit.vx2 = Double.Parse(GameObject.Find("Canvas/Starter/vx2/Text").GetComponent<Text>().text);
        TBInit.vy2 = Double.Parse(GameObject.Find("Canvas/Starter/vy2/Text").GetComponent<Text>().text);
        TBInit.vz2 = Double.Parse(GameObject.Find("Canvas/Starter/vz2/Text").GetComponent<Text>().text);

        TBInit.m3 = Double.Parse(GameObject.Find("Canvas/Starter/m3/Text").GetComponent<Text>().text);
        TBInit.x3 = Double.Parse(GameObject.Find("Canvas/Starter/x3/Text").GetComponent<Text>().text);
        TBInit.y3 = Double.Parse(GameObject.Find("Canvas/Starter/y3/Text").GetComponent<Text>().text);
        TBInit.z3 = Double.Parse(GameObject.Find("Canvas/Starter/z3/Text").GetComponent<Text>().text);
        TBInit.vx3 = Double.Parse(GameObject.Find("Canvas/Starter/vx3/Text").GetComponent<Text>().text);
        TBInit.vy3 = Double.Parse(GameObject.Find("Canvas/Starter/vy3/Text").GetComponent<Text>().text);
        TBInit.vz3 = Double.Parse(GameObject.Find("Canvas/Starter/vz3/Text").GetComponent<Text>().text);

        TBInit.xp = Double.Parse(GameObject.Find("Canvas/Starter/xp/Text").GetComponent<Text>().text);
        TBInit.yp = Double.Parse(GameObject.Find("Canvas/Starter/yp/Text").GetComponent<Text>().text);
        TBInit.zp = Double.Parse(GameObject.Find("Canvas/Starter/zp/Text").GetComponent<Text>().text);
        TBInit.vxp = Double.Parse(GameObject.Find("Canvas/Starter/vxp/Text").GetComponent<Text>().text);
        TBInit.vyp = Double.Parse(GameObject.Find("Canvas/Starter/vyp/Text").GetComponent<Text>().text);
        TBInit.vzp = Double.Parse(GameObject.Find("Canvas/Starter/vzp/Text").GetComponent<Text>().text);

        TBCalculate.time = 0; TBCalculate.reload = true;

        GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
