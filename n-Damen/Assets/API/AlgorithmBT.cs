using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading;

public class AlgorithmBT : MonoBehaviour
{
	public GameItems gameItems= new GameItems();
	public int[,] twoDimArrayBoard;
	public int proplemN;
	public int countSolve=0;
	public int variantenGepruft=0;

//Create an n * n board and fill with zeros
    public AlgorithmBT (int n){
		twoDimArrayBoard=new int [n,n];
		for (int i=0;i<n;i++) {
			for (int j=0;j<n;j++) {
				twoDimArrayBoard[i,j]=0;
			}
		}
        proplemN=n;
        gameItems.createBoard(n);
    } 
//The queen is placed in a field with the coordinates x, y.
	public void setQueenLogiс(int x, int y) {
		variantenGepruft++;
		//Thread.Sleep(1000);
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
		gameItems.createQueen(x+"_"+y,new Vector3(x,0,y));//x z y
	}
//The queen is removed in a field with the coordinates x, y.
	public void removeQueenLogiс(int x, int y) {
		//Thread.Sleep(1000);
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
		gameItems.deleteQueen(x+"_"+y);//x z y
		twoDimArrayBoard[x,y]=0;
			
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
	public void solve (int i) {
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
}
