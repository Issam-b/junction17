using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScenesManager : MonoBehaviour {

	
   // enum State curentState ={ idle, drill};

	void Start () {
		InvokeRepeating (ChangeScene (1), 60, 0);
	}
	
	// Update is called once per frame
	public void ChangeScene (int i) {
		SceneManager.LoadScene (i);
	}
}
