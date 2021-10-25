using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Main : MonoBehaviour
{
    public AlgorithmBT backtraking;
    //enum Modi{ Simulation, Spiel,  Quiz}
    // Start is called before the first frame update
    void Start()
    {
        //GameItems gameItems = this.gameObject.AddComponent<GameItems>();
        //gameItems.createBoard(8);
        //gameItems.setFieldGreen("45");
        backtraking = new AlgorithmBT(8);
        backtraking.solve(0);
        //backtraking.setQueenLogiс(1,2);
        //backtraking.removeQueenLogiс(1,2);
        Debug.Log(backtraking.countSolve);
        Debug.Log(backtraking.arrayListLogAlgoritm.Count);
        

    }

    // Update is called once per frame
        void Update()
    {
        backtraking.button();

    }
}
