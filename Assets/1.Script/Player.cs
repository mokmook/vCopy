using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float hAxis;
    float vAxis;
    [SerializeField] float speed;

    void Start()
    {
      
    }

    void Update()
    {
        hAxis=Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");

        Vector3 moveVec = new Vector3(hAxis, 0, vAxis).normalized;
        transform.position += moveVec * speed * Time.deltaTime;
        transform.LookAt(transform.position + moveVec);
        
    }

   /* void moveMoment(Vector3 dir)
    {
        Vector3 lookdir=transform.TransformDirection(dir);
        lookdir.y = 0;
        transform.Translate(dir * speed * Time.deltaTime);
        Quaternion q=Quaternion.LookRotation(lookdir,Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, q,10*Time.deltaTime);
    }*/
}
