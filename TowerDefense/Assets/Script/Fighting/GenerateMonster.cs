using System.Collections;
using UnityEngine;
//生成怪物
public class GenerateMonster : MonoBehaviour
{
    #region 
    [Header("產生敵人的設定")]
    [Tooltip("敵人物件")] public Transform[] enemyTransform ;
    [Tooltip("敵人產生位置")] public Transform generateLocation;

    [Tooltip("間格時間")] public float waveInterval = 10;
    [Tooltip("敵人數量")] public int enemyQuantity = 0;
    [Tooltip("波的數量")]public int waveNumber = 20;
    [Tooltip("怪物之間生成的短暫間隔"),Range(0.1f,1)]public float timeInterva = 0.5f;
    private float reciprocalTime = 5f;//倒數的時間

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
        if (reciprocalTime<=0 && waveNumber>0)
        {
            waveNumber--;
            enemyQuantity = (int) Random.Range(0, 20);//亂數決定怪物數量
            StartCoroutine(EceryGenerateQuantity());//產生敵人
            reciprocalTime = enemyQuantity* timeInterva + waveInterval;//重製時間
        }
        reciprocalTime -= Time.deltaTime;//時間倒數
        if (waveNumber == 0)
        {
            //通關瞜~~~~
        }
    }

    /// <summary>
    /// 敵人生成數量
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
        
        Instantiate(enemyTransform[(int)Random.Range(0,2)],generateLocation.position , generateLocation.rotation);
    }

    #endregion
}
