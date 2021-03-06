﻿#nullable enable
using System;
using System.Collections.Generic;
using System.Linq;
using Robust.Client.AutoGenerated;
using Robust.Client.Player;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.IoC;

namespace Content.Client.UserInterface.AdminMenu.CustomControls
{
    [GenerateTypedNameReferences]
    public partial class PlayerListControl : VBoxContainer
    {
        private List<IPlayerSession>? _data;

        public event Action<IPlayerSession?>? OnSelectionChanged;

        protected override void EnteredTree()
        {
            // Fill the Option data
            _data = IoCManager.Resolve<IPlayerManager>().Sessions.ToList();
            PopulateList();
            PlayerItemList.OnItemSelected += PlayerItemListOnOnItemSelected;
            PlayerItemList.OnItemDeselected += PlayerItemListOnOnItemDeselected;
            FilterLineEdit.OnTextChanged += FilterLineEditOnOnTextEntered;
        }

        private void FilterLineEditOnOnTextEntered(LineEdit.LineEditEventArgs obj)
        {
            PopulateList(FilterLineEdit.Text);
        }

        private static string GetDisplayName(IPlayerSession session)
        {
            return $"{session.Name} ({session.AttachedEntity?.Name})";
        }

        private void PlayerItemListOnOnItemSelected(ItemList.ItemListSelectedEventArgs obj)
        {
            var selectedPlayer = (IPlayerSession) obj.ItemList[obj.ItemIndex].Metadata!;
            OnSelectionChanged?.Invoke(selectedPlayer);
        }

        private void PlayerItemListOnOnItemDeselected(ItemList.ItemListDeselectedEventArgs obj)
        {
            OnSelectionChanged?.Invoke(null);
        }

        private void PopulateList(string? filter = null)
        {
            // _data should never be null here
            if (_data == null)
                return;
            PlayerItemList.Clear();
            foreach (var session in _data)
            {
                var displayName = GetDisplayName(session);
                if (!string.IsNullOrEmpty(filter) &&
                    !displayName.ToLowerInvariant().Contains(filter.Trim().ToLowerInvariant()))
                {
                    continue;
                }

                PlayerItemList.Add(new ItemList.Item(PlayerItemList)
                {
                    Metadata = session,
                    Text = displayName
                });
            }
        }

        public void ClearSelection()
        {
            PlayerItemList.ClearSelected();
        }
    }
}
