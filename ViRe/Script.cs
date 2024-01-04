using System;
using GTA;
using LemonUI;
using LemonUI.Menus;

namespace ViRe;

/// <summary>
/// The main class of the ViRe script.
/// </summary>
public class ViRe : Script
{
    #region Fields

    private ObjectPool pool = new ObjectPool();
    private Configuration config = Configuration.Load();
    private NativeMenu menuRegister = new NativeMenu("", "Register", "Register to work in ViRe.");
    private NativeMenu menuServices = new NativeMenu("", "Available", "The services you can provide in your area.");
    private NativeMenu menuCurrent = new NativeMenu("", "Current", "Manages your current service.");
    
    #endregion
    
    #region Constructors

    public ViRe()
    {
        pool.Add(menuRegister);
        pool.Add(menuServices);
        pool.Add(menuCurrent);
        
        Tick += OnTick;
    }
    
    #endregion
    
    #region Event Functions

    private void OnTick(object sender, EventArgs e)
    {
        pool.Process();
    }

    #endregion
}
