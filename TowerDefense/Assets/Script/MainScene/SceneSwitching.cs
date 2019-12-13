using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SceneSwitching : MonoBehaviour
{
    public Image 跑條;
    /// <summary>
    /// 立刻切換場景
    /// </summary>
    /// <param name="SceneName"></param>
    public void Switch(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    /// <summary>
    /// 需再次點擊才能切換場景
    /// </summary>
    /// <param name="SceneName"></param>
    public void WaitSwitch(string SceneName)
    {
        StartCoroutine(Read(SceneName));
    }

    IEnumerator Read(string name)
    {
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        ao.allowSceneActivation = false;

        while (ao.isDone ==false)
        {
            跑條.fillAmount = ao.progress/0.9f;
            yield return null;
            if (ao.progress == 0.9f /*&& Input.anyKey*/)
            {
                ao.allowSceneActivation = true;
            }
        }
    }

    public void RetrySwitch()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
