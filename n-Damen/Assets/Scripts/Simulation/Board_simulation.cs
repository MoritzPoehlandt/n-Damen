using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlgorithmBT;

public class NewBehaviourScript : MonoBehaviour
{
    public AlgorithmBT backtraking;
    // Start is called before the first frame update
    void Start()
    {
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
