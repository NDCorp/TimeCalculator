using System.Windows;

namespace TimeCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MVTIME conversion;
        public MainWindow()
        {
            InitializeComponent();
            conversion = new MVTIME();
            DataContext = conversion;
        }

        private void btnCalcTime_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtNbrSec.Text) && int.TryParse(txtNbrSec.Text, out var valid))
                conversion.ConvertTime();       //nbrSecEmpty = false
            else
                conversion.ConvertTime(true);   //nbrSecEmpty = true
        }
    }
}
