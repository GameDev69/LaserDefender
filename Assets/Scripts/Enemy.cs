using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 100;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        DamageDealer damageDealer = collider2D.gameObject.GetComponent<DamageDealer>();
        health -= damageDealer.GetDamage();
    }
}
