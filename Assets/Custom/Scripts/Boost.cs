using UnityEngine;
using System.Collections;

// Allow boosts on car
public class Boost : MonoBehaviour {

	// Text counting the number of boosts available
	public GUIText textBoost;
	// Maximum number of boosts
	public int MaxBoost;
	// Number of boosts available
	[SerializeField]
	private int nbBoost;

	// Method to get the number of boosts
	public int NbBoost
	{
		get { return nbBoost; }
	}

	// Add a boost
	public void AddBoost() {
		nbBoost++;
		// If superior than max
		if (this.nbBoost > this.MaxBoost) {
			this.nbBoost = this.MaxBoost;
		}
	}

	// Subtract a boost
	public void SubBoost() {
		nbBoost--;
		// If inferior than 0
		if (this.nbBoost < 0) {
			this.nbBoost = 0;
		}
	}

	// Display the number of boosts
	void Update(){
		this.textBoost.text = "Boost : " + this.nbBoost + "/" + this.MaxBoost;
	}
}
