using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Konsol : NetworkBehaviour {
    public InputField isim, miktar, mesaj;
    public Envanter er;
    public DataItem di;
    public int sayi;
	// Use this for initialization
	void Start () {
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        di = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            if(isim.text != "" && miktar.text != "")
            {
                int miktarim = int.Parse(miktar.text);
                Ekle(isim.text,miktarim);
                isim.text = "";
                miktar.text = "";
            }
        }
	}
    void Ekle(string itemismi,int itemmiktari)
    {
        sayi++;
        for(int i = 0;i < di.items.Count; i++)
        {
            if(itemismi == di.items[i].itemismi)
            {
                er.itemEkle(di.items[i].itemid, itemmiktari);
            }
        }
        if(sayi < 5)
        {
            mesaj.text += "\n"+itemmiktari+" Tane "+itemismi+ " Eklendi. ";
        }
        else
        {
            mesaj.text = "";
            mesaj.text += "\n" + itemmiktari + " Tane " + itemismi + " Eklendi. ";
        }
    }
}
