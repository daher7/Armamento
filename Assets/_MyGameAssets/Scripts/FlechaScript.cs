using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlechaScript : MonoBehaviour {

    private void OnCollisionEnter(Collision other) {
        // Para que la flecha se quede clavada en la pared
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }
}
