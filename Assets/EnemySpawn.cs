using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public float timeBetweenSpawn = 0.1f;
    public GameObject enemyPrefabs;
    public Transform Enemes;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            Instantiate(enemyPrefabs, transform.position, enemyPrefabs.transform.rotation, Enemes);
        }
    }
}
