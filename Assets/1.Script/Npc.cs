using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    [SerializeField] Camera cam;
    [SerializeField] Canvas can;
    [SerializeField] string key;

    bool isActiveNow=false;
    private void OnTriggerStay(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player!=null&& Input.GetKeyDown(KeyCode.Space))
        {           
                Acttion(!isActiveNow);           
        }
    }
    private void OnTriggerExit(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            Acttion(false);
        }
    }
  void Acttion(bool active)
    {
        cam.gameObject.SetActive(active);
        can.gameObject.SetActive(active);

        isActiveNow = !active;
    }
}
