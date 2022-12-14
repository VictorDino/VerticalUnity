using UnityEngine;
using System.Collections;

public class Turret : MonoBehaviour {

	private Transform target;

	public GameObject turretBullet;
	public Transform firePoint;

    public float range = 15f;
    public float fireRate = 1f;
	private float fireCountdown = 0f;

	public string enemyTag = "Enemy";

	public Transform partToRotate;
	public float turnSpeed = 10f;

	private void Start () {
		InvokeRepeating("UpdateTarget", 0f, 0.5f);
	}
	
	void UpdateTarget ()
	{
		GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
		float shortestDistance = Mathf.Infinity;
		GameObject nearestEnemy = null;
		foreach (GameObject enemy in enemies)
		{
			float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
			if (distanceToEnemy < shortestDistance)
			{
				shortestDistance = distanceToEnemy;
				nearestEnemy = enemy;
			}
		}

		if (nearestEnemy != null && shortestDistance <= range)
		{
			target = nearestEnemy.transform;
			
		} else
		{
			target = null;
		}

	}

	
	private void Update () 
	{
		if (target == null)
		{
			return;
		}
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

		if (fireCountdown <= 0f)
			{
				Shoot();
				fireCountdown = 1f / fireRate;
			}
		fireCountdown -= Time.deltaTime;
		
	}

	private void Shoot ()
	{
		GameObject bulletGO = (GameObject)Instantiate (turretBullet,firePoint.position,firePoint.rotation);
		TurretBulletController bullet = bulletGO.GetComponent<TurretBulletController>();

		if(bullet != null)
		{
			bullet.Seek(target);
		}
	}

	private void OnDrawGizmosSelected ()
	{
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(transform.position, range);
	}
}
