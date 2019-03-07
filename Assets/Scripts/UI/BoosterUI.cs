using UnityEngine;
using SuperHot.Gameplay.Boosters;

namespace SuperHot.UI
{
    public class BoosterUI : MonoBehaviour
    {
        [SerializeField] GameObject timer;
        [SerializeField] Booster booster;

        public void Activate()
        {
            if (!booster.ActivateIfCan()) return;
            ResetTimerUI();
        }

        private void ResetTimerUI()
        {
            timer.SetActive(false);
            timer.SetActive(true);
        }
    }
}