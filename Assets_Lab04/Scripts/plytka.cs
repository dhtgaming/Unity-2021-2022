using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plytka : MonoBehaviour
{
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
        if (other.tag == "Player")
        {
            // DODATKOWO DO MoveWithCharacterController dodalem fukcje explode
            other.gameObject.GetComponent<MoveWithCharacterController>().explode();
        }
    }
}