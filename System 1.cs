using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace System_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
        {
            string guestName = txtGuestName.Text.Trim();
            int age, nights, guests;
             
                bool validAge = int.TryParse(txtGuestAge.Text.Trim(), out age);
                bool validNights = int.TryParse(txtNights.Text.Trim(), out nights);
                bool validGuests = int.TryParse(txtGuests.Text.Trim(), out guests);

                if (!validAge || !validNights || !validGuests)
                {
                    MessageBox.Show(
                        "Check Guest Age, Number of Nights and Number of Guests."
                    );
                    return;
                }

                if (guestName == "")
            {
                MessageBox.Show("Please enter guest name.");
                txtGuestName.Focus();
                return;
            }

            if (!int.TryParse(txtGuestAge.Text, out age) ||
                !int.TryParse(txtNights.Text, out nights) ||
                !int.TryParse(txt.Text, out guests))
            {
                MessageBox.Show("Enter valid numbers for age, nights and guests.");
                return;
            }

            if (age < 18 || age > 90)
            {
                MessageBox.Show("Age must be between 18 and 90.");
                return;
            }

            if (nights < 1 || nights > 30)
            {
                MessageBox.Show("Nights must be between 1 and 30.");
                return;
            }

            if (guests < 1 || guests > 6)
            {
                MessageBox.Show("Guests must be between 1 and 6.");
                return;
            }

            decimal rate;
            int maxGuests;

            switch (cboRoomType.Text)
            {
                case "Standard":
                    rate = 50m;
                    maxGuests = 2;
                    break;

                case "Normal":
                    rate = 80m;
                    maxGuests = 4;
                    break;

                case "Hight":
                    rate = 130m;
                    maxGuests = 6;
                    break;

                default:
                    MessageBox.Show("Please select room type.");
                    return;
            }

            if (guests > maxGuests)
            {
                lblResult.Text =
                    "BOOKING REJECTED\n" +
                    $"Maximum guests for this room: {maxGuests}";
                return;
            }

            decimal basicCost = rate * nights;

            decimal discountRate = 0m;

            if (nights >= 10)
                discountRate = 0.12m;
            else if (nights >= 5)
                discountRate = 0.05m;

            decimal discount = basicCost * discountRate;

            decimal breakfastCost =
                chkBreakfast.Checked ? 10m * guests * nights : 0m;

            decimal subtotal = basicCost - discount + breakfastCost;

            decimal serviceSurcharge =
                guests > 4 ? subtotal * 0.05m : 0m;

            decimal seniorDiscount =
                age >= 60 ? (basicCost - discount) * 0.05m : 0m;

            decimal finalCost =
                subtotal + serviceSurcharge - seniorDiscount;

            lblResult.Text =
                $"BOOKING APPROVED\n" +
                $"Guest: {guestName}\n" +
                $"Room: {cboRoomType.Text}\n" +
                $"Basic Room Cost: {basicCost:C2}\n" +
                $"Discount: {discount:C2}\n" +
                $"Breakfast: {breakfastCost:C2}\n" +
                $"Service Surcharge: {serviceSurcharge:C2}\n" +
                $"Senior Discount: {seniorDiscount:C2}\n" +
                $"FINAL COST: {finalCost:C2}";
        }
    }
    }
}
