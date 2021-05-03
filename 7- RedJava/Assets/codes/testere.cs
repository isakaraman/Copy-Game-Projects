using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class testere : MonoBehaviour
{
    GameObject[] gidilecekNoktalar;
    bool aradakiMesafeBirKereAl = true;
    bool ilerimiGerimi;
    Vector3 aradakiMesafe;
    int aradakiMesafeSayaci = 0;
    
    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];
        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilecekNoktalar[i].transform.SetParent(transform.parent);
        }
        
    }
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount-1; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }
        
    }
#endif
    void FixedUpdate()
    {
        noktalaraGit();
        transform.Rotate(0, 0, 5);
    }
    
    void noktalaraGit()
    {
        if (aradakiMesafeBirKereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayaci].transform.position - transform.position).normalized;
            aradakiMesafeBirKereAl = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayaci].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime*10;
        if (mesafe<0.5f)
        {
            aradakiMesafeBirKereAl = true;
            if (aradakiMesafeSayaci==gidilecekNoktalar.Length-1)
            {
                ilerimiGerimi = false;

            }
            else if (aradakiMesafeSayaci==0)
            {
                ilerimiGerimi = true;
            }
            if (ilerimiGerimi)
            {
                aradakiMesafeSayaci++;
            }
            else
            {
                aradakiMesafeSayaci--;
            }
        }
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(testere))]
    [System.Serializable]
    class testereEditor: Editor
    {
        public override void OnInspectorGUI()
        {
            testere script = (testere)target;
            if (GUILayout.Button("EKLE"))
            {
                GameObject yeniObje = new GameObject("heyheyhey");
                yeniObje.transform.parent = script.transform;
                yeniObje.transform.position = script.transform.position;
                yeniObje.name = script.transform.childCount.ToString();
            }
        }
    }
#endif
}
