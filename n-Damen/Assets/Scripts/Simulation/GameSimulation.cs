using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlgorithmBT;

public class GameSimulation : MonoBehaviour
{
    public AlgorithmBT backtraking;
    public int timeSimulation=500;

    void Start()
    {
        backtraking = new AlgorithmBT(8);
        //backtraking.setQueenLogiс(1,3);
        backtraking.solve(0);
        
        Debug.Log(backtraking.countSolve);
        Debug.Log(backtraking.arrayListLogAlgoritm.Count);
    }

    // Update is called once per frame
    void Update()
    {
        checkSimulationRunning();
        simulationRun();

        simulationBack();
        simulationForward();
        
    }

    public void checkSimulationRunning()
    {
        //pressing the space starts the simulation. When pressed again, stop
        if (Input.GetKeyDown("space"))
        {
            if (backtraking.simulation.isPlay == false)
            {
                backtraking.simulation.isPlay = true;
            }
            else
            {
                backtraking.simulation.isPlay = false;
            }
        }
    }

    public void simulationRun()
    {
        //While the mod play, we take one step in front and again check if the value has changed
        if (backtraking.simulation.isPlay)
        {
            backtraking.runSimulation(timeSimulation);
        }
    }

    public void simulationBack()
    {
        //when pressing to the left 1 step of the algorithm back 
        if (Input.GetKeyDown("left"))
        {
            if (backtraking.simulation.isPlay)
            {
                backtraking.simulation.isPlay = false;
            }
            else
            {
                backtraking.prevStep();
            }
        }
    }

    public void simulationForward()
    {
        //when pressing to the right 1 step of the algorithm forward
        if (Input.GetKeyDown("right"))
        {
            if (backtraking.simulation.isPlay)
            {
                backtraking.simulation.isPlay = false;
            }
            else
            {
                backtraking.nextStep();
            }
        }
    }
    public void playButton(){
        if (backtraking.simulation.isPlay == false) {
                backtraking.simulation.isPlay = true;
            }
            else {
                backtraking.simulation.isPlay = false;
            }
        }
    public void backButton(){
           if (backtraking.simulation.isPlay)
            {
                backtraking.simulation.isPlay = false;
            }
            else
            {
                backtraking.prevStep();
            }
        }        
    public void forwardButton(){
        if (backtraking.simulation.isPlay) {
                backtraking.simulation.isPlay = false;
            }
            else  {
                backtraking.nextStep();
            }
        } 
    public void increaseSpeed(){
        if (timeSimulation>=200){
        timeSimulation=timeSimulation-100;
        }

        }   
    public void reduceSpeed(){
        timeSimulation=timeSimulation+100;
        }                   
}
