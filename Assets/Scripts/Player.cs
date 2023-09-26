using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public static int SCORE = 0;
    public static float xBorderLimit, yBorderLimit;

    public GameObject gun, bulletPrefab;
    public GameObject miniAsteroidPrefab;

    public Rigidbody _rigidbody;

    Vector2 thrustDirection;

    // Start is called before the first frame update
    // Se ejecuta una sola vez en el primer frame thel gameObject -> configuracion inicial
    void Start()
    {
        // rigidbody para aplicar fuerzas en el jugador
        _rigidbody = GetComponent<Rigidbody>();

        xBorderLimit = Camera.main.orthographicSize + 1;
        yBorderLimit = (Camera.main.orthographicSize + 1) * Screen.width / Screen.height;
    }

    // Update is called once per frame
    void Update()
    {
        // Obtenemos las pulsaciones del teclado
        float rotation = Input.GetAxis("Rotate") * rotationSpeed * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * thrustForce * Time.deltaTime;
        
        // Direccion de empuje por defecto -> right (eje X positivo)
        thrustDirection = transform.right;

        // Rotar en negativo para que la dirección sea correcta
        transform.Rotate(Vector3.forward, -rotation);
        
        // Aplicar fuerza capturada a la nave (rigidbody)
        _rigidbody.AddForce(thrustDirection * thrust);

        // Espacio infinito

        var newPos = transform.position;

        if(newPos.x > xBorderLimit){
            newPos.x = -xBorderLimit + 1;
        }else if(newPos.x < -xBorderLimit){
            newPos.x = xBorderLimit - 1;
        }else if(newPos.y > yBorderLimit){
            newPos.y = -yBorderLimit + 1;
        }else if(newPos.y < -yBorderLimit){
            newPos.y = yBorderLimit - 1;
        }
        
        transform.position = newPos;

        // Generación de balas
        
        if(Input.GetKeyDown(KeyCode.Space)){ 

            // Al pulsar espacio se instancia un nuevo objeto bala
            GameObject bullet = Instantiate(bulletPrefab, gun.transform.position, Quaternion.identity);
            // Obtener la referencia al gameobject de la bala
            Bullet bulletScript = bullet.GetComponent<Bullet>();
            // Le damos dirección a la bala
            bulletScript.targetVector = transform.right;
            // Agregar una referencia al prefab del mini-asteroide.
            bulletScript.miniAsteroidPrefab = miniAsteroidPrefab;
        }

    }

    private void OnCollisionEnter(Collision collision){

        // Si el jugador se choca con un asteroide entonces la nave muere
        if(collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "MiniEnemy"){
            SCORE = 0;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}
