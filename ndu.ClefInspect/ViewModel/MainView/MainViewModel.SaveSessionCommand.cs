﻿using System.Windows;

namespace ndu.ClefInspect.ViewModel.MainView
{
    public partial class MainViewModel
    {
        private class SaveSessionCommand : AbstractCanAlwaysExecuteCommand
        {
            private readonly MainViewModel _mainViewModel;

            public SaveSessionCommand(MainViewModel mainViewModel)
            {
                _mainViewModel = mainViewModel;
            }

            public override void Execute(object? parameter)
            {
                List<string> openFiles = new();
                foreach (ClefTab c in _mainViewModel.ClefTabs)
                {
                    openFiles.Add(c.ClefViewModel.FilePath);
                }
                _mainViewModel.Settings.SetSessionFiles(openFiles);
                try
                {
                    _mainViewModel.Settings.Persist();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message, "Error saving settings", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }
    }
}
