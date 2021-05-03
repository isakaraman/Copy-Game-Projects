using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public class maceKontrol : MonoBehaviour
{
    GameObject[] gidilecekNoktalar;
    GameObject karakter;

    bool aradakiMesafeBirKereAl = true;
    bool ilerimiGerimi;

    Vector3 aradakiMesafe;

    int aradakiMesafeSayaci = 0;
    int hiz = 5;

    RaycastHit2D ray;

    public LayerMask layermask;

    public Sprite GozAcik;
    public Sprite GozKapali;

    public GameObject kursun;

    SpriteRenderer spriteRendere;

    float atesZamani = 0;


    void Start()
    {
        gidilecekNoktalar = new GameObject[transform.childCount];

        for (int i = 0; i < gidilecekNoktalar.Length; i++)
        {
            gidilecekNoktalar[i] = transform.GetChild(0).gameObject;
            gidilecekNoktalar[i].transform.SetParent(transform.parent);
        }

        karakter = GameObject.FindGameObjectWithTag("Player");

        spriteRendere = GetComponent <SpriteRenderer>();

    }
#if UNITY_EDITOR
    void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.GetChild(i).transform.position, 1);
        }
        for (int i = 0; i < transform.childCount - 1; i++)
        {
            Gizmos.color = Color.black;
            Gizmos.DrawLine(transform.GetChild(i).transform.position, transform.GetChild(i + 1).transform.position);
        }

    }
#endif
    void FixedUpdate()
    {
        noktalaraGit();
        beniGorduMu();
        if (ray.collider.tag=="Player")
        {
            hiz = 8;
            spriteRendere.sprite = GozAcik;
            AtesEt();
            

        }
        else
        {
            hiz = 5;
            spriteRendere.sprite = GozKapali;
        }
        
    }

    void AtesEt()
    {
        atesZamani += Time.deltaTime;
        if (atesZamani>Random.Range(0.2f,1))
        {
            Instantiate(kursun, transform.position, Quaternion.identity);
            atesZamani = 0;
        }
    }

    void beniGorduMu()
    {
        Vector3 rayYonum = karakter.transform.position - transform.position;
        ray = Physics2D.Raycast(transform.position, rayYonum, 1000,layermask);
        Debug.DrawLine(transform.position, ray.point, Color.magenta);
    }
    void noktalaraGit()
    {
        if (aradakiMesafeBirKereAl)
        {
            aradakiMesafe = (gidilecekNoktalar[aradakiMesafeSayaci].transform.position - transform.position).normalized;
            aradakiMesafeBirKereAl = false;
        }
        float mesafe = Vector3.Distance(transform.position, gidilecekNoktalar[aradakiMesafeSayaci].transform.position);
        transform.position += aradakiMesafe * Time.deltaTime * hiz;
        if (mesafe < 0.5f)
        {
            aradakiMesafeBirKereAl = true;
            if (aradakiMesafeSayaci == gidilecekNoktalar.Length - 1)
            {
                ilerimiGerimi = false;

            }
            else if (aradakiMesafeSayaci == 0)
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

    public Vector2 getYon()
    {
        return (karakter.transform.position - transform.position).normalized;
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(maceKontrol))]
    [System.Serializable]
    class maceEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            maceKontrol script = (maceKontrol)target;
            if (GUILayout.Button("EKLE"))
            {
                GameObject yeniObje = new GameObject("heyheyhey");
                yeniObje.transform.parent = script.transform;
                yeniObje.transform.position = script.transform.position;
                yeniObje.name = script.transform.childCount.ToString();
            }
            EditorGUILayout.PropertyField(serializedObject.FindProperty("layermask"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("GozAcik"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("kursun"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("GozKapali"));
            serializedObject.ApplyModifiedProperties();
            serializedObject.Update();
        }
    }
#endif
}


