using BatDemo.Debugging;

namespace BatDemo
{
    public class BatDemoConsts
    {
        public const string LocalizationSourceName = "BatDemo";

        public const string ConnectionStringName = "Default";
        public const string ConnectionStringNameTRG = "OracleDbTRG";

        public const bool MultiTenancyEnabled = false;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "20bf23e59c094c7a82bf7aa022bce862";

        public const int OTP_MAX_LENGHT = 6;
    }
}








