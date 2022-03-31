using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletStatement : MonoBehaviour
{
    public float damage = 5;
    public float speed = 1000;
    public bool camp = true;
    public float shootdistance = 1000;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            EnemyStatement enemy = other.GetComponent<EnemyStatement>();
            if (enemy != null)
            {
                enemy.hp -= damage;
            }
        }
        Destroy(this.gameObject);
    }
    private void Update()
    {
        this.GetComponent<Rigidbody>().velocity = -this.transform.up * speed;
        if (this.transform.localPosition.magnitude >= shootdistance)
        {
            DestroyImmediate(this.gameObject);
        }
    }
}
