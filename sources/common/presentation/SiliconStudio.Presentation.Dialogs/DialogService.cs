﻿// Copyright (c) 2014 Silicon Studio Corp. (http://siliconstudio.co.jp)
// This file is distributed under GPL v3. See LICENSE.md for details.
using System;
using System.Windows;
using System.Windows.Threading;
using SiliconStudio.Presentation.Services;
using MessageBoxButton = SiliconStudio.Presentation.Services.MessageBoxButton;
using MessageBoxImage = SiliconStudio.Presentation.Services.MessageBoxImage;
using MessageBoxResult = SiliconStudio.Presentation.Services.MessageBoxResult;

namespace SiliconStudio.Presentation.Dialogs
{
    public class DialogService : IDialogService
    {
        private readonly Dispatcher dispatcher;

        public DialogService(Dispatcher dispatcher, Window parentWindow)
        {
            if (dispatcher == null) throw new ArgumentNullException("dispatcher");
            this.dispatcher = dispatcher;
            ParentWindow = parentWindow;
        }

        public Window ParentWindow { get; private set; }

        public IFileOpenModalDialog CreateFileOpenModalDialog()
        {
            return new FileOpenModalDialog(dispatcher, ParentWindow);
        }

        public IFolderOpenModalDialog CreateFolderOpenModalDialog()
        {
            return new FolderOpenModalDialog(dispatcher, ParentWindow);
        }

        public IFileSaveModalDialog CreateFileSaveModalDialog()
        {
            return new FileSaveModalDialog(dispatcher, ParentWindow);
        }

        public MessageBoxResult ShowMessageBox(string message, string caption, MessageBoxButton button, MessageBoxImage image)
        {
            return (MessageBoxResult)MessageBox.Show(message, caption, (System.Windows.MessageBoxButton)button, (System.Windows.MessageBoxImage)image);
        }

        public void CloseCurrentWindow(bool? dialogResult = null)
        {
            // Window.DialogResult setter will throw an exception when the window was not displayed with ShowDialog, even if we're setting null.
            if (ParentWindow.DialogResult != dialogResult)
            {
                ParentWindow.DialogResult = dialogResult;
            }
            ParentWindow.Close();
            ParentWindow = null;
        }
    }
}