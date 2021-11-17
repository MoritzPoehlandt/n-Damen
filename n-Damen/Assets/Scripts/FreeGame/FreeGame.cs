using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;

    void Start()
    {
        backtraking = new AlgorithmBT(5);
        backtraking.createQueenWithClick = true;
        backtraking.displayBoard();
        
        //backtraking.setQueenLogiс(0, 1);//add in arrayList
        //!!!!der Code ist der gleiche, aber x und y sind vertauscht
        //backtraking.simulation.setQueenSim(1, 0);//add in logik brett  
        //backtraking.editBoard();// zeigt logik brett
        //backtraking.nextStep();//use createQueen und  zeigt logik brett

        backtraking.simulation.solveCount=0;
        backtraking.simulation.solve(0,0);
        Debug.Log("0 Step " +backtraking.simulation.solveCount);

        //!!!!der Code ist der gleiche, aber x und y sind vertauscht
        backtraking.simulation.setQueenSim(1, 0);
        createQueen("0_1",new Vector3(0,0,1));
        backtraking.simulation.solveCount=0;
        backtraking.simulation.solve(0,0);
        Debug.Log("1 Step " +backtraking.simulation.solveCount);


        backtraking.simulation.setQueenSim(4, 1);
        createQueen("1_4",new Vector3(1,0,4));
        backtraking.simulation.solveCount=0;
        backtraking.simulation.solve(0,0);
        Debug.Log("2 Step " +backtraking.simulation.solveCount);

        backtraking.editBoard();
     

        
        
    }

    public void setQueen(int x, int y)
    {
        backtraking.simulation.setQueenSim(y, x);
        createQueen(x + "_"+ y,new Vector3(x,0,y));
        backtraking.simulation.solve(0,0);
        backtraking.editBoard();
    }

    public void removeQuee(int x, int y)
    {
        backtraking.simulation.removeQueenSim(y, x);
        deleteQueen(x.ToString() + "_" + y.ToString());
        backtraking.simulation.solve(0, 0);
        backtraking.editBoard();
    }


}
