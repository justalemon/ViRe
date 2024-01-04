using System;
using GTA;
using LemonUI;

namespace ViRe;

/// <summary>
/// The main class of the ViRe script.
/// </summary>
public class ViRe : Script
{
    #region Fields

    private ObjectPool pool = new ObjectPool();
    private Configuration config = Configuration.Load();
    
    #endregion
    
    #region Constructors

    public ViRe()
    {
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
