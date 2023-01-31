using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private int damage = 10;
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
        ChegaradanCiqqanda(); // ABSTRACTION
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
            other.GetComponent<Enemy>().getDamage(damage);
        }
    }

}
