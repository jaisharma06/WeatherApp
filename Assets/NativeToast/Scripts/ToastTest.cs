using UnityEngine;

namespace Toast
{
    public class ToastTest : MonoBehaviour
    {
        public void OnClickShowToast()
        {
            NativeToast.Instance.ShowToast("This is just a test toast message.");
        }
    }
}