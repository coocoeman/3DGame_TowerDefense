using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 變數
    [Header("怪物屬性")]
    [Tooltip("敵人的生命值")] public int hp = 100;
    [Tooltip("敵人移動速度")] public float speed = 10f;
    [Tooltip("擊殺敵人所掉的金錢")] public int money = 50;
    public int damaeValue = 1;
    [Tooltip("敵人死亡的特效")] public GameObject deathParticle;
    [Tooltip("方向位置")]public Transform enemyDirection;
    private Transform pointTarget;//敵人前往的目標位置
    private int point = 0;//敵人鎖定的第幾個目標
    [Tooltip("修正位置 暫無用途")] public Vector3 correction;
    #endregion

    #region 事件
    private void Start()//取得第一的定位點
    {
        pointTarget = LocationPoint.points[0];
    }

    private void Update()
    {
        Mobile();
        Direction();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 向定位點移動
    /// </summary>
    private void Mobile()
    {
        //定位點與自身之間的距離
        Vector3 targetDistance = pointTarget.position - transform.position ;
        //開始往定位點移動
        transform.Translate(targetDistance.normalized * speed * Time.deltaTime);
        
        //如果快掉定位點時去取得下一個點
        if (Vector3.Distance(transform.position,pointTarget.position)<=0.5f)
        {
            NextPoint();
        }
    }

    /// <summary>
    /// 取得下個定位點 終點判斷
    /// </summary>
    private void NextPoint()
    {
        if (point>=LocationPoint.points.Length-1)
        {
            End();
            return;
        }
        point++;
        pointTarget = LocationPoint.points[point];
    }

    /// <summary>
    /// 怪物攻擊到主塔 刪除物件(怪物)
    /// </summary>
    private void End()
    {
        Destroy(gameObject);
        PanelManage.instance.血量.totalValue -= damaeValue;
    }

    /// <summary>
    /// 傷害怪物
    /// </summary>
    /// <param name="hurtValue">英雄給予的傷害值</param>
    public void HurtEnemy(int hurtValue)
    {
        hp -= hurtValue;
        if (hp <= 0)
        {
            Kill();
        }
    }

    /// <summary>
    /// 擊殺怪物
    /// </summary>
    private void Kill()
    {
        GameObject getDeathParticle = (GameObject)Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(getDeathParticle, 5f);
        Destroy(gameObject);
        PanelManage.instance.Earn();
    }

    /// <summary>
    /// 敵人面對的方向
    /// </summary>
    private void Direction()
    {
        Quaternion quaternion = Quaternion.LookRotation(pointTarget.position - transform.position);
        Vector3 vector3 = Quaternion.Lerp(enemyDirection.rotation, quaternion, Time.deltaTime * 10).eulerAngles;
        enemyDirection.rotation = Quaternion.Euler(enemyDirection.rotation.x, vector3.y, enemyDirection.rotation.z);
    }
    #endregion
}

