using UnityEngine;
using UnityEngine.UI;

public class 強化命令 : MonoBehaviour
{
    public 英雄藍圖 藍圖;
    public GameObject 卡牌位置;
    public Text 名子, 等級, 代價, 傷害, 偵測範圍, 波及範圍, 攻擊速度;

    private GameObject 卡牌;

    public void 關閉強化畫面方法()
    {
        gameObject.SetActive(false);
        Destroy(卡牌);
        藍圖 = null;
    }

    private void Update()
    {
        顯示方法();
    }

    public void 建立卡牌()
    {
        卡牌 = Instantiate(Resources.Load("Prefab/Card/" + 藍圖.名子, typeof(object)) as GameObject, 卡牌位置.transform);
    }

    private void 顯示方法()
    {
        名子.text = 藍圖.名子;
        等級.text = "等級:" + 藍圖.等級;
        代價.text = "代價:" + 藍圖.金額;
        傷害.text = "傷害:" + 藍圖.攻擊值;
        偵測範圍.text = "偵測範圍:" + 藍圖.偵測範圍;
        波及範圍.text = "波及範圍:" + 藍圖.波及範圍;
        攻擊速度.text = "攻速:" + 藍圖.攻擊速度;
    }
}
