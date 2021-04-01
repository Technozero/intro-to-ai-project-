using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject player;
    private Animator enemy;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GetComponent<Animator>();
       
    }
    private void Update()
    {
        enemy.Play("Walk");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == player)
        {
            enemy.SetBool("IsPlayerClose", true);
            enemy.SetTrigger("Attack");
        }
       
       
        

      


    }
}
