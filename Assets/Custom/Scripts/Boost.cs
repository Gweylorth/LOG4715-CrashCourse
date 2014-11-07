using UnityEngine;
using System.Collections;

public class Boost : MonoBehaviour {

	public GUIText textBoost;
	public int MaxBoost;
	[SerializeField]
	private int nbBoost;

	
	public int NbBoost
	{
		get { return nbBoost; }
	}

	public void AddBoost() {
		nbBoost++;
		if (this.nbBoost > this.MaxBoost) {
			this.nbBoost = this.MaxBoost;
		}
	}

	public void SubBoost() {
		nbBoost--;
		if (this.nbBoost < 0) {
			this.nbBoost = 0;
		}
	}

	void Update(){
		this.textBoost.text = "Boost : " + this.nbBoost + "/" + this.MaxBoost;
	}
}
