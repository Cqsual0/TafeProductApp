using System;
using System.Windows;
using System.Windows.Controls;

namespace ProductApps
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Product cProduct;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CalculateTotalCharge(TextBox totalChargeTextBlock, decimal totalPayment)
        {
            decimal totalCharge = totalPayment + 25m;
            totalChargeTextBlock.Text = totalCharge.ToString("C2");
        }

        private decimal UpdateWrapCharge(decimal totalPayment)
        {
            decimal wrapCharge = totalPayment + 25.00m + 5.00m; // TotalPayment + $25.00 + $5.00
            wrapChargeTextBox.Text = wrapCharge.ToString("C2");
            return wrapCharge;
        }

        private void UpdateGSTCharge(decimal totalWithWrap)
        {
            decimal gstCharge = totalWithWrap * 0.10m; // 10% of totalWithWrap
            gstChargeTextBox.Text = gstCharge.ToString("C2");
        }

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                cProduct = new Product(Convert.ToDecimal(priceTextBox.Text), Convert.ToInt16(quantityTextBox.Text));
                cProduct.calTotalPayment();
                totalPaymentTextBlock.Text = Convert.ToString(cProduct.TotalPayment);

                // Calculate and display the total charge
                CalculateTotalCharge(totalChargeTextBox, cProduct.TotalPayment);

                // Calculate and display the wrap charge and get the total with wrap
                decimal totalWithWrap = UpdateWrapCharge(cProduct.TotalPayment);

                // Calculate and display the GST charge on the total with wrap
                UpdateGSTCharge(totalWithWrap);
            }
            catch (FormatException)
            {
                MessageBox.Show("Enter data again", "Data Entry Error");
            }
        }

        private void clearButton_Click(object sender, RoutedEventArgs e)
        {
            productTextBox.Text = "";
            priceTextBox.Text = "";
            quantityTextBox.Text = "";
            totalPaymentTextBlock.Text = "";
            totalChargeTextBox.Text = "";
            wrapChargeTextBox.Text = "";
            gstChargeTextBox.Text = ""; // Clear the gstChargeTextBox as well
        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        // This method will be triggered when the text in wrapChargeTextBox changes
        private void wrapChargeTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            // If you want to do something when the text changes, you can add the logic here
        }
    }
}
