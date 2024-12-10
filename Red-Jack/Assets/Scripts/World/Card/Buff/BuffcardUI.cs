using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BuffcardUI : BuffCard
{
    [SerializeField] private TextMeshProUGUI prefabName;
    [SerializeField] private Sprite prefabImage;
    [SerializeField] private TextMeshProUGUI prefabDesc;

    private void Start()
    {
        prefabName.text = buffCardName;
        prefabImage = buffcardImage;
        //prefabDesc = buffCardDescription;
    }
    private void DrawCardOnMenu()
    {

    }
    private void DrawCardOnGive()
    {

    }
}
