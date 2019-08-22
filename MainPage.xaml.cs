using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tabbar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private Image[] indicators;
        private Button[] tabs;

        public MainPage()
        {
            this.InitializeComponent();

            this.indicators = new Image[] {
                this.firstIndicator,
                this.secondIndicator,
                this.thirdIndicator,
                this.forthIndicator
            };

            this.tabs = new Button[] {
                this.FirstBtn,
                this.SecondBtn,
                this.ThirdBtn,
                this.ForthBtn
            };
        }

        private void FirstButton(object sender, RoutedEventArgs args)
        {
            this.SetupIndicator(this.firstIndicator);
            this.SetupButton(this.FirstBtn);
        }

        private void SecondButton(object sender, RoutedEventArgs args)
        {
            this.SetupIndicator(this.secondIndicator);
            this.SetupButton(this.SecondBtn);
        }

        private void ThirdButton(object sender, RoutedEventArgs args)
        {
            this.SetupIndicator(this.thirdIndicator);
            this.SetupButton(this.ThirdBtn);
        }


        private void FothButton(object sender, RoutedEventArgs args)
        {
            this.SetupIndicator(this.forthIndicator);
            this.SetupButton(this.ForthBtn);
        }

        /// <summary>
        /// Setup Indicator Visibility
        /// </summary>
        /// <param name="indicator"></param>
        private void SetupIndicator(Image indicator)
        {
            indicator.Opacity = 1;

            foreach(Image image in indicators)
            {
                if (image != indicator)
                {
                    image.Opacity = 0;
                }
            }
        }

        /// <summary>
        /// Setup Tab Background and Text Color
        /// </summary>
        /// <param name="btn"></param>
        private void SetupButton(Button btn)
        {
            btn.Foreground = new SolidColorBrush(Colors.White);
            btn.Background = new SolidColorBrush(Colors.Black);

            foreach(Button button in tabs)
            {
                if (button != btn)
                {
                    button.Foreground = new SolidColorBrush(Colors.Black);
                    button.Background = new SolidColorBrush(Colors.White);
                }
            }
        }
    }
}
