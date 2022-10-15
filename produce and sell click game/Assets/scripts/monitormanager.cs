using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class monitormanager : MonoBehaviour
{
    public TextMeshProUGUI scoretext1;
    public double curretscore1;
    public double hitpower1;
    public double scoreinscardpersecond1;
    public double x1;



    public int mouseresmi = 16;

    //imageler
    public GameObject monitorimage1;
    public GameObject monitorimage2;
    public GameObject monitorimage3;
    public GameObject monitorimage4;

    public double selldeger1;
    public TextMeshProUGUI pricetext1;
    public double money;
    public TextMeshProUGUI moneytext1;

    public double tutar1;

    public double autoprice1;
    public TextMeshProUGUI autopricetext1;

    public double buttonupgradeprice1;
    public TextMeshProUGUI buttonupgradetext1;

    public int allupgradefiyat1;
    public TextMeshProUGUI allupgradetext1;

    public TextMeshProUGUI netxleveltext;
    public int nextlevel1;


    public int levelbutonkontrol = 0;

    void Start()
    {
        curretscore1 = 0;
        hitpower1 = 1;
        scoreinscardpersecond1 = 1;
        x1 = 0f;
        autoprice1 = 900;
        buttonupgradeprice1 = 1800;
        allupgradefiyat1 = 4500;
        selldeger1 = 3;
        nextlevel1 = 5500;

        monitorimage1.SetActive(false);
        monitorimage2.SetActive(false);
        monitorimage3.SetActive(false);
        monitorimage4.SetActive(false);


        curretscore1 = PlayerPrefs.GetInt("curretscore1", 0);
        hitpower1 = PlayerPrefs.GetInt("hitpower1", 1);
        x1 = PlayerPrefs.GetInt("x1", 0);
        money = PlayerPrefs.GetInt("money1", 0);
        tutar1 = PlayerPrefs.GetInt("tutar1", 0);
        selldeger1 = PlayerPrefs.GetInt("selldeger1", 1);
        autoprice1 = PlayerPrefs.GetInt("autoprice1", 100);
        buttonupgradeprice1 = PlayerPrefs.GetInt("butonupgradedeger1", 200);
        allupgradefiyat1 = PlayerPrefs.GetInt("allupgradedeger1", 500);
        nextlevel1 = PlayerPrefs.GetInt("nextlevel1", 2500);
        levelbutonkontrol = PlayerPrefs.GetInt("levelkontrol", 0);
    }


    void Update()
    {
        scoretext1.text = "Your Mouse Amount:" + (int)curretscore1;
        scoreinscardpersecond1 = x1 * Time.deltaTime;
        curretscore1 = curretscore1 + scoreinscardpersecond1;

        PlayerPrefs.SetInt("curretscore1", (int)curretscore1);
        PlayerPrefs.SetInt("hitpower1", (int)hitpower1);
        PlayerPrefs.SetInt("x1", (int)x1);
        PlayerPrefs.SetInt("money1", (int)money);
        PlayerPrefs.SetInt("tutar1", (int)tutar1);
        PlayerPrefs.SetInt("selldeger1", (int)selldeger1);
        PlayerPrefs.SetInt("autoprice1", (int)autoprice1);
        PlayerPrefs.SetInt("butonupgradedeger1", (int)buttonupgradeprice1);
        PlayerPrefs.SetInt("allupgradedeger1", (int)allupgradefiyat1);
        PlayerPrefs.SetInt("nextlevel", (int)nextlevel1);
        PlayerPrefs.SetInt("levelkontrol", (int)levelbutonkontrol);

        pricetext1.text = "Price:" + selldeger1 + "$";
        moneytext1.text = "Your Money:" + (int)money + "$";
        autopricetext1.text = "Auto Bild Tier:" + autoprice1 + "$";
        buttonupgradetext1.text = "Button Upgrade Tier:" + buttonupgradeprice1 + "$";
        allupgradetext1.text = "Allupgrade Tier:" + allupgradefiyat1 + "$";
        netxleveltext.text = "Next Level Tier:" + nextlevel1 + "$";

        if (mouseresmi % 4 == 1)
        {
            monitorimage1.SetActive(true);
            monitorimage2.SetActive(false);
            monitorimage3.SetActive(false);
            monitorimage4.SetActive(false);
        }
        else if (mouseresmi % 4 == 2)
        {
            monitorimage1.SetActive(true);
            monitorimage2.SetActive(true);
            monitorimage3.SetActive(false);
            monitorimage4.SetActive(false);
        }
        else if (mouseresmi % 4 == 3)
        {
            monitorimage1.SetActive(true);
            monitorimage2.SetActive(true);
            monitorimage3.SetActive(true);
            monitorimage4.SetActive(false);
        }
        else if (mouseresmi % 4 == 0)
        {
            monitorimage1.SetActive(true);
            monitorimage2.SetActive(true);
            monitorimage3.SetActive(true);
            monitorimage4.SetActive(true);
        }

        if (levelbutonkontrol == 1)
        {
            Destroy(netxleveltext);
        }
    }
    public void Hit()
    {
        curretscore1 += hitpower1;
        mouseresmi++;
    }
    public void sell()
    {
        money += (curretscore1 * selldeger1);
        curretscore1 = 0;
    }
    public void autoUpgrade()
    {

        if (money >= autoprice1)
        {
            money -= autoprice1;
            tutar1 += 3;
            x1 += 3;
            autoprice1 += 250;
        }
    }
    public void hitUpgrade()
    {
        if (money >= buttonupgradeprice1)
        {
            hitpower1 += 3;
            buttonupgradeprice1 *= 2;
            money -= buttonupgradeprice1;
        }
    }
    public void allupgradebutton()
    {
        if (money >= allupgradefiyat1)
        {
            money -= allupgradefiyat1;
            hitpower1 *= 2;
            x1 *= 2;
            tutar1 *= 2;
            allupgradefiyat1 *= 2;
        }
    }
    public void nextlevelbuton()
    {
        if (money >= nextlevel1)
        {
            SceneManager.LoadScene(2);
            money -= nextlevel1;
            SceneManager.LoadScene(1);
        }
        else if (levelbutonkontrol == 1)
        {
            SceneManager.LoadScene(1);
        }
    }
}
