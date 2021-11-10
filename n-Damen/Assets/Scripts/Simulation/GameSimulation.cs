using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlgorithmBT;

public class GameSimulation : MonoBehaviour
{
    public AlgorithmBT backtraking;

    void Start()
    {
        backtraking = new AlgorithmBT(8);
        backtraking.setQueenLogiс(1,3);
        backtraking.solve(0,0);
        
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

    private void checkSimulationRunning()
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

    private void simulationRun()
    {
        //While the mod play, we take one step in front and again check if the value has changed
        if (backtraking.simulation.isPlay)
        {
            backtraking.runSimulation(100);
        }
    }

    private void simulationBack()
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

    private void simulationForward()
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
    
}
