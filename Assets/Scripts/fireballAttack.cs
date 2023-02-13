using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireballAttack : MonoBehaviour
{
    public float Speed = 4.5f;
    
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] otherObjects = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject Projectile in otherObjects) {
            Physics2D.IgnoreCollision(Projectile.GetComponent<Collider2D>(), GetComponent<Collider2D>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += -transform.right * Time.deltaTime * Speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
