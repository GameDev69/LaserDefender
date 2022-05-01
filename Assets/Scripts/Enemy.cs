using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("Данные префаба")]
    [SerializeField] private float health = 100;
    
    [Header("Характеристики срельбы")]
    [SerializeField] private float shotCounter;
    [SerializeField] private float minTimeBetweenShots = 0.2f;
    [SerializeField] private float maxTimeBetweenShots = 3f;
    [SerializeField] private GameObject enemyLaserPrefab;
    [SerializeField] private float enemyLaserSpeed;
    
    [Header("Данне об уничтожении объекта")]
    [SerializeField] private GameObject destroyEnemyVFX;
    [SerializeField] private AudioClip deathSFX;
    [SerializeField] [Range(0, 1)] private float deathSoundVolume = 0.75f;
    
    [Header("Данные стрельбы")]
    [SerializeField] private AudioClip shootSound;
    [SerializeField] [Range(0,1)] private float shootSoundVolume = 0.25f;


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
        if (shotCounter <= 0f)
        {
            Fire();
            shotCounter = Random.Range(minTimeBetweenShots, maxTimeBetweenShots);
        }
    }

    private void Fire()
    {
        GameObject enemyLaser = Instantiate(
            enemyLaserPrefab,
            transform.position,
            Quaternion.identity);
        enemyLaser.GetComponent<Rigidbody2D>().velocity = new Vector2(0, -enemyLaserSpeed);
        AudioSource.PlayClipAtPoint(shootSound, Camera.main.transform.position, shootSoundVolume);
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        DamageDealer damageDealer = collider2D.gameObject.GetComponent<DamageDealer>();
        // Если у объекта collider2D нет компонента DamageDealer...
        if (!damageDealer) return;
        ProcessHit(damageDealer);
    }

    private void ProcessHit(DamageDealer damageDealer)
    {
        health -= damageDealer.GetDamage();
        damageDealer.Hit();
        if (health <= 0)
        {
            Die(out var sparkles);
        }
    }

    private void Die(out GameObject sparkles)
    {
        Destroy(gameObject);
        sparkles = Instantiate(destroyEnemyVFX, transform.position, Quaternion.identity);
        Destroy(sparkles, 1f);
        PlayDieSFX();
    }

    private void PlayDieSFX()
    {
        AudioSource.PlayClipAtPoint(deathSFX, Camera.main.transform.position, deathSoundVolume);
    }
}
