using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecontrol : MonoBehaviour
{
    public GameObject Astroid;
    public Vector3 randomPos;
    public float baslangicBekleme;
    public float olusturmaBekleme;
    public float donguBekleme;

    void Start()
    {

        StartCoroutine(Olustur());
    }
    IEnumerator Olustur()
    {
        while (true)
        {

            yield return new WaitForSeconds(baslangicBekleme);
            for (int i = 0; i <= 10; i++)
            {
                Vector3 vec = new Vector3(Random.Range(-randomPos.x, randomPos.x), 0, randomPos.z);
                Instantiate(Astroid, vec, Quaternion.identity);
                yield return new WaitForSeconds(olusturmaBekleme);
            }
            yield return new WaitForSeconds(donguBekleme);
        }
        }
    public void oyunBitti()
    {

    }
}
