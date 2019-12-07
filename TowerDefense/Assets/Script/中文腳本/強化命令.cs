using UnityEngine;

public class 強化命令 : MonoBehaviour
{
    public static 強化命令 統一;
    private void Awake()
    {
        if (統一 != null)
        {
            return;
        }
        統一 = this;
    }
    public GameObject 強化畫面;
    private 卡牌屬性 屬性;

    private void Update()
    {
        Debug.Log(屬性.名子);
        強化畫面.SetActive(屬性方法);
    }

    public void 傳遞卡牌屬性(卡牌屬性 傳遞屬性)
    {
        屬性 = 傳遞屬性;
        Debug.Log("成功");
    }
    public bool 屬性方法 { get { return 屬性 != null; } }
}
