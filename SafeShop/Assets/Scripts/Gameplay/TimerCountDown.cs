﻿using TMPro;
using UnityEngine;

public class TimerCountDown : MonoBehaviour
{
    public float timeDuration = 2f;//To put as private or protected 
    public TextMeshProUGUI textBox;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        textBox.text = timeDuration.ToString();
        gameManager = GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        timeDuration -= Time.deltaTime;
        textBox.text = Mathf.Round(timeDuration).ToString();

        if(timeDuration < 0)
        {
                gameManager.TimeUpEndGame();           
        }
        
    }
}
