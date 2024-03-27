using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ColorSwap : MonoBehaviour, IDropHandler
{
    //Ref. to the sprite that needs to change colors
    public GameObject Sprite, PrefabSpawn, ProverbBG;

    //textboxes
    public TMP_Text colorText, fortuneText;
    public Color color;

    //string getting passed to the textbox
    public string str;

    //string arrays for fortune, each has 3
    private string[] rDeck = {"You will be hungry again in one hour.", "You will conquer obstacles to achieve success.", "He who places a chicken on a hill may someday have eggrolls."};
    private string[] bDeck = {"It's better to be alone sometimes.", "You will live long enough to open many fortune cookies.", "Perfection makes perfect, Imperfection makes you."};
    private string[] yDeck = {"A smile is your passport into the hearts of others.", "You cannot love life until you live the life you love.", "Time is precious, but you have wasted most of it."};
    private string[] gDeck = {"Land is always on the mind of a flying bird.", "You must try, or hate yourself for not trying.", "Luck is coming your way - then it will pass you on the left."};
    private string[] oDeck = {"Joys are often the shadows, cast by sorrows.", "A conclusion is simply the place where you got tired of thinking.", "A diseased llama will spit in your sock drawer."};
    private string[] pDeck = {"Hard work pays off in the future, laziness pays off now.", "A smile is your passport into the hearts of others.", "You got a lame fortune cookie message."};

    //Ref. to this code
    public static ColorSwap instance;

    void Awake()
    {
        //make sure that textboxes don't show on awake
        colorText.enabled = false;

        ProverbBG.SetActive(false);
        fortuneText.enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        instance = this;

        color = Color.white;
        SwapColor(color);
    }
    
    public void OnDrop(PointerEventData edata)
    {
        int rand = Random.Range(0,2);

        //prevent the overlap
        if(transform.childCount == 0)
        {
            GameObject dropped = edata.pointerDrag;

            if(dropped.tag == "Red")
            {
                color = Color.red;
                SwapColor(color);

                //string is set to the random number within the set
                str = rDeck[rand];
            }
            else if(dropped.tag == "Blue")
            {
                color = Color.blue;
                SwapColor(color);

                str = bDeck[rand];
            }
            else if(dropped.tag == "Yellow")
            {
                color = Color.yellow;
                SwapColor(color);
                
                str = yDeck[rand];
            }
            else if(dropped.tag == "Green")
            {
                color = Color.green;
                SwapColor(color);

                str = gDeck[rand];
            }
            else if(dropped.tag == "Orange")
            {
                //had to make a custom rgb for orange because there is no default
                color = new Color(1.0f, 0.374343f, 0.0f);
                SwapColor(color);

                str = oDeck[rand];
            }
            else if(dropped.tag == "Purple")
            {
                color = Color.magenta;
                SwapColor(color);

                str = pDeck[rand];
            }
        }
    }

    //Function to change the colors
    public void SwapColor(Color swapToColor)
    {
        Sprite.GetComponent<SpriteRenderer>().color = swapToColor;
        PrefabSpawn.GetComponent<SpriteRenderer>().color = swapToColor;
        
        Debug.Log("The square is now " + swapToColor);

        //update the text as a HEX
        colorText.enabled = true;
        colorText.text = "Current Color is now: \n" +  "#" + ColorUtility.ToHtmlStringRGB(swapToColor);

        //match the text to color
        colorText.color = color;    
        fortuneText.color = color;
    }

    //show fortune
    public void showWords()
    {
        fortuneText.text = str;

        ProverbBG.SetActive(true);
        fortuneText.enabled = true;
    }

    //hide fortune
    public void hideWords()
    {
        new WaitForSeconds(30);

        ProverbBG.SetActive(false);
        fortuneText.enabled = false;
    }
}