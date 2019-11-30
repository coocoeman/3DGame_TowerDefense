using UnityEngine;

public class 卡牌管理 : MonoBehaviour
{
    //public static 卡牌管理 總管;
    public 英雄藍圖[] 全圖鑑;
    public static 英雄藍圖[] 解鎖圖鑑;

    /*private void Awake()
    {
        if (總管 != null)
        {
            return;
        }
        總管 = this;
    }*/

    private void Start()
    {
        更新圖鑑方法();
    }

    public void 更新圖鑑方法()
    {
        int a = 0;
        for (int i = 0; i < 全圖鑑.Length; i++)
        {
            if (全圖鑑[i].鎖)
            {
                a++;
            }
        }
        解鎖圖鑑 = new 英雄藍圖[a];
        for (int i = 0; i < a; i++)
        {
            for (int j = 0; j < a;)
            {
                if (全圖鑑[i].鎖)
                {
                    解鎖圖鑑[j] = 全圖鑑[i];
                    j++;
                }
            }
        }
    }
}
