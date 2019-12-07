using UnityEngine;

public class 選單命令 : MonoBehaviour
{
    public GameObject 卡牌;

    private 英雄藍圖[] 藍圖;

    public void 顯示擁有的卡牌方法()
    {
        藍圖 = new 英雄藍圖[卡牌管理.解鎖圖鑑.Length];
        藍圖 = 卡牌管理.解鎖圖鑑;
        if (卡牌.transform.childCount == 0)
        {
            for (int i = 0; i < 藍圖.Length; i++)
            {
                Instantiate(Resources.Load("Prefab/Card/" + 藍圖[i].名子, typeof(object)) as GameObject, 卡牌.transform);
            }
        }
        else
        {
            for (int i = 0; i < 藍圖.Length; i++)
            {
                for (int j = 0; j < 卡牌.transform.childCount; j++)
                {
                    if (藍圖[i].名子 == 卡牌.transform.GetChild(j).GetComponent<卡牌屬性>().名子)
                    {
                        break;
                    }
                    else if (j == 藍圖.Length-1 && 藍圖[i].名子 != 卡牌.transform.GetChild(j).GetComponent<卡牌屬性>().名子)
                    {
                        Instantiate(Resources.Load("Prefab/Card/" + 藍圖[i].名子, typeof(object)) as GameObject, 卡牌.transform);
                    }
                }
            }
        }
    }
}
