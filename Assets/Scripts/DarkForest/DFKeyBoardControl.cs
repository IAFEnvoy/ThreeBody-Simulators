using System.IO;
using System.Runtime.InteropServices;
using UnityEngine;

public class DFKeyBoardControl : MonoBehaviour
{
  void Start()
  {
    GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha = 0;
    GameObject.Find("Menu").GetComponent<CanvasGroup>().interactable = false;
    GameObject.Find("Menu").GetComponent<CanvasGroup>().blocksRaycasts = false;
    CameraMove.enable = true;
  }
  void Update()
  {
    CameraMove.enable = GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha == 0;
    CameraMove.enable &= GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha == 0;
    if (Input.GetKeyDown(KeyCode.Escape))
      if (GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha == 1)
      {
        GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Setting").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Setting").GetComponent<CanvasGroup>().blocksRaycasts = false;
        CameraMove.enable = true;
      }
      else
      {
        GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha;
        GameObject.Find("Menu").GetComponent<CanvasGroup>().interactable ^= true;
        GameObject.Find("Menu").GetComponent<CanvasGroup>().blocksRaycasts ^= true;
        CameraMove.enable ^= true;
      }
    if (Input.GetKeyDown(KeyCode.Space))
      DFCalculate.execute = !DFCalculate.execute;
    if (Input.GetKeyDown(KeyCode.S))
      DFCalculate.sortscore = !DFCalculate.sortscore;
    if (Input.GetKeyDown(KeyCode.F2))//截屏系统
    {
      Rect r = new Rect(0, 0, Screen.width, Screen.height);
      Camera came = GameObject.Find("Main Camera").GetComponent<Camera>();
      RenderTexture rt = new RenderTexture((int)r.width, (int)r.height, 0);

      came.targetTexture = rt;
      came.Render();
      RenderTexture.active = rt;
      Texture2D screenShot = new Texture2D((int)r.width, (int)r.height, TextureFormat.RGB24, false);
      screenShot.ReadPixels(r, 0, 0);
      screenShot.Apply();
      came.targetTexture = null;
      RenderTexture.active = null;
      GameObject.Destroy(rt);
      byte[] bytes = screenShot.EncodeToPNG();

      OpenFileName openFileName = new OpenFileName();
      openFileName.structSize = Marshal.SizeOf(openFileName);
      openFileName.filter = "*.png\0*.png";
      openFileName.file = new string(new char[256]);
      openFileName.maxFile = openFileName.file.Length;
      openFileName.fileTitle = new string(new char[64]);
      openFileName.maxFileTitle = openFileName.fileTitle.Length;
      openFileName.initialDir = (UnityEngine.Application.dataPath).Replace('/', '\\');//默认路径
      openFileName.title = "保存截图";
      openFileName.flags = 0x00080000 | 0x00001000 | 0x00000800 | 0x00000008;

      if (LocalDialog.GetSaveFileName(openFileName))
      {
        if (openFileName.file.Contains(".png") == false) openFileName.file += ".png";
        File.WriteAllBytes(openFileName.file, bytes);
      }
    }
    if (Input.GetKeyDown(KeyCode.H))
      GameObject.Find("UI").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("UI").GetComponent<CanvasGroup>().alpha;
    if (Input.GetKeyDown(KeyCode.V))
      if (GameObject.Find("Menu").GetComponent<CanvasGroup>().alpha == 0)
      {
        GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha = 1 - GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha;
        GameObject.Find("Setting").GetComponent<CanvasGroup>().interactable ^= true;
        GameObject.Find("Setting").GetComponent<CanvasGroup>().blocksRaycasts ^= true;
        CameraMove.enable ^= true;
      }
  }
}
