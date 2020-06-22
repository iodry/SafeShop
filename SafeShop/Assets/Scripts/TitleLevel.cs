using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TextMeshProUGUI>().text = "LEVEL " + (SceneManager.GetActiveScene().buildIndex - 1) + " - LITTLE MARKET";
    }

}
