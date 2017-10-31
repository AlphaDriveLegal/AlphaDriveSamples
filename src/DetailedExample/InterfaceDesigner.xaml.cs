using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DetailedExample {
    /// <summary>
    /// Interaction logic for InterfaceDesigner.xaml
    /// </summary>
    public partial class InterfaceDesigner : UserControl {
        public InterfaceDesigner() {
            InitializeComponent();
        }


        private void mnuShowFolders_Click(object sender, RoutedEventArgs e) {
            e.Handled = true;

            var MySettings = Settings.Default;
            MySettings.MatterNotesExtension_Enabled = mnuShowFolders.IsChecked;
            MySettings.Save();

            AlphaDrive.Windows.Controls.MessageBox.Create()
                .WithTitle("Setting Updated")
                .WithMessage($"{nameof(MySettings.MatterNotesExtension_Enabled)} = {MySettings.MatterNotesExtension_Enabled}")
                .RunOk(mnuShowFolders)
                ;

        }

        private void mnuLaunchDialog_Click(object sender, RoutedEventArgs e) {
            e.Handled = true;

            AlphaDrive.Windows.Controls.ThreadedWindow.ShowDialog<InterfaceDialog>();
        }

        private void mnuMainGroup_SubmenuOpened(object sender, RoutedEventArgs e) {
            e.Handled = true;

            var MySettings = Settings.Default;
            mnuShowFolders.IsChecked = MySettings.MatterNotesExtension_Enabled;
        }
    }
}
