using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Setting : MonoBehaviour
{

    [SerializeField] int defaultAuido;
    [SerializeField] Slider auidoSilder;
    public int cur_Auido { get; private set; }
    private void OnEnable()
    {
        Time.timeScale = 0;
    }

    void Start()
    {
        cur_Auido = defaultAuido;
        auidoSilder.value = cur_Auido;
        auidoSilder.onValueChanged.AddListener((float v) => 
        { 
            cur_Auido = (int)v;
            print(cur_Auido);
        });
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}
