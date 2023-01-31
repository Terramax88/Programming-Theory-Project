using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    [SerializeField] private float timeBetweenSpawn = 0.1f;
    [SerializeField] private GameObject enemyPrefabs;
    [SerializeField] private Transform Enemes;

    GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        StartCoroutine(Spawn());
    }

    IEnumerator Spawn()
    {
        while (!gameManager.IsGameOVer)
        {
            yield return new WaitForSeconds(timeBetweenSpawn);
            Instantiate(enemyPrefabs, transform.position, enemyPrefabs.transform.rotation, Enemes);
        }
    }
}
