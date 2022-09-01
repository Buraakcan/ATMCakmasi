using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool oyunDevam;
    public float zSpeed;
    public float yatayInput;
    public float xSpeed;
    public List<GameObject> moneyList;
    public GameObject Para;
    public Joystick joystick;
    public float zamanCarpani;
    

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
            //gameObject.transform.SetParent(this.transform);


        }

    }
    public void ParaTakipEt()
    {
        int sayac = 0;
        foreach (var money in moneyList)
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
