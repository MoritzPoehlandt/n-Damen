using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimulationItems : MonoBehaviour
{
    public GameObject simulationUI = new GameObject();

    public void feld_Beenden(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Beenden", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Beenden";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Info(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Info", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Info";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Kamera(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Kamera", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Kamera";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Pause(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Pause", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Pause";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Vor(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Vor", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Vor";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Vor_Schnell(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/feld_Vor_Schnell", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "feld_Vor_Schnell";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Vor_Schnell_2(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Vor_Schnell_2", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Vor_Schnell_2";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void feld_Zurueck(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Feld_Zurück", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Feld_Zurück";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }

    public void tafel(Vector3 postion)
    {
        GameObject button = Instantiate(Resources.Load("Pref/Simulation/Tafel", typeof(GameObject))) as GameObject;
        button.transform.position = new Vector3(0, 0, 0);
        button.transform.localScale = postion;
        button.name = "Tafel";
        button.transform.parent = simulationUI.transform;
        button.AddComponent<BoxCollider>();
    }
}
