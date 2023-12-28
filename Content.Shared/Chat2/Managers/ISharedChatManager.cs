namespace Content.Shared.Chat2.Managers;

/// <summary>
/// <para>Defines the public API for the system used to manage out-of-simulation chat.</para>
/// </summary>
public partial interface ISharedChatManager
{
    /// <summary>
    /// Prepares the chat system to be able to handle chat messages.
    /// </summary>
    public void Initialize();

    /// <summary>
    /// Prepares the chat manager for disposal.
    /// </summary>
    public void Shutdown();
}
