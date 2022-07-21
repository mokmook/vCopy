using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class Monster : MonoBehaviour
{
    [SerializeField] float cur_hp;
    [SerializeField] float speed;
    Transform PlayerTr;
    public bool Dead { get; private set; }

    Animator anim;
    NavMeshAgent ai;
    // Start is called before the first frame update
    void Start()
    {
        ai = GetComponent<NavMeshAgent>();
        PlayerTr = FindObjectOfType<Player>().transform;
        anim=GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (cur_hp <= 0)
        {
            Die();
        }
        else
        {
            ai.SetDestination(PlayerTr.position);
            anim.SetBool("Walk", true);
            Dead = false;
        }
        print("¸ó½ºÅÍ HP: " + cur_hp);
    }
    void Die()
    {
        gameObject.SetActive(false);
        Dead = true;
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Hitbox")
        {
            cur_hp = cur_hp - 5;
        }
    }
}
