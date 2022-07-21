using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster : MonoBehaviour
{
    [SerializeField] float cur_hp;
    [SerializeField] float speed;
    [SerializeField] Transform PlayerTr;


    NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        ai.SetDestination(new Vector3(PlayerTr.position.x, PlayerTr.position.y, PlayerTr.position.z));
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag=="Hitbox")
        {
            cur_hp -= 5;
        }
    }
}
