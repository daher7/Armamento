using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancotiradorScript : MonoBehaviour {

    [SerializeField] Transform puntoDisparo;

    private void OnMouseDown() {
        // Declaramos el Vector
        Vector3 forward = puntoDisparo.forward;
        // Creamos el rayo
        Ray rayo = new Ray(puntoDisparo.position, forward);
        // Declaramos el objeto que recoge el impacto
        RaycastHit hitInfo;
        // Lanzamos el Rayo
        bool impactoConseguido = Physics.Raycast(rayo, out hitInfo, 25);

        if (impactoConseguido) {
            print(hitInfo.collider.gameObject.name);
        } else {
            print("AGUA");
        }
    }
}
