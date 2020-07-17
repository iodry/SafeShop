using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public Inventory inventory;
    //private Transform inventoryPan;
    public GameObject messagePanel ;
    public GameObject popUpPanel;
    public Button button;
    private Animator buttonAnimator;
    // Start is called before the first frame update
    void Start()
    {
        inventory.ItemAdded += InventoryScript_ItemAdded;
        messagePanel.GetComponent<Image>().DOFade(0, 0f);
        messagePanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, 0f);
        popUpPanel.GetComponent<Image>().DOFade(0, 0f);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, 0f);
        popUpPanel.GetComponentInChildren<Image>().DOFade(0, 0f);
        popUpPanel.transform.GetChild(0).GetComponent<Image>().DOFade(0, 0f);
        buttonAnimator = button.GetComponent<Animator>();
        //Transform inventoryPan = this.transform;
    }

    private void InventoryScript_ItemAdded(object sender, InventoryEventArgs e)
    {
       
        foreach (Transform slot in transform)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();
            if (!image.enabled)
            {
                image.enabled = true;
                image.sprite = e.Item.Image;
                break;
            }
        }
    }

    public void RemoveItemsUI()
    {
        foreach (Transform slot in transform)
        {
            Image image = slot.GetChild(0).GetComponent<Image>();
            if (image.enabled)
            {
                image.enabled = false;
                //break;
            }
        }
    }

    public void OpenMessagePanel(string textMessage)
    {
        messagePanel.GetComponentInChildren<TextMeshProUGUI>().text = textMessage;
        messagePanel.GetComponent<Image>().DOFade(1, .5f);
        messagePanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(1, .5f);
        buttonAnimator.SetTrigger("Highlighted");
        //button.Select();
        //messagePanel.SetActive(true);
    }
    public void CloseMessagePanel()
    {
        messagePanel.GetComponent<Image>().DOFade(0, .5f);
        messagePanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, .5f);
        buttonAnimator.SetTrigger("Normal");
        //messagePanel.SetActive(false);
    }

    public void PopUpPanel(string textMessage, float displayTime)
    {
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().text = textMessage;
        popUpPanel.transform.GetChild(0).GetComponent<Image>().enabled = false;
        //popUpPanel.transform.GetChild(0).GetComponent<Image>().sprite = null;
        //popUpPanel.transform.GetChild(0).GetComponent<Image>().DOFade(0, .5f);
        StartCoroutine(CoPopUp(displayTime, true));

    }

    public void PopUpPanel(string textMessage, float displayTime, Sprite sprite)
    {
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().text = textMessage;
        popUpPanel.transform.GetChild(0).GetComponent<Image>().sprite = sprite;
        StartCoroutine(CoPopUp(displayTime));
        

    }

    IEnumerator CoPopUp(float time)
    {
        if (popUpPanel.transform.GetChild(0).GetComponent<Image>().enabled == false)
        {
            popUpPanel.transform.GetChild(0).GetComponent<Image>().enabled = true;
        }
        //popUpPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 400f), 1f);
        popUpPanel.GetComponent<Image>().DOFade(1, .5f);
        popUpPanel.transform.GetChild(0).GetComponent<Image>().DOFade(1, .5f);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(1, .5f);
        popUpPanel.GetComponent<RectTransform>().DOScale(1.5f,.25f);
        yield return new WaitForSecondsRealtime(time);
        //popUpPanel.GetComponent<RectTransform>().DOAnchorPos(new Vector2(0f, 250f), 1f);
        popUpPanel.GetComponent<RectTransform>().DOScale(1f, .25f);
        popUpPanel.GetComponent<Image>().DOFade(0, .5f);
        popUpPanel.transform.GetChild(0).GetComponent<Image>().DOFade(0, .5f);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, .5f);
        //popUpPanel.transform.GetChild(0).GetComponent<Image>().sprite = null;
        //popUpPanel.transform.GetChild(0).GetComponent<Image>().;
    }

    IEnumerator CoPopUp(float time, bool spriteLoad)
    {
        popUpPanel.GetComponent<Image>().DOFade(1, .5f);
        //popUpPanel.transform.GetChild(0).GetComponent<Image>().DOFade(1, .5f);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(1, .5f);
        popUpPanel.GetComponent<RectTransform>().DOScale(1.5f, .25f);
        if(spriteLoad)
        {
            popUpPanel.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        else
        {
            popUpPanel.transform.GetChild(0).GetComponent<Image>().enabled = false;
        }
        yield return new WaitForSecondsRealtime(time);
        popUpPanel.GetComponent<RectTransform>().DOScale(1f, .25f);
        popUpPanel.GetComponent<Image>().DOFade(0, .5f);
        popUpPanel.GetComponentInChildren<TextMeshProUGUI>().DOFade(0, .5f);
    }
}
