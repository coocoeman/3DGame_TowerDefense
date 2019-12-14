using UnityEngine;

public class 招式命令 : MonoBehaviour
{
    [Header("招式設定")]
    public GameObject 命中特效;
    public float 速度;

    private Transform 攻擊目標;
    private int 攻擊值;
    private float 波及範圍;
    private string 目標標籤;

    private void Update()
    {
        if (攻擊目標 == null)
        {
            Destroy(gameObject);
            return;
        }

        移動方法();
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 波及範圍);
    }

    public void 給予招式方法(Transform 目標, int 傷害, float 範圍,string 名稱)
    {
        攻擊目標 = 目標;
        攻擊值 = 傷害;
        波及範圍 = 範圍;
        目標標籤 = 名稱;
    }

    private void 移動方法()
    {
        Vector3 目標距離 = 攻擊目標.position - transform.position;
        float 飛行速度 = 速度 * Time.deltaTime;
        if (目標距離.magnitude <= 飛行速度)
        {
            命中方法();
            return;
        }
        transform.Translate(目標距離.normalized * 飛行速度, Space.World);
    }

    private void 命中方法()
    {
        GameObject 效果 = (GameObject)Instantiate(命中特效, transform.position, transform.rotation);
        Destroy(效果, 0.2f);
        if (波及範圍 >0f)
        {
            範圍攻擊方法();
        }
        else
        {
            攻擊方法(攻擊目標);
        }
        Destroy(gameObject);
    }

    private void 攻擊方法(Transform 目標)
    {
        怪物命令 _怪物命令 = 目標.GetComponent<怪物命令>();
        if (_怪物命令 != null)
        {
            _怪物命令.受傷方法(攻擊值);
        }
    }

    private void 範圍攻擊方法()
    {
        Collider[] cs = Physics.OverlapSphere(transform.position, 波及範圍);
        foreach (Collider c in cs)
        {
            if (c.tag == 目標標籤)
            {
                攻擊方法(c.transform);
            }
        }
    }

}
