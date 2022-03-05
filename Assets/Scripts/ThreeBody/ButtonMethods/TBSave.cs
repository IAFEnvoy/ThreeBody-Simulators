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
        if (GameObject.Find("Canvas/Starter").GetComponent<CanvasGroup>().alpha == 0)
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

        sw.WriteLine(GameObject.Find("Canvas/Starter/m1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/m2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/m3/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Canvas/Starter/x1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/x2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/x3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/xp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Canvas/Starter/y1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/y2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/y3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/yp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Canvas/Starter/z1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/z2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/z3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/zp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Canvas/Starter/vx1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vx2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vx3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vxp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Canvas/Starter/vy1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vy2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vy3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vyp/Text").GetComponent<Text>().text);

        sw.WriteLine(GameObject.Find("Canvas/Starter/vz1/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vz2/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vz3/Text").GetComponent<Text>().text);
        sw.WriteLine(GameObject.Find("Canvas/Starter/vzp/Text").GetComponent<Text>().text);

        sw.Close();
        sw.Dispose();
    }
}
