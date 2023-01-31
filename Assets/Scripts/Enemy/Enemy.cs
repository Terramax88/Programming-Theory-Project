using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Enemy : ObjectWithHealth // INHERITANCE
{
    [SerializeField] private int damage = 10;
    NavMeshAgent navMeshAgent;
    Transform target;

    bool is_DamageCourotineStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        FindManager();
        if (GameObject.FindGameObjectWithTag("Player") == null) return;
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.IsGameOVer)
        {
            if (navMeshAgent != null) navMeshAgent.Stop();
            return;
        }
        navMeshAgent.SetDestination(target.position);
        PlayerYaqinida(); // ABSTRACTION
    }

    void PlayerYaqinida() // ABSTRACTION
    {
        if(Vector3.Distance(target.position, transform.position) < 2)
        {
            if (!is_DamageCourotineStarted) StartCoroutine(DamageAndWait());
        }
        else
        {
            if (is_DamageCourotineStarted) StopAllCoroutines();
        }
    }

    IEnumerator DamageAndWait()
    {
        is_DamageCourotineStarted = true;
        while (!gameManager.IsGameOVer)
        {
            target.GetComponent<Player>().getDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }

    public override void Dead() // POLYMORPHISM
    {
        gameManager.Score++;
        target = null;
        StopAllCoroutines();
    }
}
