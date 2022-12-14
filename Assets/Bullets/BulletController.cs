using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BulletController : MonoBehaviour
{
    EnemyHealth enemyHealth;

    public GameObject start;

    [SerializeField]
    private float  speed = 50f;
    private float timeDestroy = 0.5f;
    public float damage = 15f;

    public Vector3 target { get; set; }
    public bool hit { get; set; }

    private void Start()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
    }
    private void OnEnable()
    {
        Destroy(gameObject, timeDestroy);
    }


    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,target,speed * Time.deltaTime);
        if(!hit && Vector3.Distance(transform.position,target) < 0.01f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
            enemyHealth.currentHealth = enemyHealth.currentHealth - damage;

            if (enemyHealth.currentHealth <= 0)
            {
                Destroy(other.gameObject);
                
            }
        }
    }

  


}
