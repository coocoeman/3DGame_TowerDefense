using UnityEngine;

public class HeroAccack : MonoBehaviour
{
    #region
    /// <summary>
    /// 擊中特效
    /// </summary>
    [Header("子彈設定")]
    [Tooltip("擊中特效")]public GameObject hitParticle;
    /// <summary>
    /// 飛行速度
    /// </summary>
    [Tooltip("飛行速度")] public float flightSpeed = 70f;

    /// <summary>
    /// 鎖定目標
    /// </summary>
    private Transform accackTarget;
    /// <summary>
    /// 波及範圍
    /// </summary>
    private float spreadRange;
    /// <summary>
    /// 傷害值
    /// </summary>
    private int attackValue;
    #endregion

    #region 事件
    //判斷是否有目標
    private void Update()
    {
        if(accackTarget == null)
        {
            Destroy(gameObject);
            return;
        }
        Flight();
    }
    //設定攻擊偵測範圍
    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, spreadRange);
    }
    #endregion

    #region 方法
    /// <summary>
    /// 英雄給予 攻擊目標,攻擊範圍,傷害值
    /// </summary>
    /// <param name="target">攻擊目標</param>
    /// <param name="range">攻擊範圍</param>
    /// <param name="Value">傷害值</param>
    public void Search(Transform target, float range, int Value )
    {
        accackTarget = target;
        spreadRange = range;
        attackValue = Value;
    }

    /// <summary>
    /// 攻擊飛向敵人
    /// </summary>
    private void Flight()
    {
        Vector3 dir = accackTarget.position - transform.position;
        float targetDistance = flightSpeed * Time.deltaTime;
        if (dir.magnitude <= targetDistance)
        {
            HitTarget();
            return;
        }
        transform.Translate(dir.normalized * targetDistance, Space.World);
    }

    /// <summary>
    /// 擊中目標 使用特效
    /// </summary>
    void HitTarget()
    {
        GameObject useHitParticle = (GameObject)Instantiate(hitParticle, transform.position, transform.rotation);
        Destroy(useHitParticle, 0.2f);

        //範圍傷害
        if (spreadRange>0f)
        {
            RangeHurt();
        }
        else
        {
            HurtEnemy(accackTarget);
        }
        Destroy(gameObject);
    }

    /// <summary>
    /// 傷害目標
    /// </summary>
    /// <param name="target">攻擊目標</param>
    void HurtEnemy(Transform target)
    {
        Enemy enemy = target.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.HurtEnemy(attackValue);//給予怪物傷害值進行扣血
        }
    }

    /// <summary>
    /// 範圍傷害
    /// </summary>
    private void RangeHurt()
    {
        //儲存所有在範圍內標記為敵人的物件
        Collider[] colliders = Physics.OverlapSphere(transform.position, spreadRange);
        foreach (Collider collider in colliders)
        {
            if (collider.tag == "enemy")
            {
                HurtEnemy(collider.transform);
            }
        }
    }

    #endregion
}
