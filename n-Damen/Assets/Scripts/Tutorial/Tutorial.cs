using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Tutorial : MonoBehaviour
{

    public GameObject scenes;

    public void LoadMenu()
    {
        SceneManager.LoadScene("MenuScene");
    }

    public void LoadNext()
    {
        for (int i = 0; i < scenes.transform.childCount; i++)
        {
            GameObject child = scenes.transform.GetChild(i).gameObject;
            if (child.gameObject.activeSelf)
            {
                child.SetActive(false);
                // if last element
                if (i == scenes.transform.childCount - 1)
                {
                    LoadMenu();
                }
                else
                {
                    scenes.transform.GetChild(i + 1).gameObject.SetActive(true);
                    break;
                }
            }
        }
    }

    public void LoadPrevious()
    {
        for (int i = scenes.transform.childCount - 1; i > 0; i--)
        {
            GameObject child = scenes.transform.GetChild(i).gameObject;
            if (child.gameObject.activeSelf)
            {
                child.SetActive(false);
                scenes.transform.GetChild(i - 1).gameObject.SetActive(true);
                break;
            }
        }
    }

}
