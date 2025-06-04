// using UnityEngine;
// using UnityEngine.SceneManagement;
// using TMPro;
// using System.Collections.Generic;
// using System.Linq;

// public class MenuManager : MonoBehaviour
// {
//     [SerializeField] GameObject mainMenu;
//     [SerializeField] GameObject settings;
//     [SerializeField] TextMeshProUGUI leaderboardText;

//     void Start()
//     {
//         float newTime = GameResultData.LastRunTime;
//         AddTimeToLeaderboard(newTime);
//         ShowLeaderboard();
//     }

//     void AddTimeToLeaderboard(float newTime)
//     {
//         if (newTime <= 0f) return;

//         string saved = PlayerPrefs.GetString("LeaderboardTimes", "");
//         List<float> times = new List<float>();

//         if (!string.IsNullOrEmpty(saved))
//         {
//             string[] parts = saved.Split(',');
//             foreach (var part in parts)
//                 if (float.TryParse(part, out float t))
//                     times.Add(t);
//         }

//         times.Add(newTime);
//         times = times.OrderBy(t => t).Take(10).ToList(); // Только топ-10
//         string result = string.Join(",", times.Select(t => t.ToString()));
//         PlayerPrefs.SetString("LeaderboardTimes", result);
//         PlayerPrefs.Save();
//     }

//     void ShowLeaderboard()
//     {
//         string saved = PlayerPrefs.GetString("LeaderboardTimes", "");
//         if (string.IsNullOrEmpty(saved))
//         {
//             leaderboardText.text = "Нет результатов.";
//             return;
//         }

//         string[] parts = saved.Split(',');
//         int rank = 1;
//         string leaderboard = "Таблица лидеров:\n\n";

//         foreach (var part in parts)
//         {
//             if (float.TryParse(part, out float t))
//             {
//                 leaderboard += $"{rank}. {t:F2} сек\n";
//                 rank++;
//             }
//         }

//         leaderboardText.text = leaderboard;
//     }

//     public void ShowMainMenu()
//     {
//         mainMenu.SetActive(true);
//         settings.SetActive(false);
//     }

//     public void StartGame()
//     {
//         SceneManager.LoadScene(1);
//     }

    // public void GoToMainMenu()
    // {
    //     SceneManager.LoadScene(0);
    // }

//     public void Exit()
//     {
//         Application.Quit();
//     }

//     public void OpenSettings()
//     {
//         mainMenu.SetActive(false);
//         settings.SetActive(true);
//     }
// }


using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections.Generic;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    [SerializeField] GameObject mainMenu;
    [SerializeField] GameObject settings;
    [SerializeField] TMP_Text leaderboardText;

    void Start()
    {
        if (!GameResultData.IsSaved && GameResultData.LastRunTime > 0f)
        {
            AddTimeToLeaderboard(GameResultData.LastRunTime);
            GameResultData.IsSaved = true;
        }

        DisplayLeaderboard();
    }

    void AddTimeToLeaderboard(float newTime)
    {
        string saved = PlayerPrefs.GetString("LeaderboardTimes", "");
        List<float> times = new List<float>();

        if (!string.IsNullOrEmpty(saved))
        {
            string[] parts = saved.Split(',');
            foreach (var part in parts)
                if (float.TryParse(part, out float t))
                    times.Add(t);
        }

        times.Add(newTime);
        times = times.OrderBy(t => t).ToList();

        string result = string.Join(",", times.Select(t => t.ToString()));
        PlayerPrefs.SetString("LeaderboardTimes", result);
        PlayerPrefs.Save();
    }

    public void ClearLeaderboard()
    {
        PlayerPrefs.DeleteKey("LeaderboardTimes");
        PlayerPrefs.Save();
        if (leaderboardText != null)
            leaderboardText.text = "Таблица очищена.";
    }

    void DisplayLeaderboard()
    {
        string saved = PlayerPrefs.GetString("LeaderboardTimes", "");
        if (string.IsNullOrEmpty(saved))
        {
            leaderboardText.text = "Нет результатов";
            return;
        }

        string[] parts = saved.Split(',');
        leaderboardText.text = "Таблица лидеров:\n";

        for (int i = 0; i < parts.Length; i++)
        {
            if (float.TryParse(parts[i], out float t))
            {
                leaderboardText.text += $"{i + 1}. {t:F2} сек\n";
            }
        }
    }

    public void ShowMainMenu()
    {
        mainMenu.SetActive(true);
        settings.SetActive(false);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene(0);
        GameObject go = GameObject.Find("MusicManager");
        Destroy(go);
    }

    public void Exit()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        mainMenu.SetActive(false);
        settings.SetActive(true);
    }
}
