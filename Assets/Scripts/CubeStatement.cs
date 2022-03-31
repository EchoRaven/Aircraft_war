using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeStatement : MonoBehaviour
{
    public float blood = 100f;
    
    void OnTriggerEnter(Collider other){
        if(blood >= 0){
            this.blood -= 2.5f;
            print("blood: " + blood);
        }
        else{
            Destroy(this.gameObject);
        }
    }
    
}
