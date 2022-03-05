class global
{
    public static int startcnt = 0;//初始文明数量
    public static int startscore = 0;//初始得分
    public static double travel_speed = 1.5;//旅行速度
    public static int develop = 20;//发展速度
    public static int cooperation = 5;//合作的时候额外的发展速度
    public static int attack = -30;//战争的时候额外的发展速度
                                   //（通常设置为小于-develop的数，当然你也可以设置为正的。。。）
    public static bool allowspawn = true;//是否生成新文明
    public static int spawnprobability = 100;//新文明生成概率，填1000则每一次Update有1/1000的概率生成新文明
    public static int cooldowntime = 500;//需要多少score才能发射飞船
    public static double rangex = 200, rangey = 200, rangez = 200;//生成范围
    public static int defensetimes = 1;//score和舰队强度的比值
    public static int peace = 40, middle = 20, attacks = 40;//生成概率
    public static bool allowtechboom = true;//是否允许技术爆炸
    public static int techboommax = 5;//最大允许技术爆炸次数
    public static int techboom_addon = 5;//每进行一次技术爆炸发展速度的加成
    public static int techboom_probability = 10000;//技术爆炸概率，填1000则每一次Update有1/1000的概率发生技术爆炸
    public static bool allow2d = true;//是否允许二维化
    public static int score2d = 50000;//二维化所需要的科技水平（得分）
    public static double speed2d = 6;//二向箔飞行速度
    public static int cooldown2d = 1000;//二向箔使用冷却
    public static bool allow_attack_help = true;//是否允许攻击型文明接受和平型文明的帮助
}