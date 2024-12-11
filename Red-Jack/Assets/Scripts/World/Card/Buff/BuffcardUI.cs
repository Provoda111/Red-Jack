using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuffcardUI : MonoBehaviour
{
    private string prefabName; 
    private Sprite prefabImage;
    private string prefabDesc;
    [SerializeField] private GameObject buffCardSlot;
    [SerializeField] private GameObject buffCardMenu;
    [SerializeField] private GameObject buffCardGetMenu;
    [SerializeField] private Player player;
    
    internal void DrawCardOnMenu()
    {
        Vector3[] corners = new Vector3[4];
        buffCardMenu.GetComponent<RectTransform>().GetWorldCorners(corners);
        Vector3 spawnSlotPosition = corners[1];
        
        int xOffset = 250; 
        int yOffset = 100; 
        buffCardMenu.SetActive(true);
        for (int i = 0; i < player.buffCards.Count; i++)
        {
            int xPosition = i / 2;
            int yPosition = i % 2;
            
            Vector3 cardSlotPosition = spawnSlotPosition + new Vector3(xOffset * xPosition, 
                -yOffset * yPosition, 0);
            
            GameObject newBuffCardSlot = Instantiate(buffCardSlot, cardSlotPosition, 
                Quaternion.identity, buffCardMenu.transform);

            newBuffCardSlot.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge
                (RectTransform.Edge.Left, xOffset * xPosition, 300);
            var buffPrefab = player.buffCards[i].GetComponent<BuffCard>();
            buffCardSlot.GetComponentInChildren<TextMeshProUGUI>().text = buffPrefab.buffCardName.ToString();
            buffCardSlot.GetComponentInChildren<Image>().sprite = buffPrefab.buffcardImage;
        }
    }
    private void DrawCardOnGive()
    {
        buffCardGetMenu.SetActive(true);
    }
}
