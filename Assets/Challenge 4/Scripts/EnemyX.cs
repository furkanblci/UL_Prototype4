﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyX : MonoBehaviour
{
    public static EnemyX instance;
    public float speed;
    private float startSpeed = 2;
    private Rigidbody enemyRb;
    private GameObject playerGoal;

  
    void Start()
    {
        instance = this;
        enemyRb = GetComponent<Rigidbody>();
        playerGoal = GameObject.Find("Player");
    }


    void Update()
    {
        Vector3 lookDirection = (playerGoal.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);

    }

    private void OnCollisionEnter(Collision other)
    {
        // If enemy collides with either goal, destroy it
        if (other.gameObject.name == "Enemy Goal")
        {
            Destroy(gameObject);
        } 
        else if (other.gameObject.name == "Player Goal")
        {
            Destroy(gameObject);
        }

    }

}
