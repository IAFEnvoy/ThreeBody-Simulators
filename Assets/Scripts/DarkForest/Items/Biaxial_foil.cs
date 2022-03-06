using System;

[Serializable]
class Biaxial_foil//二向箔
{
    public Biaxial_foil(int num, int start, int target, Stars startstar, Stars targetstar)
    {
        this.num = num;
        this.life = true;
        this.start = start;
        this.target = target;
        this.distance = 0;
        this.total = Math.Sqrt((startstar.x - targetstar.x) * (startstar.x - targetstar.x)
            + (startstar.y - targetstar.y) * (startstar.y - targetstar.y) + (startstar.z - targetstar.z) * (startstar.z - targetstar.z));

        float asd = (float)(total / DFGlobal.speed2d);
        this.directionx = (targetstar.x - startstar.x) / asd;
        this.directiony = (targetstar.y - startstar.y) / asd;
        this.directionz = (targetstar.z - startstar.z) / asd;
        
        this.nowx = startstar.x;
        this.nowy = startstar.y;
        this.nowz = startstar.z;
    }
    public int num;//仅供数组索引使用
    public bool life;//是否存在
    public int start;//母星的下标
    public int target;//目标恒星的下标
    public double distance, total;//已飞行距离和总距离
    public float nowx, nowy, nowz;//当前位置
    public float directionx, directiony, directionz;//单位方向向量
}