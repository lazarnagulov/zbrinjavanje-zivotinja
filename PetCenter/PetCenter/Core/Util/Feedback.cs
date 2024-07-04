﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PetCenter.Core.Util
{
    public static class Feedback
    {
        public const string NotificationCaption = "Notification";
        public const string ErrorCaption = "Error";

        public const string HiddenPost = "The post was successfully hidden.";
        public const string DisplayedPost = "The post was successfully displayed.";
        public const string AddedPost = "The post was successfully created.";
        public static string CannotHidePostMessage(string state) => $"Cannot hide the post in {state} state!";



        public static void SuccessfulHiddenPost() 
            => MessageBox.Show(HiddenPost, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);

        public static void SuccessfullyDisplayedPost()
            => MessageBox.Show(DisplayedPost, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);

        public static void CannotHidePost(string state)
            => MessageBox.Show(CannotHidePostMessage(state), ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);

        public static void SuccessfullyCreatedPost()
            => MessageBox.Show(AddedPost, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);


    }
}
