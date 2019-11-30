using System.Collections;
using UnityEngine;
//生成怪物
public class GenerateMonster : MonoBehaviour
{
    #region 
    /// <summary>
    /// 怪物物件
    /// </summary>
    [Header("怪物種類")]
    public Transform[] enemyTransform ;
    [Header("怪物生成設定")]
    [Tooltip("出生位置")] public Transform generateLocation;
    [Tooltip("波的數量")] public int waveQuantity = 20;
    [Tooltip("間格時間")] public float waveInterval = 10;
    [Tooltip("敵人數量")] public int enemyQuantity = 0;
    [Tooltip("怪物之間生成的短暫間隔"),Range(0.1f,1)]public float timeInterva = 0.5f;
    [Tooltip("倒數時間")]public float reciprocalTime = 5f;

    #endregion
    #region 事件
    private void Update()
    {
        ReciprocalTime();
    }
    #endregion

    #region 事件
    /// <summary>
    /// 時間倒數 並 生成 與達成通關條件
    /// </summary>
    private void ReciprocalTime()
    {
        if (reciprocalTime<=0 && waveQuantity>0)
        {
            waveQuantity--;
            enemyQuantity++;   
            StartCoroutine(EceryGenerateQuantity());//產生敵人
            reciprocalTime = enemyQuantity* timeInterva + waveInterval;//重製倒數時間
        }
        reciprocalTime -= Time.deltaTime;//時間倒數
        if (waveQuantity == 0)
        {
            Debug.Log("通關條件");
        }
    }

    /// <summary>
    /// 每波怪與怪之間的生成間隔
    /// </summary>
    /// <returns></returns>
    IEnumerator EceryGenerateQuantity()
    {
        for (int i = 0; i < enemyQuantity; i++)
        {
            EnemyGenerateLocation();//敵人生成
            yield return new WaitForSeconds(timeInterva);//間隔
        }
    }

    /// <summary>
    /// 敵人生成的位置
    /// </summary>
    private void EnemyGenerateLocation()
    {
        
        Instantiate(enemyTransform[(int)Random.Range(0, enemyTransform.Length)],generateLocation.position , generateLocation.rotation);
    }

    #endregion
}
