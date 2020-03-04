namespace XamarinDemo.Common
{
    public static class Session
    {
        public static void Set(string key, object value)
        {
            App.Current.Properties[key] = value;
        }

        public static object Get(string key)
        {
            if (App.Current.Properties.ContainsKey(key))
            {
                return App.Current.Properties[key];
            }
            return null;
        }

        public static void Clear()
        {
            App.Current.Properties.Remove(AppConstants.Constants.Token);
            App.Current.Properties.Remove(AppConstants.Constants.UserId);
            App.Current.Properties.Remove(AppConstants.Constants.RoleId);
        }
    }
}
