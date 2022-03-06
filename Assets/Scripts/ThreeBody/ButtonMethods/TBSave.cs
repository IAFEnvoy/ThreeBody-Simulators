using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TBSave : MonoBehaviour
{
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(Click);
    }

    private void Click()
    {
        if (GameObject.Find("Starter").GetComponent<CanvasGroup>().alpha == 0)
            return;

        OpenFileName openFileName = new OpenFileName();
        openFileName.structSize = Marshal.SizeOf(openFileName);
        openFileName.filter = "三体预设文件(*.3dstmn)\0*.3dstmn";
        openFileName.file = new string(new char[256]);
        openFileName.maxFile = openFileName.file.Length;
        openFileName.fileTitle = new string(new char[64]);
        openFileName.maxFileTitle = openFileName.fileTitle.Length;
        openFileName.initialDir = (UnityEngine.Application.dataPath + "\\Saves").Replace('/', '\\');//默认路径
        openFileName.title = "保存预设";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (!LocalDialog.GetSaveFileName(openFileName) == true)
            return;

        if (openFileName.file.Contains(".3dstmn") == false)
            openFileName.file += ".3dstmn";

        StreamWriter sw = new StreamWriter(openFileName.file, false);

        sw.WriteLine(GameObject.Find("Starter/m1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/m2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/m3/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Starter/x1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/x2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/x3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/xp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Starter/y1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/y2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/y3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/yp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Starter/z1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/z2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/z3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/zp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Starter/vx1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vx2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vx3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vxp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Starter/vy1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vy2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vy3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vyp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Starter/vz1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vz2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vz3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Starter/vzp/Text").GetComponent<Text>().text);

        sw.Close();
        sw.Dispose();
    }
}
