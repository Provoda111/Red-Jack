using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BuffcardUI : MonoBehaviour
{
    [SerializeField] private string prefabName;
    [SerializeField] private Sprite prefabImage;
    [SerializeField] private TextMeshProUGUI prefabDesc;
    [SerializeField] private GameObject buffCardSlot;
    [SerializeField] private GameObject buffCardMenu;
    [SerializeField] private Player player;

    private void Start()
    {
        //prefabDesc = buffCardDescription;
    }
    internal void DrawCardOnMenu()
    {
        Vector3[] v = new Vector3[4];
        buffCardMenu.GetComponent<RectTransform>().GetWorldCorners(v);
        Vector3 spawnSlotPosition = new Vector3(0, 20, 0);
        Vector3 spawnSlotOffset = new Vector3(0, 0, 0);
        //buffCardMenuPanel.SetActive(true);
        for (int i = 0; i < player.buffCards.Count; i++)
        {
            if (i % 3 == 0)
            {

            }
            buffCardSlot = Instantiate(buffCardSlot, v[1] + 
                spawnSlotPosition + spawnSlotOffset * i, Quaternion.identity, buffCardMenu.transform);
            buffCardSlot.GetComponent<RectTransform>().SetInsetAndSizeFromParentEdge(RectTransform.Edge.Left, i, 300);

            prefabName = player.buffCards[i].GetComponent<BuffCard>().buffCardName;
            prefabImage = player.buffCards[i].GetComponent<BuffCard>().buffcardImage;
            buffCardSlot.GetComponentInChildren<TextMeshProUGUI>().text = prefabName.ToString();
            buffCardSlot.GetComponentInChildren<Image>().sprite = prefabImage;
        }
    }
    private void DrawCardOnGive()
    {

    }
}
