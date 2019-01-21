using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EnvanterSlot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler,IPointerDownHandler{

   
    public Item item;
    public int slotsayi;
    Envanter er;

    public Image itemicon;
    public Text itemmiktar;
	public GameObject itemkullanim;
    void Start()
    {
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
    }
    void Update()
    {
        item = er.items[slotsayi];    
        if(item.itemismi != null)
        {
            itemicon.enabled = true;
            itemicon.sprite = item.itemicon;
            if(item.itemmiktar > 1)
            {
                itemmiktar.enabled = true;
                itemmiktar.text = item.itemmiktar.ToString();
            }
            else
            {
                itemmiktar.enabled = false;
            }
			if(item.itemkullanim <= 0){
				er.items[slotsayi] = new Item();
			}
            if(item.itemtipi == Item.ItemType.Malzeme){
				itemkullanim.SetActive(true);
				itemkullanim.transform.localScale = new Vector2(item.itemkullanim/100,1);
				if(item.itemkullanim > 75 ){
					itemkullanim.GetComponent<Image>().color = Color.green;
				}
				else if(item.itemkullanim > 25 && item.itemkullanim < 75){
					itemkullanim.GetComponent<Image>().color = Color.yellow;
				}
				else if(item.itemkullanim > 0 && item.itemkullanim < 25){
					itemkullanim.GetComponent<Image>().color = Color.red;
				}
			}else{
				itemkullanim.SetActive(false);
			}
        }
        else
        {
            itemicon.enabled = false;
            itemmiktar.enabled = false;
			itemkullanim.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData data)
    {   if(item.itemismi != null) { er.bilgipanelAc(item); }
        
    }

    public void OnPointerDown(PointerEventData data)
    {
      if(data.button.ToString() == "Left")
        {
            if(!er.tasimaacik && item.itemismi != null)
            {
                er.tasimapanelAc(item);
                er.items[slotsayi] = new Item();
            } else if(er.tasimaacik)
            {
                if(item.itemismi == null)
                {
                    er.items[slotsayi] = er.tasinanitem;
                    er.tasimapanelKapat();
                }
                else
                {
                    if(item.itemismi == er.tasinanitem.itemismi)
                    {   if (item.itemtipi == Item.ItemType.Yiyecek || item.itemtipi == Item.ItemType.Malzeme || item.itemtipi == Item.ItemType.Blocks)
                        {
                            er.items[slotsayi].itemmiktar += er.tasinanitem.itemmiktar;
                            er.tasimapanelKapat();
                        }
                    }
                    else
                    {
                        Item yeniItem = er.items[slotsayi];
                        er.items[slotsayi] = er.tasinanitem;
                        er.tasinanitem = yeniItem;
                    }
                }
                
            }
        }

      if(data.button.ToString() == "Right")
        {
            if (!er.tasimaacik)
            {
                if(item.itemtipi == Item.ItemType.Yiyecek || item.itemtipi == Item.ItemType.Malzeme || item.itemtipi == Item.ItemType.Blocks)
                {
                    if(item.itemmiktar > 1)
                    {
                        int deger = item.itemmiktar / 2;
                        Item yeniItem = new Item(item.itemismi, item.itembilgi, item.itemid, deger, item.itemdepomiktar, item.itemdamage, item.itemkullanim, item.itemtipi);
                        er.tasimapanelAc(yeniItem);
                        int deger2 = item.itemmiktar - deger;
                        er.items[slotsayi].itemmiktar = deger2;
                    }
                }
            }
        }
    }

    public void OnPointerExit(PointerEventData data)
    {
        er.bilgipanelKapat();
    }

    
}
