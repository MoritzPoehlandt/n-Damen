using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneWithButtons : MonoBehaviour
{
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
    public void Quit() => Application.Quit();
}
