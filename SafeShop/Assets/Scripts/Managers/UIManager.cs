using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    // Start is called before the first frame update
    public RectTransform levelComplete, gameOver, timesUp;
    public RectTransform settingsPan;
    public RectTransform achievementPan;
    public RectTransform shopPan;
    public RectTransform menuPan;
    public RectTransform pausePan;

    public Transform miniMap;
    public Transform startPan;

    public Camera miniMapCam;
    public Transform starLevelPan;
    public Sprite starYellow;
    public Transform mapPlaceHolder;

    public GameObject loadingPan;
    public Slider loadingSlider;
    public TextMeshProUGUI loadingText;

    //Position of each panel
    private Vector2 posSettingPan; //= new Vector2(-2000, 0);
    private Vector2 posAchievementPan;//= new Vector2(2000, 0);
    private Vector2 posMenuPan;//= new Vector2(0, 1200);
    private Vector2 posShopPan;//= new Vector2(0, -1200);
    private Vector2 posPausePan;
    private Vector2 shopPanPos;
    private Vector2 posMiniMap;
    private bool touchedToStart = false;

    private void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex <= 1)
        {
        }
        else if (SceneManager.GetActiveScene().name == "Credits")
        {
        }
        else
        {
            miniMap.GetComponent<RectTransform>().DOAnchorPos(new Vector2(1600f, 500f), 0);
            miniMap.GetComponent<RectTransform>().DOSizeDelta(new Vector2(500f, 500f), 0);
            miniMap.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(480f, 480f), 0);
            //miniMap.position = Vector3.zero;
            miniMapCam.DOOrthoSize(12f, 0);
            startPan.parent.gameObject.SetActive(true);
            startPan.GetComponent<Image>().DOFade(0f, 0f).SetUpdate(true);
            touchedToStart = false;
            miniMap.position = new Vector2(-350f, -160f);
        }

    }
    void Start()
    {
        
        //ShowMenu();
        //Debug.Log(SceneManager.GetActiveScene().buildIndex);
        if (SceneManager.GetActiveScene().buildIndex==0)
        {
           // menuPan.sizeDelta = new Vector2(menuPan.sizeDelta.x, menuPan.GetComponentInParent<RectTransform>().sizeDelta.y+50f);
            posSettingPan = settingsPan.anchoredPosition;
            posAchievementPan = achievementPan.anchoredPosition;
            posMenuPan = menuPan.anchoredPosition;
            posShopPan = shopPan.anchoredPosition;
            ShowMenu();
        }
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
        }
        else if (SceneManager.GetActiveScene().name == "Credits")
        {
            Debug.Log("Credits");
            posSettingPan = settingsPan.anchoredPosition;
            posAchievementPan = achievementPan.anchoredPosition;
            posMenuPan = menuPan.anchoredPosition;
            posShopPan = shopPan.anchoredPosition;

            ShowMenu();
        }
        else
        {
            //Debug.Log("Scene=" + SceneManager.GetActiveScene().buildIndex);
            if (pausePan!=null)
            {
                posPausePan = pausePan.anchoredPosition;
                startPan.GetComponent<Image>().DOFade(1f, 1f).SetUpdate(true);
                Time.timeScale = 0f;
            }


        }

    }


    //For automatic start of level, use Nested Coroutines StartCoroutine(CRstartLevelFadeIn());
    //If using touch.Input to start level, set timeScale to 0 in Awake or Start function.
   /* IEnumerator CRstartLevel()
    {
        Time.timeScale = 0f;
        yield return new WaitForSecondsRealtime(1f);

        startPan.GetComponent<Image>().DOFade(0f, 1f).SetUpdate(true);
        for (int i = 0; i < startPan.childCount; i++)
        {
            if (startPan.GetChild(i).GetComponent<TextMeshProUGUI>() != null)
            {
                startPan.GetChild(i).GetComponent<TextMeshProUGUI>().DOFade(0f, 2f).SetUpdate(true);
            }
            else if (startPan.GetChild(i).GetComponent<Image>() != null)
            {
                startPan.GetChild(i).GetComponent<Image>().DOFade(0f, 1f).SetUpdate(true);
            }

        }

        miniMap.GetComponent<RectTransform>().DOSizeDelta(new Vector2(240f, 240f), .5f);
        miniMap.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(230f, 230f), 0.5f);
        //miniMap.position = Vector3.zero;
        miniMapCam.DOOrthoSize(5f, .5f);

    }*/
