using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectInstantiate : MonoBehaviour
{
    [SerializeField]
    GameObject fireSpirit;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            GameObject spiritTemp = Instantiate(fireSpirit, transform.position, Quaternion.identity);
            StartCoroutine(SpiritToKinematicCoroutine(spiritTemp));
        }
    }

    IEnumerator SpiritToKinematicCoroutine(GameObject g)
    {
        yield return new WaitForSeconds(2);
        g.GetComponent<Rigidbody>().isKinematic = true;
    }
}
