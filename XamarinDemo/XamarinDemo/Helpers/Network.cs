using Xamarin.Essentials;

namespace XamarinDemo.Helpers
{
    public static class Network
    {
        public static bool IsNetworkAvailable()
        {
            if (Connectivity.NetworkAccess == NetworkAccess.ConstrainedInternet || Connectivity.NetworkAccess == NetworkAccess.None)
            {
                return false;
            }
            if (Connectivity.NetworkAccess == NetworkAccess.Internet)
            {
                return true;
            }
            return false;
        }
    }
}
