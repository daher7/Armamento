using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancotiradorScript : MonoBehaviour {

    [SerializeField] Transform puntoDisparo;
    [SerializeField] Camera miCamara;
    [SerializeField] GameObject mirilla;
    bool apuntando = false;
    float currentFOV;
    float minFOV = 25;
    float maxFOV;

    private void Start() {
        maxFOV = miCamara.fieldOfView;
        currentFOV = miCamara.fieldOfView;
    }

    private void Update() {
        if (Input.GetMouseButtonDown(1)) {
            apuntando = true;
            mirilla.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1)) {
            apuntando = false;
        }
        if (apuntando) {
            currentFOV -= 1;
            // Cogemos el valor maximo de dos valores
            currentFOV = Mathf.Max(currentFOV, minFOV);
        }
        if (apuntando == false) {
            currentFOV += 1;
            // Cogemos el valor maximo de dos valores
            currentFOV = Mathf.Min(currentFOV, maxFOV);
        }

        miCamara.fieldOfView = currentFOV;
    }

    private void OnMouseDown() {
        // Declaramos el Vector
        Vector3 forward = puntoDisparo.forward;
        // Creamos el rayo
        Ray rayo = new Ray(puntoDisparo.position, forward);
        // Declaramos el objeto que recoge el impacto
        RaycastHit hitInfo;
        // Lanzamos el Rayo
        bool impactoConseguido = Physics.Raycast(rayo, out hitInfo, 25);
        // Evaluamos el impacto
        if (impactoConseguido) {
            print(hitInfo.collider.gameObject.name);
            Debug.DrawLine(
                puntoDisparo.position,
                hitInfo.collider.transform.position,
                Color.red, 
                5);
        } else {
            print("AGUA");
        }
    }
}
