using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PhraseDisplay : MonoBehaviour
{
    public Text phraseText;
    public float displayDuration = 5f;
    public float timerDuration = 30f;

    private string[] phrases = new string[]
    {
        "Первая заготовленная фраза.",
        "Вторая заготовленная фраза.",
        "Третья заготовленная фраза.",
        "Четвертая заготовленная фраза.",
        "Пятая заготовленная фраза."
    };

    void Start()
    {
        phraseText.gameObject.SetActive(false);
        StartCoroutine(DisplayPhraseAfterDelay());
    }

    private IEnumerator DisplayPhraseAfterDelay()
    {
        yield return new WaitForSeconds(timerDuration);

        
        int randomIndex = Random.Range(0, phrases.Length);
        phraseText.text = phrases[randomIndex];

        phraseText.gameObject.SetActive(true);

        yield return new WaitForSeconds(displayDuration);

        phraseText.gameObject.SetActive(false);
    }
}
