using UnityEngine;

public class Kapi : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Money para;
        if (other.transform.TryGetComponent<Money>(out para))
        {
            if (para.sonKapi != gameObject)
            {
                para.Donusturme();
                para.sonKapi = gameObject;
            }
        }
    }
}
