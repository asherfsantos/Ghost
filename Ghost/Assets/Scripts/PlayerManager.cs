using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {

    public static PlayerManager instance;
    public delegate void OnDeathEvent();
    public static event OnDeathEvent OnDeath;
    #region Monobehavior Callbacks
    private void Awake()
    {
        instance = this;
    }
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void PlayerDeath()
    {
        if(OnDeath!=null)
            OnDeath();
        SceneManager.LoadScene(0);
    }
    #endregion
}
