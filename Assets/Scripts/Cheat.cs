using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cheat : MonoBehaviour
{
    private PlayerMovement player;
    private int cheat;
    // Start is called before the first frame update
    private void Start()
    {
        player = GetComponentInParent<PlayerMovement>();
    }
    
    // Update is called once per frame
    void Update()
    {
    
        if(Input.GetKeyDown(KeyCode.UpArrow)){
            if(cheat == 0){
                cheat++;
                print("cheat = " + cheat);
            }
            else if(cheat == 1){
                cheat++;
                print("cheat = " +cheat);
            }
            else{
                cheat = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow)){
            if(cheat == 2){
                cheat++;
                print("cheat = " + cheat);
            }
            else if(cheat == 3) {
                cheat++;
                print("cheat = " + cheat);
            }
            else{
                cheat = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.LeftArrow)){
            if(cheat == 4){
                cheat++;
                print("cheat = " + cheat);
            }
            else if(cheat ==6){
                cheat++;
                print("cheat = " + cheat);
            }
            else {
                cheat = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.RightArrow)){
            if(cheat == 5){
                cheat++;
                print("cheat = " + cheat);
            }
            else if(cheat == 7){
                cheat++;
                print("cheat = " + cheat);
            }
            else {
                cheat = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.B)){
            if(cheat == 8){
                cheat++;
                print("cheat = " + cheat);
            }
            else if(cheat == 10){
                cheat++;
                print("cheat = " + cheat);
            }
            else {
                cheat = 0;
            }
        }
        else if(Input.GetKeyDown(KeyCode.A)){
            if(cheat == 9){
                cheat++;
                print("cheat = "+ cheat);
            }
            else if(cheat == 11){
                cheat++;
                print("cheat = " + cheat);
            }
            else {
                cheat = 0;
            }
        }
        
        if(cheat == 12){
            player.boomnum = 999;
            player.boom_cd = 0.1f;
            cheat = 0;
        }
    }
}
