using UnityEngine;

public class 怪物命令 : MonoBehaviour
{
    public 怪物藍圖 屬性;
    public int 傷害值 = 1;
    private Transform[] 目標點S;
    private Transform 前往目標;
    private int 目標數 = 0;

    private void Start()
    {
        目標點S = 怪物生成管理.路線S[(int)Random.Range(0, 怪物生成管理.路線S.Length)].GetComponent<怪物移動目標點>().posints;
        前往目標 = 目標點S[0];
        transform.position = 目標點S[0].position;
    }

    private void Update()
    {
        移動方法();
    }

    #region 主動
    private void 移動方法()
    {
        Vector3 距離 = 前往目標.position - transform.position;
        transform.Translate(距離.normalized * 屬性.速度 * Time.deltaTime);
        if (Vector3.Distance(transform.position, 前往目標.position) <= 0.5)
        {
            取得下個目標點方法();
        }
        面對目標點方法();
    }
    private void 取得下個目標點方法()
    {
        if (目標數>= 目標點S.Length-1)
        {
            到達終點方法();
            return;
        }
        目標數++;
        前往目標 = 目標點S[目標數];
    }
    private void 到達終點方法()
    {
        Destroy(gameObject);
        介面命令.介面管理.血量.總值 -= 傷害值; 
    }
    private void 面對目標點方法()
    {
        Quaternion q = Quaternion.LookRotation(前往目標.position - transform.position);
        Vector3 v3 = Quaternion.Lerp(屬性.轉向.rotation, q, Time.deltaTime * 10).eulerAngles;
        屬性.轉向.rotation = Quaternion.Euler(屬性.轉向.rotation.x, v3.y, 屬性.轉向.rotation.z);
    }
    #endregion
    #region 被動
    public void 受傷方法(int 值)
    {
        屬性.生命 -= 值;
        if (屬性.生命 <= 0)
        {
            死亡方法();
        }
    }

    private void 死亡方法()
    {
        GameObject 特效 = (GameObject)Instantiate(屬性.死亡特效, transform.position, Quaternion.identity,transform);
        Destroy(特效, 0.3f);
        Destroy(gameObject);
        //獲取資源
    }
    #endregion
}
