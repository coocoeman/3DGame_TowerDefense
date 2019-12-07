using UnityEngine;
using System.IO;

public class 存取命令 : MonoBehaviour
{
    private string text = " ";

    private 英雄藍圖[] 存取圖鑑;

    void Start()
    {
        FileStream fs = new FileStream(Application.dataPath + "/Data.txt", FileMode.Create);
        fs.Close();
        讀檔();
    }
    void Update()
    {
        
        if (Input.GetKey(KeyCode.S))
        {
            存檔();
        }
        if (Input.GetKey(KeyCode.D))
        {
            讀檔();
        }
    }

    public void 存檔()
    {
        存取圖鑑 = 卡牌管理.解鎖圖鑑;
        FileStream fs = new FileStream(Application.dataPath + "/Data.txt", FileMode.Create);
        StreamWriter sw = new StreamWriter(fs);
        for (int i = 0; i < 存取圖鑑.Length; i++)
        {
            sw.WriteLine(存取圖鑑[i].名子);
            sw.WriteLine(存取圖鑑[i].金額);
            sw.WriteLine(存取圖鑑[i].等級);
            sw.WriteLine(存取圖鑑[i].攻擊值);
            sw.WriteLine(存取圖鑑[i].偵測範圍);
            sw.WriteLine(存取圖鑑[i].波及範圍);
            sw.WriteLine(存取圖鑑[i].攻擊速度);
        }
        sw.Close();
        fs.Close();
    }
    public void 讀檔()
    {
        FileStream fs = new FileStream(Application.dataPath + "/Data.txt", FileMode.Open);
        StreamReader sr = new StreamReader(fs);
        //Debug.Log(卡牌管理.解鎖圖鑑.Length);
        text = sr.ReadLine();
        while (text != null)
        {
            for (int i = 0; i < 卡牌管理.解鎖圖鑑.Length; i++)
            {
                if (卡牌管理.解鎖圖鑑[i].名子 == text)
                {
                    卡牌管理.解鎖圖鑑[i].名子 = text;
                    text = sr.ReadLine();
                    卡牌管理.解鎖圖鑑[i].金額 = int.Parse(text);
                    text = sr.ReadLine();
                    卡牌管理.解鎖圖鑑[i].等級 = int.Parse(text);
                    text = sr.ReadLine();
                    卡牌管理.解鎖圖鑑[i].攻擊值 = int.Parse(text);
                    text = sr.ReadLine();
                    卡牌管理.解鎖圖鑑[i].偵測範圍 = int.Parse(text);
                    text = sr.ReadLine();
                    卡牌管理.解鎖圖鑑[i].波及範圍 = int.Parse(text);
                    text = sr.ReadLine();
                    卡牌管理.解鎖圖鑑[i].攻擊速度 = int.Parse(text);
                }
            }
        }
        sr.Close();
        fs.Close();
    }
}