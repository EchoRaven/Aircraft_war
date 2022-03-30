using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatement : MonoBehaviour
{
    public float damage = 100;
    public float speed = 1000;
    public bool camp = true;
    public float shootdistance = 1000;
    
    void OnTriggerEnter(Collider other){
        Destroy(this.gameObject);
    }
}
