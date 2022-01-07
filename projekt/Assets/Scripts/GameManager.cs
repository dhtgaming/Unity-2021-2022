using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static bool isGameOver;
    public GameObject gameOverScreen;

    public void Awake()
    {
        isGameOver = false;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(isGameOver)
        {
            gameOverScreen.SetActive(true);
            Punktacja.punktacja = 0;
        }
    }

    public void ResetGame()
    {
        SceneManager.LoadScene(0);
        Zycie.punktacjaZycia = 1f;
    }
}
