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
    public bool createQueenWithClick = false;
    GameObject parent;
    //This methode creates a board with n* n fields
    // Each field get a specific number starting from 0 to n*n

    public void createBoard(int n)
    {
        bool isWhite = true;
        parent = new GameObject();
        parent.name = "board";

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (isWhite == true)
                {
                    GameObject field_white = Instantiate(Resources.Load("Prefab/white", typeof(GameObject))) as GameObject;
                    field_white.transform.position = new Vector3(i, 0, j);
                    field_white.transform.localScale = new Vector3(1.05f, 1.0f, 1.05f);
                    field_white.name = j.ToString() + i.ToString();
                    field_white.transform.parent = parent.transform;
                    if (createQueenWithClick == true)
                    {
                        field_white.AddComponent<GameItemsOnClick>();
                    }
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
                    GameObject field_black = Instantiate(Resources.Load("Prefab/black", typeof(GameObject))) as GameObject;
                    field_black.transform.position = new Vector3(i, 0, j);
                    field_black.transform.localScale = new Vector3(1.05f, 1.0f, 1.05f);
                    field_black.name = j.ToString() + i.ToString();
                    field_black.transform.parent = parent.transform;
                    if (createQueenWithClick == true)
                    {
                        field_black.AddComponent<GameItemsOnClick>();
                    }
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

    // This methode removes the field with name and set a green field on the same position

    public void setFieldGreen(string name)
    {
        GameObject field = GameObject.Find(name);
        GameObject chield = field.transform.GetChild(1).transform.gameObject;
        var renderer = chield.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.green);
    }

    // This methode removes the field with name and set a red field on the same position

    public void setFieldRed(string name)
    {
        GameObject field = GameObject.Find(name);
        GameObject chield = field.transform.GetChild(1).transform.gameObject;
        var renderer = chield.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.red);
    }

    // This methode removes the field with name and set a white field on the same position

    public void setFieldWhite(string name)
    {
        GameObject field = GameObject.Find(name);
        GameObject chield = field.transform.GetChild(1).transform.gameObject;
        var renderer = chield.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.white);
    }

    // This methode removes the field with name and set a black field on the same position

    public void setFieldBlack(string name)
    {
        GameObject field = GameObject.Find(name);
        GameObject chield = field.transform.GetChild(1).transform.gameObject;
        var renderer = chield.GetComponent<Renderer>();
        renderer.material.SetColor("_Color", Color.black);
    }

    // This methode creates a queen with name an d position

    public void createQueen(string name, Vector3 position)
    {
        GameObject queen = Instantiate(Resources.Load("Prefab/queen", typeof(GameObject))) as GameObject;
        queen.transform.position = position;
        queen.transform.Rotate(-90.0f, 0f, 0f);
        queen.name = name;
        queen.AddComponent<GameItemsOnClick>();
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
            queen.transform.position = Vector3.MoveTowards(queen.transform.position, qPosition, qSpeed * Time.deltaTime);
            if (queen.transform.position == qPosition)
            {
                queen = null;
                qPosition = Vector3.zero;
            }
        }
    }

}
