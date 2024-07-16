using Content.Shared.Alert;
using Content.Shared.Damage;
using Content.Shared.FixedPoint;
using Robust.Shared.Prototypes;

namespace Content.Server.Temperature.Components;

/// <summary>
/// Makes it possible for an entity to take damage from being too hot or too cold. Must be paired with a <see cref="TemperatureComponent"/> to function.
/// </summary>
[RegisterComponent]
public sealed partial class TemperatureDamageThresholdsComponent : Component
{
    /// <summary>
    /// The temperature above which this entity will start to take damage from overheating.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float HeatDamageThreshold = 360f;

    /// <summary>
    /// The temperature below which this entity will start to take damage from overcooling.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float ColdDamageThreshold = 260f;

    /// <summary>
    /// Overrides <see cref="HeatDamageThreshold"/> if the entity's within a parent with the <see cref="TemperatureDamageThresholdsComponent"/> component.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float? ParentHeatDamageThreshold;

    /// <summary>
    /// Overrides <see cref="ColdDamageThreshold"/> if the entity's within a parent with the <see cref="TemperatureDamageThresholdsComponent"/> component.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public float? ParentColdDamageThreshold;

    /// <summary>
    /// The base amount of damage the entity will take per second when it is too hot.
    /// This is scaled logistically according to how much the entity is overheating.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public DamageSpecifier HeatDamage = new();

    /// <summary>
    /// The base amount of damage the entity will take per second when it is too cold.
    /// This is scaled logistically according to how much the entity is overcooling.
    /// </summary>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public DamageSpecifier ColdDamage = new();

    /// <summary>
    /// The maximum multiple of <see cref="HeatDamage"/> or <see cref="ColdDamage"/> this entity will take per second.
    /// </summary>
    /// <remarks>
    /// Okay it genuinely reaches this basically immediately for a plasma fire.
    /// </remarks>
    [DataField, ViewVariables(VVAccess.ReadWrite)]
    public FixedPoint2 DamageCap = FixedPoint2.New(8);

    /// <summary>
    /// Used to keep track of when damage starts/stops. Useful for logs.
    /// </summary>
    [DataField]
    public bool TakingDamage = false;

    /// <summary>
    /// The alert shown to this entity when it is too hot.
    /// </summary>
    [DataField]
    public ProtoId<AlertPrototype> HotAlert = "Hot";

    /// <summary>
    /// The alert shown to this entity when it is too cold.
    /// </summary>
    [DataField]
    public ProtoId<AlertPrototype> ColdAlert = "Cold";
}
