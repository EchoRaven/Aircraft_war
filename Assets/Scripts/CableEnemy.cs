using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableEnemy : MonoBehaviour
{
    public GameObject prefab;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject enemy in objects)
            {
                Vector3 dir = Camera.main.WorldToScreenPoint(enemy.transform.position);
                dir.x = dir.x - Screen.width / 2;
                dir.y = dir.y - Screen.height / 2;
                if (dir.z > 0)
                {
                    GameObject obj = GameObject.Instantiate(prefab, this.transform);
                    obj.transform.localPosition += dir;
                    Destroy(obj, 0.5f);
                }
            }
        }
    }
}
