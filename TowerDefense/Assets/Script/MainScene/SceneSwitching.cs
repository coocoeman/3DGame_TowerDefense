using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;

public class SceneSwitching : MonoBehaviour
{
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
            yield return null;
            if (ao.progress == 0.9f && Input.anyKey)
            {
                ao.allowSceneActivation = true;
            }
        }
    }
}
