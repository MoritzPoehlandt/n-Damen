using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Queen
{
    public int x;
    public int y;
    public bool set_or_remove;
    public Queen(int x, int y, bool set_or_remove){
        this.x=x;
        this.y=y;
        this.set_or_remove=set_or_remove;
    }
}
