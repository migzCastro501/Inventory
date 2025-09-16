using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory
{
    public partial class frmAddProduct : Form
    {
        private string _ProductName;
        private string _Category;
        private string _MfgDate;
        private string _ExpDate;
        private string _Description;
        private int _Quantity;
        private double _SellPrice;

        private BindingSource showProductList;

        private string[] ListOfProductCategory = new string[]
        {
        };

        public frmAddProduct()
        {
            InitializeComponent();
            showProductList = new BindingSource();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void frmAddProduct_Load(object sender, EventArgs e)
        {
            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }
        public string Product_Name(string name)
        {
            if (!Regex.IsMatch(name, @"^[a-zA-Z]+$"))
                MessageBox.Show("String Format Error", "StringFormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return name;
        }

        public int Quantity(string qty)
        {
            if (!Regex.IsMatch(qty, @"^[0-9]+$"))
                MessageBox.Show("Number Format Error", "NumberFormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return Convert.ToInt32(qty);
        }

        public double SellingPrice(string price)
        {
            if (!Regex.IsMatch(price, @"^(\d*\.)?\d+$"))
                MessageBox.Show("Currency Format Error", "CurrencyFormatException", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return Convert.ToDouble(price);
        }

        private void richTxtDescription_TextChanged(object sender, EventArgs e)
        {

        }

        private void frmAddProduct_Load_1(object sender, EventArgs e)
        {
            string[] ListOfProductCategory = {
                "Beverages","Bread/Bakery","Canned/Jarred Goods","Dairy",
                "Frozen Goods","Meat","Personal Care","Other"
            };

            foreach (string category in ListOfProductCategory)
            {
                cbCategory.Items.Add(category);
            }
        }

        private void btnAddProduct_Click_1(object sender, EventArgs e)
        {
            try
            {
                _ProductName = Product_Name(txtProductName.Text);
                _Category = cbCategory.Text;
                _MfgDate = dtPickerMfgDate.Value.ToString("yyyy-MM-dd");
                _ExpDate = dtPickerExpDate.Value.ToString("yyyy-MM-dd");
                _Description = richTxtDescription.Text;
                _Quantity = Quantity(txtQuantity.Text);
                _SellPrice = SellingPrice(txtSellPrice.Text);

                showProductList.Add(new ProductClass(
                    _ProductName, _Category, _MfgDate, _ExpDate, _SellPrice, _Quantity, _Description
                ));

                gridViewProductList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
                gridViewProductList.DataSource = showProductList;
            }
            catch (StringFormatException ex)
            {
                MessageBox.Show(ex.Message, "String Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (NumberFormatException ex)
            {
                MessageBox.Show(ex.Message, "Number Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (CurrencyFormatException ex)
            {
                MessageBox.Show(ex.Message, "Currency Format Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (ExpiredDateException ex)
            {
                MessageBox.Show(ex.Message, "Date Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}