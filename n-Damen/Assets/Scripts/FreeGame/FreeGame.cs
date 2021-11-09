using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreeGame : MonoBehaviour
{

    public AlgorithmBT backtraking;

    // Start is called before the first frame update
    void Start()
    {
        backtraking = new AlgorithmBT(5);
        backtraking.solve(2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
