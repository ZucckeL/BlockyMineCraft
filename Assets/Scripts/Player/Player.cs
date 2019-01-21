using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;
public class Player : NetworkBehaviour {

    [SerializeField]
    private float maxHealth = 100f;
    [SerializeField]
	private float maxSu = 100f;
    [SerializeField]
	private float maxAclik = 100f;
    [SerializeField]
	private float maxStamina = 100f;
    public Image StaminaImage;
    public Image AclikImage;
    public Image SuImage;
    public Image HealthImage;
	public GameObject GOPanel;
    [SyncVar]
    public float currentHealth;
    [SyncVar]
	public float currentAclik, currentSu,currentStamina;
    public Slider Can,Aclik,Su,Stamina;

    public FirstPersonController FPS;
    void Awake()
    {
        SetDefaults();
    }
  
    void Update()
    {

        AclikDusmeHizi();
        SusuzlukDusmeHizi();
        CanDusmeHizi();
        StaminaDusmeHizi();
        Can.value = currentHealth;
        Su.value = currentSu;
        Aclik.value = currentAclik;
        Stamina.value = currentStamina;
        if(currentAclik < 1f || currentSu < 1f)
        {
            currentHealth = currentHealth - Time.deltaTime;
        }
		
		if (currentHealth <= 0f)
        {
            currentHealth = 0f;
			
				if(!isLocalPlayer){
				return;
					}else{
						//SceneManager.LoadScene("GameOver");
						NetworkManager.Destroy(gameObject);
						NetworkManager.singleton.ServerChangeScene("GameOver");
					}
				
			
        }
    }

    public void TakeDamage(float _amount)
    {
        currentHealth -= _amount;

        Debug.Log(transform.name + "now has " + currentHealth + " health.");
    }
    public void CanDusmeHizi()
    {
		if(currentAclik> 50f && currentSu > 50f && currentHealth > 0){
			currentHealth = currentHealth + Time.deltaTime;
		}
        if (currentHealth > 100f)
        {
            currentHealth = 100f;
        }

        if (currentHealth < 30f)
        {
            HealthImage.color = new Color(HealthImage.color.r, HealthImage.color.g, HealthImage.color.b, 0.7f);
        }
        else
        {
            HealthImage.color = new Color(HealthImage.color.r, HealthImage.color.g, HealthImage.color.b, 1f);
        }
    }
    public void AclikDusmeHizi()
    {
        currentAclik = currentAclik - (Time.deltaTime/2);
        if(currentAclik < 0f)
        {
            currentAclik = 0f;
        }
        if(currentAclik > 100f)
        {
            currentAclik = 100f;
        }

        if (currentAclik < 30f)
        {
            AclikImage.color = new Color(AclikImage.color.r, AclikImage.color.g, AclikImage.color.b, 0.7f);
        }
        else
        {
            AclikImage.color = new Color(AclikImage.color.r, AclikImage.color.g, AclikImage.color.b, 1f);
        }

    }

    public void SusuzlukDusmeHizi()
    {
        currentSu = currentSu - (Time.deltaTime);
        if(currentSu < 0f)
        {
            currentSu = 0f;
        }
        if(currentSu > 100f)
        {
            currentSu = 100f;
        }
        if (currentSu < 30f)
        {
            SuImage.color = new Color(SuImage.color.r, SuImage.color.g, SuImage.color.b, 0.7f);
        }
        else
        {
            SuImage.color = new Color(SuImage.color.r, SuImage.color.g, SuImage.color.b, 1f);
        }
    }

    public void StaminaDusmeHizi()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentStamina = currentStamina - Time.deltaTime * 10;
        }
        else
        {
            currentStamina = currentStamina + Time.deltaTime * 3;
        }
        if(currentStamina < 0f)
        {
            currentStamina = 0f;
            if(currentStamina == 0f)
            {
                FPS.m_RunSpeed = 4f;
                FPS.m_WalkSpeed = 2f;
            }
        }
        else if(currentStamina > 30f)
        {
            FPS.m_WalkSpeed = 5f;
            FPS.m_RunSpeed = 10f;
            StaminaImage.color = new Color(StaminaImage.color.r, StaminaImage.color.g, StaminaImage.color.b, 1f);
        }
        else if(currentStamina < 30f)
        {
            StaminaImage.color = new Color(StaminaImage.color.r, StaminaImage.color.g, StaminaImage.color.b, 0.7f);
            

        }

        if(currentStamina > 100f)
        {
            currentStamina = 100f;
        }
    }
    public void SetDefaults()
    {
        currentHealth = maxHealth;
        currentSu = maxSu;
        currentAclik = maxAclik;
        currentStamina = maxStamina;
    }
}
