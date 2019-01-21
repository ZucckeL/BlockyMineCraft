using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
public class BlockList : NetworkBehaviour
{	
    public static List<Block> Blocks = new List<Block>();
    int count = 0;
    public void Awake()
    {
        //Dirt Block
        Block dirt = new Block("Dirt", false, 0, 15,1);
        dirt.SetColor(Color.white, true);
        Blocks.Add(dirt);
        //Grass Block
        Blocks.Add(new Block("Grass", false, 0, 15, 3, 15, 2, 15,1));
        Blocks.Add(new Block("Stone", false, 1, 1,2));
        Blocks.Add(new Block("Barrier", false, 7, 15,10));
        Blocks.Add(new Block("TNT", false, 8, 15,1));
        Blocks.Add(new Block("Wood", false, 8, 9,2));
        Blocks.Add(new Block("Window", false, 1, 10,1));
        Blocks.Add(new Block("Sponge", false, 0, 12,1));
        Blocks.Add(new Block("Jail", false, 1, 11,2));
        Blocks.Add(new Block("Tree", false, 1, 6,2));

    }
   


    public static Block GetBlock(string Name)
    {
        foreach(Block b in Blocks)
        {
            if(b.BlockName == Name)
                return b;
        }
        return null;
    }
}
