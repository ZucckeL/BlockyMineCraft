using UnityEngine;
using System.Collections;
using UnityEngine.Networking;
public class PlayerController : NetworkBehaviour
{
	
    [SyncVar]public GameObject chunckPrefab;
    public int viewRange = 30;
    int collumnHeight = 60;
	[SyncVar]
    public GameObject block;
    TreeGenerator tree = new TreeGenerator();
    private const string PLAYER_TAG = "Player";
    public GameObject BlockHighlight;
    El el; Envanter er; YanPanel yp;
    public LayerMask lm;
    DataItem dataitem;
    int gridSize = 1;
    Block map;
    Item item;
    Item itemdon;
    int tmp;
	public GameObject openSundriesPanel;
    void Start()
    {
        er = GameObject.FindGameObjectWithTag("Envanter").GetComponent<Envanter>();
        el = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<El>();
        yp = GameObject.FindGameObjectWithTag("YanPanel").GetComponent<YanPanel>();
        BlockHighlight = GameObject.FindGameObjectWithTag("CubeHighlight");
        dataitem = GameObject.FindGameObjectWithTag("DataItem").GetComponent<DataItem>();

    }
    
    bool once = true;
    void Update () 
    {
        tmp = Random.Range(2, 10);
        if (Mathf.FloorToInt(Time.time) % 5 == 0 && once)
        {
            for (float x = transform.position.x - viewRange; x < transform.position.x + viewRange; x += Chunck.Width * gridSize)
            {
                for (float z = transform.position.z - viewRange; z < transform.position.z + viewRange; z += Chunck.Width * gridSize)
                {
                    int xx = Mathf.FloorToInt(x / Chunck.Width) * Chunck.Width;
                    int zz = Mathf.FloorToInt(z / Chunck.Width) * Chunck.Width;

                    Chunck chunck = Chunck.GetChunck(Mathf.FloorToInt(xx), 0, Mathf.FloorToInt(zz));
                    if (chunck == null)
                    {
                        for (int y = 0; y < collumnHeight; y++)
                        {
                            int yr = (y * Chunck.Height)/*- (y)*/;
                            
                            for (int ix = 0; ix < gridSize; ix++)
                            {
                                for (int iz = 0; iz < gridSize; iz++)
                                {
                                    GameObject ch = Instantiate(chunckPrefab, new Vector3(xx + (Chunck.Width * ix), yr, zz + (Chunck.Width * iz)), Quaternion.identity);

                                    
                                }
                            }
                        }
                    }
                   
                }
            }
         
            once = false;
        }
        else
        {
            once = true;
        }
       
        BlockController();
		SundriesController();
        Chunck c = Chunck.GetChunck(10,90,10);
        if (c == null)
            return;
    }
	void SundriesController(){
		if(Chunck.Blockworking) return;

		RaycastHit hit;
		if(Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 7f, lm)){
			if(hit.transform.gameObject.tag == "Sundries"){
				if(Input.GetKeyDown(KeyCode.B)){
				openSundriesPanel.SetActive(true);
				}
			}else{
			openSundriesPanel.SetActive(false);
			}
			
		}
		if(Input.GetKeyDown(KeyCode.Escape)){
			openSundriesPanel.SetActive(false);
		}
	}

	public void TakeTNT(){
		er.itemEkle(5,1);
	}
	public void TakeOldSword(){
		er.itemEkle(13,1);
	}
	public void TakeTwoHandedSword(){
		er.itemEkle(14,1);
	}
	public void TakeSwordDagger(){
		er.itemEkle(12,1);
	}
	public void TakeTwoHandedAxe(){
		er.itemEkle(10,1);
	}
	public void TakeOneHandedAxe(){
		er.itemEkle(9,1);
	}
	public void TakeTwoHandedMace(){
		er.itemEkle(19,1);
	}
	public void TakeOldMace(){
		er.itemEkle(18,1);
	}
	public void TakeApple(){
		er.itemEkle(20,1);
	}
	public void TakeHammer(){
		er.itemEkle(4,1);
	}
	public void TakeOldDagger(){
		er.itemEkle(11,1);
	}
	public void TakeBarrier(){
		er.itemEkle(3,1);
	}
    void BlockController()
    {
        if (Chunck.Blockworking) return;

        RaycastHit hit;
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 7f, lm))
        {
            Vector3 p = hit.point - hit.normal/2;
            if (hit.transform.gameObject.tag != "Player")
            {
                if (hit.transform.gameObject.tag != "SpawnPoint")
                {
					if(hit.transform.gameObject.tag != "Sundries")
					{
                    BlockHighlight.transform.position = new Vector3(Mathf.Floor(p.x), Mathf.Floor(p.y), Mathf.Floor(p.z));

                    if (Input.GetMouseButtonDown(0))
                    {
                        if (er.items[yp.slotsayi].itemtipi == Item.ItemType.Malzeme && hit.transform.gameObject.tag != "Tree" && hit.collider.name != PLAYER_TAG)
                        {
						
                            SetBlock(p, null);

                        }
                    }
                    if (Input.GetMouseButtonDown(1))
                    {
                        p = hit.point + hit.normal / 2;

                        for (int i = 0; i < el.objeler.Count; i++)
                        {
                            if (el.objeler[i].name == er.items[yp.slotsayi].itemismi)
                            {
                                if (er.items[yp.slotsayi].itemtipi == Item.ItemType.Blocks)
                                {

                                    SetBlock(p, Block.getBlock(el.objeler[i].name));
                                    er.items[yp.slotsayi].itemmiktar--;
                                    if (er.items[yp.slotsayi].itemmiktar == 0)
                                    {
                                        er.items[yp.slotsayi] = new Item();
                                    }
                                }
                                else
                                {	
                                    return;
                                }
                            }
                        }
						}
                    }
                }
            }
            else
            {
                BlockHighlight.transform.position = new Vector3(0, -1000, 0);
            }
        }
    }

    void SetBlock(Vector3 p, Block b)
    {
        RaycastHit hit;
        int i = 0;
        
        Chunck chunck = Chunck.GetChunck(Mathf.FloorToInt(p.x), Mathf.FloorToInt(p.y), Mathf.FloorToInt(p.z));
        Vector3 localPos = chunck.transform.position - p;
        if (b == null)
        {
            map = chunck.GetBlock(p);
			
           if (map == null)
            { 
                map = Block.getBlock(BlockList.Blocks[tmp].BlockName);
            }
            item = GetItem(map);
            
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 7f, lm))
            {
                if (hit.transform.gameObject.tag != "Obje")
                {
                    if (hit.transform.gameObject.tag != "Tree")
                    {
                        if (hit.transform.gameObject.tag != "Player")
                        {
                            GameObject obje = Instantiate(Resources.Load<GameObject>(map.BlockName), BlockHighlight.transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity) as GameObject;
                            obje.GetComponent<Obje>().item = item;
                            Debug.Log("Obje = " + obje.transform.position + "Chunck Pos = " + chunck.transform.position + "P=" + p + "Local Pos=" + localPos);
                        }
                    }
                }
            }
        }
        map = null;
        if ((Mathf.FloorToInt(localPos.x) * -1) == (Chunck.Width))
        {
            Chunck c = Chunck.GetChunck(Mathf.FloorToInt(p.x + 5), Mathf.FloorToInt(p.y), Mathf.FloorToInt(p.z));
            if (c == null)
                return;
            
            c.SetBlock(p + new Vector3(+1, 0, 0), b);
        }
        else
        {
            Chunck c = Chunck.GetChunck(Mathf.FloorToInt(p.x - 5), Mathf.FloorToInt(p.y), Mathf.FloorToInt(p.z));
            if (c == null)
                return;
           
            c.SetBlock(p + new Vector3(+1, 0, 0), b);
        }

        chunck.SetBlock(p + new Vector3(+1, 0, 0), b);
    }

    public Item GetItem(Block b)
    {   
       
        for (int i = 0; i < dataitem.items.Count; i++)
        {
            if (dataitem.items[i].itemismi == b.BlockName)
            {
                itemdon = dataitem.items[i];
            }
            
        }
        if(itemdon == null)
        {
                itemdon = dataitem.items[0];
        }
        return itemdon;
    }

    

}
