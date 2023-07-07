// FPSCounter5.cs
using System.Collections;
using UnityEngine;
 
namespace Tools
{
 
    public class FpsCounter : MonoBehaviour
    {
 
        public int Fps { get; private set; }
        [SerializeField] private float fpsRefreshTime = 1f;
 
        private WaitForSecondsRealtime _waitForSecondsRealtime;
 
        private void OnValidate()
        {
 
            SetWaitForSecondsRealtime();
        }
 
        private IEnumerator Start()
        {
 
            SetWaitForSecondsRealtime();
 
            while (true)
            {
 
                fps = (int)(1 / Time.unscaledDeltaTime);
                yield return _waitForSecondsRealtime;
            }
        }
 
        private void SetWaitForSecondsRealtime()
        {
 
            _waitForSecondsRealtime = new WaitForSecondsRealtime(fpsRefreshTime);
        }
    }
}