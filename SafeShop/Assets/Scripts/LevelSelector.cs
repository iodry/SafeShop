using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class LevelSelector : MonoBehaviour
{
    public GameObject levelHolder;
    public GameObject levelIcon;
    public GameObject thisCanvas;
    public int numberOfLevels = 50;
    public Vector2 iconSpacing;
    public Sprite lockLevelSprite;
    public Sprite fullStar;
    public Sprite emptyStar;
    [HideInInspector] public LevelData levelData;

    private Rect panelDimensions;
    private Rect iconDimensions;
    private int amountPerPage;
    private int currentLevelCount;

    // Start is called before the first frame update
    void Start()
    {
        numberOfLevels = SceneManager.sceneCountInBuildSettings - 2;
        levelData = GameManager.instance.levelData;

        panelDimensions = levelHolder.GetComponent<RectTransform>().rect;
        iconDimensions = levelIcon.GetComponent<RectTransform>().rect;
        int maxInARow = Mathf.FloorToInt((panelDimensions.width + iconSpacing.x) / (iconDimensions.width + iconSpacing.x));
        int maxInACol = Mathf.FloorToInt((panelDimensions.height + iconSpacing.y) / (iconDimensions.height + iconSpacing.y));
        amountPerPage = maxInARow * maxInACol;
        int totalPages = Mathf.CeilToInt((float)numberOfLevels / amountPerPage);
        LoadPanels(totalPages);
    }
    void LoadPanels(int numberOfPanels)
    {
        GameObject panelClone = Instantiate(levelHolder) as GameObject;
        PageSwiper swiper = levelHolder.AddComponent<PageSwiper>();
        swiper.totalPages = numberOfPanels;

        for (int i = 1; i <= numberOfPanels; i++)
        {
            GameObject panel = Instantiate(panelClone) as GameObject;
            panel.transform.SetParent(thisCanvas.transform, false);
            panel.transform.SetParent(levelHolder.transform);
            panel.name = "Page-" + i;
            panel.GetComponent<RectTransform>().localPosition = new Vector2(panelDimensions.width * (i - 1), 0);
            SetUpGrid(panel);
            int numberOfIcons = i == numberOfPanels ? numberOfLevels - currentLevelCount : amountPerPage;
            LoadIcons(numberOfIcons, panel);
        }
        Destroy(panelClone);
    }
    void SetUpGrid(GameObject panel)
    {
        GridLayoutGroup grid = panel.AddComponent<GridLayoutGroup>();
        grid.cellSize = new Vector2(iconDimensions.width, iconDimensions.height);
        grid.childAlignment = TextAnchor.MiddleCenter;
        grid.spacing = iconSpacing;
    }
    void LoadIcons(int numberOfIcons, GameObject parentObject)
    {
        for (int i = 1; i <= numberOfIcons; i++)
        {
            currentLevelCount++;
            GameObject icon = Instantiate(levelIcon) as GameObject;
            icon.transform.SetParent(thisCanvas.transform, false);
            icon.transform.SetParent(parentObject.transform);
            icon.name = "Level " + i;
            //check lock levels
            //Debug.Log("LevelAt:" + levelData.levelAt);
            if (i<levelData.levelAt)
            {
                int levelIndex = i+1;
                icon.GetComponentInChildren<TextMeshProUGUI>().SetText("" + currentLevelCount);
                icon.GetComponent<Button>().onClick.AddListener(()=>GameManager.instance.LoadLevel(levelIndex, true));
                //Debug.Log("currentLevelCount=" + currentLevelCount);
                //Function check star nb
                int countCheck = 0;
                //Debug.Log("Count=" +i+"  "+ icon.transform.GetComponentsInChildren<Image>().Length);
                for (int a = 0; a < icon.transform.GetComponentsInChildren<Image>().Length-1; a++)
                {
                    //Debug.Log("Child" + a + "=" + icon.transform.GetComponentsInChildren<Image>()[a].name+ icon.transform.GetComponentsInChildren<Image>()[a].sprite);
                    if (countCheck<levelData.levelScores[i+1])
                    {
                        countCheck++;
                        if (icon.transform.GetChild(a + 1)!=null)
                        {
                         icon.transform.GetChild(a + 1).GetComponent<Image>().sprite = fullStar;
                        }
                        
                    }
                    else
                    {
                        if (icon.transform.GetChild(a + 1) != null)
                        {
                            icon.transform.GetChild(a + 1).GetComponent<Image>().sprite = emptyStar;
                        }
                    }
                }
            }
            else
            {
                icon.GetComponentInChildren<TextMeshProUGUI>().SetText("");
                icon.GetComponent<Button>().GetComponent<Image>().sprite = lockLevelSprite;
                icon.GetComponent<Button>().interactable = false;
                for (int a = 0; a < icon.transform.childCount; a++)
                {
                    if (icon.transform.GetChild(a).GetComponent<Image>() != null)
                    {
                        icon.transform.GetChild(a).GetComponent<Image>().enabled = false;
                    }
                }

            }
           
        }
    }

/*    public void LoadLevel(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
        Debug.Log("delegate" + levelIndex);
    }*/
    // Update is called once per frame
    void Update()
    {

    }
}