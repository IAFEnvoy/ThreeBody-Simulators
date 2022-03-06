using System;

[Serializable]
class Ships
{
    public Ships(int start, int target, double defense, Stars startstar, Stars targetstar)
    {
        this.start = start;
        this.target = target;
        this.distance = 0;
        this.total = Math.Sqrt((startstar.x - targetstar.x) * (startstar.x - targetstar.x)
            + (startstar.y - targetstar.y) * (startstar.y - targetstar.y) + (startstar.z - targetstar.z) * (startstar.z - targetstar.z));
        this.stats = 0;
        this.defense = defense;
        if (startstar.type == 1) type = 1;
        if (startstar.type == -1)
        {
            if (targetstar.type == 1) if (DFGlobal.allow_attack_help) type = 0; else type = 1;
            if (targetstar.type == -1) type = 0;
            if (targetstar.type == 0) type = 0;
        }
        if (startstar.type == 0)
        {
            if (targetstar.type == 1) type = 1;
            if (targetstar.type == -1) type = 0;
            if (targetstar.type == 0) type = -1;
        }

        float asd = (float)(total / DFGlobal.travel_speed);
        this.directionx = (targetstar.x - startstar.x) / asd;
        this.directiony = (targetstar.y - startstar.y) / asd;
        this.directionz = (targetstar.z - startstar.z) / asd;

        this.nowx = startstar.x;
        this.nowy = startstar.y;
        this.nowz = startstar.z;
        this.targetv_x = targetstar.x;
        this.targetv_y = targetstar.y;
        this.targetv_z = targetstar.z;
    }
    public int start;//母星的下标
    public int target;//目标恒星的下标
    public double distance, total;//已飞行距离和总距离
    public int stats;//状态，0=飞行，1=攻击
    public double defense;//舰队强度，当发展速度所减的值等于此值时舰队会返回
    public int type;//0为合作，1为攻击，-1则不会产生任何事情
    public float directionx, directiony, directionz;//单位方向向量
    public float nowx, nowy, nowz;//当前位置
    public float targetv_x, targetv_y, targetv_z;//目标星坐标（用来防止二向箔导致的瞬移）
}

