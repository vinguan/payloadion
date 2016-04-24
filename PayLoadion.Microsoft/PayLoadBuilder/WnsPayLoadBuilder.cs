using System;
using System.Linq.Expressions;
using System.Threading.Tasks;
using NotificationsExtensions.Badges;
using NotificationsExtensions.Toasts;
using PayLoadion.Builder;

namespace PayLoadion.Microsoft.PayLoadBuilder
{
    public class WnsPayLoadBuilder : IBuilder<string>
    {
        public string Build()
        {
            var badgeNumericNotification = new BadgeGlyphNotificationContent(GlyphValue.Activity);

            var toastNotification = new NotificationsExtensions.Toasts.ToastContent()
            {
                Visual = new ToastVisual()
                {
                  
                }
            };

            var x = new NotificationsExtensions.Toasts.ToastActionsCustom() {};

            toastNotification.Actions = new ToastActionsSnoozeAndDismiss() {};

            toastNotification.Visual.InlineImages.Add(new ToastImage() { Source = new ToastImageSource("ms-appx:///Images/defaulticon.png") });

            return toastNotification.GetContent();
        }

        public Task<string> BuildAsync()
        {
            throw new NotImplementedException();
        }
    }

    public class CustomAction : IToastActions
    {
        
    }
}