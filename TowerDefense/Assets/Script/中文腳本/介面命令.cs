using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[System.Serializable]
public class 介面
{
    public float 總值;
    public float 初始值;
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

    private SceneSwitching _SS;
    

    private bool 存活開關 = true;
    public GameObject 結束畫面,能量條,通關畫面;

    private void Start()
    {
        _SS = GameObject.Find("關卡管理").GetComponent<SceneSwitching>();
        血量.總值 = 血量.初始值;
        能量.總值 = 能量.初始值;

    }

    private void Update()
    {
        血量方法();
        能量方法();
        存活方法();
    }

    private void 血量方法()
    {
        血量.text.text ="HP:" + 血量.總值.ToString();
        血量.image.fillAmount =血量.總值 /血量.初始值;
    }

    private void 能量方法()
    {
        if (能量.總值>=5)
        {
            能量.總值 = 5;
        }
        else
        {
            能量.總值 += 0.1f * Time.deltaTime;
        }
        for (int i = 0; i < 5; i++)
        {
            if (能量.總值 == 0)
            {
                能量條.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
            }
            if ((int)能量.總值>i)
            {
                能量條.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,1f);
            }
            else
            {
                能量條.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Color(1,1,1,0);
            }
            if (能量.總值>i&& 能量.總值<i+1)
            {
                能量條.transform.GetChild(i).transform.GetChild(0).GetComponent<Image>().color = new Color(1, 1, 1, 能量.總值-i);
            }
        }
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
        _SS.RetrySwitch();
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void 選單方法(GameObject 畫面)
    {
        開關畫面方法(畫面);
        _SS.WaitSwitch("主畫面");
        //SceneManager.LoadScene("主畫面");
    }

    public void 通關方法()
    {
        Time.timeScale = 0f;
        通關畫面.SetActive(true);

    }
}

