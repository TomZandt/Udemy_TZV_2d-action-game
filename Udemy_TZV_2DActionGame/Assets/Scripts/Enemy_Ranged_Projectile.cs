using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Ranged_Projectile : MonoBehaviour
{
    [Header("The speed of the projectile")]
    public float projectileSpeed = 15f;

    [Header("The damage dealt by the projectile")]
    public int damageDealt = 1;

    [Header("The death effect")]
    public GameObject deathEffect;

    private MainCharacter playerScript;
    private Vector2 targetPosition;

    //****************************************************************************************************
    private void Start()
    {
        playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<MainCharacter>();

        targetPosition = playerScript.transform.position;
    }

    //****************************************************************************************************
    private void Update()
    {
        // If we are close to the player
        if (Vector2.Distance(transform.position, targetPosition) > 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, projectileSpeed * Time.deltaTime);
        }
        else
        {
            // Play particle effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            Destroy(gameObject);
        }
    }

    //****************************************************************************************************
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            // Play particle effect
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            playerScript.TakeDamage(damageDealt);

            Destroy(gameObject);
        }
    }
}
