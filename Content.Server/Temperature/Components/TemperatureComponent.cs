using Content.Server.Temperature.Systems;
using Content.Shared.Atmos;

namespace Content.Server.Temperature.Components;

/// <summary>
/// Handles the temperature and heat capacity of an entity.
/// </summary>
[RegisterComponent]
public sealed partial class TemperatureComponent : Component
{
    /// <summary>
    /// Surface temperature which is modified by the environment.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float CurrentTemperature = Atmospherics.T20C;

    /// <summary>
    /// Heat capacity per kg of mass.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float SpecificHeat = 50f;

    /// <summary>
    /// How well does the air surrounding you merge into your body temperature?
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float AtmosTemperatureTransferEfficiency = 0.1f;

    [Obsolete("Use system method")]
    public float HeatCapacity
    {
        get
        {
            return IoCManager.Resolve<IEntityManager>().System<TemperatureSystem>().GetHeatCapacity(Owner, this);
        }
    }
}
