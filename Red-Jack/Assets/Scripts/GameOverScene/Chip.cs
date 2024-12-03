using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public float fallSpeed = 1f;         // Nopeus, jolla objekti putoaa
    public float rotationSpeed = 100f;  // Pyörimisnopeus
    private float rotationDirection;    // Satunnainen pyörimissuunnan kerroin

    private void Start()
    {
        // Asetetaan satunnainen pyörimissuunta: joko -1 (vastapäivään) tai 1 (myötäpäivään)
        rotationDirection = Random.value > 0.5f ? 1f : -1f;

        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        // Putoamisliike alaspäin
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Pyöriminen satunnaiseen suuntaan Z-akselin ympäri
        transform.Rotate(0, 0, rotationSpeed * rotationDirection * Time.deltaTime);
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Delete"))
        {
            Destroy(gameObject);
        }
    }
}
