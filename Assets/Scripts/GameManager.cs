using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour 
{
	public static GameManager Instance
	{
		get; private set;
	}

	[SerializeField]
	private Text scoreLabel;
	private int points;

	private void Awake ()
	{
		if (Instance != null)
			Destroy (gameObject);
		else
			Instance = this;
	}

	public void IncreaseScore (int points)
	{
		this.points += points;
		scoreLabel.text = string.Format ("Score: {0}", points);
	}

	public void WinGame ()
	{
		scoreLabel.text = string.Format ("Level completed!");
	}
}
