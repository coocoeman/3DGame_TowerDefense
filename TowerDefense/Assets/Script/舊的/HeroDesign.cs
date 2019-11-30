using UnityEngine;

[System.Serializable]
public class HeroDesign
{
    [Tooltip("玩家是否傭有")] public bool holdCrad;
    /// <summary>
    /// 英雄物件
    /// </summary>
    [Tooltip("英雄物件")] public GameObject prefab;
    /// <summary>
    /// 英雄名
    /// </summary>
    [Tooltip("英雄名")] public string name;
    /// <summary>
    /// 金額
    /// </summary>
    [Tooltip("金額")] public int price;
    /// <summary>
    /// 等級
    /// </summary>
    [Tooltip("等級")] public int level;
    /// <summary>
    /// 攻擊值
    /// </summary>
    [Tooltip("攻擊值")] public int attackValue;
    /// <summary>
    /// 偵測範圍
    /// </summary>
    [Tooltip("偵測範圍")] public float detectionRange;
    /// <summary>
    /// 攻擊傷害範圍
    /// </summary>
    [Tooltip("攻擊傷害範圍")] public float attackRange;
    /// <summary>
    /// 攻擊速度
    /// </summary>
    [Tooltip("攻擊速度")] public float attackSpeed;

}
