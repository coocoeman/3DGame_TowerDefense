using UnityEngine;
using UnityEngine.EventSystems;

public class 英雄生成點 : MonoBehaviour
{
    public GameObject 點上英雄;

    [Header("點位設定")]
    public Color 符合條件;
    public Color 不符合條件;

    private Renderer rerer;
    private Color myC , myCr;
    public Vector3 調整;

    private void Start()
    {
        rerer = GetComponent<Renderer>();
        myC = rerer.material.color;
    }
    private void Update()
    {
        顯示();
    }

    private void 顯示()
    {
        rerer.material.color = Color.clear;
        if (!英雄生成管理.統一.藍圖方法)
            return;
        if (點上英雄 != null)
            return;
        
        rerer.material.color = myC;
    }

    private void OnMouseEnter()
    {
        myCr = myC;
        if (EventSystem.current.IsPointerOverGameObject())
            return;
        if (!英雄生成管理.統一.藍圖方法)
            return;
        if (點上英雄 != null)
            return;
        if (英雄生成管理.統一.金額方法)
        {
            myC = 符合條件;
            英雄生成管理.統一.傳遞生成點方法(this);
        }
        else
        {
            myC = 不符合條件;
        }
    }
    private void OnMouseExit()
    {
        myC = myCr;
        英雄生成管理.統一.傳遞生成點方法(null);
    }

    public Vector3 給予座標方法()
    {
        return transform.position + 調整;
    }
    public Transform 給予物件方法()
    {
        return transform;
    }
}
