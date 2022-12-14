using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBulletController : MonoBehaviour
{
    private Transform target;

    public float speed;

    public float damage;

    EnemyHealth enemyHealth;
    public void Seek(Transform _target)
    {
        target = _target;
    }

    private void Start()
    {
        enemyHealth = GameObject.FindGameObjectWithTag("Enemy").GetComponent<EnemyHealth>();
    }

    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if (dir.magnitude <= distanceThisFrame)
        {
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
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
