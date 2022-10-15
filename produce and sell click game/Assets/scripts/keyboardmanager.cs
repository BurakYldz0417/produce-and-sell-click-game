using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class keyboardmanager : MonoBehaviour
{

    public TextMeshProUGUI scoretext2;
    public double curretscore2;
    public double hitpower2;
    public double scoreinscardpersecond2;
    public double x2;



    public int keyboardresmi = 16;

    //imageler
    public GameObject keyboardimage1;
    public GameObject keyboardimage2;
    public GameObject keyboardimage3;
    public GameObject keyboardimage4;

    public double selldeger2;
    public TextMeshProUGUI pricetext2;
    public double money;
    public TextMeshProUGUI moneytext;

    public double tutar2;

    public double autoprice2;
    public TextMeshProUGUI autopricetext2;

    public double buttonupgradeprice2;
    public TextMeshProUGUI buttonupgradetext2;

    public int allupgradefiyat2;
    public TextMeshProUGUI allupgradetext2;

    public TextMeshProUGUI netxleveltext;
    public int nextlevel2;

    public int levelbutonkontrol = 0;

    void Start()
    {
        curretscore2 = 0;
        hitpower2 = 1;
        scoreinscardpersecond2 = 1;
        x2 = 0f;
        autoprice2 = 600;
        buttonupgradeprice2 = 1200;
        allupgradefiyat2 = 3000;
        selldeger2 = 2;
        nextlevel2 = 2500;

        keyboardimage1.SetActive(false);
        keyboardimage2.SetActive(false);
        keyboardimage3.SetActive(false);
        keyboardimage4.SetActive(false);

        
        curretscore2 = PlayerPrefs.GetInt("curretscore2", 0);
        hitpower2 = PlayerPrefs.GetInt("hitpower2", 1);
        x2 = PlayerPrefs.GetInt("x2", 0);
        money = PlayerPrefs.GetInt("money", 0);
        tutar2 = PlayerPrefs.GetInt("tutar2", 0);
        selldeger2 = PlayerPrefs.GetInt("selldeger2", 1);
        autoprice2 = PlayerPrefs.GetInt("autoprice2", 100);
        buttonupgradeprice2 = PlayerPrefs.GetInt("butonupgradedeger2", 200);
        allupgradefiyat2 = PlayerPrefs.GetInt("allupgradedeger2", 500);
        nextlevel2 = PlayerPrefs.GetInt("nextlevel2", 2500);
        levelbutonkontrol = PlayerPrefs.GetInt("levelkontrol", 0);
    }


    void Update()
    {
        scoretext2.text = "Your keyboar Amount:" + (int)curretscore2;
        scoreinscardpersecond2 = x2 * Time.deltaTime;
        curretscore2 = curretscore2 + scoreinscardpersecond2;

        
        PlayerPrefs.SetInt("curretscore2", (int)curretscore2);
        PlayerPrefs.SetInt("hitpower2", (int)hitpower2);
        PlayerPrefs.SetInt("x2", (int)x2);
        PlayerPrefs.SetInt("money", (int)money);
        PlayerPrefs.SetInt("tutar2", (int)tutar2);
        PlayerPrefs.SetInt("selldeger2", (int)selldeger2);
        PlayerPrefs.SetInt("autoprice2", (int)autoprice2);
        PlayerPrefs.SetInt("butonupgradedeger2", (int)buttonupgradeprice2);
        PlayerPrefs.SetInt("allupgradedeger2", (int)allupgradefiyat2);
        PlayerPrefs.SetInt("nextlevel2", (int)nextlevel2);
        PlayerPrefs.SetInt("levelkontrol", (int)levelbutonkontrol);

        pricetext2.text = "Price:" + selldeger2 + "$";
        moneytext.text = "Your Money:" + (int)money + "$";
        autopricetext2.text = "Auto Bild Tier:" + autoprice2 + "$";
        buttonupgradetext2.text = "Button Upgrade Tier:" + buttonupgradeprice2 + "$";
        allupgradetext2.text = "Allupgrade Tier:" + allupgradefiyat2 + "$";
        netxleveltext.text = "Next Level Tier:" + nextlevel2 + "$";
        
        if (keyboardresmi % 4 == 1)
        {
            keyboardimage1.SetActive(true);
            keyboardimage2.SetActive(false);
            keyboardimage3.SetActive(false);
            keyboardimage4.SetActive(false);
        }
        else if (keyboardresmi % 4 == 2)
        {
            keyboardimage1.SetActive(true);
            keyboardimage2.SetActive(true);
            keyboardimage3.SetActive(false);
            keyboardimage4.SetActive(false);
        }
        else if (keyboardresmi % 4 == 3)
        {
            keyboardimage1.SetActive(true);
            keyboardimage2.SetActive(true);
            keyboardimage3.SetActive(true);
            keyboardimage4.SetActive(false);
        }
        else if (keyboardresmi % 4 == 0)
        {
            keyboardimage1.SetActive(true);
            keyboardimage2.SetActive(true);
            keyboardimage3.SetActive(true);
            keyboardimage4.SetActive(true);
        }
        if (levelbutonkontrol == 1)
        {
            Destroy(netxleveltext);
        }
    }
    public void Hit()
    {
        curretscore2 += hitpower2;
        keyboardresmi++;
    }
    public void sell()
    {
        money += (curretscore2 * selldeger2);
        curretscore2 = 0;
    }
    public void autoUpgrade()
    {

        if (money >= autoprice2)
        {
            money -= autoprice2;
            tutar2 += 2;
            x2 += 2;
            autoprice2 += 125;
        }
    }
    public void hitUpgrade()
    {
        if (money >= buttonupgradeprice2)
        {
            hitpower2 += 2;
            buttonupgradeprice2 *= 2;
            money -= buttonupgradeprice2;

        }
    }
    public void allupgradebutton()
    {
        if (money >= allupgradefiyat2)
        {
            money -= allupgradefiyat2;
            hitpower2 *= 2;
            x2 *= 2;
            tutar2 *= 2;
            allupgradefiyat2 *= 2;
        }
    }
    public void nextlevelbuton()
    {
        if (money >= nextlevel2)
        {
            money -= nextlevel2;
            levelbutonkontrol += 1;
            SceneManager.LoadScene(2);
           
        }
        else if (levelbutonkontrol == 1)
        {
            SceneManager.LoadScene(1);
            netxleveltext.text = "";
        }
    }
    public void prevlevelbuton()
    {
         SceneManager.LoadScene(0);
    }
}
