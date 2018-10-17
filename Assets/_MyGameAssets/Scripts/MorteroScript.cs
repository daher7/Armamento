using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MorteroScript : MonoBehaviour {

    [SerializeField] Transform genPoint;
    [SerializeField] GameObject prefabProyectil;
    [SerializeField] int force = 5;

    private void OnMouseDown() {
        // Instanciamos al prefab en el punto de generación
        GameObject proyectil = Instantiate(
            prefabProyectil,
            genPoint.transform.position,
            genPoint.transform.rotation);
        // Al proyectil le aplicamos una fuerza para que salga disparada
        proyectil.GetComponent<Rigidbody>().AddRelativeForce(Vector3.forward * force);
    }
}
