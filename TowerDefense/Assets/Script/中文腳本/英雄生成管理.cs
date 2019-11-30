using UnityEngine;

public class 英雄生成管理 : MonoBehaviour
{

    public static 英雄生成管理 統一;
    private void Awake()
    {
        if (統一 != null)
        {
            return;
        }
        統一 = this;
    }

    private 英雄藍圖 藍圖;
    private 英雄生成點 生成點;
    private GameObject 卡;

    /// <summary>
    /// 是否有要建立的藍圖
    /// </summary>
    public bool 藍圖方法 { get { return 藍圖 != null; } }
    /// <summary>
    /// 是否足夠金額建立
    /// </summary>
    public bool 金額方法 { get { return 介面命令.介面管理.能量.總值 >= 藍圖.金額; } }

    public void 傳遞藍圖方法(英雄藍圖 給予藍圖)
    {
        藍圖 = 給予藍圖;
    }

    public void 傳遞生成點方法(英雄生成點 給予生成點)
    {
        生成點 = 給予生成點;
    }

    public void 建立英雄方法()
    {
        if (生成點 ==null)
            return;
        if (介面命令.介面管理.能量.總值 < 藍圖.金額)
        {
            Debug.Log("金額不足");
            return;
        }
        介面命令.介面管理.能量.總值 -= 藍圖.金額;
        GameObject 英雄 = (GameObject)Instantiate(藍圖.英雄預製件, 生成點.給予座標方法(), Quaternion.identity);
        生成點.點上英雄 = 英雄;
        Destroy(卡);
        藍圖 = null;
        
    }

    public void 刪除卡牌方法(GameObject 牌)
    {
        卡 = 牌;
    }
}
