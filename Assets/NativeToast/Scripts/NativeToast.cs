using UnityEngine;

namespace Toast
{
    public class NativeToast : MonoBehaviour
    {

        public static NativeToast Instance;

        #region UnityBuiltInsMethods
        private void OnEnable()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                if (Instance != this)
                {
                    Destroy(gameObject, 0);
                }
            }
        }

        private void OnDisable()
        {
            if (Instance == this)
            {
                Instance = null;
            }
        }
        #endregion

#if !UNITY_EDITOR && UNITY_ANDROID
        /// <summary>
        /// Shows a native toast on an android device
        /// </summary>
        /// <param name="message">Message to be shown in the toast</param>
        public void ShowToast(string message)
        {
            AndroidJavaClass unityPlayer = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
            AndroidJavaObject unityActivity = unityPlayer.GetStatic<AndroidJavaObject>("currentActivity");

            if (unityActivity != null)
            {
                AndroidJavaClass toastClass = new AndroidJavaClass("android.widget.Toast");

                object[] toastParams = new object[3];
                toastParams[0] = unityActivity;
                toastParams[1] = message;
                toastParams[2] = toastClass.GetStatic<int>("LENGTH_LONG");

                unityActivity.Call("runOnUiThread", new AndroidJavaRunnable(() =>
                {
                    AndroidJavaObject toastObject = toastClass.CallStatic<AndroidJavaObject>("makeText", toastParams);
                    toastObject.Call("show");
                }));
            }
        }
#else
        public void ShowToast(string message)
        {
            Debug.Log($"Toast: {message}");
        }
#endif
    }
}