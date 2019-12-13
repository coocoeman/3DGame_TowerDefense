using UnityEngine;

public class 選單命令 : MonoBehaviour
{
    public AudioSource 遊戲音樂;
    public AudioClip 背景音樂;

    public GameObject 卡牌欄位;
    public GameObject 強化畫面;

    private 英雄藍圖[] 藍圖;

    private void Start()
    {
        遊戲音樂 = GameObject.Find("遊戲總管").GetComponent<AudioSource>();
        遊戲音樂.clip = 背景音樂;
        遊戲音樂.Play();
    }

    public void 顯示擁有的卡牌方法()
    {
        藍圖 = new 英雄藍圖[卡牌管理.解鎖圖鑑.Length];
        藍圖 = 卡牌管理.解鎖圖鑑;
        if (卡牌欄位.transform.childCount == 0)
        {
            for (int i = 0; i < 藍圖.Length; i++)
            {
                Instantiate(Resources.Load("Prefab/Card/" + 藍圖[i].名子, typeof(object)) as GameObject, 卡牌欄位.transform);
            }
        }
        else
        {
            for (int i = 0; i < 藍圖.Length; i++)
            {
                for (int j = 0; j < 卡牌欄位.transform.childCount; j++)
                {
                    if (藍圖[i].名子 == 卡牌欄位.transform.GetChild(j).GetComponent<卡牌屬性>().名子)
                    {
                        break;
                    }
                    else if (j == 藍圖.Length-1 && 藍圖[i].名子 != 卡牌欄位.transform.GetChild(j).GetComponent<卡牌屬性>().名子)
                    {
                        Instantiate(Resources.Load("Prefab/Card/" + 藍圖[i].名子, typeof(object)) as GameObject, 卡牌欄位.transform);
                    }
                }
            }
        }
    }

    
}
