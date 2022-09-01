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
            print("paraya çarptý");
            if (isCollected) 
            {
                print("para parayý çeker");
                playerController.ParaAlma(other.gameObject);
            }
         
        }
        if (other.transform.CompareTag("Player"))
        {
            print("player a  çarptý");
            if (!isCollected)
            {
                print("player parayý çeker");
                playerController.ParaAlma(gameObject);
            }
        }

        // kaçýncý sýrada = playerController.moneyList.IndexOf(gameObject);3
        //listede kaç obje var == playerController.moneyList.Count;7
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
