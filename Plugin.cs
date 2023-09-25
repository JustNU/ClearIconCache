using BepInEx;
using BepInEx.Configuration;
using System.IO;
using UnityEngine;


namespace ClearIconCache
{
    [BepInPlugin("com.JustNU.ClearIconCache", "JustNU-ClearIconCache", "1.0.0")]
    public class Plugin : BaseUnityPlugin
    {
        // create config ent
        public static ConfigEntry<bool> ConfClearIconCache;

        private void Awake()
        {
            // set up config
            ConfClearIconCache = Config.Bind("Core", "Clears Icon Cache on game start-up", false, "Clears icon cache");

            // Plugin startup logic
            Logger.LogInfo($"Plugin com.JustNU.ClearIconCache is loading");

            // clean icon cache
            if (Plugin.ConfClearIconCache.Value == true)
            {
                System.IO.DirectoryInfo IconCachePath = new DirectoryInfo(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live"));
                System.IO.DirectoryInfo ClothingCachePath = new DirectoryInfo(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live\\Clothing"));

                if (Directory.Exists(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live"))) 
                {
                    foreach (FileInfo file in IconCachePath.GetFiles())
                    {
                        file.Delete();
                    }
                }

                if (Directory.Exists(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live\\Clothing")))
                {
                    foreach (FileInfo file in ClothingCachePath.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
        }
    }
}
