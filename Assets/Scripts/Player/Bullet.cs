using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 10f;
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
        float distance = Vector3.Distance(transform.position, startPosition);
        if(distance > 100)
        {
            Destroy(gameObject);
        }
    }

}
