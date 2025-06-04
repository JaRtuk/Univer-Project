using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGame : MonoBehaviour
{
    [SerializeField] Timer timer;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            GameResultData.LastRunTime = timer.GetTime();
            GameResultData.IsSaved = false;
            
            SceneManager.LoadScene(3);
        }
    }
}
