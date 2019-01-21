using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Bitki : MonoBehaviour {
    public float can, odundegeri, elmadegeri;
    public Transform[] odunlarsp;
    public Transform elmasp;
    public GameObject odun, elma;
    DataItem dataitem;

    Rigidbody agirlik;

    
	// Use this for initialization
	void Start () {
        
        odunlarsp[0] = gameObject.transform;
        odunlarsp[1] = gameObject.transform;
        odunlarsp[2] = gameObject.transform;
        odunlarsp[3] = gameObject.transform;
        odunlarsp[4] = gameObject.transform;
        elmasp = gameObject.transform;
        dataitem = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();
        agirlik = GetComponent<Rigidbody>();
        agirlik.isKinematic = true;
        agirlik.useGravity = false;
        can = 100;
        odundegeri = Random.Range(2, 5);
	}
	
	// Update is called once per frame
	void Update () {
        
        if (can <= 0)
        {
            can = 0;
            agirlik.useGravity = true;
            agirlik.isKinematic = false;
            Invoke("Sil", Random.Range(3, 4));
        }
	}

    void OdunlariCikar()
    {
        elmadegeri = Random.Range(0, 2);
        if(elmadegeri == 1)
        {
            GameObject elmam = Instantiate(elma,elmasp.position,Quaternion.identity) as GameObject;
            elmam.GetComponent<Obje>().item = dataitem.items[20];
        }
        for(int i = 0; i < odundegeri; i++)
        {
            GameObject odunum = Instantiate(odun, odunlarsp[i].position, Quaternion.identity) as GameObject;
            odunum.GetComponent<Obje>().item = dataitem.items[16];
        }
    }

    void Sil()
    {
        OdunlariCikar();
        Destroy(gameObject);
    }
}
