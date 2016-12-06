// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace QuizApp.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
	    private static ISettings AppSettings
	    {
	      get
	      {
	        return CrossSettings.Current;
	      }
	    }

	    #region Setting Constants

	    private const string SettingsKey = "settings_key";
	    private static readonly string SettingsDefault = string.Empty;

		private const string AdminUserNameKey = "username_key";
		private static readonly string AdminUserNameDefault = string.Empty;

		private const string AdminUserPwdKey = "pwd_key";
		private static readonly string AdminUserPwdDefault = string.Empty;

	    #endregion


	    public static string GeneralSettings
	    {
	      get
	      {
	        return AppSettings.GetValueOrDefault<string>(SettingsKey, SettingsDefault);
	      }
	      set
	      {
	        AppSettings.AddOrUpdateValue<string>(SettingsKey, value);
	      }
	    }

		public static string AdminUserName
		{
			get { return AppSettings.GetValueOrDefault<string>(AdminUserNameKey, AdminUserNameDefault); }
			set { AppSettings.AddOrUpdateValue<string>(AdminUserNameKey, value); }
		}

		public static string AdminUserPwd
		{
			get { return AppSettings.GetValueOrDefault<string>(AdminUserPwdKey, AdminUserPwdDefault); }
			set { AppSettings.AddOrUpdateValue<string>(AdminUserPwdKey, value); }
		}

		public static bool IsFirstStart
		{
			get {

				bool isUserNull = string.IsNullOrEmpty(AdminUserName);
				bool isPwdNull = string.IsNullOrEmpty(AdminUserPwd);

				return isUserNull || isPwdNull;
			}
		}


	}
}