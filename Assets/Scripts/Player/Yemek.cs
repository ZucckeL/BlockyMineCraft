using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Yemek : MonoBehaviour {
    public float aclik1, aclik2;
    public float su1, su2;
   public El el; public Envanter er; public YanPanel yp;
	// Use this for initialization
	void Start () {
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
        yp = GameObject.FindGameObjectWithTag("YanPanel").GetComponent<YanPanel>();
    }
	
	// Update is called once per frame
	void Update () {
		 
        if (Input.GetMouseButtonDown(1))
        {
            transform.root.gameObject.GetComponent<Player>().currentAclik += Random.Range(aclik1, aclik2);
            transform.root.gameObject.GetComponent<Player>().currentSu += Random.Range(su1, su2);
           for (int i = 0; i < el.objeler.Count; i++)
                        {
                            if (el.objeler[i].name == er.items[yp.slotsayi].itemismi)
                            {
								if(er.items[yp.slotsayi].itemtipi == Item.ItemType.Yiyecek){
									 er.items[yp.slotsayi].itemmiktar--;
                                    if (er.items[yp.slotsayi].itemmiktar == 0)
                                    {
                                        er.items[yp.slotsayi] = new Item();
                                    }
																							}
                            }
                        }
        }
	}
}
