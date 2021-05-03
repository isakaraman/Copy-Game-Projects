using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class oyunyoneticisikod : MonoBehaviour
{
    GameObject donenCember;
    GameObject AnaCember;
    public Animator animator;
    public Text DonenCemberLeveli;
    public Text bir;
    public Text iki;
    public Text uc;
    public int kactanekucukcemberolsun;
    bool kontrol = true;
    void Start()
    {
        PlayerPrefs.SetInt("kayit",int.Parse(SceneManager.GetActiveScene().name));
        
        donenCember = GameObject.FindGameObjectWithTag("donencembertag");
        AnaCember = GameObject.FindGameObjectWithTag("anacembertag");
        DonenCemberLeveli.text = SceneManager.GetActiveScene().name;

        if (kactanekucukcemberolsun<2)
        {
            bir.text = kactanekucukcemberolsun+"";
        }
        else if (kactanekucukcemberolsun<3)
        {
            iki.text = (kactanekucukcemberolsun-1) + "";
        }
        else 
        {
            bir.text = kactanekucukcemberolsun + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";
            uc.text = (kactanekucukcemberolsun - 2) + "";
        }

    }
    public void KucukCemberlerdeTextGosterme()
    {
        kactanekucukcemberolsun--;
        if (kactanekucukcemberolsun < 2)
        {
            bir.text = kactanekucukcemberolsun + "";
            iki.text = "";
            uc.text = "";
        }
        else if (kactanekucukcemberolsun < 3)
        {
            bir.text = kactanekucukcemberolsun + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";
            uc.text = "";
        }
        else
        {
            bir.text = kactanekucukcemberolsun + "";
            iki.text = (kactanekucukcemberolsun - 1) + "";
            uc.text = (kactanekucukcemberolsun - 2) + "";
        }
        if (kactanekucukcemberolsun==0)
        {
            StartCoroutine(yeniLevel());
        }
    }
    IEnumerator yeniLevel()
    {
        donenCember.GetComponent<dondurme>().enabled = false;
        AnaCember.GetComponent<anacember>().enabled = false;
        yield return new WaitForSeconds(1);
        if (kontrol)
        {
            animator.SetTrigger("yenilevel");
            yield return new WaitForSeconds(2);
            SceneManager.LoadScene(int.Parse(SceneManager.GetActiveScene().name) + 1);
        }
        
        
    }
    public void oyunBitti()
    {
        StartCoroutine(cagrilan());
    }
    IEnumerator cagrilan()
    {
        donenCember.GetComponent<dondurme>().enabled = false;
        AnaCember.GetComponent<anacember>().enabled = false;
        animator.SetTrigger("oyunbitti");
        kontrol = false;
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene("ana menu");
    }
}