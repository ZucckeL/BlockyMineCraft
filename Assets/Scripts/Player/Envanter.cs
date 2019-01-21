using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class Envanter : NetworkBehaviour {
    public List<Item> items;
    public int baslangicmiktar,slotmiktar;
    public GameObject slot,bilgiPanel,tasimaPanel;
    public bool bilgiacik,tasimaacik;

    DataItem dataitem;

    public Item bilgiitem,tasinanitem;
    void Start()
    {
        
        dataitem = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();
        for (int i = baslangicmiktar; i < slotmiktar; i++)
        {
            GameObject slotobj = (GameObject)Instantiate(slot);
            slotobj.transform.SetParent(gameObject.transform);
            slotobj.GetComponent<RectTransform>().localScale = new Vector2(1, 1);
            slotobj.GetComponent<EnvanterSlot>().slotsayi = i;
            items.Add(new Item());
        }
        for(int i = 0; i < slotmiktar; i++)
        {
            items.Add(new Item());
        }
        itemEkle(18, 1);
        itemEkle(19, 1);
        itemEkle(18, 1);

        itemEkle(1,2);
        itemEkle(2,3);
        itemEkle(1,2);
        itemEkle(1,2);
        itemEkle(4, 1);
        itemEkle(3, 2);
        itemEkle(5, 10);
        itemEkle(6, 2);
        itemEkle(7, 2);
        itemEkle(8, 2);
        itemEkle(9, 1);
        itemEkle(10, 1);
        itemEkle(11, 1);
        itemEkle(12, 1);
        itemEkle(13, 1);
        itemEkle(14, 1);
        itemEkle(15, 2);
        itemEkle(16, 2);
        itemEkle(17, 5);
		itemEkle(20,2);

    }

    public void itemEkle(int id,int miktar)
    {
        for(int i = 0;i < dataitem.items.Count; i++)
        {
            if(dataitem.items[i].itemid == id)
            {
                Item yeniitem = new Item(dataitem.items[i].itemismi, dataitem.items[i].itembilgi, dataitem.items[i].itemid,
                                miktar, dataitem.items[i].itemdepomiktar, dataitem.items[i].itemdamage, dataitem.items[i].itemkullanim, dataitem.items[i].itemtipi);

                if(yeniitem.itemtipi == Item.ItemType.Yiyecek || yeniitem.itemtipi == Item.ItemType.Malzeme || yeniitem.itemtipi == Item.ItemType.Blocks)
                {
                    SlotunUzerineEkle(yeniitem);
                }
                else if(yeniitem.itemmiktar > 1)
                {
                    int deger = yeniitem.itemmiktar - 1;
                    Item yeniItem2 = new Item(yeniitem.itemismi, yeniitem.itembilgi, yeniitem.itemid,
                                deger, yeniitem.itemdepomiktar, yeniitem.itemdamage, yeniitem.itemkullanim, yeniitem.itemtipi);
                    yeniitem.itemmiktar = 1;
                    SlotunUzerineEkle(yeniitem);
                    itemEkle(yeniItem2.itemid, yeniItem2.itemmiktar);
                }
                else
                {
                    BosSlotitemEkle(yeniitem);
                }
               
            }
        }
    }

    public void BosSlotitemEkle(Item item)
    {
        for (int i = 0;i < items.Count; i++){
            if(items[i].itemismi == null)
            {
                items[i] = item;
                break;
            }
        }
    }

    public void SlotunUzerineEkle(Item item)
    {
       
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].itemismi == item.itemismi)
                {
                if (item.itemtipi != Item.ItemType.Malzeme)
                {
                    items[i].itemmiktar += item.itemmiktar;
                    break;
                }
                }
                if (i == items.Count - 1)
                {
                    BosSlotitemEkle(item);

                }
            }
        
    }

    public void bilgipanelAc(Item item)
    {
        bilgiacik = true;
        bilgiitem = item;
        bilgiPanel.SetActive(true);
    }
    public void bilgipanelKapat()
    {
        bilgiacik = false;
        bilgiitem = null;
        bilgiPanel.SetActive(false);
    }

    public void tasimapanelAc(Item item)
    {
        tasimaacik = true;
        tasinanitem = item;
        tasimaPanel.SetActive(true);
    }
    public void tasimapanelKapat()
    {
        tasimaacik = false;
        tasinanitem = null;
        tasimaPanel.SetActive(false);
    }


    void Update()
    {
        if (bilgiacik)
        {
            bilgiPanel.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            bilgiPanel.transform.GetChild(0).gameObject.GetComponent<Text>().text = bilgiitem.itemismi;
            bilgiPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = bilgiitem.itembilgi;

        }
        if (tasimaacik)
        {   
            tasimaPanel.transform.GetChild(0).gameObject.GetComponent<Image>().sprite = tasinanitem.itemicon;
            tasimaPanel.GetComponent<RectTransform>().position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            if(tasinanitem.itemmiktar > 1)
            {
                tasimaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = true;
                tasimaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().text = tasinanitem.itemmiktar.ToString();
            }
            else
            {
                tasimaPanel.transform.GetChild(1).gameObject.GetComponent<Text>().enabled = false;
            }
        }
    }
}
