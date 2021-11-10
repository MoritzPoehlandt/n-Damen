using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;

    void Start()
    {
        backtraking = new AlgorithmBT(8);
        backtraking.solve(0);

        backtraking.setQueenLogiс(0, 1);
        createQueen("0_1", new Vector3(0, 0, 1));

        backtraking.setQueenLogiс(1, 4);
        createQueen("1_4", new Vector3(1, 0, 4));

        backtraking.editBoard();
    }


}
