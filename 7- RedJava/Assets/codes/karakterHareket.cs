using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class karakterHareket : MonoBehaviour
{
    Rigidbody2D fizik;

    SpriteRenderer spriterenderer;

    public Sprite[] bekleme;
    public Sprite[] yurume;
    public Sprite[] ziplama;
    public Text canText;
    public Text altinText;
    public Image GecisArkaPlan;
    


    float horizontal = 0;
    float beklemeZamani = 2;
    float yurumeZamani = 0;
    float GecisArkaPlanSayac = 0;
    float anaMenuDonZaman = 0;

    Vector3 vec;
    Vector3 kameraIlk;
    Vector3 kameraSon;

    bool birKereZipla = true;

    int beklemeSayac = 0;
    int yurumeSayac = 0;
    int can = 100;
    int altinsayisi = 0;
    


    GameObject kamera;

    void Start()
    {
        Time.timeScale = 1;
        fizik = GetComponent<Rigidbody2D>();

        spriterenderer = GetComponent<SpriteRenderer>();

        kamera = GameObject.FindGameObjectWithTag("MainCamera");
        kameraIlk = kamera.transform.position - transform.position;
        
        canText.text = "CAN: " + can;
        
        if (SceneManager.GetActiveScene().buildIndex>PlayerPrefs.GetInt("kacincibolum"))
        {
         PlayerPrefs.SetInt("kacincibolum", SceneManager.GetActiveScene().buildIndex);
        }

        
        
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (birKereZipla)
            {
                fizik.AddForce(new Vector2(0, 600));
                birKereZipla = false;
            }

        }
    }

    void FixedUpdate()
    {
        karakterhareket();
        animasyon();

        if (can<=0)
        {
            Time.timeScale = 0.3f;
            canText.enabled = false;
            GecisArkaPlanSayac += 0.03f;
            GecisArkaPlan.color = new Color(0, 0, 0, GecisArkaPlanSayac);
            anaMenuDonZaman += Time.deltaTime;
            if (anaMenuDonZaman>1)
            {
                SceneManager.LoadScene("anamenu");
            }
        }
    }
    
    void LateUpdate()
    {
        kameraKontrol();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        birKereZipla = true;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag=="pupil")
        {
            can--;
            canText.text = "CAN: " + can;
        }
        if (col.gameObject.tag == "mace")
        {
            can -= 10;
            canText.text = "CAN: " + can;
        }
        if (col.gameObject.tag == "saw")
        {
            can -= 10;
            canText.text = "CAN: " + can;
        }
        if (col.gameObject.tag=="bolumsonu")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        if (col.gameObject.tag == "can kutusu")
        {
            if (can<100)
            {
            can += 10;
            canText.text = "CAN: " + can;
            col.GetComponent<BoxCollider2D>().enabled = false;
            col.GetComponent<canver>().enabled = true;
            Destroy(col.gameObject, 3);
            }
            
        }
        if (col.gameObject.tag == "altın")
        {
            altinsayisi++;
            altinText.text = "30 - " + altinsayisi;
            Destroy(col.gameObject);
        }
        if (col.gameObject.tag=="su")
        {
            can = 0;
        }

    }

    void karakterhareket()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vec = new Vector3(horizontal * 10, fizik.velocity.y, 0);
        fizik.velocity = vec;
    }

    void animasyon()
    {
        if (birKereZipla)
        {
            if (horizontal == 0)
            {
                beklemeZamani += Time.deltaTime;
                if (beklemeZamani > 0.05f)
                {
                    spriterenderer.sprite = bekleme[beklemeSayac++];
                    if (beklemeSayac == bekleme.Length)
                    {
                        beklemeSayac = 0;
                    }
                    beklemeZamani = 0;
                }

            }

            else if (horizontal > 0)
            {
                yurumeZamani += Time.deltaTime;
                if (yurumeZamani > 0.01f)
                {
                    spriterenderer.sprite = yurume[yurumeSayac++];
                    if (yurumeSayac == yurume.Length)
                    {
                        yurumeSayac = 0;
                    }
                    yurumeZamani = 0;
                }
                transform.localScale = new Vector3(1, 1, 1);


            }
            else if (horizontal < 0)
            {
                yurumeZamani += Time.deltaTime;
                if (yurumeZamani > 0.01f)
                {
                    spriterenderer.sprite = yurume[yurumeSayac++];
                    if (yurumeSayac == yurume.Length)
                    {
                        yurumeSayac = 0;
                    }
                    yurumeZamani = 0;
                }
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else
        {
            if (fizik.velocity.y > 0)
            {
                spriterenderer.sprite = ziplama[0];

            }
            else
            {
                spriterenderer.sprite = ziplama[1];
                if (horizontal > 0)
                {
                    transform.localScale = new Vector3(1, 1, 1);
                }
                else if(horizontal < 0)
                {
                    transform.localScale = new Vector3(-1, 1, 1);
                }
            }

        }
    }

    void kameraKontrol()
    {
        kameraSon = kameraIlk + transform.position;
        kamera.transform.position = Vector3.Lerp(kamera.transform.position, kameraSon, 0.1f);
    }
}

