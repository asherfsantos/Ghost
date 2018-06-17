using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerManager : MonoBehaviour {
    #region Public Variables
    public static PlayerManager instance;
    public delegate void OnDeathEvent();
    public static event OnDeathEvent OnDeath;
    public int realWorldHealth = 3;
    public int spiritWorldHealth = 1;
    #endregion

    #region Private Variables

    #endregion

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
		if(realWorldHealth == 0 || spiritWorldHealth == 0)
        {
            PlayerDeath();
        }
	}
    public void PlayerDeath()
    {
        if(OnDeath!=null)
            OnDeath();
        SceneManager.LoadScene(0);
    }
    public void TakeRealWorldDamage(int damage)
    {
        realWorldHealth -= damage;
    }
    public void TakeSpiritWorldDamage(int damage)
    {
        spiritWorldHealth -= damage;
    }
    #endregion
}
