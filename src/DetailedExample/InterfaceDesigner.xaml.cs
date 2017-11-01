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
    /// The InterfaceDesigner.xaml provides a nice surface/container to create our XAML objects and contain our code that
    /// will get grafted into the UI.  An important thing about the InterfaceDesigner classes is that generally you won't graft
    /// the entire control into a parent.  In this case, we only graft the items that are children of "SourceContainer".
    /// If I wanted to graft in multiple components that work together, I should do that through one InterfaceDesigner+InterfaceExtension.
    /// If I wanted to graft in multiple independent components, I should create an InterfaceDesigner+InterfaceExtension for each one.
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
