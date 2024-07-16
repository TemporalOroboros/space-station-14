using Robust.Shared.GameStates;

namespace Content.Shared.Temperature.Components;

[RegisterComponent, NetworkedComponent, AutoGenerateComponentState]
public sealed partial class ContainerTemperatureDamageThresholdsComponent : Component
{
    [DataField, AutoNetworkedField, ViewVariables(VVAccess.ReadWrite)]
    public float? HeatDamageThreshold;

    [DataField, AutoNetworkedField, ViewVariables(VVAccess.ReadWrite)]
    public float? ColdDamageThreshold;
}
