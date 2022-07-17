using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelScreen : MonoBehaviour
{
    [SerializeField]
    private GameObject deathPanel;

    [SerializeField]
    private GameObject victoryPanel;

    // Start is called before the first frame update
    public void Start()
    {

    }

    // Update is called once per frame
    public void Update()
    {
        if (PlayerManager.player == null) {
            deathPanel.SetActive(true);
        }
        
    }

    public void Replay() {
        SceneManager.LoadScene("Loader");
    }

}
