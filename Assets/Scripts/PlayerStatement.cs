using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatement : MonoBehaviour
{
    public int HP;
    public float speed;
    public float turn;

    void Update(){
        if(Input.GetKeyDown(KeyCode.C)){
            if(speed == 200)
                speed = 10000;
            else 
                speed = 200;
        }
    }
}
