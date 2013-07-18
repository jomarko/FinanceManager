using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinanceManager
{
    public partial class ItemWindow : Form
    {
        private List<Category> incomes;
        private List<Category> outgoes;
        private Item item;

        public Item Item
        {
            get
            {
                return item;
            }

            set
            {
                item = value;
            }
        }

        public ItemWindow()
        {
            InitializeComponent();

            CategoryManager catMan = new CategoryManager();
            incomes = catMan.GetAllIncomes();
            outgoes = catMan.GetAllOutgoes();
            
            categComboBox.DataSource = incomes;
            btnOk.DialogResult = DialogResult.None;

            rbtnIncome.Text = TypeEnum.Income.ToString();
            rbtnOutgo.Text = TypeEnum.Outgo.ToString();

            datePicker.MaxDate = DateTime.Now;
        }

        private void txtboxDescription_Validating(object sender, CancelEventArgs e)
        {
            if (String.IsNullOrEmpty(txtboxDescription.Text))
            {
                btnOk.DialogResult = DialogResult.None;
                errorProvider1.SetError(txtboxDescription, "Description can't bee empty!");
            }
            else
            {
                btnOk.DialogResult = DialogResult.OK;
                errorProvider1.SetError(txtboxDescription, "");
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (btnOk.DialogResult == DialogResult.OK)
            {
                SaveItem();
            }
            else
            {
                item = null;
            }
               
        }

        private void SaveItem()
        {
            Item i;

            if (item == null)
            {
                i = new Item();
            }
            else
            {
                i = item;
            }

            if (rbtnIncome.Checked)
            {
                i.Type = TypeEnum.Income;
            }
            else
            {
                i.Type = TypeEnum.Outgo;
            }

            i.Date = datePicker.Value.Date;

            i.Category = (Category) categComboBox.SelectedItem;

            i.Value = (Decimal) numUpDownValue.Value;

            i.Description = txtboxDescription.Text;

            item = i;
        }

        private void rbtnIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIncome.Checked) categComboBox.DataSource = incomes;
        }

        private void rbtnOutgo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOutgo.Checked) categComboBox.DataSource = outgoes;
        }

        public void InitControlsByItem() 
        {
            if (item != null)
            {
                if (item.Type == TypeEnum.Income)
                {
                    rbtnIncome.Checked = true;
                }
                else
                {
                    rbtnOutgo.Checked = true;
                }

                datePicker.Value = item.Date;

                categComboBox.SelectedItem = item.Category;

                numUpDownValue.Value = item.Value;

                txtboxDescription.Text = item.Description;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            item = null;
        }
    }
}
