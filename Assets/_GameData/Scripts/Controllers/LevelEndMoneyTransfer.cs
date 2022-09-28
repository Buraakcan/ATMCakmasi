using System.Collections.Generic;
using UnityEngine;

public class LevelEndMoneyTransfer : MonoBehaviour
{
    public List<GameObject> paralar;


    private void Update()
    {
        if (paralar.Count > 0)
        {
            for (int i = 0; i < paralar.Count; i++)
            {
                paralar[i].gameObject.transform.position = new Vector3(
                    paralar[i].gameObject.transform.position.x - 0.1f,
                    paralar[i].gameObject.transform.position.y,
                    paralar[i].gameObject.transform.position.z);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Money>(out Money para))
        {
            para.playerController.moneyList.Remove(para.gameObject);
            paralar.Add(para.gameObject);
        }


    }
}
