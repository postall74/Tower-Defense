using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameOver : MonoBehaviour
{
    [SerializeField] private Text _roundText;

    public void OnRetry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnMenu()
    {
        Debug.Log("Go to menu");
    }

    private void OnEnable()
    {
        _roundText.text = PlayerStats.Rounds.ToString();
    }
}
