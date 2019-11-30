using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PanelManage : MonoBehaviour
{
    public static PanelManage instance;
    public 介面 血量;
    public 介面 能量;

    private bool endBool = false;
    public GameObject endPanelGameObject;

    private void Awake()
    {
        if (instance != null)
        {
            return;
        }
        instance = this;
    }

    private void Start()
    {
        血量.totalValue = 血量.initialValue;
        能量.totalValue = 能量.initialValue;
    }

    private void Update()
    {
        血量.text.text = 血量.totalValue.ToString();
        能量.text.text = 能量.totalValue.ToString();
        StopPanel();
    }
    #region 方法
    #region 能量
    /// <summary>
    /// 招喚消耗能量
    /// </summary>
    /// <param name="value"></param>
    public void Consumption(int value)
    {
        能量.totalValue -= value;
    }
    /// <summary>
    /// 擊殺獲取能量
    /// </summary>
    public void Earn()
    {
        能量.totalValue++;
    }
    #endregion
    #region 畫面控制

    /// <summary>
    /// 血量判斷
    /// </summary>
    private void StopPanel()
    {
        //Debug.Log(endBool);
        if (endBool)
            return;
        if (血量.totalValue<=0)
        {
            endBool = true;
            StopTime(endPanelGameObject);
        }
    }
    /// <summary>
    /// 時間跟畫面控制
    /// </summary>
    /// <param name="ui"></param>
    private void StopTime(GameObject ui)
    {
        ui.SetActive(!ui.activeSelf);
        if (ui.activeSelf)
        {
            Time.timeScale = 0f;
        }
        else
        {
            Time.timeScale = 1f;
        }
    }

    /// <summary>
    /// 按鈕重製場景
    /// </summary>
    /// <param name="ui"></param>
    public void Retry(GameObject ui)
    {
        StopTime(ui);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    /// <summary>
    /// 按鈕返回場景
    /// </summary>
    /// <param name="ui"></param>
    public void Menu(GameObject ui)
    {
        StopTime(ui);
        SceneManager.LoadScene("主畫面");
    }
    #endregion
    #endregion

}

