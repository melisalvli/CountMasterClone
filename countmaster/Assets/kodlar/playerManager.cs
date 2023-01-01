using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using Unity.Mathematics;


public class playerManager : MonoBehaviour
{
    public Transform player;
    private int minionsCount;
    [SerializeField] private TextMeshPro counterText;
    [SerializeField] private GameObject minions;
    [Range(0f,1f)] [SerializeField] private float DistanceFactor, Radius;
    private Camera camera;
    [SerializeField] private Transform road; 
    void Start()
    {
        player = transform;
        minionsCount = transform.childCount -1;
        counterText.text = minionsCount.ToString();
        camera= Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void FormatMinion(){
        for(int i=1; i< player.childCount ;i++){
            var x = DistanceFactor * Mathf.Sqrt(i) * Mathf.Cos(i*Radius);
            var z = DistanceFactor * Mathf.Sqrt(i) * Mathf.Sin(i*Radius);
            var newPos = new Vector3(x,2,z);
            player.transform.GetChild(i).position=newPos;
        }

    }
        private void CreateMinion(int num){
        for(int i=1;i<num;i++){
            Instantiate(minions,transform.position, quaternion.identity, transform);

        }
        minionsCount = transform.childCount -1;
        counterText.text = minionsCount.ToString();
        FormatMinion();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Door")){
            other.transform.parent.GetChild(0).GetComponent<BoxCollider>().enabled=false;
            other.transform.parent.GetChild(1).GetComponent<BoxCollider>().enabled=false;

            var gates = other.GetComponent<kapı>();
            if(gates.multiply){
                CreateMinion(minionsCount * gates.randoms);
            }
            else{
                CreateMinion(minionsCount + gates.randoms);
            }
        }
    }

}