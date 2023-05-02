using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewScene : MonoBehaviour
{
    public string nextScene;
    /**
    public void ChangeTo()
    {
        Invoke(nameof(ChangeScene), 0.1f);
    }
   **/
    public void ChangeScene()
    {
        SceneManager.LoadScene(nextScene);
    }

}
