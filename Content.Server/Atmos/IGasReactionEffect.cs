using Content.Server.Atmos.EntitySystems;
using Content.Server.Atmos.Reactions;

namespace Content.Server.Atmos
{
    [ImplicitDataDefinitionForInheritors]
    public partial interface IGasReactionEffect
    {
        ReactionResult React<THolder>(GasMixture mixture, THolder? holder, AtmosphereSystem atmosphereSystem);
    }
}
