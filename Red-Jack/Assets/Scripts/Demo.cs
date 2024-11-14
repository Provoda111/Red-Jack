using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject demoPanel;
    public GameObject demoPanelOpener;
    public GameObject demoPanelCloser;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DemoPanelOpener()
    {
        demoPanel.SetActive(true);
    }
    public void DemoPanelCloser()
    {
        demoPanel.SetActive(false);
    }
}
