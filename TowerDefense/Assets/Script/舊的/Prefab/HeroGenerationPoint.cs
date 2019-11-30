using UnityEngine;
using UnityEngine.EventSystems;
/// <summary>
/// 英雄產生點
/// </summary>
public class HeroGenerationPoint : MonoBehaviour
{
    #region 變數
    /// <summary>
    /// 點位上的英雄
    /// </summary>
    [Header("產生點的英雄")]
    public GameObject hero;

    [Header("產生點設定")]
    [Tooltip("目標的顏色")]public Color colorTarget;
    [Tooltip("餘額不足的顏色")]public Color colorNotMoney;

    /// <summary>
    /// 存產生點自身
    /// </summary>
    private Renderer storageRenderer;
    /// <summary>
    /// 自身原本的顏色
    /// </summary>
    private Color colorOriginal;
    /// <summary>
    /// 調整英雄生成
    /// </summary>
    public Vector3 adjustmentHero;

    #endregion

    #region 事件
    private void Start()
    {
        storageRenderer = GetComponent<Renderer>();
        colorOriginal = storageRenderer.material.color; //保存原色

    }

    //滑鼠進入產生點
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;//在UI上點擊不會處發生成 排除UGUI點擊BUG
        if (!GenerateHeroManagement.instance.HeroBool)
            return;//建立英雄判斷
        if (hero != null)
            return;//點位上英雄判斷
        if (GenerateHeroManagement.instance.MoneyBool)
        {//金錢判斷
            storageRenderer.material.color = colorTarget;
            GenerateHeroManagement.instance.SetPoint(this);
        }
        else
        {
            storageRenderer.material.color = colorNotMoney;
        }
    }

    //滑鼠離開產生點
    void OnMouseExit()
    {
        storageRenderer.material.color = colorOriginal;
        GenerateHeroManagement.instance.SetPoint(null);
    }
    #endregion

    #region 方法

    /// <summary>
    /// 回傳產生點的座標
    /// </summary>
    /// <returns>座標=點位+微調</returns>
    public Vector3 GeneratingTargetVector()
    {
        return transform.position + adjustmentHero;
    }

    #endregion
}
