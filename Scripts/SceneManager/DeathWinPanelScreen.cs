using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathWinPanelScreen : MonoBehaviour
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
        } else if (BossManager.boss == null && SceneManager.GetActiveScene().name == "BossMap") {
            victoryPanel.SetActive(true);
        }
        
    }

    public void Replay() {
        PlayerManager.player.HP = 100f;
        PlayerManager.player.Attack = 5f;
        PlayerManager.player.Defense = 5f;
        PlayerManager.player.Speed = 5f;
        PlayerManager.player.Level = 1;
        PlayerManager.player.Exp = 0;
        SceneManager.LoadScene("Loader");
    }

}
