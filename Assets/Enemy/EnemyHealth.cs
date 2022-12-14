using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth = 100;

    public float currentHealth;
   
    private void Start()
    {
        currentHealth = maxHealth;
        
    }


}
