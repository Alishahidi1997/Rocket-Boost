using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip FinishApplaud;

    AudioSource asRocket;

    bool isTransitioning = false; 
    private void Start()
    {
        asRocket = GetComponent<AudioSource>();
    }

    private void Update()
    {
        RespondToDebugKeys();
    }

    void RespondToDebugKeys()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            NextLevel();
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(!isTransitioning)
            switch (collision.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("Hit into the launching pad");
                    break;
                case "Finish":
                    startSuccessSquence();
                    break;
                case "Obstacle":
                    StartCrashSequence();
                    break;
                case "Fuel":
                    Debug.Log("Long way to go, more fuel could be helpful");
                    break;
                default:
                    break; 

            }
    }

    private void StartCrashSequence()
    {
        isTransitioning = true;
        GetComponent<RocketMovement>().enabled = false;
        asRocket.PlayOneShot(crash);
        Invoke("ReloadLevel", 1f);

    }
    void startSuccessSquence()
    {
        
        isTransitioning = true;
        GetComponent<RocketMovement>().enabled = false;
        asRocket.PlayOneShot(FinishApplaud);
        Invoke("NextLevel", 2f);
        
    }

    void NextLevel()
    {
        isTransitioning = false;
        int numOfScene = SceneManager.sceneCountInBuildSettings;
        int currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        int nextScene = (currentScene) % numOfScene;
        SceneManager.LoadScene(nextScene);
    }

    void ReloadLevel()
    {
        isTransitioning = false;
        int activeScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(activeScene);
    }
}
