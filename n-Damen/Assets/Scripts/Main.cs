using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class Main : MonoBehaviour
{
    public AlgorithmBT backtraking;
    public int iteration =0;
    public bool isPlay =false;
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
        //pressing the space starts the simulation. When pressed again, stop
        if (Input.GetKeyDown("space")){
            if (isPlay==false){
                isPlay=true;
                Debug.Log("Play Simulaton");
            }else {
                isPlay=false;
                Debug.Log("Stop Simulaton");
                }
		}
        //While the mod play, we take one step in front and again check if the value has changed
        if (isPlay){
                if (backtraking.arrayListLogAlgoritm.Count>iteration){
                     if (backtraking.arrayListLogAlgoritm[iteration].set_or_remove==true){
                    backtraking.createQueen(backtraking.arrayListLogAlgoritm[iteration].x+"_"+
                    backtraking.arrayListLogAlgoritm[iteration].y
                    ,new Vector3(backtraking.arrayListLogAlgoritm[iteration].x,0,backtraking.arrayListLogAlgoritm[iteration].y));
                    }else{
                    backtraking.deleteQueen(backtraking.arrayListLogAlgoritm[iteration].x+"_"+
                         backtraking.arrayListLogAlgoritm[iteration].y); 
                    }
                iteration++;
                Thread.Sleep(1000);
            }
        }
        //when pressing to the left 1 step of the algorithm back 
        if (Input.GetKeyDown("left")){
            isPlay=false;
            if(backtraking.arrayListLogAlgoritm[iteration-1].set_or_remove==true){
                backtraking.deleteQueen(backtraking.arrayListLogAlgoritm[iteration-1].x+"_"+
                         backtraking.arrayListLogAlgoritm[iteration-1].y);
            }else
            {
                backtraking.createQueen(backtraking.arrayListLogAlgoritm[iteration-1].x+"_"+
                    backtraking.arrayListLogAlgoritm[iteration-1].y
                    ,new Vector3(backtraking.arrayListLogAlgoritm[iteration-1].x,0,backtraking.arrayListLogAlgoritm[iteration].y));
            }             
        iteration--;   
		}
        //when pressing to the right 1 step of the algorithm forward
		 if (Input.GetKeyDown("right")){
             isPlay=false;
             if (backtraking.arrayListLogAlgoritm[iteration].set_or_remove==true){
                    backtraking.createQueen(backtraking.arrayListLogAlgoritm[iteration].x+"_"+
                    backtraking.arrayListLogAlgoritm[iteration].y
                    ,new Vector3(backtraking.arrayListLogAlgoritm[iteration].x,0,backtraking.arrayListLogAlgoritm[iteration].y));
             }else{
                    backtraking.deleteQueen(backtraking.arrayListLogAlgoritm[iteration].x+"_"+
                         backtraking.arrayListLogAlgoritm[iteration].y); 
             }
            iteration++;
		}
    }
}
