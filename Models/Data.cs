namespace EventApp.Models
{
	internal class Data
    {
        public static int Access;
		public static bool IsManager() => Access == 0;
		public static bool IsDirector() => Access == 1;
		public static string CurrentDirectory { get; set; } = "EventApp";
		public static string CurrentConfigFile { get; set; } = "config";
		public static string CurrentConfigExtension { get; set; } = "json";
	}
}
