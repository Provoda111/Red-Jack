using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Chip : MonoBehaviour
{
    public float fallSpeed = 1f;         // Nopeus, jolla objekti putoaa
    public float rotationSpeed = 100f;  // Py�rimisnopeus
    private float rotationDirection;    // Satunnainen py�rimissuunnan kerroin

    private void Start()
    {
        // Asetetaan satunnainen py�rimissuunta: joko -1 (vastap�iv��n) tai 1 (my�t�p�iv��n)
        rotationDirection = Random.value > 0.5f ? 1f : -1f;

        Destroy(gameObject, 10f);
    }

    private void Update()
    {
        // Putoamisliike alasp�in
        transform.position += Vector3.down * fallSpeed * Time.deltaTime;

        // Py�riminen satunnaiseen suuntaan Z-akselin ymp�ri
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
