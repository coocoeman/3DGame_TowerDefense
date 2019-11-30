using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class 介面
{
    public int 總值, totalValue;
    public int 初始值, initialValue;
    public Text text;
    public Image image;
}

public class 介面命令 : MonoBehaviour
{
    public static 介面命令 介面管理;
    private void Awake()
    {
        if (介面管理 != null)
        {
            return;
        }
        介面管理 = this;
    }

    public 介面 血量;
    public 介面 能量;

    private bool 存活開關 = true;
    public GameObject 結束畫面;

    private void Start()
    {
        血量.總值 = 血量.初始值;
        能量.總值 = 能量.初始值;
    }

    private void Update()
    {
        血量.text.text = 血量.總值.ToString();
        能量.text.text = 能量.總值.ToString();
        存活方法();
    }

    private void 存活方法()
    {
        if (!存活開關)
        {
            return;
        }
        if (血量.總值 <= 0)
        {
            存活開關 = false;
            開關畫面方法(結束畫面);
        }
    }

    public void 開關畫面方法(GameObject 畫面)
    {
        畫面.SetActive(!畫面.activeSelf);
        if (畫面.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    public void 重製方法(GameObject 畫面)
    {
        開關畫面方法(畫面);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void 選單方法(GameObject 畫面)
    {
        開關畫面方法(畫面);
        SceneManager.LoadScene("主畫面");
    }
}

