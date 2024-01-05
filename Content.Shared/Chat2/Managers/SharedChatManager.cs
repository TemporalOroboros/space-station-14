using Robust.Shared.Network;

namespace Content.Shared.Chat2.Managers;

/// <summary>
/// <para>The system responsible for handling out-of-simulation chat.</para>
/// </summary>
/// <seealso cref="ISharedChatManager"/>
public abstract partial class SharedChatManager : ISharedChatManager
{
    [Dependency] protected readonly INetManager NetManager = default!;

    public virtual void Initialize()
    {
        IoCManager.InjectDependencies(this);
    }

    public virtual void Shutdown() { }
}
