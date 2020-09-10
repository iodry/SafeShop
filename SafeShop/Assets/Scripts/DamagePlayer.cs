using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class DamagePlayer : MonoBehaviour
{
    public int damage = 1;

    private void OnTriggerEnter(Collider other)
    {
      if(other.tag=="Player")
        {
            FindObjectOfType<HealthManager>().DamagePlayer(damage);
            GetComponent<ThirdPersonCharacter>().Cough();
        }
    }
}
