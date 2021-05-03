using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class anamenukontrol : MonoBehaviour
{


    GameObject bolumler,kilitler,acikKilit;
    void Start()
    {
 

        bolumler = GameObject.Find("bolumlerr");
        kilitler = GameObject.Find("kilitlerr");

        

        for (int i = 0; i < bolumler.transform.childCount; i++)
        {
            bolumler.transform.GetChild(i).gameObject.SetActive(false);
        }
        for (int i = 0; i < kilitler.transform.childCount; i++)
        {
            kilitler.transform.GetChild(i).gameObject.SetActive(false);
        }



        //PlayerPrefs.DeleteAll();


        for (int i = 0; i < PlayerPrefs.GetInt("kacincibolum"); i++)
        {
            bolumler.transform.GetChild(i).GetComponent<Button>().interactable = true;
        }
    }

    public void butonSec(int numara)
    {
        if (numara==1)
        {
            SceneManager.LoadScene(1);
        }
        else if (numara == 2)
        {
            for (int i = 0; i < kilitler.transform.childCount; i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(true);
            }
            
            for (int i = 0; i < bolumler.transform.childCount; i++)
            {
                bolumler.transform.GetChild(i).gameObject.SetActive(true);
            }


            for (int i = 0; i < PlayerPrefs.GetInt("kacincibolum"); i++)
            {
                kilitler.transform.GetChild(i).gameObject.SetActive(false);

            }



        }
        else if (numara == 3)
        {
            Application.Quit();
        }
    }
    public void bolumlerButton(int gelenBolum)
    {
        SceneManager.LoadScene(gelenBolum);
    }
}
