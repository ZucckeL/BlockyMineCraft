using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Toplama : NetworkBehaviour {
    public RaycastHit hit;
    public Envanter er;
    public Obje oe;
    public Text raycastYazi;
   void Start()
    {
       
            er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
       
    }
    void Update()
    {
        
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 5))
            {
                if (hit.transform.gameObject.tag == "Obje")
                {
                    oe = hit.transform.gameObject.GetComponent<Obje>();
                    if (oe.item.itemmiktar > 1)
                    {
                        raycastYazi.text = oe.item.itemismi + " x" + oe.item.itemmiktar;
                    }
                    else
                    {
                        raycastYazi.text = oe.item.itemismi;
                    }
                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        er.itemEkle(oe.item.itemid, oe.item.itemmiktar);
                        Destroy(hit.transform.gameObject);

                    }
                }
                else
                {
                    raycastYazi.text = "";
                }
            }
            else
            {
                raycastYazi.text = "";
            }
        }
    
}
