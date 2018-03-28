using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;


public class PlayerHealth : NetworkBehaviour {
	public const float m_StartingHealth = 100f;               
    public Slider m_Slider;                             
    public Image m_FillImage;                           
    public Color m_FullHealthColor = Color.green;       
    public Color m_ZeroHealthColor = Color.red;         
    public GameObject m_ExplosionPrefab;                
    
   // private AudioSource m_ExplosionAudio;               
    private ParticleSystem m_ExplosionParticles;        
    [SyncVar (hook = "onChangeHealth")]
    private float m_CurrentHealth = m_StartingHealth;                      
    private bool m_Dead;                                


    private void Awake ()
    {
        
        m_ExplosionParticles = Instantiate (m_ExplosionPrefab).GetComponent<ParticleSystem> ();
        m_ExplosionParticles.gameObject.SetActive (false);
    }


    private void OnEnable()
    {
        m_Dead = false;
        InitHealthUI();
    }


    public void TakeDamage (float amount)
    {
       if(!isServer){
	
			return;
	
		}

        m_CurrentHealth -= amount;

        
        if (m_CurrentHealth <= 0f && !m_Dead)
        {
            RpcOnDeath ();
        }
    }

    void onChangeHealth(float m_CurrentHealth) {
        m_Slider.value = m_CurrentHealth;
        m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor, m_CurrentHealth / m_StartingHealth);
    }
    
    private void InitHealthUI ()
     {
         m_Slider.value = m_CurrentHealth;

         m_FillImage.color = Color.Lerp (m_ZeroHealthColor, m_FullHealthColor,  m_CurrentHealth);
     }


[ClientRpc]
    private void RpcOnDeath ()
    {
        m_Dead = true;
        m_ExplosionParticles.transform.position = transform.position;
        m_ExplosionParticles.gameObject.SetActive (true);
        m_ExplosionParticles.Play ();
        gameObject.SetActive (false);
    }
}


