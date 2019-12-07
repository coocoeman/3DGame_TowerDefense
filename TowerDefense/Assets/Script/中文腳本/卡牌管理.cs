using UnityEngine;

public class 卡牌管理 : MonoBehaviour
{
    public 英雄藍圖[] 全圖鑑;
    public static 英雄藍圖[] 解鎖圖鑑;
    public 英雄藍圖[] 顯示圖鑑;

    private void Start()
    {
        InvokeRepeating("更新圖鑑方法", 0f, 0.5f);
    }

    private void Update()
    {
        顯示圖鑑 = 解鎖圖鑑;
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
        for (int i = 0; i < a;)
        {
            for (int j = 0; j < 全圖鑑.Length;j++)
            {
                if (全圖鑑[j].鎖)
                {
                    解鎖圖鑑[i] = 全圖鑑[j];
                    i++;
                }
            }
        }
    }
}
