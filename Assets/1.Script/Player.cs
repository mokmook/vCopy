using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] AudioClip attckClip;
    [SerializeField] float cur_hp;
    float hAxis;
    float vAxis;
    bool startCor = false;
    [SerializeField] float speed;
    [SerializeField, Range(0, 5)] int WeaponNum;
    [SerializeField] public int attackDelay;
    [SerializeField] int Power;

    [Header("µµ³¢")]
    [SerializeField] GameObject Weapon1;
    [SerializeField] GameObject Weapon1Hitbox;

    [Header("½ºÅÂÇÁ")]
    [SerializeField] GameObject Weapon2;
    [SerializeField] GameObject Weapon2Hitbox;

    [Header("ÇØ¸Ó")]
    [SerializeField] GameObject Weapon3;
    [SerializeField] GameObject Weapon3Hitbox;

    [Header("¹æÆÐ")]
    [SerializeField] GameObject Weapon4;

    [Header("Ä®")]
    [SerializeField] GameObject Weapon5;
    [SerializeField] GameObject Weapon5Hitbox;


    Animator anim;
    Rigidbody rb;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);

        if (moveVec != Vector3.zero)
            anim.SetBool("Walk", true);
        else
            anim.SetBool("Walk", false);

        switch (WeaponNum)
        {
            case 0:
                Defalut(); break;
            case 1:
                Axe(); break;
            case 2:
                Staff(); break;
            case 3:
                Hammer(); break;
            case 4:
                Shield(); break;
            case 5:
                Sword(); break;

        }
        if (cur_hp<=0)
        {
            Die();
        }

    }
    void Defalut()
    {
        Weapon1.SetActive(false);
        Weapon2.SetActive(false);
        Weapon3.SetActive(false);
        Weapon4.SetActive(false);
        Weapon5.SetActive(false);
    }
    void Axe()
    {
        Weapon1.SetActive(true);
        if (!startCor)
            StartCoroutine(attack(Weapon1Hitbox, Weapon1));
    }
    void Staff()
    {
        Weapon2.SetActive(true);
        if (!startCor)
            StartCoroutine(attack(Weapon2Hitbox, Weapon2));
    }
    void Hammer()
    {
        Weapon3.SetActive(true);
        if (!startCor)
            StartCoroutine(attack(Weapon3Hitbox, Weapon3));
    }
    void Shield()
    {
        Weapon4.SetActive(true);
        //Instantiate(Weapon4,transform.position,Quaternion.identity);
    }
    void Sword()
    {
        Weapon5.SetActive(true);
        if (!startCor)
            StartCoroutine(attack(Weapon5Hitbox, Weapon5));
    }
    void Die()
    {
        anim.SetTrigger("Die");
        Invoke("TimeStop", 3);

    }
    void TimeStop()
    {
        Time.timeScale = 0;
    }
    IEnumerator attack(GameObject Hitbox, GameObject Weapon)
    {
        startCor = true;

        while (Weapon.activeSelf == true)
        {
            if (Weapon == Weapon2)
            {
                anim.SetTrigger("Attack" + WeaponNum);
                AudioManager.instance.PlayAudioClip(attckClip,transform);
                GameObject gameObj = (GameObject)Instantiate(Hitbox, transform.position, Quaternion.identity);
                gameObj.GetComponent<Rigidbody>().AddForce(transform.forward * Power, ForceMode.Impulse);
                yield return new WaitForSeconds(attackDelay);
                Destroy(gameObj);
            }
            else if (Weapon == Weapon5)
            {
                anim.SetTrigger("Attack" + WeaponNum);
                GameObject game = Instantiate(Hitbox, new Vector3(transform.position.x, 0.7f, transform.position.z), Quaternion.identity);
                Destroy(game, 0.1f);
                yield return new WaitForSeconds(attackDelay);
            }
            else
            {
                anim.SetTrigger("Attack" + WeaponNum);
                GameObject game = Instantiate(Hitbox, transform.position + transform.forward, Quaternion.identity);

                Destroy(game, 0.1f);
                yield return new WaitForSeconds(attackDelay);
            }

        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="Monster")
        {
            cur_hp = cur_hp - 2;
        }
    }

}
