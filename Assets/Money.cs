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

    }

}
