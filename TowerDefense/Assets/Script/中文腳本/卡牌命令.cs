using UnityEngine;

public class 卡牌命令 : MonoBehaviour
{
    public GameObject 發牌位置;
    private GameObject 拖曳英雄;
    private GameObject 牌;

    private 英雄藍圖[] 藍圖;

    public void 發牌方法()
    {
        for (int i = 0; i < 5; i++)
        {
            if (發牌位置.transform.GetChild(i).transform.childCount == 0)
            {
                藍圖 = new 英雄藍圖[卡牌管理.解鎖圖鑑.Length];
                藍圖 = 卡牌管理.解鎖圖鑑;
                string name = 藍圖[0].名子;
                Instantiate(Resources.Load("Prefab/Card/" + name, typeof(object)) as GameObject, 發牌位置.transform.GetChild(i).transform);
            }
        }
    }

    public void 卡牌觸發方法(GameObject 牌按鈕)
    {
        牌 = 牌按鈕.transform.GetChild(0).gameObject;
        英雄生成管理.統一.傳遞藍圖方法(牌.GetComponent<卡牌屬性>().藍圖);
        英雄生成管理.統一.刪除卡牌方法(牌);
        Vector3 v3 = Input.mousePosition;
        Quaternion q = new Quaternion(0, 0, 0, 0);
        拖曳英雄 = Instantiate( 牌.GetComponent<卡牌屬性>().藍圖.英雄預製件, v3, q);
        拖曳英雄.GetComponent<英雄命令>().enabled = false;
    }
    public void 卡牌拖曳方法()
    {
        牌.SetActive(false);
        Vector3 v3 = Camera.main.WorldToScreenPoint(拖曳英雄.transform.position);
        v3 = new Vector3(Input.mousePosition.x, Input.mousePosition.y, v3.z);
        v3 = Camera.main.ScreenToWorldPoint(v3);
        拖曳英雄.transform.position = new Vector3(v3.x, 10, v3.z);
    }

    public void 卡牌放開方法()
    {
        if (牌 !=null)
        {
            牌.SetActive(true);
        }
        Destroy(拖曳英雄);
    }
}
