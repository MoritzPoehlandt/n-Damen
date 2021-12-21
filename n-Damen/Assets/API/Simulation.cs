using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Simulation
{
    public int[,] logicArrayBoard;
    public int proplemN;
    public int iteration =0;
    public bool isPlay =false;
	public int solveCount=0;
	public int queens;

    public Simulation (int n){
		logicArrayBoard=new int [n,n];
		for (int i=0;i<n;i++) {
			for (int j=0;j<n;j++) {
				logicArrayBoard[i,j]=0;
			}
		}
        proplemN=n;
		queens=0;
    } 
    public void setQueenSim(int x, int y) {
		for (int i=0; i<proplemN;i++) {
			logicArrayBoard[i,y]++;
			logicArrayBoard[x,i]++;
			// Pruefen ob die Diagonale nicht ausserhalb des Randes des Brettes liegt.
			if (x+y-i<proplemN&&x+y-i>=0) {
				logicArrayBoard[x+y-i,i]++;
			}
			if (x-y+i<proplemN&&x-y+i>=0) {
				logicArrayBoard[x-y+i,i]++;
			}
		}
		logicArrayBoard[x,y]=-1;
		queens++;
	}
    public void removeQueenSim(int x, int y) {
		for (int i=0; i<proplemN;i++) {
			logicArrayBoard[i,y]--;
			logicArrayBoard[x,i]--;
			// checking that the diagonal does not go beyond the board field
			if (x+y-i<proplemN&&x+y-i>=0) {
				logicArrayBoard[x+y-i,i]--;
			}
			if (x-y+i<proplemN&&x-y+i>=0) {
				logicArrayBoard[x-y+i,i]--;
			}
		}
		logicArrayBoard[x,y]=0;  
		queens--;	
	}
	public void solve(int startX, int startY){	
		for(int i=startX;i<proplemN;i++){
			for(int j=startY;j<proplemN;j++){
				if(logicArrayBoard[i,j]==0){
					setQueenSim(i, j);
					if (queens==proplemN){
						solveCount++;
						}else solve(i,0);
					removeQueenSim(i, j);	
				}	
			}		
		}	
	}
	public void printBoard (){
		
		for (int i=0;i<proplemN;i++) {
			string a="";
			for (int j=0;j<proplemN;j++) {
				a=a +" "+ logicArrayBoard[i,j];
			}
			Debug.Log(a);
		}

	}
}
