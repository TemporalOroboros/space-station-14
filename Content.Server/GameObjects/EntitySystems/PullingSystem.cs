﻿using Content.Server.GameObjects.Components.Pulling;
using Content.Shared.GameObjects.EntitySystemMessages.Pulling;
using Content.Shared.GameObjects.EntitySystems;
using JetBrains.Annotations;
using Robust.Server.GameObjects;

namespace Content.Server.GameObjects.EntitySystems
{
    [UsedImplicitly]
    public class PullingSystem : SharedPullingSystem
    {
        public override void Initialize()
        {
            base.Initialize();

            UpdatesAfter.Add(typeof(PhysicsSystem));

            SubscribeLocalEvent<PullableComponent, PullableMoveMessage>(OnPullableMove);
            SubscribeLocalEvent<PullableComponent, PullableStopMovingMessage>(OnPullableStopMove);
        }

        public override void Shutdown()
        {
            base.Shutdown();

            UnsubscribeLocalEvent<PullableComponent, PullableMoveMessage>(OnPullableMove);
            UnsubscribeLocalEvent<PullableComponent, PullableStopMovingMessage>(OnPullableStopMove);
        }
    }
}
