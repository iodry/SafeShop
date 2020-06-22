using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public Image[] life;
    public Image maskLife;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Update UI for life
        for (int i = 0; i < life.Length; i++)
        {
            if(i<currentHealth)
            {
                life[i].enabled = true;
            }
            else
            {
                life[i].enabled = false;
            }
        }

        if(currentHealth<=0)
        {
            PlayerManager.instance.Die();
            GetComponent<GameManager>().Invoke("EndGame", 0.5f);//EndGame();
        }
    }

    public void DamagePlayer(int damage)
    {
        currentHealth -= damage;
        PlayerManager.instance.React();
    }
    public void HealPlayer(int healValue)
    {
        currentHealth += healValue;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
