using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;

    private Vector3[] queensPosition = new Vector3[10];

    public bool infoHidden;

    public ArrayList moves;
    public int counter;

    void Start()
    {
        infoHidden = false;
        infoField();

        counter = 0;
    }

    public void setQueen(int x, int y)
    {
        if (backtraking.simulation.logicArrayBoard[y, x] == 0)
        {
            Debug.Log(x.ToString() + y.ToString());
            Debug.Log(moves[counter]);
            if (moves.Count > counter)
            {
                if (moves[counter].ToString() == x.ToString() + y.ToString() + "1")
                {
                    backtraking.simulation.setQueenSim(y, x);
                    createQueen(x + "_" + y, new Vector3(x, 0, y));
                    backtraking.simulation.solve(0, 0);

                    //Board Color
                    backtraking.editBoard();
                    counter += 1;
                }
            }
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
        if (moves.Count > counter)
        {
            if (queenRemovable == true && moves[counter].ToString() == x.ToString() + y.ToString() + "0")
            {
                backtraking.simulation.removeQueenSim(y, x);
                deleteQueen(x.ToString() + "_" + y.ToString());
                backtraking.simulation.solve(0, 0);
                backtraking.editBoard();
                    counter += 1;
            }
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

    public void infoField()
    {
        if(infoHidden == true)
        {
            GameObject canvas = GameObject.Find("CanvasInfo");
            CanvasGroup group = canvas.GetComponent<CanvasGroup>();
            group.alpha = 1.0f;
            infoHidden = false;
        } else
        {
            GameObject canvas = GameObject.Find("CanvasInfo");
            CanvasGroup group = canvas.GetComponent<CanvasGroup>();
            group.alpha = 0.0f;
            infoHidden = true;
        }
    }

    public void level1()
    {
        moves = new ArrayList() { "211", "341", "401", "531"};

        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 2);
        queens[1] = new Vector3(1, 0, 5);
        level(6, queens);
    }

    public void level2()
    {
        moves = new ArrayList() { "201", "331", "330", "200", "221", "301", "431"};

        Vector3[] queens = new Vector3[2];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 4);
        level(5, queens);
    }

    public void level3()
    {
        moves = new ArrayList() { "311", "461", "521", "651","650","520","460","310","351","421","561","611","731"};

        Vector3[] queens = new Vector3[3];
        queens[0] = new Vector3(0, 0, 0);
        queens[1] = new Vector3(1, 0, 4);
        queens[2] = new Vector3(2, 0, 7);
        level(8, queens);

        setQueen(3, 1);
        setQueen(4, 6);
        setQueen(5, 2);
        setQueen(6, 5);
    }


    private void removeAllFromScene()
    {
        queensPosition = null;
        queensPosition = new Vector3[10];
        counter = 0;
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
}
