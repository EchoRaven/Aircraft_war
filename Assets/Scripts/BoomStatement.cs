using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomStatement : MonoBehaviour
{
    public float damage = 50;
    public float speed = 100;
    public bool camp = true;//true��ʾ�ѷ���Ӫ
    public float shootdistance = 1000;

    private Transform Target = null;
    
    private float Acceleration = 10.0f;             //���ٶ�
    private float MaximumRotationSpeed = 120.0f;    //���ת���ٶ�
    private float MaximumSpeed = 300.0f;            //����ٶ�     
    public float MaximumLifeTime = 5.0f;          //�����������
    public float lifeTime = 0.0f;                 //��������
    
    //��ײ�¼�
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyStatement enemy = other.GetComponent<EnemyStatement>();
            if (enemy != null)
            {
                enemy.hp -= damage;
            }
            Destroy(this.gameObject);
        }
    }

    private void Start()
    {
        this.GetComponent<Rigidbody>().velocity = -this.transform.right * speed;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
        int len = objects.Length;
        int target = 0;
        float distance = float.PositiveInfinity;
        for (int i = 0; i < len; i++)
        {
            Vector3 dir = Camera.main.WorldToScreenPoint(objects[i].transform.position);
            if (dir.z < 0)
            {
                continue;
            }
            if (dir.x * dir.x + dir.y * dir.y + dir.z * dir.z < distance)
            {
                distance = dir.x * dir.x + dir.y * dir.y + dir.z * dir.z;
                target = i;
            }
        }
        Target = objects[target].transform;
        print(target);
    }
    void Update() {
        lifeTime += Time.deltaTime;
        if( lifeTime > MaximumLifeTime )
        {
            Destroy(this.gameObject);
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
