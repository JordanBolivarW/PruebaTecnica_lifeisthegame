using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerC : MonoBehaviour
{
    public void SceneLoad_(int sceneNumeber)
    {
        SceneManager.LoadSceneAsync(sceneNumeber);
    }
}
