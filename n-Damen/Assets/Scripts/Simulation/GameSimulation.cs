using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static AlgorithmBT;
using UnityEngine.UI;
using System;
public class GameSimulation : SwitchCamera
{
    public AlgorithmBT backtraking;
    public int timeSimulation=500;
    public Text text;
    public int userProblemN=0;
    public InputField inputN;
    //----------------------
    public Sprite pause_image;
    public Sprite play_image;
    public Button play;
    public GameObject[] arrayCameras;
    public Camera ortCamera;
    private int cameraIndex=0;

    void Start()
    {
        focusOnCamera(cameraIndex);
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
         if(userProblemN>0&&userProblemN<12){
        
        setText("");
        if (backtraking.simulation.isPlay == false) {
                backtraking.simulation.isPlay = true;
            
            }
            else {
                backtraking.simulation.isPlay = false;
            }
         }else {
            setText("Geben Sie N ein. Und klicken Sie auf die Schaltfläche mit dem Häkchen.");
        }
        changeBtnPlay();
        }
    public void backButton(){
        if(userProblemN>0&&userProblemN<12){
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
        
        }else {
            setText("Geben Sie N ein. Und klicken Sie auf die Schaltfläche mit dem Häkchen.");
        }
        changeBtnPlay();
        }        
    public void forwardButton(){
        if(userProblemN>0&&userProblemN<12){
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
        }else {
            setText("Geben Sie N ein. Und klicken Sie auf die Schaltfläche mit dem Häkchen.");
        }
        changeBtnPlay();
        } 
    public void increaseSpeed(){
        if (timeSimulation>=200){
        timeSimulation=timeSimulation-200;
        }
    }   
    public void reduceSpeed(){// bis 1.9 
    if (timeSimulation<2000){
        timeSimulation=timeSimulation+200;
    }
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
            //set cameras
            arrayCameras[0].transform.position=getPostionMainCamera(userProblemN);
            arrayCameras[1].transform.position=getPostionOrtCamera(userProblemN);
            setSizeOrtCamera(setOrtCamera(userProblemN));
            //====================================
            backtraking = new AlgorithmBT(userProblemN);
            backtraking.displayBoard();
            backtraking.solve(0);
            Debug.Log(backtraking.countSolve);
            changeBtnPlay();
            //Debug.Log(backtraking.arrayListLogAlgoritm.Count);
        }
    }
    public void changeBtnPlay(){
        if (backtraking.simulation.isPlay){
            play.image.sprite=pause_image;
        }else{
            play.image.sprite=play_image;
        }
        
    }
    public void focusOnCamera(int index){
        for(int i=0;i<arrayCameras.Length;i++){
            arrayCameras[i].SetActive (i==index);    
        }
    }
    public void changeCamera(){
        if (cameraIndex==0){
            focusOnCamera(1);
            cameraIndex=1;
        }else{
            focusOnCamera(0);
            cameraIndex=0;
        }
    }
        public void setSizeOrtCamera(float size){
         ortCamera.orthographicSize= size;
    }
}