/*    IEnumerator CRstartLevelFadeIn()
    {

        StartCoroutine(CRstartLevel());
        miniMap.GetComponent<RectTransform>().DOAnchorPos(posMiniMap, 1f);//new Vector2(-350f, -160f)
        miniMap.parent = mapPlaceHolder;
        yield return new WaitForSecondsRealtime(2f);
        Debug.Log("co2");
        startPan.gameObject.SetActive(false);
        Time.timeScale = 1f;


    }*/

    //If using input.touch to start level
    IEnumerator StartLevel()
    {
        startPan.GetComponent<Image>().DOFade(0f, 1f).SetUpdate(true);
        for (int i = 0; i < startPan.childCount; i++)
        {
            if (startPan.GetChild(i).GetComponent<TextMeshProUGUI>() != null)
            {
                startPan.GetChild(i).GetComponent<TextMeshProUGUI>().DOFade(0f, 2f).SetUpdate(true);
            }
            else if (startPan.GetChild(i).GetComponent<Image>() != null)
            {
                startPan.GetChild(i).GetComponent<Image>().DOFade(0f, 1f).SetUpdate(true);
            }
        }
        //Debug.Log("co2");
        miniMap.GetComponent<RectTransform>().DOSizeDelta(new Vector2(240f, 240f), .5f).SetUpdate(true);
        miniMap.GetChild(0).GetComponent<RectTransform>().DOSizeDelta(new Vector2(230f, 230f), 0.5f).SetUpdate(true);
        //miniMap.position = Vector3.zero;
        miniMapCam.DOOrthoSize(5f, .5f).SetUpdate(true);
        miniMap.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 0f), 1f).SetUpdate(true);
        miniMap.SetParent(mapPlaceHolder); //parent = mapPlaceHolder;
        yield return new WaitForSecondsRealtime(1f);
        startPan.parent.gameObject.SetActive(false);


        Time.timeScale = 1f;

        



    }

    // Update is called once per frame
    void Update()
    {
        //Check first input.touch (or mouse click down) to start level
        if (SceneManager.GetActiveScene().buildIndex > 1)
        {
            if (!touchedToStart)
            {
                if (Input.touchCount > 0 | Input.GetMouseButtonDown(0))
                {
                    StartCoroutine(StartLevel());
                    touchedToStart = true;
                }

            }
        }

    }

    //To communize Function with rectransfom in parameter
    public void ShowGameOver()
    {
        gameOver.DOAnchorPos(Vector2.zero, .5f);
    }

    public void ShowTimesUp()
    {
        timesUp.DOAnchorPos(Vector2.zero, .5f);
    }

    public void ShowPauseMenu()
    {
        //Debug.Log("Pause");
        Time.timeScale = 0f;
        pausePan.DOAnchorPos(Vector2.zero, .2f).SetUpdate(true);
    }
    public void HidePauseMenu()
    {
        pausePan.DOAnchorPos(posPausePan, .2f).SetUpdate(true);//posPausePan
        Time.timeScale = 1f;
    }

    public void ShowLevelComplete()
    {
        levelComplete.DOAnchorPos(Vector2.zero, .5f).SetUpdate(true);
    }

    public void ShowSettings()
    {
        settingsPan.DOAnchorPos(Vector2.zero, .5f).SetUpdate(true);
    }

    public void ShowShop()
    {
        shopPan.DOAnchorPos(Vector2.zero, .5f);
    }

    public void ShowAchievements()
    {
        achievementPan.DOAnchorPos(Vector2.zero, .5f);
    }
    public void ShowMenu()
    {
        //Debug.Log("Menu called");
        menuPan.DOAnchorPos(new Vector2(0,0), .5f);
    }

    public void ShowMenuBack(RectTransform currentPan)
    {
        Vector2 vec = new Vector2(0, 1200) ;
        if (currentPan==settingsPan)
        {
            vec = posSettingPan;
        }
        else if(currentPan == achievementPan)
        {
            vec = posAchievementPan;
        }
        else if (currentPan == shopPan)
        {
            vec = posShopPan;
        }
        else if (currentPan==menuPan)
        {
            vec = posMenuPan;
        }
/*        else if (currentPan == pausePan)
        {
            vec = posPausePan;
        }*/

        currentPan.DOAnchorPos(vec, .5f);
        menuPan.DOAnchorPos(Vector2.zero, .5f);
    }

    public void ShowStarLevel(int star)
    {
        if (star == 0)
        {

        }
        else if (star == 1)
        {
            starLevelPan.GetChild(1).GetComponent<Image>().sprite = starYellow;
        }
        else if (star == 2)
        {
            starLevelPan.GetChild(2).GetComponent<Image>().sprite = starYellow;
            starLevelPan.GetChild(1).GetComponent<Image>().sprite = starYellow;

        }
        else if (star == 3)
        {
            starLevelPan.GetChild(2).GetComponent<Image>().sprite = starYellow;
            starLevelPan.GetChild(1).GetComponent<Image>().sprite = starYellow;
            starLevelPan.GetChild(0).GetComponent<Image>().sprite = starYellow;
        }
    }

    public void ShowShoppingCard(RectTransform shopPan)
    {
        shopPanPos = shopPan.anchoredPosition;
        shopPan.DOAnchorPos(new Vector2(0, 0), .5f);
    }
    public void HideShoppingCard(RectTransform shopPan)
    {
        shopPan.DOAnchorPos(shopPanPos, .5f);
    }

    public void ShowLoadingScreen()
    {
        loadingPan.SetActive(true);
    }
}
