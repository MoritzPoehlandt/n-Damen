using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItems : MonoBehaviour
{

    /// <summary>
    /// 
    /// add the following Line to your Start methode to get access to the following methodes
    /// 
    /// GameItems gameItems = this.gameObject.AddComponent<GameItems>();
    ///
    /// Example:
    /// void Start()
    /// {
    ///    GameItems gameItems = this.gameObject.AddComponent<GameItems>();
    ///    gameItems.createBoard(8);
    /// }
    /// 
    /// </summary>


    private GameObject queen;
    private Vector3 qPosition;
    private float qSpeed = 1.0f;

    //This methode creates a board with n* n fields
    // Each field get a specific number starting from 0 to n*n

    public void createBoard(int n)
    {
        bool isWhite = true;
        GameObject parent = new GameObject();
        parent.name = "board";

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isWhite == true)
                {
                    GameObject field_white = Instantiate(Resources.Load("Prefab/Feld-Weis-01", typeof(GameObject))) as GameObject;
                    field_white.transform.position = new Vector3(i, 0, j);
                    field_white.name = j.ToString() + i.ToString();
                    field_white.transform.parent = parent.transform;
                    if (j == n - 1 && n % 2 == 0)
                    {
                        isWhite = true;
                    }
                    else
                    {
                        isWhite = false;
                    }
                }
                else
                {
                    GameObject field_black = Instantiate(Resources.Load("Prefab/Feld-Schwarz-01", typeof(GameObject))) as GameObject;
                    field_black.transform.position = new Vector3(i, 0, j);
                    field_black.name = j.ToString() + i.ToString();
                    field_black.transform.parent = parent.transform;
                    if (j == n - 1 && n % 2 == 0)
                    {
                        isWhite = false;
                    }
                    else
                    {
                        isWhite = true;
                    }
                }
            }
        }
    }

    // This methodes creates a queen with name an d position

    public void createQueen(string name, Vector3 position)
    {
        GameObject queen = Instantiate(Resources.Load("Prefab/Dame-01", typeof(GameObject))) as GameObject;
        queen.transform.position = position;
        queen.transform.Rotate(-90.0f, 0f, 0f);
        queen.name = name;
    }

    // This methode move the given queen to specific position
    // speed modefies the velocity of the movement

    public void moveQueen(string name, Vector3 position, float speed)
    {
        queen = GameObject.Find(name);
        qPosition = position;
        qSpeed = speed;
    }

    // This methode deletes a queen with the given name

    public void deleteQueen(string name)
    {
        queen = GameObject.Find(name);
        Destroy(queen);
    }

    // Update is called once per frame

    void Update()
    {

        // check if quee and position is given and move the queen to the new position

        if (queen != null && qPosition != null)
        {
            Debug.Log(queen.transform.position);
            queen.transform.position = Vector3.MoveTowards(queen.transform.position, qPosition, qSpeed * Time.deltaTime);
            if (queen.transform.position == qPosition)
            {
                queen = null;
                qPosition = Vector3.zero;
            }
        }
    }

}
