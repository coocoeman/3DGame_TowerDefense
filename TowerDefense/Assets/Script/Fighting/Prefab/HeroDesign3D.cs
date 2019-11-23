using UnityEngine;

public class HeroDesign3D : MonoBehaviour
{
    #region
    [Header("英雄身上的物件")]
    [Tooltip("旋轉位置")] public Transform heroRotate;
    [Tooltip("產生攻擊位置")] public Transform heroAttack;
    [Tooltip("攻擊招式的物件")] public GameObject attackSkill;

    [Header("英雄設定")]
    [Tooltip("Tag標籤攻擊目標")] public string attackTargetKind = "enemy";
    [Tooltip("轉動的速度"), Range(1, 20)] public float rotationSpeed = 10f;

    public HeroDesign HD;

    private float attackIntervalTime = 0f; //用來計算攻擊間隔時間
    private Transform attackTarget; //鎖定目標
    #endregion

    private void Awake()
    {
        for (int i = 0; i < HeroCardsTeam.HDS.Length; i++)
        {
            if (HeroCardsTeam.HDS[i].name == HD.name)
            {
                HD = HeroCardsTeam.HDS[i];
            }
        }

    }

    private void Start()
    {
        
        InvokeRepeating("RenewTarget", 0f, 0.5f);//從0秒開始 每0.5秒調用一次 方法
        
    }

    private void Update()
    {
        if (attackTarget == null)//是否有目標
            return;
        LookLockingTarget();//讓英雄看著鎖定的目標
        if (attackIntervalTime <= 0)
        {
            AttackLockingTarget();//攻擊鎖定的目標
            AttackIntervalTime();//攻擊間格時間
        }
        attackIntervalTime -= Time.deltaTime;

    }
    
    /// <summary>
    /// 設定只能在編輯中看的偵測範圍
    /// </summary>
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, HD.detectionRange);
    }

    /// <summary>
    /// 設定攻擊目標
    /// </summary>
    private void RenewTarget()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag(attackTargetKind);
        //將所有Tag標記為"enemy"存到陣列裡;

        float misDistance = Mathf.Infinity;      //暫時先設定為無限大
        GameObject misDistanceEnemy = null;      //暫時先設定為空的

        foreach (GameObject judgeEnemy in enemys)//找到所有敵人最近的存到misDistanceEnemy
        {       
            float judgeEnemyDistance = Vector3.Distance(transform.position, judgeEnemy.transform.position);
            //將每一個敵人與英雄之間的距離暫存
            if (judgeEnemyDistance < misDistance)
            {
                misDistance = judgeEnemyDistance;
                misDistanceEnemy = judgeEnemy;
            }
        }

        if (misDistanceEnemy != null && misDistance <= HD.detectionRange)
        {//暫存的物件裡不為空並且最點距離在攻擊範圍內時 將此目標設為攻擊目標
            attackTarget = misDistanceEnemy.transform;
        }
        else
        {
            attackTarget= null;
        }
    }

    /// <summary>
    /// 面對目標
    /// </summary>
    private void LookLockingTarget()
    {
        //儲存與目標的位置
        Quaternion lookEnemy = Quaternion.LookRotation(attackTarget.position - transform.position);
        //儲存與目標的角度
        Vector3 TemporaryStorage = Quaternion.Lerp(heroRotate.rotation, lookEnemy, Time.deltaTime * rotationSpeed).eulerAngles;
        //改變角度
        heroRotate.rotation = Quaternion.Euler(0f, TemporaryStorage.y, 0f);
    }

    /// <summary>
    /// 攻擊目標
    /// </summary>
    private void AttackLockingTarget()
    {
        //建立攻擊
        GameObject openFire = (GameObject)Instantiate(attackSkill, heroAttack.position, heroAttack.rotation);
        HeroAccack heroAccack = openFire.GetComponent<HeroAccack>();
        if (heroAccack != null)//是否目標還在 給予數值
        {
            heroAccack.Search(attackTarget, HD.attackRange, HD.attackValue);
        }
    }
    
    /// <summary>
    /// 攻擊間格時間
    /// </summary>
    private void AttackIntervalTime()
    {
        attackIntervalTime = 1f / HD.attackSpeed;
    }
}
