using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    private GameObject player;
    
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

   
    void Update()
    {
        if (transform.position.y<-10)
        {
            Destroy(gameObject);
        }
        
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        rb.AddForce(lookDirection* speed);
    }
}
