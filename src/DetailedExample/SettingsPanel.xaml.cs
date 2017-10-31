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
    /// Interaction logic for SettingsPanel.xaml
    /// </summary>
    /// 
    [AlphaDrive.Windows.Controls.Sort(ExtensionPriorities.Settings)]
    [System.ComponentModel.DesignTimeVisible(false)] //We don't want this control to show up in the VS toolbox.
    public partial class SettingsPanel : AlphaDrive.Windows.Controls.SettingsControl {
        public SettingsPanel() {
            InitializeComponent();
        }

        public override void LoadSettings() {
            var MySettings = Settings.Default;

            chkEnableMatterNoteFolders.IsChecked = MySettings.MatterNotesExtension_Enabled;
        }

        public override void SaveSettings() {
            var MySettings = Settings.Default;

            MySettings.MatterNotesExtension_Enabled = chkEnableMatterNoteFolders.IsChecked ?? true;

            MySettings.Save();
        }

    }
}
