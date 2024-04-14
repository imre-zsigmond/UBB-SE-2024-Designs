using System;
using System.Windows;
using System.Windows.Controls;

namespace ISSLab.Services
{
    public static class NavigationService
    {
        public static void NavigateTo(UserControl target)
        {
            Window parentWindow = Window.GetWindow(target);

            if (parentWindow != null)
            {
                parentWindow.Content = target;
            }
            else
            {
                throw new InvalidOperationException("Parent window not found.");
            }
        }
    }
}
