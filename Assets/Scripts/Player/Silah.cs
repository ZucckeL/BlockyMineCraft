using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Silah : NetworkBehaviour {
	
    public int hasar1, hasar2,mesafe;
    RaycastHit hit;
    Envanter er;
	El el;
    public GameObject rayText;
    public float maxzaman,zaman;
    public bool aktif;
    void Start()
    {
        rayText = GameObject.FindGameObjectWithTag("Yazi");
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        
    }
   void Update()
    {
        if(Physics.Raycast(Camera.main.transform.position,Camera.main.transform.forward,out hit, mesafe))
        {
            if(hit.transform.tag == "Tree")
            {
                Bitki bi = hit.transform.gameObject.GetComponent<Bitki>();
                rayText.GetComponent<Text>().text = "Tree Health: " + bi.can.ToString();
            }
           
            
        }
        if (Input.GetMouseButtonDown(0) && !aktif)
        {
            aktif = true;
            zaman = maxzaman;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, mesafe))
            {
                if(hit.transform.tag == "Tree")
                {
                    Bitki bi = hit.transform.gameObject.GetComponent<Bitki>();
                    bi.can -= Random.Range(hasar1, hasar2);
                    
                    er.items[GetComponent<ItemEl>().slotsayi].itemkullanim -= Random.Range(3, 6);
					if(er.items[GetComponent<ItemEl>().slotsayi].itemkullanim < 0){
						er.items[GetComponent<ItemEl>().slotsayi] = new Item();
					}
                    Debug.Log(er.items[GetComponent<ItemEl>().slotsayi].itemkullanim + "-" + er.items[GetComponent<ItemEl>().slotsayi].itemismi);
                   
                }
                
            }
        }

        if (aktif)
        {
            if(zaman > 0)
            {
                zaman -= 3*Time.deltaTime;
            }
            else
            {
                aktif = false;
            }
        }
    }
}
