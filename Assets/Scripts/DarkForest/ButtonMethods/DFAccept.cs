using UnityEngine;
using UnityEngine.UI;

public class DFAccept : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }

    void Click()
    {
        if (GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha == 0) return;
        DFGlobal.startcnt = int.Parse(GameObject.Find("Setting/startcnt/Value").GetComponent<Text>().text);
        DFGlobal.startscore = int.Parse(GameObject.Find("Setting/startscore/Value").GetComponent<Text>().text);
        DFGlobal.travel_speed = double.Parse(GameObject.Find("Setting/travel_speed/Value").GetComponent<Text>().text);
        DFGlobal.develop = int.Parse(GameObject.Find("Setting/develop/Value").GetComponent<Text>().text);
        DFGlobal.cooperation = int.Parse(GameObject.Find("Setting/cooperation/Value").GetComponent<Text>().text);
        DFGlobal.attack = int.Parse(GameObject.Find("Setting/attack/Value").GetComponent<Text>().text);
        DFGlobal.allowspawn = GameObject.Find("Setting/allowspawn/Value").GetComponent<Text>().text == "是" ? true : false;
        DFGlobal.spawnprobability = int.Parse(GameObject.Find("Setting/spawnprobability/Value").GetComponent<Text>().text);
        DFGlobal.cooldowntime = int.Parse(GameObject.Find("Setting/cooldowntime/Value").GetComponent<Text>().text);
        DFGlobal.rangex = double.Parse(GameObject.Find("Setting/rangex/Value").GetComponent<Text>().text);
        DFGlobal.rangey = double.Parse(GameObject.Find("Setting/rangey/Value").GetComponent<Text>().text);
        DFGlobal.rangez = double.Parse(GameObject.Find("Setting/rangez/Value").GetComponent<Text>().text);
        DFGlobal.defensetimes = int.Parse(GameObject.Find("Setting/defensetimes/Value").GetComponent<Text>().text);
        DFGlobal.peace = int.Parse(GameObject.Find("Setting/peace/Value").GetComponent<Text>().text);
        DFGlobal.middle = int.Parse(GameObject.Find("Setting/middle/Value").GetComponent<Text>().text);
        DFGlobal.attacks = int.Parse(GameObject.Find("Setting/attacks/Value").GetComponent<Text>().text);
        DFGlobal.allowtechboom = GameObject.Find("Setting/allowtechboom/Value").GetComponent<Text>().text == "是" ? true : false;
        DFGlobal.techboommax = int.Parse(GameObject.Find("Setting/techboommax/Value").GetComponent<Text>().text);
        DFGlobal.techboom_addon = int.Parse(GameObject.Find("Setting/techboom_addon/Value").GetComponent<Text>().text);
        DFGlobal.techboom_probability = int.Parse(GameObject.Find("Setting/techboom_probability/Value").GetComponent<Text>().text);
        DFGlobal.allow2d = GameObject.Find("Setting/allow2d/Value").GetComponent<Text>().text == "是" ? true : false;
        DFGlobal.score2d = int.Parse(GameObject.Find("Setting/score2d/Value").GetComponent<Text>().text);
        DFGlobal.speed2d = double.Parse(GameObject.Find("Setting/speed2d/Value").GetComponent<Text>().text);
        DFGlobal.cooldown2d = int.Parse(GameObject.Find("Setting/cooldown2d/Value").GetComponent<Text>().text);
        DFGlobal.allow_attack_help = GameObject.Find("Setting/allow_attack_help/Value").GetComponent<Text>().text == "是" ? true : false;

        GameObject.Find("Setting").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Setting").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Setting").GetComponent<CanvasGroup>().blocksRaycasts = false;
        CameraMove.enable=true;
    }
}
