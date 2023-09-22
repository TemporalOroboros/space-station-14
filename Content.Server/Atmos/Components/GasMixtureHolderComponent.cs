namespace Content.Server.Atmos.Components
{
    [RegisterComponent]
    public sealed partial class GasMixtureHolderComponent : Component
    {
        [DataField("air")] public GasMixture Air { get; set; } = new GasMixture();
    }
}
