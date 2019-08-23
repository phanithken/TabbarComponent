using System.Collections.Generic;
using System.Linq;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Tabbar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<Image> Indicators;
        private List<Button> Tabs;
        private double TotalWidth;
        private int TabAmount;

        public MainPage()
        {
            this.InitializeComponent();

            this.TotalWidth = this.Container.Width - 2;
            this.TabAmount = VisualTreeHelper.GetChildrenCount(this.Container);
            this.Tabs = new List<Button>();
            this.Indicators = new List<Image>();

            // to add new tab, we have to generate tab from this method
            var firstBtn = this.GenerateTabButton("商品マップ");
            var secondBtn = this.GenerateTabButton("ユーザーレビュー");
            var thirdBtn = this.GenerateTabButton("商品情報");
            var forthBtn = this.GenerateTabButton("オンラインストア在庫");

            // and add it as subview
            this.AddNewTab(firstBtn);
            this.AddNewTab(secondBtn);
            //this.AddNewTab(thirdBtn);
            //this.AddNewTab(forthBtn);

            // initialize first tab
            this.InitTab();
        }

        /// <summary>
        /// Tab Click callback
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="args"></param>
        private void TabClickCallback(object sender, RoutedEventArgs args)
        {
            var btn = (Button)sender;
            this.SetupButton(btn);

            // set indicator margin
            var i = 0;
            foreach(var button in Tabs)
            {
                if (button == btn)
                {
                    var tabwidth = (this.TotalWidth / this.TabAmount);
                    double acc = 0;

                    if (i > 0)
                    {
                        acc = (tabwidth / 2) + (tabwidth * i);
                    } else
                    {
                        acc = (tabwidth / 2);
                    }

                    this.Indicator.Margin = new Thickness(acc, 0, 0, 0);
                }
                i++;
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

            foreach(Button button in Tabs)
            {
                if (button != btn)
                {
                    button.Foreground = new SolidColorBrush(Colors.Black);
                    button.Background = new SolidColorBrush(Colors.White);
                }
            }
        }

        /// <summary>
        /// Init to set up width, style and margin of first tab
        /// </summary>
        private void InitTab() {
            this.SetupButton(this.Tabs.First());

            var minMargin = (this.TotalWidth / this.TabAmount) / 2;
            this.Indicator.Margin = new Thickness(minMargin, 0, 0, 0);
        }

        /// <summary>
        /// set up width of each tab
        /// </summary>
        private void SetupWidth()
        {
            var width = this.TotalWidth / this.TabAmount;

            // set up button width
            foreach(var button in Tabs)
            {
                button.Width = width;
            }
        }

        /// <summary>
        /// Generate Tab
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        private Button GenerateTabButton(string title)
        {
            Button btn = new Button();
            btn.Content = title;
            btn.Style = (Style)Application.Current.Resources["BtnStyle"];
            btn.Height = 50;
            btn.Click += this.TabClickCallback;
            btn.BorderBrush = new SolidColorBrush(Colors.Black);
            btn.BorderThickness = new Thickness(1, 1, 1, 1);
            btn.Foreground = new SolidColorBrush(Colors.Black);
            btn.Background = new SolidColorBrush(Colors.White);
            return btn;
        }

        /// <summary>
        /// Add new Tab
        /// </summary>
        /// <param name="tab"></param>
        private void AddNewTab(Button tab)
        {
            // add button to tabs
            this.Container.Children.Add(tab);

            // add and re-calculate tab width
            this.Tabs.Add(tab);
            this.TabAmount += 1;
            this.SetupWidth();
        }
    }
}
