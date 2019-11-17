using UnityEngine;

public class Enemy : MonoBehaviour
{
    #region 變數
    [Header("敵人屬性")]
    [Tooltip("敵人移動速度")] public float speed = 10f;
    [Tooltip("敵人的生命值")] public int hp = 100;
    [Tooltip("擊殺敵人所掉的金錢")] public int money = 50;
    [Tooltip("敵人死亡的特效")] public GameObject deathParticle;
    [Tooltip("方向位置")]public Transform enemyDirection;
    private Transform pointTarget;//敵人前往的目標位置
    private int point = 0;//敵人鎖定的第幾個目標
    public Vector3 correction;
    #endregion

    #region 事件
    private void Start()
    {
        pointTarget = LocationPoint.points[0];//存取第一個點
    }

    private void Update()
    {
        Mobile();//移動位置
        Direction();
    }
    #endregion

    #region 方法
    /// <summary>
    /// 往定位點移動
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
    /// 判斷第幾個定位點
    /// </summary>
    private void NextPoint()
    {
        //判斷總定位點數量是否到最後一個
        if (point>=LocationPoint.points.Length-1)
        {
            End();//到達最後定位點時刪除物件
            return;
        }
        point++;//定位點數增加
        pointTarget = LocationPoint.points[point];//取的陣列的第幾位定位點

    }

    /// <summary>
    /// 到達最後定位點時刪除物件
    /// </summary>
    private void End()
    {
        Destroy(gameObject);
        HP.Damage();
    }

    /// <summary>
    /// 等待受到的傷害值 去減去自身生命
    /// </summary>
    /// <param 傷害值="hurtValue"></param>
    public void Hurt(int hurtValue)
    {
        hp -= hurtValue; //生命減去受到的傷害
        if (hp <= 0)//如果<=0讓他死亡
        {
            Death();//死亡
            Money.Obtain();
        }
    }

    /// <summary>
    /// 死亡特效、刪除物件、死亡後的計算之類...
    /// </summary>
    private void Death()
    {
        //死亡特效與維持時間
        GameObject getDeathParticle = (GameObject)Instantiate(deathParticle, transform.position, Quaternion.identity);
        Destroy(getDeathParticle, 5f);
        
        Destroy(gameObject);//刪除物件
    }

    /// <summary>
    /// 敵人面對的方向
    /// </summary>
    private void Direction()
    {
        Quaternion quaternion = Quaternion.LookRotation(pointTarget.position - transform.position);
        Vector3 vector3 = Quaternion.Lerp(enemyDirection.rotation, quaternion, Time.deltaTime * 10).eulerAngles;
        enemyDirection.rotation = Quaternion.Euler(0f, vector3.y, 0f);
    }
    #endregion
}

