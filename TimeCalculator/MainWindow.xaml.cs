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
            conversion.CalculateTime();       //Call the method to calculate the number of D, M, H, S
        }
    }
}
