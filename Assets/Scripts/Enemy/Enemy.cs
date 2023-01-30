using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : ObjectWithHealth
{
    public int damage = 10;
    NavMeshAgent navMeshAgent;
    Transform target;

    bool is_DamageCourotineStarted = false;
    
    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (target == null) return;
        navMeshAgent.SetDestination(target.position);
        PlayerYaqinida();
    }

    void PlayerYaqinida()
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
        while (true)
        {
            yield return new WaitForSeconds(1f);
            target.GetComponent<Player>().getDamage(damage);
            if (target.GetComponent<Player>().is_Dead) {
                target = null;
                StopAllCoroutines();
            }
        }
    }

    
}
