using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomStatement : MonoBehaviour
{
    public float damage = 100;
    public float speed = 100;
    public bool camp = true;//true表示友方阵营
    public float shootdistance = 1000;

    void OnTriggerEnter(Collider other)
    {
        print("Hit it!");
        Destroy(other.gameObject);
        Destroy(this.gameObject);
    }
}
