using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
    public int damage = 10;
    Rigidbody rigidbody;

    Vector3 startPosition;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = transform.forward * speed;
        startPosition = transform.position;
    }

    private void Update()
    {
        ChegaradanCiqqanda();
    }

    private void ChegaradanCiqqanda()
    {
        float distance = Vector3.Distance(transform.position, startPosition);
        if (distance > 100)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {        
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("Bullet tregired");
            other.GetComponent<Enemy>().getDamage(damage);
        }
    }

}
