using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class karakterkontrol : MonoBehaviour
{
    float horizontal = 0;
    float vertical = 0;
    float headRotationUpDown=0;
    float headRotationLeftRight = 0;
   

    Animator animator;
    Rigidbody fizik;
    Vector3 cameraDistance;
    RaycastHit hit;
    RaycastHit hitAtes;
    GameObject kamera, poz1, poz2;
    
    public GameObject headCamera;
    public GameObject nisangah;
    public Vector3 offset;
    public RuntimeAnimatorController atesEdildiginde;
    public RuntimeAnimatorController atesEdilmediginde;
    public GameObject kursun;
    public Transform kursununYeri;
    public GameObject[] kursunHavuzu;
    public float hiz = 0;

    bool atesKontrol = false;

    Transform iskelet = null;



    
    
    void Start()
    {
        //ANİMATORA ULAŞMA
        animator = GetComponent<Animator>();

        //RİGİDBODY YE ULAŞMA
        fizik = GetComponent<Rigidbody>();

        cameraDistance = headCamera.transform.position - transform.position;

        kamera = Camera.main.gameObject;
        poz1 = headCamera.transform.Find("Pose1").gameObject;
        poz2 = headCamera.transform.Find("Pose2").gameObject;

        iskelet = animator.GetBoneTransform(HumanBodyBones.Chest);
    }
    public void LateUpdate()
    {
        if (atesKontrol)
        {
            if (hitAtes.distance>3)
            {
            iskelet.LookAt(hitAtes.point);
            iskelet.rotation = iskelet.rotation * Quaternion.Euler(offset);
            }

        }
        
    }
    private void Update()
    {

        //KOŞMA VE ANİMASYONU
        if (Input.GetKeyDown(KeyCode.Space))
        {
            
            animator.SetBool("JumpParam", true);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (!atesKontrol)
            {
                hiz /= 2;
            }
            
            animator.SetBool("RunParam", true);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            hiz /= 2;
            animator.SetBool("RunParam", false);
        }
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            nisangah.SetActive(true);
            atesKontrol = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse1))
        {
            nisangah.SetActive(false);
            atesKontrol = false;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameObject kursunObj=Instantiate(kursun, kursununYeri.position, kursununYeri.transform.rotation);
            kursunObj.GetComponent<Rigidbody>().AddForce((hitAtes.point - kursununYeri.transform.position).normalized * 1000);
            animator.SetBool("FireParam", true);
        }
        else if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("FireParam", false);
        }
    }
    void FixedUpdate()
    {
        Hareket();
        if (!atesKontrol)
        {
            animator.runtimeAnimatorController = atesEdilmediginde;
            kamera.transform.position = Vector3.Lerp(kamera.transform.position, poz1.transform.position, 0.1f);
            rotation();
        }
        else
        {
            animator.runtimeAnimatorController = atesEdildiginde;
            kamera.transform.position = Vector3.Lerp(kamera.transform.position, poz2.transform.position, 0.1f);
            rotation2();
        }
        rotation();

        //KARAKTER YÜRÜTMEYİ ANİMATORE ATAMA
        animator.SetFloat("Horizontal", horizontal);
        animator.SetFloat("Vertical", vertical);
    }
    void KursunHavuzu()
    {
        kursunHavuzu = new GameObject[20];

        for (int i = 0; i < kursunHavuzu.Length; i++)
        {
            GameObject kursunObj = Instantiate(kursun);
            kursun.SetActive(false);
            kursunHavuzu[i] = kursunObj;
        }
    }
    void Hareket()
    {
        //KARAKTER YÜRÜTME
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        Vector3 vec = new Vector3(horizontal, 0, vertical);

        //KARAKTER NEREYE DÖNERSE ORAYA HAREKET ETMESİ İÇİN GEREKEN KOD
        vec = transform.TransformDirection(vec);
        vec.Normalize();
        fizik.position += vec * Time.fixedDeltaTime * hiz;
    }

    void rotation()
    {
        rotationCode();

        if (horizontal != 0 || vertical != 0)
        {
            Physics.Raycast(Vector3.zero, headCamera.transform.GetChild(0).forward, out hit);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z)), 0.4f);
           // Debug.DrawLine(Vector3.zero, hit.point);
        }

    }
    void rotation2()
    {

        rotationCode();
        
            Physics.Raycast(Vector3.zero, headCamera.transform.GetChild(0).forward, out hit);
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.LookRotation(new Vector3(hit.point.x, 0, hit.point.z)), 0.4f);
            //Debug.DrawLine(Vector3.zero, hit.point);


        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f));
        Physics.Raycast(ray,out hitAtes);
        Debug.DrawLine(ray.origin,hitAtes.point);


    }
    void rotationCode()
    {
        //KAMERAYI KARAKTERE ATAMA
        headCamera.transform.position = transform.position + cameraDistance;

        //KAMERAYI MAUSLA KONTROL ETMEK
        headRotationUpDown += Input.GetAxis("Mouse Y") * Time.fixedDeltaTime * -150;
        headRotationLeftRight += Input.GetAxis("Mouse X") * Time.fixedDeltaTime * 150;

        //KAMERA SINIRLARINI BELİRLEME
        headRotationUpDown = Mathf.Clamp(headRotationUpDown, -20, 20);
        headCamera.transform.rotation = Quaternion.Euler(headRotationUpDown, headRotationLeftRight, transform.eulerAngles.z);
    }
    

    void JumpParamStop()
    {
        animator.SetBool("JumpParam", false);
    }
    void JumpAddForce()
    {
        fizik.AddForce(0, Time.deltaTime * 15000, 0);
    }

}
