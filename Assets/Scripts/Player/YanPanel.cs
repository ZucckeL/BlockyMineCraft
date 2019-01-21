using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class YanPanel : NetworkBehaviour {
	[SerializeField]
    public List<GameObject> slotlar;
	[SerializeField]	
    public int slotsayi;
	[SerializeField]
    public Sprite seciliSlot, bosSlot;
    [SerializeField]
	Envanter er; 
	El el;
	void Start () {
		
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
    }
	

	void Update () {
        if(!isLocalPlayer){
            iconBelirle();
            slotsayiBelirle();
            itemSec(er.items[slotsayi]);
        }
		else if(isClient){
			iconBelirle();
            slotsayiBelirle();
            itemSec(er.items[slotsayi]);
		}
	}
    public int slotsayiBelirle()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            slotsayi = 0;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            slotsayi = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            slotsayi = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            slotsayi = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            slotsayi = 4;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            slotsayi = 5;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            slotsayi = 6;
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            slotsayi = 7;
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            slotsayi = 8;
        }
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            slotsayi = 9;
        }
        return slotsayi;
    }

    void iconBelirle()
    {
        for(int i = 0;i < slotlar.Count; i++)
        {
            slotlar[i].GetComponent<Image>().sprite = bosSlot;
        }
        slotlar[slotsayi].GetComponent<Image>().sprite = seciliSlot;
    }
   public int itemSec(Item item)
    {
        int i;
        for(i = 0; i < el.objeler.Count; i++)
        {
           if(el.objeler[i].name == item.itemismi)
            {
                el.objeler[i].SetActive(true);
                el.objeler[i].GetComponent<ItemEl>().slotsayi = slotsayi;
            }
            else
            {
                el.objeler[i].SetActive(false);
            }
            
        }
        return i;
    }
}
