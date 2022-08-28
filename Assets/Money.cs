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

    }

}
