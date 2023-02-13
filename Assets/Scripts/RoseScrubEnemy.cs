using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseScrubEnemy : MonoBehaviour
{
public GameObject petalPrefab;
public float shootingInterval = 3f;
private float timeSinceLastShot;
public PlayerMover playerHealth;
public PlayerMover enemyKnockback;
public PlayerMover fromRight;
public Transform LaunchOffset;
public int damage = 1;
public int health = 3;
private void Update()
{
timeSinceLastShot += Time.deltaTime;
    if (timeSinceLastShot >= shootingInterval)
    {
        ShootPetal();
        timeSinceLastShot = 0f;
    }
}

private void ShootPetal()
{
    GameObject petal = Instantiate(petalPrefab, LaunchOffset.position, transform.rotation);

    Rigidbody2D rigidbody = petal.GetComponent<Rigidbody2D>();
    Vector2 direction = new Vector2(-1,0);
    rigidbody.velocity = direction * 10;
    Destroy(petal, 1f);
}

private void OnCollisionEnter2D(Collision2D collision)
{
    if (collision.gameObject.tag == "Projectile")
    {
        health -= damage;
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
      if(collision.gameObject.tag == "Sword")
        {
            health--;
        }
    else if (collision.gameObject.tag == "Player")
    {
        playerHealth.TakeDamage(damage);
        enemyKnockback.knockbackCount = 0.6f;
        if (collision.transform.position.x < transform.position.x)
        {
            fromRight.knockFromRight = true;
        }
        else
        {
            fromRight.knockFromRight = false;
        }
    }
}
}