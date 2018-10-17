using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GranadaScript : MonoBehaviour {

    [SerializeField] int tiempoParaExplosion = 3;
    [SerializeField] int radioExplosion = 3;
    [SerializeField] int fuerzaExplosion = 100;
    [SerializeField] int alturaExplosion = 3;
	// Use this for initialization
	void Start () {
        Invoke("Explotar", tiempoParaExplosion);
	}
	
    private void Explotar() {
        // Da el componente del GameObject
        Collider[] cosas = Physics.OverlapSphere(transform.position, radioExplosion);

        foreach (var cosa in cosas) {
            
            if(cosa.gameObject.CompareTag("Explosionable")) {
                // Mostramos el nombre de los "Explosionables"
                print(cosa.gameObject.name);
                // Vamos a aplicar la fuerza en los explosionables
                cosa.gameObject.GetComponent<Rigidbody>().AddExplosionForce(
                    fuerzaExplosion,
                    this.transform.position,
                    radioExplosion,
                    alturaExplosion
                    );
            }
        }
    }
}
