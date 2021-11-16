using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;

    void Start()
    {
        backtraking = new AlgorithmBT(8);
        backtraking.createQueenWithClick = true;
        backtraking.displayBoard(backtraking.proplemN);

        backtraking.setQueenLogiс(0, 1);
        backtraking.setQueenLogiс(1, 4);

        backtraking.solve(0, 0);
        backtraking.nextStep();
        backtraking.nextStep();
        backtraking.editBoard();
    }

    public void setQueen(int x, int y)
    {
        backtraking.setQueenLogiс(x, y);
        backtraking.solve(0,0);
        backtraking.editBoard();
        backtraking.nextStep();
    }


}
