/* TEAM ONE: TIME CALCULATOR
 * Shane Frost - 5600861
 * Jeewan Kalia - 8032997
 * Mireille Tabod Epse Nubaga - 6542864
 * Abhishek Sharma - 7719818
 * Edward Barber - 7925969
 * Joseph Kasumba - 8147696 
 */

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

        private void BtnCalcTime_Click(object sender, RoutedEventArgs e)
        {
            conversion.CalculateTime();       //Call the method to calculate the number of D, M, H, S
        }
    }
}
