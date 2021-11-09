using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuItems : MonoBehaviour
{
    public GameObject menu = new GameObject();

    public void learn(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/algLearn", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void back(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/back", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void beenden(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/beenden", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void loesung(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/loesung", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void multChoice(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/multipleChoice", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void referenzen(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/referenzen", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void simulation(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/simulation", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

    public void szenarien(Vector3 postion)
    {
        GameObject learn = Instantiate(Resources.Load("Pref/Menu/szenarien", typeof(GameObject))) as GameObject;
        learn.transform.position = new Vector3(0, 0, 0);
        learn.transform.localScale = postion;
        learn.name = "learn";
        learn.transform.parent = menu.transform;
    }

}
