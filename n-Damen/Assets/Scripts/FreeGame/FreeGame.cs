using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FreeGame : GameItems
{

    public AlgorithmBT backtraking;

    private Vector3[] queensPosition = new Vector3[10];

    public bool infoHidden;

    public ArrayList moves;
    public int counter;
    public bool isdifficult;


    void Start()
    {
        infoHidden = false;
        isdifficult = true;
        infoField();

        counter = 0;
    }

    public void setQueen(int x, int y)
    {
        infoTextField();
        if (backtraking.simulation.logicArrayBoard[y, x] == 0)
        {
            if (moves.Count > counter)
            {
                if (moves[counter].ToString() == x.ToString() + y.ToString() + "1")
                {
                    backtraking.simulation.setQueenSim(y, x);
                    createQueen(x + "_" + y, new Vector3(x, 0, y));
                    backtraking.simulation.solve(0, 0);

                    //Board Color
                    if (isdifficult == true)
                    {
                        backtraking.editBoard();
                    }
                    counter += 1;
                }
            }
        }
    }

    public void removeQuee(int x, int y)
    {

        var queenRemovable = true;
        infoTextField();
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
                if (isdifficult == true)
                {
                    backtraking.editBoard();
                }
                counter += 1;
            }
        }
    }

    public void level(int n, Vector3[] queens)
    {
        backtraking = null;
        queensPosition = null;
        queensPosition = new Vector3[10];
        counter = 0;
        removeAllFromScene();

        backtraking = new AlgorithmBT(n);
        backtraking.createQueenWithClick = true;
        backtraking.displayBoard();

        changeCameraposition(new Vector3(n / 2, 28, n / 2 - 0.5f));

        for (int i = 0; i < queens.Length; i++)
        {
            // set queen
            backtraking.simulation.setQueenSim((int)queens[i].z, (int)queens[i].x);
            createQueen(queens[i].x.ToString() + "_" + queens[i].z.ToString(), queens[i]);
            queensPosition[i] = queens[i];
        }
        backtraking.simulation.solveCount = 0;
        backtraking.simulation.solve(0, 0);
        if (isdifficult == true)
        {
            backtraking.editBoard();
        }
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
    public void infoTextField()
    {

        // Create the Text GameObject.
        Text textBox = GameObject.Find("Canvas/Text").GetComponent<Text>();

        String isBacktrack = "";

        if (counter + 1 < moves.Count)
        {
            isBacktrack = moves[counter + 1].ToString();

            if (isBacktrack.Substring(3 - 1) == "1")
            {
                textBox.text = "Der Backtracking Algorithmus platziert jeweils eine Dame in einer Zeile an der ersten gültigen Position. " +
                                "Das macht er für jede Zeile, bis er in einer Zeile keine Dame mehr setzten kann." +
                                "Probiere wie der Algorithmus, für jede Zeile eine Dame zu setzten.";
            }
            else
            {
                textBox.text = "Wenn du keine Dame mehr setzten kannst, da alle Felder besetzt sind, musst du deine zu letzt platzierte Dame enternen." +
                                "Findet sich in der Zeile, wo die Dame entfernt wurde eine neue Position, kannst du dort eine Dame sezten." +
                                "Falls sich kein freies Feld in der Zeile mehr findet musst du die Dame in der Zeile davor ebenfalls entfernen und schauen, ob sich dadurch ein freies Feld ergibt." +
                                "Dieses Verfahren nennt man Backtracking";
            }
        } else
        {
            textBox.text = "Geschafft :)";
        }

    }

    public void changeDifficulty()
    {
        if(isdifficult == true)
        {
            isdifficult = false;
            GameObject button = GameObject.Find("difficulty");
            Text text = button.GetComponentInChildren<Text>();
            text.text = "schwer";
        } else
        {
            isdifficult = true;
            GameObject button = GameObject.Find("difficulty");
            Text text = button.GetComponentInChildren<Text>();
            text.text = "einfach";
        }
    }

    public void changeCameraposition(Vector3 position)
    {
        GameObject camera = GameObject.Find("Camera");
        camera.transform.position = position;
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
        backtraking.editBoard();
    }

    public void level4()
    {
        moves = new ArrayList() { "321", "441", "571", "631", "630", "570", "440","461", "460", "471", "470", "320", "361", "431", "571", "621", "741"};

        Vector3[] queens = new Vector3[3];
        queens[0] = new Vector3(0, 0, 1);
        queens[1] = new Vector3(1, 0, 5);
        queens[2] = new Vector3(2, 0, 0);
        level(8, queens);

        setQueen(3, 2);
        setQueen(4, 4);
        backtraking.editBoard();
    }


    private void removeAllFromScene()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (GameObject.Find(i.ToString() + "_" + j.ToString()) != null)
                {
                    Destroy(GameObject.Find(i.ToString() + "_" + j.ToString()));
                }
                if (GameObject.Find(i.ToString() + j.ToString()) != null)
                {
                    Destroy(GameObject.Find(i.ToString() + j.ToString()));
                }
            }
        }

        if (GameObject.Find("board") != null)
        {
            Destroy(GameObject.Find("board"));
            backtraking = null;
        }
    }
}
