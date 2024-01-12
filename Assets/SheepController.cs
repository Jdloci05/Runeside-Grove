using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SheepController : MonoBehaviour
{
    [SerializeField] List<Vector2> movementPattern;
    [SerializeField] float timeBetweenPattern;

    SheepState state;
    float idleTimer = 0f;
    int currentPattern = 0;

    Sheep character;

    private void Awake()
    {
        character = GetComponent<Sheep>();
    }

    private void Update()
    {
        if (state == SheepState.Idle)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer > timeBetweenPattern)
            {
                idleTimer = 0f;
                if (movementPattern.Count > 0)
                    StartCoroutine(Walk());
            }
        }

        character.HandleUpdate();
    }

    IEnumerator Walk()
    {
        state = SheepState.Walking;

        var oldPos = transform.position;

        yield return character.Move(movementPattern[currentPattern]);

        if (transform.position != oldPos)
            currentPattern = (currentPattern + 1) % movementPattern.Count;

        state = SheepState.Idle;
    }
}

public enum SheepState { Idle, Walking }

