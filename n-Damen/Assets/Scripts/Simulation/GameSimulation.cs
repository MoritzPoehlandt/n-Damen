using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlgorithmBT;
using UnityEngine.UI;
using System;
public class GameSimulation : MonoBehaviour
{
    public AlgorithmBT backtraking;
    public int timeSimulation=500;
    public Text text;
    public int userProblemN=0;
    public InputField inputN;
    //----------------------
    private bool pause=true; 
    public Sprite pause_image;
    public Sprite play_image;
    public Button play;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        checkSimulationRunning();
        simulationRun();
        simulationBack();
        simulationForward(); 
    }
    public void oneOfSolution(){
        if(backtraking.simulation.queens==userProblemN){
            setText("Es ist eine Lösung");
        }
    }
    public void checkSimulationRunning()
    {
        //pressing the space starts the simulation. When pressed again, stop
        if (Input.GetKeyDown("space"))
        {
            changeBtnPlay();
            if (backtraking.simulation.isPlay == false)
            {
                backtraking.simulation.isPlay = true;
            }
            else
            {
                backtraking.simulation.isPlay = false;
            }
        }
    }

    public void simulationRun()
    {
        
        //While the mod play, we take one step in front and again check if the value has changed
        if (backtraking.simulation.isPlay)
        {
            backtraking.runSimulation(timeSimulation);
        }
    }

    public void simulationBack()
    {
        //when pressing to the left 1 step of the algorithm back 
        if (Input.GetKeyDown("left")) {
        backButton();
        }
    }

    public void simulationForward()
    {
        //when pressing to the right 1 step of the algorithm forward
        if (Input.GetKeyDown("right")){
        forwardButton();}
    }
    public void playButton(){
        changeBtnPlay();
        setText("");
        if (backtraking.simulation.isPlay == false) {
                backtraking.simulation.isPlay = true;
            
            }
            else {
                backtraking.simulation.isPlay = false;
            }
        }
    public void backButton(){
           if (backtraking.simulation.isPlay)
            {
                backtraking.simulation.isPlay = false;
            }
            else
            {
                backtraking.prevStep();
                backtraking.simulation.solveCount=0;
                backtraking.simulation.solve(0,0);
                setText();
                oneOfSolution();
            }

        }        
    public void forwardButton(){
        if (backtraking.simulation.isPlay) {
                backtraking.simulation.isPlay = false;
            }
            else  {
                backtraking.nextStep();
                backtraking.simulation.solveCount=0;
                backtraking.simulation.solve(0,0);
                setText();
                oneOfSolution();
            }
        } 
    public void increaseSpeed(){
        if (timeSimulation>=200){
        timeSimulation=timeSimulation-200;
        }
    }   
    public void reduceSpeed(){
        timeSimulation=timeSimulation+200;
        }            
    public void setText(){
        text.text="Simulationsfortschritt "+$"{backtraking.simulation.iteration}"+
        "/" +$"{backtraking.arrayListLogAlgoritm.Count}"
        +"\nAnzahl der Lösungen mit diesen Anordnung  " +$"{backtraking.simulation.solveCount}";
    } 
    public void setText(string message){
        text.text=message;
    }  
    public void applyButton(){ 
        if(GameObject.Find("board") != null){
            Destroy(GameObject.Find("board")) ;
        }
        for (int i=0;i<userProblemN;i++){
            for (int j=0;j<userProblemN;j++){
                if (GameObject.Find(i+"_"+j) != null){  
                    Destroy(GameObject.Find(i+"_"+j)) ;
                }
            }
        }
        userProblemN=	 Convert.ToInt32(inputN.text);
        if(userProblemN<12 && userProblemN>0){
            createProbleme();
            //setText();
        }else{
                setText("The number must be less than 12 and greater than 0");  
        }
    }   
    public void createProbleme(){
        setText("");
        if (userProblemN!=0){
            backtraking = new AlgorithmBT(userProblemN);
            backtraking.displayBoard();
            backtraking.solve(0);
            Debug.Log(backtraking.countSolve);
            //Debug.Log(backtraking.arrayListLogAlgoritm.Count);
        }
    }
    public void changeBtnPlay(){
        if (pause){
            play.image.sprite=pause_image;
            pause=false;
        }else{
            play.image.sprite=play_image;
            pause=true;
        }
        
    }
    
}
