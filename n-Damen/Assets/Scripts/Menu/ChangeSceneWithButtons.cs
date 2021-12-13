using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButtons : MonoBehaviour
{
    public void SceneTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void Scene1()
    {
        SceneManager.LoadScene("SimulationScene");
    }
    public void Scene2()
    {
        SceneManager.LoadScene("MenuScene");
    }
    public void Scene3()
    {
        SceneManager.LoadScene("Referenzen");
    }

    public void Scene4()
    {
        SceneManager.LoadScene("FreeGameScene");
    }

    public void Scene5()
    {
        SceneManager.LoadScene("MultipleChoice");
    }
        public void Quit() => Application.Quit();
}
