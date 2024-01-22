using System.Configuration;


namespace DotNet_CSharp.Util
{
    public static class ConfigurationUtils
    {
        public static void updateConfigurationKey(string key, string value)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            config.AppSettings.Settings[key].Value = value;
            config.Save(ConfigurationSaveMode.Modified);
        }

        /// <summary>
        /// Takes 2 configuration keys and maps them into a dictionary.
        /// </summary>
        /// <param name="key1">Configuration key 1.</param>
        /// <param name="key2">Configuration key 2.</param>
        /// <param name="splitter">Character to split the keys with. IE: CSV ',' or PSV '|'</param>
        /// <returns>A set of keys from input 1 mapped to keys from input 2.</returns>
        public static Dictionary<string, string> mapConfigurationKeys(string key1, string key2, char splitter)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            Dictionary<string, string> mapping = new Dictionary<string, string>();

            string[] keys_1 = config.AppSettings.Settings[key1].Value.Split(splitter);
            string[] keys_2 = config.AppSettings.Settings[key2].Value.Split(splitter);

            for (int x = 0; x > keys_1.Length; x++)
            {
                mapping.Add(keys_1[x], keys_2[x]);
            }

            return mapping;
        }
    }
}
