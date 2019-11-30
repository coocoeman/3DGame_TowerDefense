using UnityEngine;

public class 卡牌屬性 : MonoBehaviour
{
    public string 名子;
    public 英雄藍圖 藍圖;

    private void Start()
    {
        取得藍圖初始值方法();
        //取得升等資料方法
        //計算升等後數值方法
    }

    private void 取得藍圖初始值方法()
    {
        英雄藍圖[] 藍圖S = 卡牌管理.解鎖圖鑑;
        for (int i = 0; i < 藍圖S.Length; i++)
        {
            if (名子 == 藍圖S[i].名子)
            {
                藍圖 = 藍圖S[i];
            }
        }
    }

    
}
