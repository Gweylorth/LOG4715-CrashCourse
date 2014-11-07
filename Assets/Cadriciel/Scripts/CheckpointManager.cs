using UnityEngine;
using System.Collections.Generic;

public class CheckpointManager : MonoBehaviour 
{
	
	public GUIText lapsTextP1;
	public GUIText lapsTextP2;
	
	[SerializeField]
	private GameObject _carContainer;
	
	[SerializeField]
	private int _checkPointCount;
	[SerializeField]
	private int _totalLaps;
	
	private bool _finished = false;
	
	private Dictionary<CarController,PositionData> _carPositions = new Dictionary<CarController, PositionData>();
	
	private class PositionData
	{
		public int lap;
		public int checkPoint;
		public int position;
	}
	
	void Start(){
		lapsTextP1.text = "Tour 1/" + _totalLaps;
		lapsTextP2.text = "Tour 1/" + _totalLaps;
	}
	
	// Use this for initialization
	void Awake () 
	{
		foreach (CarController car in _carContainer.GetComponentsInChildren<CarController>(true))
		{
			_carPositions[car] = new PositionData();
		}
	}
	
	public void CheckpointTriggered(CarController car, int checkPointIndex)
	{
		
		PositionData carData = _carPositions[car];
		
		if (!_finished)
		{
			if (checkPointIndex == 0)
			{
				if (carData.checkPoint == _checkPointCount-1)
				{
					carData.checkPoint = checkPointIndex;
					carData.lap += 1;
					Debug.Log(car.name + " lap " + carData.lap);
					if (IsPlayer(car))
					{
						if(car.gameObject.name == "Joueur 1") {							
							lapsTextP1.text = "Tour " + (carData.lap+1) + "/" + _totalLaps;
						}
						else if(car.gameObject.name == "Joueur 2") {							
							lapsTextP2.text = "Tour " + (carData.lap+1) + "/" + _totalLaps;
						}
						GetComponent<RaceManager>().Announce("Tour " + (carData.lap+1).ToString());
					}
					
					if (carData.lap >= _totalLaps)
					{
						_finished = true;
						GetComponent<RaceManager>().EndRace(car.name.ToLower());
					}
				}
			}
			else if (carData.checkPoint == checkPointIndex-1) //Checkpoints must be hit in order
			{
				carData.checkPoint = checkPointIndex;
			}
		}
		
		
	}
	
	bool IsPlayer(CarController car)
	{
		return car.GetComponent<CarUserControlMP>() != null;
	}
}
