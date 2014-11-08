using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class RaceManager : MonoBehaviour 
{


	[SerializeField]
	private GameObject _carContainer;
	
	[SerializeField]
	private GUIText _announcementP1;
	[SerializeField]
	private GUIText _announcementP2;

	[SerializeField]
	private int _timeToStart;

	[SerializeField]
	private int _endCountdown;

	// Use this for initialization
	void Awake () 
	{
		CarActivation(false);

	}
	
	void Start()
	{
		StartCoroutine(StartCountdown());
	}

	IEnumerator StartCountdown()
	{
		int count = _timeToStart;
		do 
		{
			_announcementP1.text = count.ToString();
			_announcementP2.text = count.ToString();
			yield return new WaitForSeconds(1.0f);
			count--;
		}
		while (count > 0);
		_announcementP1.text = "Partez!";
		_announcementP2.text = "Partez!";
		CarActivation(true);
		yield return new WaitForSeconds(1.0f);
		_announcementP1.text = "";
		_announcementP2.text = "";
	}

	public void EndRace(string winner)
	{
		StartCoroutine(EndRaceImpl(winner));
	}

	IEnumerator EndRaceImpl(string winner)
	{
		CarActivation(false);
		_announcementP1.fontSize = 20;
		_announcementP2.fontSize = 20;
		int count = _endCountdown;
		do 
		{
			_announcementP1.text = "Victoire: " + winner + " en premiere place. Retour au titre dans " + count.ToString();
			_announcementP2.text = "Victoire: " + winner + " en premiere place. Retour au titre dans " + count.ToString();
			yield return new WaitForSeconds(1.0f);
			count--;
		}
		while (count > 0);

		Application.LoadLevel("boot");
	}

	public void Announce(string announcement, int player, float duration = 2.0f)
	{
		StartCoroutine(AnnounceImpl(announcement, player, duration));
	}

	IEnumerator AnnounceImpl(string announcement, int player, float duration)
	{
		if(player == 1) {
			_announcementP1.text = announcement;
			yield return new WaitForSeconds(duration);
			_announcementP1.text = "";
		} else {
			_announcementP2.text = announcement;
			yield return new WaitForSeconds(duration);
			_announcementP2.text = "";
		}
	}

	public void CarActivation(bool activate)
	{
		foreach (CarAIControl car in _carContainer.GetComponentsInChildren<CarAIControl>(true))
		{
			car.enabled = activate;
		}
		
		foreach (CarUserControlMP car in _carContainer.GetComponentsInChildren<CarUserControlMP>(true))
		{
			car.enabled = activate;
		}

	}
}
