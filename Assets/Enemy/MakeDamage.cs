using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeDamage : MonoBehaviour
{
    GameObject player;
    Health health;

    public float damage = 10f;


    private void Start()
    {
        player = GetComponent<GameObject>();

        health = player.gameObject.GetComponent<Health>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           health.maxHealth = health.currentHealth - damage;
        }

    }

}
