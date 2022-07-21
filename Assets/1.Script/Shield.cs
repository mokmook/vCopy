using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
   [SerializeField]GameObject ObjShield;
    [SerializeField] GameObject Player;
    float rotatetion;

    void Start()
    {
    }

    void Update()
    {
        Vector3 vector3 = Player.transform.position;

        if (ObjShield.activeSelf==true)
        {
            transform.RotateAround(vector3, Vector3.up, Time.deltaTime * 55);
        }
    }
    
}
