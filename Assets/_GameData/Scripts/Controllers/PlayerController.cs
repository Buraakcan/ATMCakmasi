using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool oyunDevam;
    public float zSpeed;
    public float yatayInput;
    public float xSpeed;
    public List<GameObject> moneyList;
    //public GameObject[] moneyArray;
    public GameObject Para;
    public Joystick joystick;
    public float zamanCarpani;
    public int sonDalga;


    private void Start()
    {
        oyunDevam = true;
        GameObject uretilen = Instantiate(Para, Vector3.zero, Quaternion.identity);
        //uretilen.GetComponent<Rigidbody>().AddForce(Vector3.forward*100);
        //deger = Mathf.Clamp(transform.position.x,-2.5f,2.5f);
    }
    private void Update()
    {
        ParaTakipEt();
        if (oyunDevam)
            //transform.Translate(0, 0, zSpeed * Time.deltaTime);
            transform.position += new Vector3(0, 0, zSpeed);

        if (InputManager.instance.direction.x > 0)
        {
            if (transform.position.x + InputManager.instance.direction.x > 2.5f)
            {
                transform.position = new Vector3(2.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(InputManager.instance.direction.x * InputManager.instance.Sensitivity, y: 0, 0);
            }
        }
        if (InputManager.instance.direction.x < 0)
        {
            if (transform.position.x + InputManager.instance.direction.x < -2.5f)
            {
                transform.position = new Vector3(-2.5f, transform.position.y, transform.position.z);
            }
            else
            {
                transform.position += new Vector3(InputManager.instance.direction.x * InputManager.instance.Sensitivity, 0, 0);
            }
        }

    }


    private void JoystickControl()
    {
        yatayInput = joystick.Horizontal;
        if (yatayInput != 0)
        {
            if (yatayInput > 0)// sað ok yada d basýldýðýnda 
            {
                if (transform.position.x < 2.50f) // platform dýþýný çýkmamak için sað limit
                {
                    transform.position += new Vector3(xSpeed, 0, 0);
                }
            }
            else if (yatayInput < 0)
            {
                if (transform.position.x > -2.50f) // platform dýþýný çýkmamak için sol limit
                {
                    transform.position -= new Vector3(xSpeed, 0, 0);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            print("Oyun Finish");
            oyunDevam = false;
        }
    }
    public void ParaAlma(GameObject gameObject)

    {
        if (!moneyList.Contains(gameObject))
        {
            moneyList.Add(gameObject);
            gameObject.GetComponent<Money>().isCollected = true;
            sonDalga = moneyList.Count - 1;
            MeksikaDalgasi();
            //gameObject.transform.SetParent(this.transform);
        }
    }
    public void MeksikaDalgasi()
    {
        if (sonDalga >= 0)
        {
            StartCoroutine(Scale(moneyList[sonDalga].transform, 0.033f));
        }
    }

    public IEnumerator Scale(Transform obje, float saniye)
    {
        float alpha = 0;
        Vector3 baslangicDegeri = new Vector3(0.5f, 0.5f, 0.5f);
        Vector3 finalDegeri = baslangicDegeri * 1.5f;
        while (alpha < 1)
        {
            alpha = Mathf.Min(1.0f, alpha + (Time.deltaTime / saniye));
            obje.localScale = Vector3.Lerp(baslangicDegeri, finalDegeri, alpha);
            yield return null;
        }



        float alpha2 = 0;
        Vector3 baslangicDegeri2 = obje.localScale;
        Vector3 finalDegeri2 = baslangicDegeri;
        while (alpha2 < 1)
        {
            alpha2 = Mathf.Min(1.0f, alpha2 + (Time.deltaTime / saniye * 5));
            obje.localScale = Vector3.Lerp(baslangicDegeri2, finalDegeri2, alpha2);
            yield return null;
        }
        sonDalga--;
        MeksikaDalgasi();

    }

    //private IEnumerator TemplateCoroutine()  // (Corotiune methodu ) belli bir süre içinde  baðýmsýz bir lerp yapma 
    //{
    //    WaitForEndOfFrame frame = new WaitForEndOfFrame();
    //    float alpha = 0.0f;
    //    float duration = 1.0f;
    //    baslangic
    //    final
    //    while (alpha < 1.0f)
    //    {
    //        alpha = Mathf.Min(1.0f, alpha + (Time.deltaTime / duration));
    //        transform.position = Vector3.Lerp(baslangic,sonuc,alpha);
    //        yield return frame;
    //    }
    //}

    public void ParaTakipEt()
    {
        int sayac = 0;
        foreach (GameObject money in moneyList)   //var nedir aðam? variable (deðiþken)
        {
            money.transform.position = new Vector3(money.transform.position.x, money.transform.position.y, transform.position.z + 1 + (sayac * 0.5f));

            Vector3 varisNoktasi;
            if (sayac == 0)
            {
                varisNoktasi = new Vector3(transform.position.x, money.transform.position.y, money.transform.position.z);
            }
            else
            {
                varisNoktasi = new Vector3(moneyList[sayac - 1].transform.position.x, money.transform.position.y, money.transform.position.z);
            }



            Vector3 baslangicNoktasi = money.transform.position;
            float zaman = Time.deltaTime * zamanCarpani;
            money.transform.position = Vector3.Lerp(baslangicNoktasi, varisNoktasi, zaman);

            sayac++;
        }
    }
}
