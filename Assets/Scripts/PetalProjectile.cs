using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetalProjectile : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.GetComponent<PlayerMover>().TakeDamage(damage);
            Destroy(gameObject);
            Debug.Log("Player took damage from rose enemy!");
        }
    }
}
