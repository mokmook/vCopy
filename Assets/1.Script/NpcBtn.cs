using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class NpcBtn : MonoBehaviour
{
    [SerializeField] string[] datas;
    [SerializeField] GameObject btnPrefab;
    [SerializeField] Transform panlet;
    Button[] buttons;
    bool[] alreadySell;
    void Start()
    {
        buttons = new Button[datas.Length];
        alreadySell=new bool[datas.Length];
        for (int i = 0; i < datas.Length; i++)
        {
            buttons[i] = Instantiate(btnPrefab, panlet).GetComponent<Button>();
            buttons[i].GetComponent<RectTransform>().anchoredPosition = Vector2.down * 200*i;
            int idx = i;
            buttons[i].onClick.AddListener(() => Selctitem(idx));
            buttons[i].transform.GetChild(0).GetComponent<TextMeshProUGUI>().text= datas[i];
                
        }
    }
    void Selctitem(int dataIndex)
    {
        print(datas[dataIndex]);
        alreadySell[dataIndex] = true;
        buttons[dataIndex].interactable = false;
    }   
 
}
