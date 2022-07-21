using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterSpwan : MonoBehaviour
{
    [SerializeField] float SpwanDelay;
    [SerializeField] GameObject Monster;
    bool startCor=false;


    // Start is called before the first frame update
    private void Update()
    {
        if (!startCor)
        {
            StartCoroutine("MonsterSpwaner");
        }
    }

    IEnumerator MonsterSpwaner()
    {
        startCor = true;
        for (int i = 0; i < 4; i++)
        {
            GameObject game = Instantiate(Monster, transform.position, Quaternion.identity);
            game = Monster;
        }
        
        Monster.SetActive(false);       
        while (true)
        {
            Monster.SetActive(true);
            
            yield return new WaitForSeconds(SpwanDelay);
        }
    }
}
