using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour {

    [SerializeField] GameObject TopText;
    [SerializeField] GameObject BottomText;
    [SerializeField] float defaultTime = 3;
    [SerializeField] float actualTime;
    [SerializeField] int defaultFontSize1 = 60;
    [SerializeField] int defaultFontSize2 = 60;
    bool textActivated = false;
    float timer = 0;
    

	// Use this for initialization
	void Start () {
        BottomText.SetActive(false);
        TopText.SetActive(false);
        actualTime = defaultTime;
        generateText("Kill", "it");


    }
	
	// Update is called once per frame
	void Update () {
        if (textActivated)
        {
            changeAlpha(timer);
            timer += Time.deltaTime;
            

            if(timer > actualTime)
            {
                DeactiveTexts();
            } 
        }
	}

    private void changeAlpha(float timer)
    {
        if(timer < 1)
        {
            Color newColor = TopText.GetComponent<Text>().color;
            TopText.GetComponent<Text>().color = new Color(newColor.r, newColor.g, newColor.b, timer);

            newColor = BottomText.GetComponent<Text>().color;
            BottomText.GetComponent<Text>().color = new Color(newColor.r, newColor.g, newColor.b, timer);
        }
        else if(timer >= actualTime - 1)
        {
            Color newColor = TopText.GetComponent<Text>().color;
            TopText.GetComponent<Text>().color = new Color(newColor.r, newColor.g, newColor.b, newColor.a - Time.deltaTime);

            newColor = BottomText.GetComponent<Text>().color;
            BottomText.GetComponent<Text>().color = new Color(newColor.r, newColor.g, newColor.b, newColor.a - Time.deltaTime);
        }
    }

    public void generateText(string text1)
    {
        DeactiveTexts();
        TopText.SetActive(true);
        TopText.GetComponent<Text>().text = text1.ToUpper();
        textActivated = true;
        timer = 0;        
    }

    public void generateText(string text1, float time)
    {
        generateText(text1);
        actualTime = time;
    }

    public void generateText(string text1, string text2)
    {
        generateText(text1);
        BottomText.SetActive(true);
        BottomText.GetComponent<Text>().text = text2.ToUpper();  
    }

    public void generateText(string text1, string text2, float time)
    {
        generateText(text1, text2);
        actualTime = time;
    }

    public void generateText(string text1, string text2, int fontSize1, int fontSize2)
    {
        generateText(text1, text2);
        TopText.GetComponent<Text>().fontSize = fontSize1;
        BottomText.GetComponent<Text>().fontSize = fontSize2;

    }

    void DeactiveTexts()
    {
        TopText.GetComponent<Text>().fontSize = defaultFontSize1;
        BottomText.GetComponent<Text>().fontSize = defaultFontSize2;
        TopText.SetActive(false);
        BottomText.SetActive(false);
        textActivated = false;
        actualTime = defaultTime;
        timer = 0;
    }
}
