using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GameItems gameItems = this.gameObject.AddComponent<GameItems>();
        //gameItems.createBoard(8);
        AlgorithmBT backtraking=new AlgorithmBT(5) ;
         backtraking.solve(0);
        //backtraking.setQueenLogiс(1,2);
        //backtraking.removeQueenLogiс(1,2);
         Debug.Log(backtraking.countSolve);
         Debug.Log(backtraking.variantenGepruft);

    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
