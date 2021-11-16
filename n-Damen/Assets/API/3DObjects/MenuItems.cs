using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
    public GameObject menu = new GameObject();

    public void learn(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/algLearn", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "learn";
        button.transform.parent = menu.transform;
    }

    public void back(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/back", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "back";
        button.transform.parent = menu.transform;
    }

    public void beenden(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/beenden", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "beenden";
        button.transform.parent = menu.transform;
    }

    public void loesung(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/loesung", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "loesung";
        button.transform.parent = menu.transform;
    }

    public void multChoice(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/multipleChoice", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "multChoice";
        button.transform.parent = menu.transform;
    }

    public void referenzen(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/referenzen", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "referenzen";
        button.transform.parent = menu.transform;
    }

    public void simulation(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/simulation", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "simulation";
        button.transform.parent = menu.transform;
    }

    public void szenarien(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Menu/szenarien", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "szenarien";
        button.transform.parent = menu.transform;
    }

}
