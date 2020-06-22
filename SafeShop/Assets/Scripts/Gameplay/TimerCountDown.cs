using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerCountDown : MonoBehaviour
{
    public float timeDuration = 2f;//To put as private or protected 
    public TextMeshProUGUI textBox;
    public GameManager gameManager;
    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeDuration.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        timeDuration -= Time.deltaTime;
        textBox.text = Mathf.Round(timeDuration).ToString();

        if(timeDuration < 0)
        {
            //Debug.Log("TIME'S UP");

                gameManager.TimeUpEndGame();
            
        }
        
    }
}
