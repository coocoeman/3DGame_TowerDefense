using UnityEngine;
/// <summary>
/// 英雄建立的管理
/// </summary>
public class GenerateHeroManagement : MonoBehaviour
{
    /// <summary>
    /// 方便取得方法
    /// </summary>
    public static GenerateHeroManagement instance;

    #region 變數
    public GameObject generateParticle;//英雄產生的特效
    private HeroDesign heroDesign;//英雄的設計圖
    private HeroGenerationPoint targetPoint;//產生點
    private GameObject card;
    #endregion
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    /// <summary>
    /// 判斷是否有英雄要建立
    /// </summary>
    public bool HeroBool { get { return heroDesign != null; } }
    /// <summary>
    /// 判斷金錢是否足夠
    /// </summary>
    public bool MoneyBool { get { return PanelManage.instance.能量.totalValue >= heroDesign.price; } }

    /// <summary>
    /// 給予建立的英雄
    /// </summary>
    /// <param name="prefab">英雄</param>
    public void SetHero(HeroDesign prefab)
    {
        heroDesign = prefab;
    }
    /// <summary>
    /// 給予要建立的位置
    /// </summary>
    /// <param name="point"></param>
    public void SetPoint(HeroGenerationPoint point)
    {
        targetPoint = point;
    }

    /// <summary>
    /// 產生英雄
    /// </summary>
    public void GenerateHero()
    {
        if (targetPoint == null)
            return;
        if (PanelManage.instance.能量.totalValue < heroDesign.price)//判斷金額是否還足夠
        {
            Debug.Log("錢不夠");
            return;
        }
        PanelManage.instance.能量.totalValue -= heroDesign.price;
        //所有金錢減去建立英雄的金額
        GameObject hero = (GameObject)Instantiate(heroDesign.prefab, targetPoint.GeneratingTargetVector(), Quaternion.identity);
        targetPoint.hero = hero;
        //建立英雄
        GameObject 效果 = (GameObject)Instantiate(generateParticle, targetPoint.GeneratingTargetVector(), Quaternion.identity);
        Destroy(效果, 5f);
        //使用特效
        Destroy(card);
        heroDesign = null; //只能建立一次

    }

    /// <summary>
    /// 獲取卡片 成功建立英雄要將它刪除 失敗哲無視
    /// </summary>
    /// <param name="target"></param>
    public void CardDestroy(GameObject target)
    {
        card = target;
    }
}
