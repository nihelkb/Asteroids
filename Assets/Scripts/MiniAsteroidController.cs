using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniAsteroidController : MonoBehaviour
{
    public float moveSpeed = 3.0f;        // Velocidad de movimiento del mini-asteroide.
    public Vector2 moveDirection;         // Esta será la dirección en la que se moverá el mini-asteroide.

    void Update()
    {
        // En el método Update, movemos el mini-asteroide en la dirección especificada a la velocidad indicada.
        // Multiplicamos moveDirection por moveSpeed para obtener la velocidad correcta en esa dirección.
        // Time.deltaTime se utiliza para que el movimiento sea suave y constante independientemente de la velocidad de fotogramas.
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }

}
