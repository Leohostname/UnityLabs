using TMPro;
using UnityEngine;

public class ScoreCounterBar : MonoBehaviour
{
    [SerializeField]
    private string counterBar = "Current Score: ";
    private TextMeshProUGUI content;

	private void Start()
    {
        content = GetComponent<TextMeshProUGUI>();
	}

    private void RefreshScoreBar(int ScoreCounter)
    {
		content.text = counterBar + ScoreCounter;
	}
}
