using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Bullet : MonoBehaviour
{

    public float speed = 5f; // duracion de bala
    public float maxLifeTime = 3f; // segundos

    public Vector3 targetVector;

    // Referencia al prefab del mini-asteroide.
    public GameObject miniAsteroidPrefab;

    // Start is called before the first frame update
    void Start()
    {
        // En el primer frame se deshabilita a los 3 segundos
        StartCoroutine(DisableAfterTime(gameObject)); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * targetVector * Time.deltaTime); // teletransporta el componente
    }

    private void OnCollisionEnter(Collision collision){

        if(collision.gameObject.CompareTag("Enemy")){
            // Dividir el asteroide en dos mini-asteroides.
            SplitAsteroid(collision.transform.position, collision.transform.rotation);

            // Aumentar la puntuación.
            IncreaseScore();

            // Destruir el asteroide y deshabilitar la bala.
            Destroy(collision.gameObject);
            gameObject.SetActive(false);

        }else if(collision.gameObject.CompareTag("MiniEnemy")){
            // Aumentar la puntuación.
            IncreaseScore();
            // Destruir el asteroide y deshabilitar la bala.
            Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void SplitAsteroid(Vector3 position, Quaternion rotation){
        // Calcular la dirección bisectriz en relación con la dirección de la bala original
        Vector2 bisectorDirection = Quaternion.Euler(0, 0, 45) * targetVector.normalized;

        // Calcular las direcciones de los mini-asteroides con un ángulo fijo en relación con la bisectriz
        Vector2 miniAsteroidDirection1 = Quaternion.Euler(0, 0, 22.5f) * bisectorDirection;
        Vector2 miniAsteroidDirection2 = Quaternion.Euler(0, 0, -22.5f) * bisectorDirection;

        // Crear dos mini-asteroides
        GameObject miniAsteroid1 = Instantiate(miniAsteroidPrefab, position, rotation);
        GameObject miniAsteroid2 = Instantiate(miniAsteroidPrefab, position, rotation);

        // Asignar las direcciones calculadas a los mini-asteroides
        miniAsteroid1.GetComponent<MiniAsteroidController>().moveDirection = miniAsteroidDirection1;
        miniAsteroid2.GetComponent<MiniAsteroidController>().moveDirection = miniAsteroidDirection2;
    }


    private void IncreaseScore(){
        Player.SCORE++;
        UpdateScoreText();
    }

    private void UpdateScoreText(){
        GameObject go = GameObject.FindGameObjectWithTag("UI");
        go.GetComponent<Text>().text = "Score :   " + Player.SCORE;
    }

     // Deshabilita un GameObject después de un tiempo
    private IEnumerator DisableAfterTime(GameObject obj)
    {
        yield return new WaitForSeconds(maxLifeTime);

        if (obj != null && obj.activeSelf)
        {
            obj.SetActive(false);
        }
    }
}
