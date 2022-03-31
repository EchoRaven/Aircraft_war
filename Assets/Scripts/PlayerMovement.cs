using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    private PlayerStatement player;
    public float friction;
    public float frictionr;
    public float timer = 0;
    public float CD;
    public string[] animname;
    public float bullet_cd;
    private float bullet_timer = 0;
    private Animation anim;
    public GameObject bulletprefab;
    public GameObject boomprefab;
    private float boom_timer = 0;
    public float boom_cd;
    public int boomnum = 6;
    private Text boomtext;
    private void Start()
    {
        player = GetComponentInChildren<PlayerStatement>();
        anim = player.GetComponent<Animation>();
        boomtext=player.GetComponentInChildren<Camera>().GetComponentInChildren<Text>();
    }
    public void Update()
    {
        Rigidbody rb = player.GetComponent<Rigidbody>();
        Vector3 V_3 = new Vector3(rb.velocity.x, rb.velocity.y, rb.velocity.z);
        Vector3 R_3 = new Vector3(rb.angularVelocity.x, rb.angularVelocity.y, rb.angularVelocity.z);
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 r = player.transform.rotation.eulerAngles;
        Vector3 movement = new Vector3(moveVertical, 0, 0);
        float turnHor = Input.GetAxis("Horizontal");
        float turnUp = Input.GetAxis("UpAndDown");
        float turnRo = Input.GetAxis("Rotate");
        if (timer >= CD)
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                anim.Play(animname[0]);
                timer = 0;
                this.transform.position = player.transform.position;
                this.transform.rotation = player.transform.rotation;
                this.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
                this.GetComponent<Rigidbody>().angularVelocity = player.GetComponent<Rigidbody>().angularVelocity;
            }
            else if (Input.GetKeyDown(KeyCode.X))
            {
                anim.Play(animname[1]);
                timer = 0;
                this.transform.position = player.transform.position;
                this.transform.rotation = player.transform.rotation;
                this.GetComponent<Rigidbody>().velocity = player.GetComponent<Rigidbody>().velocity;
                this.GetComponent<Rigidbody>().angularVelocity = player.GetComponent<Rigidbody>().angularVelocity;
            }
        }
        timer += Time.deltaTime;
        Vector3 turn = new Vector3(turnRo, turnHor, turnUp);
        player.GetComponent<Rigidbody>().AddRelativeTorque(turn * Time.deltaTime * player.turn);
        player.GetComponent<Rigidbody>().AddForce(-V_3 * Time.deltaTime * friction);
        player.GetComponent<Rigidbody>().AddTorque(-R_3 * Time.deltaTime * frictionr);
        if (rb.velocity.magnitude <= 50)
        {
            player.GetComponent<Rigidbody>().AddRelativeForce(movement * Time.deltaTime * player.speed);
        }
        if(bullet_timer>=bullet_cd)
        {
            Vector3 point1 = new Vector3((float)4.0, 0, (float)0.8);
            Vector3 point2 = new Vector3((float)4.0, 0, -(float)0.8);
            GameObject obj1 = GameObject.Instantiate(bulletprefab, player.transform);
            obj1.transform.localPosition += point1;
            GameObject obj2 = GameObject.Instantiate(bulletprefab, player.transform);
            obj2.transform.localPosition += point2;
            bullet_timer = 0;
        }
        if(boom_timer >= boom_cd)
        {
            boomtext.text = "导弹就绪 剩余导弹数量 : " + boomnum.ToString();
            boomtext.color = Color.blue;
        }
        else
        {
            boomtext.text = "导弹发射冷却中 : " + (boom_cd - boom_timer).ToString("f2");
            boomtext.color= Color.red;
        }
        if (boom_timer >= boom_cd && boomnum > 0)
        {
            bool shootboom = Input.GetMouseButtonDown(0);
            if (shootboom)
            {
                Vector3 point3 = new Vector3(2, -1, 0);
                GameObject obj3 = GameObject.Instantiate(boomprefab, player.transform);
                obj3.transform.localPosition += point3;
                boom_timer = 0;
                boomnum--;
            }
        }
        bullet_timer += Time.deltaTime;
        boom_timer += Time.deltaTime;
    }
}
