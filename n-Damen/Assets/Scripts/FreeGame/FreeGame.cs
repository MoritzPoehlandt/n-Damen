using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;
    public Simulation simulation;

    void Start()
    {
        backtraking = new AlgorithmBT(8);

        backtraking.createQueenWithClick = true;
        backtraking.displayBoard();

        backtraking.setQueenLogiс(0, 1);
        backtraking.setQueenLogiс(1, 4);

        createQueen("0_1", new Vector3(0, 0, 1));
        createQueen("1_4", new Vector3(1, 0, 4));

        backtraking.solve(0, 0);

        backtraking.editBoard();
    }

    public void setQueen(int x, int y)
    {
        backtraking.setQueenLogiс(x, y);
        createQueen(x.ToString() + "_" + y.ToString(), new Vector3(x, 0, y));
        backtraking.solve(0,0);
        backtraking.editBoard();
    }


}
