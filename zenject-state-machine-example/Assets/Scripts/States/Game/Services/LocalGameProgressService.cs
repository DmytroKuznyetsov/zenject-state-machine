using UnityEngine;

namespace States.Game.Services
{
    public class LocalGameProgressService : ILocalGameProgressService
    {
        private const string GameProgress = "GameProgress";

        public void SaveProgress(GameProgress progress)
        {
            PlayerPrefs.SetString(GameProgress, JsonUtility.ToJson(progress));
        }

        public GameProgress LoadProgress()
        {
            var progress = PlayerPrefs.GetString(GameProgress);
            return progress != "" ? JsonUtility.FromJson<GameProgress>(progress) : null;
        }
    }
}