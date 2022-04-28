using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100;
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject enemyLaserPrefab;
    [SerializeField] private float enemyLaserSpeed;

    
    void Start()
    {
        shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
    }

    
    void Update()
    {
        CountDownAndShoot();
    }

    private void CountDownAndShoot()
    {
        shotCounter -= Time.deltaTime;
        Debug.Log(Time.deltaTime);
        if (shotCounter <= 0f)
        {
            StartCoroutine(Fire());
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private IEnumerator Fire()
    {
        while (true)
        {
            GameObject enemyLaser = Instantiate(
                enemyLaserPrefab,
                transform.position,
                Quaternion.identity) as GameObject;
            enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
            yield return new WaitForSeconds(shotCounter);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        DamageDealer damageDealer = collider2D.gameObject.GetComponent<DamageDealer>();
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
