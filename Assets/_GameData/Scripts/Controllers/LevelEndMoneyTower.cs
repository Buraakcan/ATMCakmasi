using System.Collections;
using UnityEngine;

public class LevelEndMoneyTower : MonoBehaviour
{
    public GameObject paraPrefab;
    public Vector3 spawnPosition;
    public PlayerController player;
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent<PlayerController>(out player))
        {
            StartCoroutine(BuildTower());
        }
    }

    public IEnumerator BuildTower()
    {
        yield return new WaitForSeconds(1);
        int toplamPara = GameManager.instance.ToplamPara;
        int i = 0;
        while (i < toplamPara)
        {
            GameObject clonObje = Instantiate(paraPrefab, spawnPosition + new Vector3(0, i * 0.5f, 0), Quaternion.identity);
            clonObje.SetActive(true);
            player.transform.position = spawnPosition + new Vector3(0, (i * 0.5f) + 1f, 0);
            i++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
