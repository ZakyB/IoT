using UnityEngine;

public class TargetController : MonoBehaviour
{
    public float targetPositionY = -4f; // la position cible en Y que vous voulez atteindre
    public float speed = 1f; // la vitesse à laquelle la cible doit se déplacer

    private Vector3 startPosition; // la position initiale de la cible
    private Vector3 targetPosition; // la position cible

    private float journeyLength; // la distance totale que la cible doit parcourir
    private float startTime; // le moment où la cible commence à se déplacer

    void Start()
    {
        // initialise les positions de départ et d'arrivée de la cible
        startPosition = transform.position;
        targetPosition = new Vector3(startPosition.x, targetPositionY, startPosition.z);
        
        // calcule la distance totale que la cible doit parcourir
        journeyLength = Vector3.Distance(startPosition, targetPosition);

        // enregistre le moment où la cible commence à se déplacer
        startTime = Time.time;
    }

    void Update()
    {
        // calcule le temps écoulé depuis le début du mouvement
        float elapsedTime = Time.time - startTime;

        // calcule la distance parcourue jusqu'à présent
        float distanceCovered = elapsedTime * speed;

        // calcule la fraction de la distance totale parcourue
        float fractionOfJourney = distanceCovered / journeyLength;

        // déplace la cible progressivement en utilisant la fonction Lerp
        transform.position = Vector3.Lerp(startPosition, targetPosition, fractionOfJourney);

        if (transform.position.y <= targetPositionY)
        {
            // détruit la cible
            Destroy(gameObject);
        }
    }
}
