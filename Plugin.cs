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
        public static ConfigEntry<bool> ConfClearItemIconCache;
        public static ConfigEntry<bool> ConfClearClothingIconCache;
        public static ConfigEntry<bool> ConfClearPlayerIconCache;

        private void Awake()
        {
            // set up config
            ConfClearItemIconCache = Config.Bind("Core", "Clear item icon cache", false, "Clear Item Icon Cache on game start-up");
            ConfClearClothingIconCache = Config.Bind("Core", "Clear clothing icon cache", false, "Clear Clothing Icon Cache on game start-up");
            ConfClearPlayerIconCache = Config.Bind("Core", "Clear player icon cache", false, "Clear Player Icon Cache on game start-up");

            // Plugin startup logic
            Logger.LogInfo($"Plugin com.JustNU.ClearIconCache is loading");

            // clean icon cache
            if (Plugin.ConfClearItemIconCache.Value == true)
            {
                System.IO.DirectoryInfo IconCachePath = new DirectoryInfo(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live"));
                
                if (Directory.Exists(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live"))) 
                {
                    foreach (FileInfo file in IconCachePath.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }

            if (Plugin.ConfClearClothingIconCache.Value == true)
            {
                System.IO.DirectoryInfo ClothingCachePath = new DirectoryInfo(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live\\Clothing"));

                if (Directory.Exists(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live\\Clothing")))
                {
                    foreach (FileInfo file in ClothingCachePath.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }

            if (Plugin.ConfClearClothingIconCache.Value == true)
            {
                System.IO.DirectoryInfo PlayerIconCachePath = new DirectoryInfo(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live\\PlayerIcons"));

                if (Directory.Exists(Path.Combine(Application.temporaryCachePath, "Icon Cache\\live\\PlayerIcons")))
                {
                    foreach (FileInfo file in PlayerIconCachePath.GetFiles())
                    {
                        file.Delete();
                    }
                }
            }
        }
    }
}
