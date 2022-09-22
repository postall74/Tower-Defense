using UnityEngine;
using UnityEngine.UI;
using System.Collections;

[RequireComponent(typeof(Text))]
public class RoundSurvived : MonoBehaviour
{
   [SerializeField] private Text _roundText;

    private void OnEnable()
    {
        StartCoroutine(AnimateText());
    }

    private IEnumerator AnimateText()
    {
        _roundText.text = "0";
        int round = 0;

        yield return new WaitForSeconds(0.5f);

        while (round < PlayerStats.Rounds)
        {
            round++;
            _roundText.text = round.ToString();

            yield return new WaitForSeconds(0.05f);
        }
    }
}
