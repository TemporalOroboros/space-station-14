using Robust.Shared.Network;

namespace Content.Shared.Chat2.Managers;

/// <summary>
/// <para>The system responsible for handling out-of-simulation chat.</para>
/// </summary>
/// <seealso cref="ISharedChatManager"/>
public abstract partial class SharedChatManager : ISharedChatManager
{
    public virtual void Initialize() { }

    public virtual void Shutdown() { }
}
