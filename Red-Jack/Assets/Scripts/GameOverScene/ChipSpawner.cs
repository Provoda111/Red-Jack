using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChipSpawner : MonoBehaviour
{
    public GameObject pokerChipPrefab; // Viittaus PokerChip prefab -objektiin
    public float spawnInterval = 0.5f; // Aikaväli spawnaukselle
    public float spawnRange = 10f;     // X-akselin alue, jossa PokerChipit spawnataan

    private void Start()
    {
        // Aloitetaan PokerChipien spawnauksen aikataulutus
        InvokeRepeating(nameof(SpawnPokerChip), 0f, spawnInterval);
    }

    private void SpawnPokerChip()
    {
        if (pokerChipPrefab == null)
        {
            Debug.LogWarning("PokerChip prefab ei ole asetettu!");
            return;
        }

        // Satunnainen X-koordinaatti välillä [-spawnRange, spawnRange]
        float randomX = Random.Range(-spawnRange, spawnRange);

        // Uusi sijainti PokerChipille
        Vector3 spawnPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

        // Instansioidaan PokerChip
        Instantiate(pokerChipPrefab, spawnPosition, Quaternion.identity);
    }
}
