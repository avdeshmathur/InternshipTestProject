using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerSoilder : MonoBehaviour {

    public GameObject soilderPrefab;
    int soilder = 0;

	void Start () {
        StartCoroutine(instantiateSoilders());
    }

    IEnumerator instantiateSoilders()
    {
        if (soilder == 0) {
            yield return new WaitForSeconds(10f);
            Instantiate(soilderPrefab, new Vector2(transform.position.x + 2, transform.position.y + 2), Quaternion.identity);
            soilder++;
        }
    }
}
