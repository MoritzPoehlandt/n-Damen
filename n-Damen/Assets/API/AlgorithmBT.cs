using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AlgorithmBT : GameItems
{
	public int[,] twoDimArrayBoard;
	public int proplemN;
	public int countSolve=0;
	public int variantenGepruft=0;
	public int countBacktrack=0;
	public List<Queen> arrayListLogAlgoritm= new List<Queen>();
	public Simulation simulation;
	public int queensOnTable;

	//Create an n * n board and fill with zeros

    public void newAlgorithmBT (int n){
		twoDimArrayBoard=new int [n,n];
		for (int i=0;i<n;i++) {
			for (int j=0;j<n;j++) {
				twoDimArrayBoard[i,j]=0;
			}
		}
        proplemN=n;
		simulation= new Simulation(n);
		queensOnTable=0;
		countBacktrack=0;
		arrayListLogAlgoritm= new List<Queen>();
    }

	public void displayBoard()
    {
		createBoard(proplemN);
    }

	//The queen is placed in a field with the coordinates x, y.

	public void setQueenLogiс(int x, int y) {
		variantenGepruft++;
		//die horizontalen und vertikalen Felder ausfuellen +1
		for (int i=0; i<proplemN;i++) {
			twoDimArrayBoard[i,y]++;
			twoDimArrayBoard[x,i]++;
			// Pruefen ob die Diagonale nicht ausserhalb des Randes des Brettes liegt.
			if (x+y-i<proplemN&&x+y-i>=0) {
				twoDimArrayBoard[x+y-i,i]++;
			}
			if (x-y+i<proplemN&&x-y+i>=0) {
				twoDimArrayBoard[x-y+i,i]++;
			}
		}
		twoDimArrayBoard[x,y]=-1;
		//put the queen on the virtual board	
		//gameItems.createQueen(x+"_"+y,new Vector3(x,0,y));//x z y
		arrayListLogAlgoritm.Add(new Queen(x,y,true));
		queensOnTable++;
	}

	//The queen is removed in a field with the coordinates x, y.

	public void removeQueenLogiс(int x, int y) {
		//fill the horizontal and vertical 0
		for (int i=0; i<proplemN;i++) {
			twoDimArrayBoard[i,y]--;
			twoDimArrayBoard[x,i]--;
			// checking that the diagonal does not go beyond the board field
			if (x+y-i<proplemN&&x+y-i>=0) {
				twoDimArrayBoard[x+y-i,i]--;
			}
			if (x-y+i<proplemN&&x-y+i>=0) {
				twoDimArrayBoard[x-y+i,i]--;
			}
		}
		//removed  the queen on the virtual board	
		twoDimArrayBoard[x,y]=0;
		arrayListLogAlgoritm.Add(new Queen(x,y,false));
		queensOnTable--;	
	}

	//prints out the position of the queen. Only works if n is less than 27

	public void printPosition() {
		string [] abc=new string [26]{"a","b","c","d","e","f","g","h","i","j","k","l","m","n","o","p","q","r",
                                        "s","t","u","v","w","x","y","z"};
		string result = "";
		for (int i=0;i<proplemN;i++) {
			for (int j=0;j<proplemN;j++) {
				if (twoDimArrayBoard[i,j]==-1) {
					result=result+abc[j]+(i+1).ToString() +" ";
				}
			}
		}
		Debug.Log(result);
	}
	
	//Hauptfunktion Lesung fuer i Zeile

	public void solve(int i) {
		for (int j=0; j<proplemN;j++) {
			if (twoDimArrayBoard[i,j]==0) {
				setQueenLogiс(i, j);
				// wenn die letzte Zeile
				if (i==proplemN-1) {
					countSolve++;
                //if necessary for testing
				//printPosition();
				}else solve(i+1);
			removeQueenLogiс(i, j);	
			}
		}	
	}
	public void solve(int startX, int startY){
		for(int i=startX;i<proplemN;i++){
			for(int j=startY;j<proplemN;j++){
				if(twoDimArrayBoard[i,j]==0){
					setQueenLogiс(i, j);
					if (queensOnTable==proplemN){
						countSolve++;
						}else solve(i,0);
					removeQueenLogiс(i, j);	
				}	
			}		
		}	
	}

	public void editBoard() {
		for (int i=0;i<proplemN;i++) {
			for (int j=0;j<proplemN;j++) {
                if (simulation.logicArrayBoard[i,j]>0){
                    setFieldRed(i.ToString()+j.ToString());
                }
				if(simulation.logicArrayBoard[i,j]==0){
					setFieldGreen(i.ToString()+j.ToString());
				}
				if(simulation.logicArrayBoard[i,j]==-1){
					setFieldWhite(i.ToString()+j.ToString());
				}
			}
		}
    }

	//1 step of the algorithm forward, work with  Atribute	simulation

	public void nextStep(){
		if(simulation.iteration<arrayListLogAlgoritm.Count){
		if (arrayListLogAlgoritm[simulation.iteration].set_or_remove==true){
			createQueen(arrayListLogAlgoritm[simulation.iteration].x+"_"+arrayListLogAlgoritm[simulation.iteration].y,
			new Vector3(arrayListLogAlgoritm[simulation.iteration].x,0,arrayListLogAlgoritm[simulation.iteration].y));
			simulation.setQueenSim( arrayListLogAlgoritm[simulation.iteration].y,arrayListLogAlgoritm[simulation.iteration].x);	
		}else{
				countBacktrack++;
				deleteQueen(arrayListLogAlgoritm[simulation.iteration].x+"_"+arrayListLogAlgoritm[simulation.iteration].y); 
				simulation.removeQueenSim(arrayListLogAlgoritm[simulation.iteration].y,arrayListLogAlgoritm[simulation.iteration].x);		 
			}
		simulation.iteration++;
		editBoard();
		}

	}

	//1 step of the algorithm back , work with  Atribute	simulation

	public void prevStep(){
		if(simulation.iteration>0){
			simulation.iteration--; 
			if(GameObject.Find(arrayListLogAlgoritm[simulation.iteration].x+"_"+arrayListLogAlgoritm[simulation.iteration].y) == null){
				if(arrayListLogAlgoritm[simulation.iteration].set_or_remove==false){
					countBacktrack--;
					createQueen(arrayListLogAlgoritm[simulation.iteration].x+"_"+arrayListLogAlgoritm[simulation.iteration].y,
                	new Vector3(arrayListLogAlgoritm[simulation.iteration].x,0,arrayListLogAlgoritm[simulation.iteration].y));
					simulation.setQueenSim(arrayListLogAlgoritm[simulation.iteration].y,arrayListLogAlgoritm[simulation.iteration].x);
					}
			}else
				{
				if(arrayListLogAlgoritm[simulation.iteration].set_or_remove==true){
					
               		deleteQueen(arrayListLogAlgoritm[simulation.iteration].x+"_"+arrayListLogAlgoritm[simulation.iteration].y);
					simulation.removeQueenSim(arrayListLogAlgoritm[simulation.iteration].y,arrayListLogAlgoritm[simulation.iteration].x);				   
					}
				}
			editBoard();
		}
	}

	//goes step by step by attribute - simulation

	public void runSimulation(int timeStep){
		if (arrayListLogAlgoritm.Count>simulation.iteration){
			nextStep();
    		Thread.Sleep(timeStep);
    	}
	}
}
