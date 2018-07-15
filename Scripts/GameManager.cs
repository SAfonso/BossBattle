using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager instance;

    public InitialSecuence initialSecuence;

    public bool isOnSecuence = false;


    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    void Start()
    {
        initialSecuence = new InitialSecuence();
        this.ExecuteSecuence(initialSecuence);
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }

    public void ExecuteSecuence(Secuence secuence)
    {
        Debug.Log("Executing");
        instance.isOnSecuence = true;
        StartCoroutine( secuence.DoSecuence());  

    }
}
