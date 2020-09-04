using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubTitleLevel : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        int sceneNum = SceneManager.GetActiveScene().buildIndex - 1;
        if (sceneNum<7)
        {
            GetComponent<TextMeshProUGUI>().text = "Tiny Shop";
        }
        else if (sceneNum >= 7)
        {
            GetComponent<TextMeshProUGUI>().text = "New Color Store";
        }
        
    }

}
