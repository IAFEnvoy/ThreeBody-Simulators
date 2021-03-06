using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class TBLoad : MonoBehaviour
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
        openFileName.title = "选择预设";
        openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

        if (!LocalDialog.GetOpenFileName(openFileName))
            return;

        StreamReader sr = new StreamReader(openFileName.file);
        GameObject.Find("Starter/m1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/m2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/m3").GetComponent<InputField>().text = sr.ReadLine();

        GameObject.Find("Starter/x1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/x2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/x3").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/xp").GetComponent<InputField>().text = sr.ReadLine();

        GameObject.Find("Starter/y1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/y2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/y3").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/yp").GetComponent<InputField>().text = sr.ReadLine();

        GameObject.Find("Starter/z1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/z2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/z3").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/zp").GetComponent<InputField>().text = sr.ReadLine();

        GameObject.Find("Starter/vx1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vx2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vx3").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vxp").GetComponent<InputField>().text = sr.ReadLine();

        GameObject.Find("Starter/vy1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vy2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vy3").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vyp").GetComponent<InputField>().text = sr.ReadLine();

        GameObject.Find("Starter/vz1").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vz2").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vz3").GetComponent<InputField>().text = sr.ReadLine();
        GameObject.Find("Starter/vzp").GetComponent<InputField>().text = sr.ReadLine();

        sr.Close();
        sr.Dispose();
    }
}
