using System.Collections;
using UnityEngine;

public class Fly : MonoBehaviour
{

    [SerializeField] float wanderDistanceRange = 1f;
    [SerializeField] float wanderTimeBase = 0.25f;
    [SerializeField] float wanderTimeRange = 0.25f;

    Vector2 startPosition;
    SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = transform.GetComponent<SpriteRenderer>();
        startPosition = transform.position;
        StartCoroutine(Wander());
    }

    IEnumerator Wander()
    {
        float elapsedTime = 0f;
        float timeUntilNewTarget = 0f;
        Vector2 targetPosition = Vector2.zero;
        Vector2 fromPosition = Vector2.zero;

        void StartNewWander()
        {
            elapsedTime = 0f;
            timeUntilNewTarget = Random.Range(wanderTimeBase, wanderTimeBase + wanderTimeRange);
            targetPosition = new Vector2(startPosition.x + Random.Range(-wanderDistanceRange, wanderDistanceRange), startPosition.y + Random.Range(-1f, 1f));
            fromPosition = transform.position;
        }

        while (true)
        {
            if (elapsedTime >= timeUntilNewTarget) StartNewWander();
            elapsedTime += Time.deltaTime;
            transform.position = Vector2.Lerp(fromPosition, targetPosition, elapsedTime / timeUntilNewTarget);
            yield return null;
        }
    }
}
