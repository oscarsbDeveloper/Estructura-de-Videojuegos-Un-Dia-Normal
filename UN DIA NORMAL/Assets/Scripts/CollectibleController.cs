using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            Character2DController controller = other.GetComponent<Character2DController>();
            if(controller != null)
            {
                /*Caso de estudio: 30 puntos*/
                /*1. LLevar el conteo de estrellas y mostrarlo en pantalla: 30pts*/
                /*2. Recolectar la llave: 15pts*/
                /*3. Abrir el cofre para ganar el nivel: 15pts*/
                /*4. Hcer un segundo novel utilizando tilemap: 30pts*/
                /*5. El tiempo de video es de 3 minutos para avanzar en el nivel: 10pts*/
                /*GITHUB: csolano40412@ufide.ac.cr*/
            }
            Destroy(gameObject);
        }
    }
}
