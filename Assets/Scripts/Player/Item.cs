using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Item {

    public string itemismi, itembilgi;
    public int itemid, itemmiktar, itemdepomiktar,itemdamage;
    public float itemkullanim;
    public Sprite itemicon;
    public GameObject itemmodel;
    public ItemType itemtipi;

    public enum ItemType {
        Blocks,
        Malzeme,
        Yiyecek,
        Bos

    }
    public Item(string isim,string bilgi,int id,int miktar,int depo,int damage,float kullanim,ItemType tip)
    {
        itemismi = isim;
        itembilgi = bilgi;
        itemid = id;
        itemmiktar = miktar;
        itemdepomiktar = depo;
        itemdamage = damage;
        itemkullanim = kullanim;
        itemtipi = tip;
        itemicon = Resources.Load<Sprite>(id.ToString());
        itemmodel = Resources.Load<GameObject>(isim);
    }
    public Item()
    {

    }
}
