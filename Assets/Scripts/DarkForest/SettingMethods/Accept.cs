using UnityEngine;
using UnityEngine.UI;

public class Accept : MonoBehaviour
{
    void Start()
    {
        this.GetComponent<Button>().onClick.AddListener(Click);
    }
    void Click()
    {
        if (GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha == 0) return;
        global.startcnt = int.Parse(GameObject.Find("Canvas/Setting/startcnt/Value").GetComponent<Text>().text);
        global.startscore = int.Parse(GameObject.Find("Canvas/Setting/startscore/Value").GetComponent<Text>().text);
        global.travel_speed = double.Parse(GameObject.Find("Canvas/Setting/travel_speed/Value").GetComponent<Text>().text);
        global.develop = int.Parse(GameObject.Find("Canvas/Setting/develop/Value").GetComponent<Text>().text);
        global.cooperation = int.Parse(GameObject.Find("Canvas/Setting/cooperation/Value").GetComponent<Text>().text);
        global.attack = int.Parse(GameObject.Find("Canvas/Setting/attack/Value").GetComponent<Text>().text);
        global.allowspawn = GameObject.Find("Canvas/Setting/allowspawn/Value").GetComponent<Text>().text == "是" ? true : false;
        global.spawnprobability = int.Parse(GameObject.Find("Canvas/Setting/spawnprobability/Value").GetComponent<Text>().text);
        global.cooldowntime = int.Parse(GameObject.Find("Canvas/Setting/cooldowntime/Value").GetComponent<Text>().text);
        global.rangex = double.Parse(GameObject.Find("Canvas/Setting/rangex/Value").GetComponent<Text>().text);
        global.rangey = double.Parse(GameObject.Find("Canvas/Setting/rangey/Value").GetComponent<Text>().text);
        global.rangez = double.Parse(GameObject.Find("Canvas/Setting/rangez/Value").GetComponent<Text>().text);
        global.defensetimes = int.Parse(GameObject.Find("Canvas/Setting/defensetimes/Value").GetComponent<Text>().text);
        global.peace = int.Parse(GameObject.Find("Canvas/Setting/peace/Value").GetComponent<Text>().text);
        global.middle = int.Parse(GameObject.Find("Canvas/Setting/middle/Value").GetComponent<Text>().text);
        global.attacks = int.Parse(GameObject.Find("Canvas/Setting/attacks/Value").GetComponent<Text>().text);
        global.allowtechboom = GameObject.Find("Canvas/Setting/allowtechboom/Value").GetComponent<Text>().text == "是" ? true : false;
        global.techboommax = int.Parse(GameObject.Find("Canvas/Setting/techboommax/Value").GetComponent<Text>().text);
        global.techboom_addon = int.Parse(GameObject.Find("Canvas/Setting/techboom_addon/Value").GetComponent<Text>().text);
        global.techboom_probability = int.Parse(GameObject.Find("Canvas/Setting/techboom_probability/Value").GetComponent<Text>().text);
        global.allow2d = GameObject.Find("Canvas/Setting/allow2d/Value").GetComponent<Text>().text == "是" ? true : false;
        global.score2d = int.Parse(GameObject.Find("Canvas/Setting/score2d/Value").GetComponent<Text>().text);
        global.speed2d = double.Parse(GameObject.Find("Canvas/Setting/speed2d/Value").GetComponent<Text>().text);
        global.cooldown2d = int.Parse(GameObject.Find("Canvas/Setting/cooldown2d/Value").GetComponent<Text>().text);
        global.allow_attack_help = GameObject.Find("Canvas/Setting/allow_attack_help/Value").GetComponent<Text>().text == "是" ? true : false;

        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().alpha = 0;
        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().interactable = false;
        GameObject.Find("Canvas/Setting").GetComponent<CanvasGroup>().blocksRaycasts = false;
    }
}
