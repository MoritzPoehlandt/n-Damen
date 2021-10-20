using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameItems gameItems = this.gameObject.AddComponent<GameItems>();
        gameItems.createBoard(8);
    }

    // Update is called once per frame

    void Update()
    {
        
    }
}
