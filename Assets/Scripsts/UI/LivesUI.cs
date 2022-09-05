using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class LivesUI : MonoBehaviour
{
    private Text _livesText;

    private void Awake()
    {
        _livesText = GetComponent<Text>();
    }

    private void Update()
    {
        _livesText.text = PlayerStats.Lives + " LIVES";
    }
}
