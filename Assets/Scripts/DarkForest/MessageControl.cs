using UnityEngine;
using UnityEngine.UI;

public class MessageControl : MonoBehaviour
{
  public static string message1="",message2="",message3="";
    void Update()
    {
        GetComponent<Text>().text = message1+"\n"+message2+"\n"+message3;
    }
}
