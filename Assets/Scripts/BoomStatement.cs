using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomStatement : MonoBehaviour
{
    public float damage = 100;
    public float speed = 0;
    public bool camp = true;//true��ʾ�ѷ���Ӫ
    public float shootdistance = 1000;
    
    public Transform Target = null;
    public Collider Target_Collider = null;
    
    private float Acceleration = 10.0f;             //���ٶ�
    private float MaximumRotationSpeed = 120.0f;    //���ת���ٶ�
    private float MaximumSpeed = 100.0f;            //����ٶ�     
    public float MaximumLifeTime = 5.0f;          //�����������
    public float lifeTime = 0.0f;                 //��������
    
    //��ײ�¼�
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
