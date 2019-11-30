using UnityEngine;

public class 英雄命令 : MonoBehaviour
{
    public 英雄藍圖 藍圖;
    [Header("預製建設定")]
    public Transform 旋轉, 攻擊位置;
    public GameObject 招式;
    public string 目標標籤 = "enemy";
    public float 旋轉速度 = 10;

    private float 攻擊間格時間 = 0f;
    private Transform 攻擊目標;


    private void Start()
    {
        for (int i = 0; i < 卡牌管理.解鎖圖鑑.Length; i++)
        {
            if (藍圖.名子 == 卡牌管理.解鎖圖鑑[i].名子)
            {
                藍圖 = 卡牌管理.解鎖圖鑑[i];
            }
        }
        InvokeRepeating("搜索目標方法", 0f, 0.5f);//每幾秒調用一次方法
        
    }

    private void Update()
    {
        if (攻擊目標 == null)
            return;
        面向攻擊目標方法();
        if (攻擊間格時間 <= 0)
        {
            攻擊目標方法();
        }
        攻擊間格時間 -= Time.deltaTime;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 藍圖.偵測範圍);
    }

    private void 搜索目標方法()
    {
        GameObject[] 敵人 = GameObject.FindGameObjectsWithTag(目標標籤);

        float 最近距離 = Mathf.Infinity;
        GameObject 最近敵人 = null;

        foreach (GameObject 查詢目標 in 敵人) 
        {
            float 敵人距離 = Vector3.Distance(transform.position, 查詢目標.transform.position);
            if (敵人距離 < 最近距離)
            {
                最近距離 = 敵人距離;
                最近敵人 = 查詢目標;
            }
        }

        if (最近敵人 != null && 最近距離 <= 藍圖.偵測範圍)
        {
            攻擊目標 = 最近敵人.transform;
        }
        else
        {
            攻擊目標 = null;
        }
    }

    private void 面向攻擊目標方法()
    {
        Quaternion q = Quaternion.LookRotation(攻擊目標.position - transform.position);
        Vector3 v3 = Quaternion.Lerp(旋轉.rotation, q, Time.deltaTime * 旋轉速度).eulerAngles;
        旋轉.rotation = Quaternion.Euler(0f,v3.y,0f);
    }

    private void 攻擊目標方法()
    {
        GameObject g = (GameObject)Instantiate(招式, 攻擊位置.position, 攻擊位置.rotation,transform);
        招式命令 _招式命令 = g.GetComponent<招式命令>();
        if (_招式命令 != null)
        {
            _招式命令.給予招式方法(攻擊目標, 藍圖.攻擊值, 藍圖.波及範圍, 目標標籤);
        }
        攻擊間格時間 = 1f / 藍圖.攻擊速度;
    }
}
