using System.Collections;
using UnityEngine;

public class 怪物生成管理 : MonoBehaviour
{
    #region
    [Header("怪物種類")]
    public GameObject[] 種類;
    [Header("怪物路線")]
    public Transform[] 路線;
    public static Transform[] 路線S;
    [Header("生成設定")]
    public Transform 存放物件;
    public int 攻擊波數;
    public float 波間隔時間;
    public int 每波怪物數量;
    public float 怪物的間隔距離;
    public float 倒數計時;
    #endregion

    private void Start()
    {
        路線S = new Transform[路線.Length];
        路線S = 路線;
    }

    private void Update()
    {
        倒數方法();
    }

    private void 倒數方法()
    {
        if (攻擊波數 <=0)
        {
            if (存放物件.transform.childCount == 0)
            {
                介面命令.介面管理.通關方法();
            }
            return;
        }
        if (倒數計時 <= 0)
        {
            每波怪物數量++;
            攻擊波數--;
            StartCoroutine(怪物間隔方法());
            倒數計時 = 每波怪物數量 * 怪物的間隔距離 + 波間隔時間;
        }
        倒數計時 -= Time.deltaTime;
    }

    IEnumerator 怪物間隔方法()
    {
        for (int i = 0; i < 每波怪物數量; i++)
        {
            怪物生成方法();
            yield return new WaitForSeconds(怪物的間隔距離);
        }
    }

    private void 怪物生成方法()
    {
        Instantiate(種類[(int)Random.Range(0, 種類.Length)],存放物件);
    }
}
