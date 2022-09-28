using Assets;
using UnityEngine;

public class Money : MonoBehaviour
{
    public bool isCollected;
    public PlayerController playerController;
    public MeshRenderer ilk;
    public MeshRenderer ikinci;
    public MeshRenderer ucuncu;
    public GameObject sonKapi;
    public CollectableType type;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Para"))
        {
            if (isCollected)
                playerController.ParaAlma(other.gameObject);
        }
        if (other.transform.CompareTag("Player"))
        {
            if (!isCollected)
                playerController.ParaAlma(gameObject);
        }

        // kaçýncý sýrada = playerController.moneyList.IndexOf(gameObject);3
        //listede kaç obje var == playerController.moneyList.Count;7
        // 
        if (isCollected == true)
        {
            if (other.transform.CompareTag("Engeller"))
            {
                int sira = playerController.moneyList.IndexOf(gameObject);
                int kactane = playerController.moneyList.Count - sira;
                for (int i = 0; i < kactane; i++)
                {

                    playerController.moneyList[sira].GetComponent<Money>().isCollected = false;
                    playerController.moneyList.RemoveAt(sira);
                }
            }
            if (other.transform.CompareTag("Destroyer"))
            {
                playerController.moneyList.Remove(gameObject);
                gameObject.SetActive(false);
            }
        }
    }

    public void AtmYukle()
    {

        playerController.moneyList.Remove(this.gameObject);
        this.gameObject.SetActive(false);

        int deger = 0;
        if (type == CollectableType.Para)
        {
            deger = 1;
        }
        else if (type == CollectableType.Altin)
        {
            deger = 2;
        }
        else if (type == CollectableType.Elmas)
        {
            deger = 3;
        }
        else
        {
            deger = 0;
        }
        GameManager.instance.ToplamPara += deger;
        GameManager.instance.paraText.text = GameManager.instance.ToplamPara.ToString();
        print("Manager Toplam : " + GameManager.instance.ToplamPara + "Son Eklenen : " + deger);
        //switch (type)
        //{
        //    case CollectableType.Para:
        //        deger = 1;
        //        break;
        //    case CollectableType.Altin:
        //        deger = 2;
        //        break;
        //    case CollectableType.Elmas:
        //        deger = 3;
        //        break;
        //    default:
        //        deger = 0;
        //        break;
        //}


    }

    [ContextMenu("Donusturme")]
    public void Donusturme()
    {
        //transform.GetComponent<MeshRenderer>().enabled = false;
        //transform.GetComponentInChildren<MeshRenderer>().enabled = true;

        if (type == CollectableType.Para)
        {
            ilk.enabled = false;
            ikinci.enabled = true;
            type = CollectableType.Altin;
            print(" Altina Donusturme");

        }
        else
        {
            ilk.enabled = false;
            ikinci.enabled = false;
            ucuncu.enabled = true;
            type = CollectableType.Elmas;
            print(" Elmasa Donusturme");

        }
    }
}

