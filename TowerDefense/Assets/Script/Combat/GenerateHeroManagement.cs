using UnityEngine;
/// <summary>
/// 英雄建立的管理
/// </summary>
public class GenerateHeroManagement : MonoBehaviour
{
    #region 變數
    public static GenerateHeroManagement instance;

    public GameObject generateParticle;//英雄產生的特效
    private HeroDesign heroDesign;//英雄的設計圖

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
    public bool SetJudge { get { return heroDesign != null; } }
    /// <summary>
    /// 讓建立英雄位置知道是否足夠金錢可以建立英雄
    /// </summary>
    public bool MoneyJudge { get { return  Money.moneys>= heroDesign.cont; } }

    /// <summary>
    /// 等待要建立的英雄物件
    /// </summary>
    /// <param name="prefab">獲取要建立的英雄物件</param>
    public void SetHero(HeroDesign prefab)
    {
        heroDesign = prefab;
    }

    /// <summary>
    /// 建立英雄與特效 並減少金錢
    /// </summary>
    /// <param name="point">取得點集到的生成英雄定位點</param>
    public void SetEnemyPosition(HeroGenerationPoint point)
    {
        if (Money.moneys < heroDesign.cont)//判斷金額是否還足夠
        {
            Debug.Log("錢不夠");
            return;
        }
        Money.moneys -= heroDesign.cont;
        //所有金錢減去建立英雄的金額
        GameObject hero = (GameObject)Instantiate(heroDesign.prefab, point.GeneratingTargetVector(), Quaternion.identity);
        point.hero = hero;
        //建立英雄
        GameObject 效果 = (GameObject)Instantiate(generateParticle, point.GeneratingTargetVector(), Quaternion.identity);
        Destroy(效果, 5f);
        //使用特效
    }

}
