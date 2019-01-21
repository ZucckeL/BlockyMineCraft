using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class DataItem : NetworkBehaviour {

    public List<Item> items;
    Item itemdon;
    void Awake()
    {
        items.Add(new Item("","",0,0,0,0,0, Item.ItemType.Bos));
        items.Add(new Item("Dirt", "5 Dirt ile Barrier\nElde Edebilirsin.", 1, 1, 6,0,1, Item.ItemType.Blocks));
        items.Add(new Item("Stone", "5 Stone ile Barrier\n Elde Edebilirsin.", 2, 1, 6,0,1, Item.ItemType.Blocks));
        items.Add(new Item("Barrier", "Barrier ile Kendi\n Alanının Çevresini\n Koruyabilirsin.", 3, 1, 6,0, 3, Item.ItemType.Blocks));
        items.Add(new Item("Hammer", "Hammer ile Block\nKırabilirsiniz.", 4, 1, 5, 2, 100, Item.ItemType.Malzeme));
        items.Add(new Item("TNT", "TNT ile Düşmana\nciddi hasarlar\nverebilirsiniz.", 5, 1, 6,30, 1, Item.ItemType.Blocks));
        items.Add(new Item("Window", "Window ile kendinize\npencere yapabilirsiniz.", 6, 1, 6, 0, 1, Item.ItemType.Blocks));
        items.Add(new Item("Sponge", "Sponge ile suları\nçekebilirsiniz..", 7, 1, 6, 0, 1, Item.ItemType.Blocks));
        items.Add(new Item("Jail", "Jail ile suları\nçekebilirsiniz..", 8, 1, 6, 0, 1, Item.ItemType.Blocks));
        items.Add(new Item("One-Handed Axe", "Axe ile düşmana\nhasar verebilirsiniz.", 9, 1, 6, 10, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Two-Handed Axe", "Axe ile düşmana\nhasar verebilirsiniz.", 10, 1, 6, 20, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Old Dagger", "Dagger ile düşmana\nhasar verebilirsiniz.", 11, 1, 6, 5, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Sword Dagger", "Dagger ile düşmana\nhasar verebilirsiniz.", 12, 1, 6, 15, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Old Sword", "Sword ile düşmana\nhasar verebilirsiniz.", 13, 1, 6, 10, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Two-Handed Sword", "Sword ile düşmana\nhasar verebilirsiniz.", 14, 1, 6, 20, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Grass", "Grass ile çimen\n yapabilirsiniz.", 15, 1, 6, 0, 1, Item.ItemType.Blocks));
        items.Add(new Item("Wood", "Wood ile Agac\n yapabilirsiniz.", 16, 1, 6, 0, 1, Item.ItemType.Blocks));
        items.Add(new Item("Tree", "Tree ile Agac\n yapabilirsiniz.", 17, 1, 6, 0, 1, Item.ItemType.Blocks));
        items.Add(new Item("Old Mace", "Mace ile düşmana\nhasar verebilirsiniz.", 18, 1, 6, 20, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Two-Handed Mace", "Mace ile düşmana\nhasar verebilirsiniz.", 19, 1, 6, 30, 100, Item.ItemType.Malzeme));
        items.Add(new Item("Elma", "Elma ile aclik \nve susuzluğunuz\ngiderilebilir.", 20, 1, 6, 0, 1, Item.ItemType.Yiyecek));
    }

   
}
