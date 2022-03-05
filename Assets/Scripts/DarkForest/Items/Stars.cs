using System.Collections.Generic;
using System;

[Serializable]
class Stars
{
    public Stars(int num, float x, float y, float z, int type, bool isout, int lifetime)
    {
        this.num = num;
        this.scorelast = 0;
        this.x = x;
        this.y = y;
        this.z = z;
        this.score = global.startscore;
        this.life = true;
        this.type = type;
        this.isout = isout;
        this.lifetime = lifetime;
        this.havetarget = false;
        this.helpcnt = 0;
        this.helplist = new List<int>();
        this.techboomcnt = 0;
        this.time2d = global.cooldown2d;

        if (this.type == 1) this.isout = true;//攻击性文明默认外向
    }
    public int num;//仅供数组索引使用
    public int scorelast;//上一轮得分，仅供计分板计算使用
    public float x, y, z;//三维坐标
    public int score;//得分
    public bool life;//是否存活，score为0时自动归为false
    public int type;//文明类型，-1为和平型，0为中立型，1为攻击型
    public bool isout;//是否为外向型文明（是则会发飞船去探索其他星球）
    public int lifetime;//出生时间，用于在打印信息时计算用
    public bool havetarget;//是否有飞船发出（一次只能发出一艘）,isout属性为false时此值恒为false
    public Ships ship;//舰队，当havetarget属性为false时此值为null
    public int helpcnt;//帮助这个文明的文明个数
    public List<int> helplist;//帮助的其他文明，当type的值为1时此数组的项数恒为0
    public int techboomcnt;//技术爆炸次数
    public int time2d;//上一次使用二向箔时间
}
