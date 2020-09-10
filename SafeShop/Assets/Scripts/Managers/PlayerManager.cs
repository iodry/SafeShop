using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.ThirdPerson;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }
    #endregion

    public GameObject player;
    //public bool pickUpEvent = false;

    public void Die()
    {
        player.GetComponent<Animator>().SetBool("Die", true);

    }

    public void React()
    {
        player.GetComponent<Animator>().SetTrigger("React");
        AudioManager.instance.Play("Cough");
    }

    public void PickUp()
    {
        player.GetComponent<Animator>().SetTrigger("PickUp");
        AudioManager.instance.Play("Pickup");
    }


}
