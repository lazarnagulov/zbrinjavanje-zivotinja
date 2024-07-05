using System;
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
        public const string CreatedPost = "The post was successfully created.";
        public const string UpdateInfo = "The Association was successfully updated.";
        public const string CreatedPostFail = "An error occured on creating post.";
        public const string UpdateInfoFail = "An error occured on updating info.";
        public static string CannotHidePostMessage(string state) => $"Cannot hide the post in {state} state!";

        public static void SuccessfulHiddenPost() 
            => MessageBox.Show(HiddenPost, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);

        public static void SuccessfullyDisplayedPost()
            => MessageBox.Show(DisplayedPost, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);

        public static void SuccessfullyUpdatedInfo()
            => MessageBox.Show(UpdateInfo, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);

        public static void CannotHidePost(string state)
            => MessageBox.Show(CannotHidePostMessage(state), ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);

        public static void SuccessfullyCreatedPost()
            => MessageBox.Show(CreatedPost, NotificationCaption, MessageBoxButton.OK, MessageBoxImage.Information);

        public static void PostCreationError()
            => MessageBox.Show(CreatedPostFail, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);

        public static void UpdateInfoError()
            => MessageBox.Show(UpdateInfoFail, ErrorCaption, MessageBoxButton.OK, MessageBoxImage.Error);

    }
}
