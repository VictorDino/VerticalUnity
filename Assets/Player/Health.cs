using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    public float maxHealth = 100;

    public float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if(currentHealth <= 0)
        {
            GameOver();
        }
    }

    private void GameOver() 
    { 
        Debug.Log("YOU LOSE");
    }


}
