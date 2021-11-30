using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;

    private Vector3[] queensPosition = new Vector3[10];

    void Start()
    {

    }

    public void setQueen(int x, int y)
    {
        if (backtraking.simulation.logicArrayBoard[y, x] == 0)
        {
            backtraking.simulation.setQueenSim(y, x);
            createQueen(x + "_" + y, new Vector3(x, 0, y));
            backtraking.simulation.solve(0, 0);

            //Board Color
            backtraking.editBoard();

        }
    }

    public void removeQuee(int x, int y)
    {
        var queenRemovable = true;

        for (int i = 0; i < queensPosition.Length; i++)
        {

            if (queensPosition[i].x == x && queensPosition[i].z == y)
            {
                queenRemovable = false;
            }
        }

        if (queenRemovable == true)
        {
            backtraking.simulation.removeQueenSim(y, x);
            deleteQueen(x.ToString() + "_" + y.ToString());
            backtraking.simulation.solve(0, 0);
            backtraking.editBoard();
        }
    }

    public void level(int n, Vector3[] queens)
    {
        removeAllFromScene();
        backtraking = new AlgorithmBT(n);
        backtraking.createQueenWithClick = true;
        backtraking.displayBoard();

        //backtraking.simulation.solveCount = 0;
        //backtraking.simulation.solve(0, 0);

        for (int i = 0; i < queens.Length; i++)
        {
            // set queen
            backtraking.simulation.setQueenSim((int)queens[i].z, (int)queens[i].x);
            createQueen(queens[i].x.ToString() + "_" + queens[i].z.ToString(), queens[i]);
            queensPosition[i] = queens[i];
        }
        backtraking.simulation.solveCount = 0;
        backtraking.simulation.solve(0, 0);
    }

    public void level1()
    {
        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        level(5, queens);
    }

    public void level2()
    {
        Vector3[] queens = new Vector3[3];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        queens[2] = new Vector3(2, 0, 2);
        level(6, queens);
    }

    public void level3()
    {
        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 3);
        queens[1] = new Vector3(4, 0, 1);
        level(6, queens);
    }

    public void level4()
    {
        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        level(7, queens);
    }

    public void level5()
    {
        Vector3[] queens = new Vector3[3];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        queens[2] = new Vector3(2, 0, 2);
        level(7, queens);
    }

    public void level6()
    {
        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 3);
        queens[1] = new Vector3(4, 0, 1);
        level(7, queens);
    }

    public void level7()
    {
        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        level(8, queens);
    }

    public void level8()
    {
        Vector3[] queens = new Vector3[3];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        queens[2] = new Vector3(2, 0, 2);
        level(8, queens);
    }

    public void level9()
    {
        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 3);
        queens[1] = new Vector3(4, 0, 1);
        level(8, queens);
    }


    private void removeAllFromScene()
    {
        queensPosition = null;
        queensPosition = new Vector3[10];
        if (GameObject.Find("board") != null)
        {
            Destroy(GameObject.Find("board"));
            backtraking = null;
        }
        for (int i = 0; i < 7; i++)
        {
            for (int j = 0; j < 7; j++)
            {
                if (GameObject.Find(i + "_" + j) != null)
                {
                    Destroy(GameObject.Find(i + "_" + j));
                }
            }
        }
    }

    public void help()
    {
        backtraking.nextStep();
    }
}
