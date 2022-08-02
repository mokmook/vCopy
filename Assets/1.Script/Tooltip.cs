using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;



public class Tooltip : MonoBehaviour ,IPointerEnterHandler,IPointerExitHandler
{
    [SerializeField] GameObject tooltop;
    [SerializeField] string content;
    [SerializeField] Vector2 offset;
    private void Start()
    {
        tooltop.GetComponent<TextMeshProUGUI>().text = content;
    }
    private void Update()
    {
        if (!tooltop.activeSelf) return;
        tooltop.transform.position = (Vector2)Input.mousePosition+offset;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        tooltop.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tooltop.SetActive(false);
    }
}
