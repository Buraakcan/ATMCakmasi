using UnityEngine;

public class Atm : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<Money>(out Money para))
            para.AtmYukle();
    }
}
