using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class kapı : MonoBehaviour
{
    public TextMeshPro doorNum;
    public int randoms;
    public bool multiply;
    void Start()
    {
        if(multiply)
        {
            randoms= Random.Range(1,3);
            doorNum.text= "X" + randoms;
        }
        else
        {
            randoms = Random.Range(10,100);
            if(randoms %2 !=0){
                randoms+=1;
            }
            doorNum.text = randoms.ToString();
        }
    }

}
