using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{
    public GameObject bullet;
    public float spawnTime;
    public Transform gun;
    public Transform Bullets;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            LookAtMousePosition();
            StartCoroutine(FireBullet());
        }

        if (Input.GetMouseButton(0))
        {
            LookAtMousePosition();
        }

        if (Input.GetMouseButtonUp(0))
        {
            StopAllCoroutines();
        }
        
    }

    IEnumerator FireBullet()
    {
        while (true)
        {
            Instantiate(bullet, gun.position, gun.parent.rotation,Bullets);
            yield return new WaitForSeconds(spawnTime);
        }        
    }

    void LookAtMousePosition()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //Debug.Log(Input.mousePosition);
        if (Physics.Raycast(ray, out hit))
        {
            //Debug.Log(hit.point);
            Vector3 lookPoint = new Vector3(hit.point.x, 0, hit.point.z);
            transform.LookAt(lookPoint);
        }
    }
}
