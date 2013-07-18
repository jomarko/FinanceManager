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
    public partial class FilterWindow : Form
    {
        private List<Category> incomes;
        private List<Category> outgoes;
        private List<Category> all;
        private Category tmp;

        public ItemFilter Filter
        {
            get;
            set;
        }

        public FilterWindow()
        {
            InitializeComponent();

            tmp = new Category();
            tmp.Name = "...";

            CategoryManager catMan = new CategoryManager();
            incomes = catMan.GetAllIncomes();
            incomes.Add(tmp);
            outgoes = catMan.GetAllOutgoes();
            outgoes.Add(tmp);
            all = catMan.GetAllIncomes();
            all.AddRange(catMan.GetAllOutgoes());
            all.Add(tmp);

            categComboBox.DataSource = all;
            categComboBox.SelectedItem = tmp;

            pickerTo.MaxDate = DateTime.Now.Date;
        }

        private void rbtnIncome_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnIncome.Checked) categComboBox.DataSource = incomes;
            categComboBox.SelectedItem = tmp;
        }

        private void rbtnOutgo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnOutgo.Checked) categComboBox.DataSource = outgoes;
            categComboBox.SelectedItem = tmp;
        }

        private void rbtnBoth_CheckedChanged(object sender, EventArgs e)
        {
            if (rbtnBoth.Checked) categComboBox.DataSource = all;
            categComboBox.SelectedItem = tmp;
        }

        private void pickerFrom_Validating(object sender, CancelEventArgs e)
        {
            if (pickerFrom.Value.Date > pickerTo.Value.Date)
            {
                btnOk.DialogResult = DialogResult.None;
                errorProvider1.SetError(pickerFrom, "Time from can't be greater than time to");
            }
            else
            {
                btnOk.DialogResult = DialogResult.OK;
                errorProvider1.SetError(pickerFrom, "");
            }
        }

        private void pickerTo_Validating(object sender, CancelEventArgs e)
        {
            if (pickerTo.Value.Date < pickerFrom.Value.Date)
            {
                btnOk.DialogResult = DialogResult.None;
                errorProvider1.SetError(pickerTo, "Time to can't be lesser than time from");
            }
            else
            {
                btnOk.DialogResult = DialogResult.OK;
                errorProvider1.SetError(pickerTo, "");
            }
        }



        private void btnOk_Click(object sender, EventArgs e)
        {
            if (btnOk.DialogResult == DialogResult.OK)
            {
                Filter = CreateFilter();
            }
            else
            {
                Filter = null;
            }
        }

        private ItemFilter CreateFilter()
        {
            ItemFilter f = new ItemFilter();
            if (rbtnBoth.Checked) f.Type = TypeEnum.Both;
            if (rbtnIncome.Checked) f.Type = TypeEnum.Income;
            if (rbtnOutgo.Checked) f.Type = TypeEnum.Outgo;
            if (!((Category)categComboBox.SelectedItem).Equals(tmp))
            {
                f.Category = (Category)categComboBox.SelectedItem;
            }
            else
            {
                f.Category = null;
            }
            f.TimeFrom = pickerFrom.Value.Date;
            f.TimeTo = pickerTo.Value.Date;

            if (numUpDownMinValue.Value > 0 || numUpDownMaxValue.Value > 0)
            {
                f.MaxValue = numUpDownMaxValue.Value;
                f.MinValue = numUpDownMinValue.Value;
            }
            else
            {
                f.MinValue = -1;
                f.MaxValue = -1;
            }
            f.Description = null;
            return f;
        }

        public void InitWindowByFilter()
        {
            if (Filter != null)
            {
                if (Filter.Type == TypeEnum.Both) rbtnBoth.Checked = true;
                if (Filter.Type == TypeEnum.Income) rbtnIncome.Checked = true;
                if (Filter.Type == TypeEnum.Outgo) rbtnOutgo.Checked = true;

                if (Filter.Category != null)
                {
                    categComboBox.SelectedItem = Filter.Category;
                }

                pickerFrom.Value = Filter.TimeFrom;
                pickerTo.Value = Filter.TimeTo;

                if (Filter.MinValue > -1 && Filter.MaxValue > -1)
                {
                    numUpDownMaxValue.Value = Filter.MaxValue;
                    numUpDownMinValue.Value = Filter.MinValue;
                }
            }
        }

        private void btnToday_Click(object sender, EventArgs e)
        {
            pickerFrom.Value = DateTime.Now.Date;
            pickerTo.Value = DateTime.Now.Date;
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            pickerFrom.Value = new DateTime(DateTime.Now.Year,DateTime.Now.Month, 1);
            pickerTo.Value = DateTime.Now.Date;
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            pickerFrom.Value = new DateTime(DateTime.Now.Year, (DateTime.Now.Month + 11)%12, 1);
            pickerTo.Value = new DateTime(DateTime.Now.Year, (DateTime.Now.Month + 11) % 12, DateTime.DaysInMonth(DateTime.Now.Year, (DateTime.Now.Month + 11) % 12));
        }

        private void btnYear_Click(object sender, EventArgs e)
        {
            pickerFrom.Value = new DateTime(DateTime.Now.Year, 1, 1);
            pickerTo.Value = DateTime.Now.Date;
        }

        private void btnMin10_Click(object sender, EventArgs e)
        {
            numUpDownMinValue.Value = 10;
        }

        private void btnMin100_Click(object sender, EventArgs e)
        {
            numUpDownMinValue.Value = 100;
        }

        private void btnMin1000_Click(object sender, EventArgs e)
        {
            numUpDownMinValue.Value = 1000;
        }

        private void btnMax10_Click(object sender, EventArgs e)
        {
            numUpDownMaxValue.Value = 10;
        }

        private void btnMax100_Click(object sender, EventArgs e)
        {
            numUpDownMaxValue.Value = 100;       
        }

        private void btnMax1000_Click(object sender, EventArgs e)
        {
            numUpDownMaxValue.Value = 1000;
        }

        private void numUpDownMinValue_ValueChanged(object sender, EventArgs e)
        {
            if (numUpDownMinValue.Value > numUpDownMaxValue.Value)
            {
                btnOk.DialogResult = DialogResult.None;
                errorProvider1.SetError(max, "Min value can't be greater than max value");
            }
            else
            {
                btnOk.DialogResult = DialogResult.OK;
                errorProvider1.SetError(max, "");
            }
        }
    }
}
