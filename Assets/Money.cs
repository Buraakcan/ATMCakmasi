using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Money : MonoBehaviour
{
    public bool isCollected;
    public PlayerController playerController;

    private void Awake()
    {
            
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Para"))
        {
            print("paraya �arpt�");
            if (isCollected) 
            {
                print("para paray� �eker");
                playerController.ParaAlma(other.gameObject);
            }
         
        }
        if (other.transform.CompareTag("Player"))
        {
            print("player a  �arpt�");
            if (!isCollected)
            {
                print("player paray� �eker");
                playerController.ParaAlma(gameObject);
            }
        }

        // ka��nc� s�rada = playerController.moneyList.IndexOf(gameObject);3
        //listede ka� obje var == playerController.moneyList.Count;7
        // 

        if (other.transform.CompareTag("Engel"))
        {
            int sira = playerController.moneyList.IndexOf(gameObject);
            int kactane = playerController.moneyList.Count - sira;
            for (int i = 0; i < kactane; i++)
            {
                playerController.moneyList.RemoveAt(sira);
            }

        }
        



    }

}
