using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [SerializeField]Slider slider;

   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (FindObjectOfType<Monster>().Dead==true)
        {
            slider.value += 3;
        }
        if (slider.value>=20)
        {
            slider.value = 0;
        }
    }
}
