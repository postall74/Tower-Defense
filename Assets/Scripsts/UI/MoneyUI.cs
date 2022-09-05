using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class MoneyUI : MonoBehaviour
{
    private Text _momeyText;

    private void Awake()
    {
        _momeyText = GetComponent<Text>();
    }

    private void Update()
    {
        _momeyText.text = "$" +  PlayerStats.Money.ToString();  
    }
}
