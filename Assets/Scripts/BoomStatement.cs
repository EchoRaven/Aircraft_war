using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomStatement : MonoBehaviour
{
    public float damage = 100;
    public float speed = 0;
    public bool camp = true;//true表示友方阵营
    public float shootdistance = 1000;
    
    public Transform Target = null;
    public Collider Target_Collider = null;
    
    private float Acceleration = 10.0f;             //加速度
    private float MaximumRotationSpeed = 120.0f;    //最大转弯速度
    private float MaximumSpeed = 100.0f;            //最大速度     
    public float MaximumLifeTime = 5.0f;          //最大生命周期
    public float lifeTime = 0.0f;                 //生命周期
    
    //碰撞事件
    void OnTriggerEnter(Collider other)
    {
        print("Boom hit it!:\t" + other);
        
        if(Target_Collider == other){
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
    
    
    void Update() {
        lifeTime += Time.deltaTime;
        if( lifeTime > MaximumLifeTime )
        {
            Destroy(this.gameObject);
            print("destroy boom");
            return;
        }

        
        Vector3 offset = Target == null ? Vector3.right : (Target.position - transform.position).normalized;
        
        float angle = Vector3.Angle(transform.right, offset);
        
        float needTime = angle / (MaximumRotationSpeed * (speed/MaximumSpeed));
        
        transform.right = Vector3.Slerp(transform.right,offset,Time.deltaTime / needTime).normalized;
        
        if(speed < MaximumSpeed)
            speed += Time.deltaTime * Acceleration;
        
        transform.position += transform.right * speed * Time.deltaTime;
    }
}
