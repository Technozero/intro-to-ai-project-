using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    private GameObject player;
    private Animator enemy;
   
 
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        enemy.Play("Enemy2idle");


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemy.SetBool("IsPlayerClose", true);
            enemy.SetTrigger("Attack");
            enemy.SetTrigger("Jump");
            
            
        }
    }
}
