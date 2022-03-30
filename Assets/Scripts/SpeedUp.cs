using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour
{
    private PlayerStatement player;
    private int speed_timer;
    private void Start()
    {
        player = GetComponentInChildren<PlayerStatement>();
    }
    
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C)){
            if(player.speed == 200){
                speed_timer = 100;
                player.speed = 1000;
            }
        }
        speed_timer--;
        if(speed_timer <= 0){
            player.speed = 200;
        }
    }
}
