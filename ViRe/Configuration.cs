﻿using System;
using System.IO;
using System.Reflection;
using GTA.UI;
using Newtonsoft.Json;

namespace ViRe;

/// <summary>
/// The configuration of the mod.
/// </summary>
internal class Configuration
{
    #region Fields

    private static readonly string path = Path.ChangeExtension(new Uri(Assembly.GetAssembly(typeof(Configuration)).CodeBase).LocalPath, ".json");
    
    #endregion
    
    #region Properties
    

    #endregion
    
    #region Functions
    
    /// <summary>
    /// Saves the configuration.
    /// </summary>
    public void Save()
    {
        string contents = JsonConvert.SerializeObject(this);
        File.WriteAllText(path, contents);
    }
    /// <summary>
    /// Gets the current configuration.
    /// </summary>
    /// <returns>The current configuration, or a new configuration if is not present.</returns>
    public static Configuration Load()
    {
        try
        {
            string contents = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<Configuration>(contents);
        }
        catch (JsonSerializationException e)
        {
            Notification.Show($"~r~Error~w~: Unable to load config: {e.Message}");
            return new Configuration();
        }
        catch (FileNotFoundException)
        {
            Configuration config = new Configuration();
            config.Save();
            return config;
        }
    }
    
    #endregion
}
