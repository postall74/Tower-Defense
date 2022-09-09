using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _roundText;

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Menu()
    {
        Debug.Log("Go to menu");
    }

    private void OnEnable()
    {
        _roundText.text = PlayerStats.Rounds.ToString();
    }

    private void OnDisable()
    {
        
    }
}
