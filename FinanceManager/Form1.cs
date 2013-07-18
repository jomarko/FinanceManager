using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.Xml;
using System.IO;

namespace FinanceManager
{
    public partial class MainWindow : Form
    {

        private Decimal balance;
        private ItemManager manager;
        private ItemFilter filter;
        private String filename;
        private bool changesSaved;

        public MainWindow()
        {
            InitializeComponent();
            manager = new ItemManager();
            listViewItems.ListViewItemSorter = new LVIComparator();

            filter = null;
            filename = null;
            ChangesSaved(true);
        }

        private void ChangesSaved(bool saved)
        {
            Text = "Finance Manager";
            if (filename != null)
            {
                String[] parts = filename.Split('\\');
                Text += " [" + parts[parts.Length-1] + "]";
            }
            else
            {
                Text += " [unnamed]";
            }
            if (!saved) Text += " *";    
            changesSaved = saved;
            
        }

        private void ComputeBalance()
        {
            balance = 0;
            Decimal income = 0, outgo = 0;
            foreach (Item i in manager.GetAllItems())
            {
                if (i.Type == TypeEnum.Income)
                {
                    balance += i.Value;
                    income += i.Value;
                }
                if (i.Type == TypeEnum.Outgo)
                {
                    balance -= i.Value;
                    outgo += i.Value;
                }
            }

            sStripBalanLab.Text = String.Format("Account balance: {0:N2} - {1:N2} = {2:N2} Eur", income, outgo, balance);
            if (balance > 0) sStripBalanLab.ForeColor = Color.Green;
            if (balance < 0) sStripBalanLab.ForeColor = Color.DarkRed;
            if (balance == 0) sStripBalanLab.ForeColor = SystemColors.WindowText;
        }

        private ListViewItem CreateLVIFromItem(Item i)
        {
            ListViewItem lvi = new ListViewItem(i.Type.ToString());
            lvi.SubItems.Add(i.Date.Day.ToString() + ". " + i.Date.Month.ToString() + ". " + i.Date.Year.ToString());
            lvi.SubItems.Add(i.Category.ToString());
            if (i.Type == TypeEnum.Income) lvi.SubItems.Add(i.Value.ToString("N2"));
            if (i.Type == TypeEnum.Outgo) lvi.SubItems.Add((-i.Value).ToString("N2"));
            lvi.SubItems.Add(i.Description);
            
            lvi.Tag = i;

            if (i.Type == TypeEnum.Income) lvi.ForeColor = Color.Green;
            if (i.Type == TypeEnum.Outgo) lvi.ForeColor = Color.DarkRed;

            return lvi;
        }

        private void EditItemInListView(Item item)
        {
            for (int i = 0; i < listViewItems.Items.Count; i++)
            {
                if (((Item)(listViewItems.Items[i].Tag)).Id == item.Id)
                {
                    listViewItems.Items[i] = CreateLVIFromItem(item);
                    break;
                }
            }

            listViewItems.Sort();
        }

        private class LVIComparator : IComparer
        {
            public LVIComparator()
            {
                Order = -1;
                IndexToSort = 1;
            }

            public int IndexToSort
            {
                get;
                set;
            }

            public int Order
            {
                get;
                set;
            }

            public int Compare(object x, object y)
            {
                int result = 0;
                Item itemx = (Item)((ListViewItem)x).Tag;
                Item itemy = (Item)((ListViewItem)y).Tag;

                switch(IndexToSort)
                {
                    case 0:
                        {
                            result = itemx.Type.CompareTo(itemy.Type);
                            break;
                        }
                    case 1:
                        {
                            result = itemx.Date.CompareTo(itemy.Date);
                            break;
                        }
                    case 2:
                        {
                            result = itemx.Category.CompareTo(itemy.Category);
                            break;
                        }
                    case 3:
                        {
                            result = itemx.Value.CompareTo(itemy.Value);
                            break;
                        }
                    case 4:
                        {
                            result = itemx.Description.CompareTo(itemy.Description);
                            break;
                        }
                }

                result *= Order;

                return result;
            }
        }

        private void listViewItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listViewItems.SelectedItems.Count == 1)
            {
                txtDescription.Text = ((Item)listViewItems.SelectedItems[0].Tag).Description;
                toolStrip1.Items[5].Enabled = true; // edit
                toolStrip1.Items[6].Enabled = true; // remove
            }
            else
            {
                txtDescription.Text = "";
                toolStrip1.Items[5].Enabled = false; // edit
                toolStrip1.Items[6].Enabled = false; // remove
            }
        }

        private void listViewItems_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (((LVIComparator)listViewItems.ListViewItemSorter).IndexToSort == e.Column)
            {
                ((LVIComparator)listViewItems.ListViewItemSorter).Order *= -1;
            }
            else
            {
                ((LVIComparator)listViewItems.ListViewItemSorter).IndexToSort = e.Column;
            }

            listViewItems.Sort();
        }

        private void FilterLVI()
        {
            ClearAndFillLVI();

            if (listViewItems.Items.Count == 0)
            {
                graphOfBalanceByCategory.Enabled = false;
                graphOfBalanceByTime.Enabled = false;
            }
            else
            {
                graphOfBalanceByCategory.Enabled = true;
                graphOfBalanceByTime.Enabled = true;
            }
            
            if (filter != null)
            {
                viewAllToolStripMenuItem.Enabled = true;
                tsbtnViewAll.Enabled = true;
                sStripFiltLab.Text = "Filter: active";
                sStripFiltLab.BackColor = Color.Goldenrod;
                
                foreach (ListViewItem i in listViewItems.Items)    
                {
                    Item item = (Item)(i.Tag);
                    if (item.Type != filter.Type && filter.Type != TypeEnum.Both)
                    {
                        listViewItems.Items.Remove(i);
                    }
                    else if (filter.Category != null && !item.Category.Equals(filter.Category))
                    {
                        listViewItems.Items.Remove(i);
                    }
                    else if (filter.TimeTo != filter.TimeFrom &&
                        (item.Date > filter.TimeTo || item.Date < filter.TimeFrom))
                    {
                        listViewItems.Items.Remove(i);
                    }
                    else if (
                        filter.MinValue > -1 && filter.MaxValue > -1 &&
                        item.Value > filter.MaxValue || item.Value < filter.MinValue)
                    {
                        listViewItems.Items.Remove(i);
                    }
                    else if (filter.Description != null 
                        && item.Description.ToLower().IndexOf(filter.Description.ToLower()) == -1)
                    {
                        listViewItems.Items.Remove(i);
                    }
                }
            }

            GraphFilteredItems();
        }

        private void ClearAndFillLVI()
        {
            listViewItems.Items.Clear();
            List<Item> tmpItems = manager.GetAllItems();

            foreach (Item i in tmpItems)
            {
                listViewItems.Items.Add(CreateLVIFromItem(i));
            }
            ComputeBalance();
        }

        private void ClearAll()
        {
            balance = 0;
            manager = new ItemManager();
            filter = null;
            filename = null;
            ChangesSaved(false);
            txtDescription.Text = "";
            FilterLVI();
            chart1.Visible = false;
            toolStrip1.Items[5].Enabled = false; // edit
            toolStrip1.Items[6].Enabled = false; // remove
        }

        private void GraphFilteredItems()
        {
            Decimal income = 0, outgo = 0;
            if (listViewItems.Items.Count == 0)
            {
                chart1.Visible = false;
            }
            else
            {
                chart1.Visible = true;

                foreach (ListViewItem lvi in listViewItems.Items)
                {
                    Item item = ((Item)lvi.Tag);
                    if (item.Type == TypeEnum.Income) income += item.Value;
                    if (item.Type == TypeEnum.Outgo) outgo += item.Value;
                }
                chart1.Series[0].Points[0].YValues[0] = (Double)income;
                chart1.Series[0].Points[1].YValues[0] = (Double)outgo;
                chart1.Invalidate();
            }

            displBalanceStatStripLabel.Text = String.Format("Displayed balance: {0:N2} - {1:N2} = {2:N2} Eur", income, outgo, income - outgo);
            if (income - outgo > 0) displBalanceStatStripLabel.ForeColor = Color.Green;
            if (income - outgo < 0) displBalanceStatStripLabel.ForeColor = Color.DarkRed;
            if (income - outgo == 0) displBalanceStatStripLabel.ForeColor = SystemColors.WindowText;
        }

        private void newToolStripButton_Click(object sender, EventArgs e)
        {
            NewFileProcess();
        }

        private void NewFileProcess()
        {
            DialogResult res = DialogResult.Yes;
            if (!changesSaved)
            {
                res = MessageBox.Show("All changes will bee lost, continue?", "New file", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);
            }

            if (res == DialogResult.Yes || changesSaved)
            {
                ClearAll();
            }
        }

        private void openToolStripButton_Click(object sender, EventArgs e)
        {
            OpenFileProcess();
        }

        private void OpenFileProcess()
        {
            DialogResult res = DialogResult.No;

            if (!changesSaved) res = MessageBox.Show("All changes will bee lost, continue?", "Open file", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes || changesSaved)
            {
                openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ItemManager manBackup = manager;
                    ItemFilter filtBackup = filter;
                    bool savedBackup = changesSaved;
                    String fileBackup = filename;
                    ClearAll();
                    if (manager.LoadItems(openFileDialog.FileName))
                    {
                        filename = openFileDialog.FileName;
                        ChangesSaved(true);
                    }
                    else
                    {
                        MessageBox.Show("Wrong input file", "Wrong file", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        manager = manBackup;
                        filter = filtBackup;
                        if (filter != null) sStripFiltLab.Text = "Filter: active";
                        filename = fileBackup;
                        ChangesSaved(savedBackup);
                    }

                    ClearAndFillLVI();
                    FilterLVI();
                }
            }
        }

        private void saveToolStripButton_Click(object sender, EventArgs e)
        {
            SaveFileProcess();
        }

        private void SaveFileProcess()
        {
            if (filename == null)
            {
                saveFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    if (saveFileDialog.FileName != "")
                    {
                        filename = saveFileDialog.FileName;
                    }
                }
            }

            if (filename != null)
            {
                manager.SaveItems(filename);
                ChangesSaved(true);
            }
        }

        private void tStripBtnNew_Click(object sender, EventArgs e)
        {
            NewItemProcess();
        }

        private void NewItemProcess()
        {
            ItemWindow itemWindow = new ItemWindow();

            if (itemWindow.ShowDialog() == DialogResult.OK)
            {
                Item i = itemWindow.Item;
                manager.AddItem(i);
                listViewItems.Items.Add(CreateLVIFromItem(i));
                listViewItems.Sort();
                FilterLVI();
                ChangesSaved(false);
            }
        }

        private void tStripBtnEdit_Click(object sender, EventArgs e)
        {
            EditItemProcess();
        }

        private void EditItemProcess()
        {
            ItemWindow itemWindow = new ItemWindow();
            Item oldSelected = (Item)listViewItems.SelectedItems[0].Tag;
            itemWindow.Item = oldSelected;
            itemWindow.InitControlsByItem();

            if (itemWindow.ShowDialog() == DialogResult.OK)
            {
                Item i = itemWindow.Item;
                manager.EditItem(i);
                EditItemInListView(i);
                FilterLVI();
                ChangesSaved(false);
            }
        }

        private void tStripBtnRemove_Click(object sender, EventArgs e)
        {
            RemoveItemProcess();
        }

        private void RemoveItemProcess()
        {
            
            if (MessageBox.Show(
                String.Format("Are you sure with removing \"{0}\" from day \"{1}\" of value \"{2}\"",
                listViewItems.SelectedItems[0].SubItems[0].Text,
                listViewItems.SelectedItems[0].SubItems[1].Text,
                listViewItems.SelectedItems[0].SubItems[3].Text),
                "Info",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Information)
                == DialogResult.Yes)
            {
                manager.RemoveItem((Item)listViewItems.SelectedItems[0].Tag);
                listViewItems.Items.Remove(listViewItems.SelectedItems[0]);
                GraphFilteredItems();
                ComputeBalance();
                ChangesSaved(false);
            }
        }

        private void filterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FilterProcess();
        }

        private void FilterProcess()
        {
            FilterWindow filterWindow = new FilterWindow();
            filterWindow.Filter = filter;
            filterWindow.InitWindowByFilter();

            if (filterWindow.ShowDialog() == DialogResult.OK)
            {
                filter = filterWindow.Filter;
                FilterLVI();
            }
        }

        private void viewAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewAllProcess();
        }

        private void ViewAllProcess()
        {
            filter = null;
            tstripTextBoxFilter.Text = "";
            ClearAndFillLVI();
            GraphFilteredItems();
            viewAllToolStripMenuItem.Enabled = false;
            tsbtnViewAll.Enabled = false;
            sStripFiltLab.Text = "Filter: inactive";
            sStripFiltLab.BackColor = SystemColors.Menu;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private bool ClosingProcess()
        {
            if (!changesSaved)
            {
                if (MessageBox.Show(
                    "All changes will bee lost, continue?",
                    "Exit",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    return true;
                }
            }
            else
            {
                return true;
            }

            return false;
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewFileProcess();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileProcess();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            NewItemProcess();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditItemProcess();
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoveItemProcess();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileProcess();
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            String tmpFilename = filename;
            filename = null;
            SaveFileProcess();
            if (filename == null) filename = tmpFilename;
        }

        private void listViewItems_DoubleClick(object sender, EventArgs e)
        {
            EditItemProcess();
        }

        private void tsbtnFilter_Click(object sender, EventArgs e)
        {
            FilterProcess();
        }

        private void tsbtnViewAll_Click(object sender, EventArgs e)
        {
            ViewAllProcess();
        }

        private void toolStripTextBox1_TextChanged(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void graphOfBalanceByCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Dictionary<String, Decimal> incomes = new Dictionary<String, Decimal>();
            Dictionary<String, Decimal> outgoes = new Dictionary<String, Decimal>();

            foreach (Item item in manager.GetAllItems())
            {
                if (item.Type == TypeEnum.Income)
                {
                    if (!incomes.ContainsKey(item.Category.Name)) incomes.Add(item.Category.Name, 0);
                    incomes[item.Category.Name] += item.Value;
                }
                else
                {
                    if (!outgoes.ContainsKey(item.Category.Name)) outgoes.Add(item.Category.Name, 0);
                    outgoes[item.Category.Name] += item.Value;
                }
            }
            incomes = incomes.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            outgoes = outgoes.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            
            GraphWindow graphWindow = new GraphWindow(incomes, outgoes);
            graphWindow.ShowDialog();
        }

        private void graphOfBalanceByTime_Click(object sender, EventArgs e)
        {
            Dictionary<DateTime, Decimal> balanceParts = new Dictionary<DateTime, Decimal>();
            decimal actual = 0;

            foreach (Item item in manager.GetAllItems().OrderBy(x => x.Date))
            {
                if (item.Type == TypeEnum.Income)
                {
                    
                    if (!balanceParts.ContainsKey(item.Date))
                    {
                        balanceParts.Add(item.Date, 0);
                    }
                    actual += item.Value;
                    balanceParts[item.Date] = actual;
                }
                else
                {
                    if (!balanceParts.ContainsKey(item.Date))
                    {
                        balanceParts.Add(item.Date, 0);
                    }
                    actual -= item.Value;
                    balanceParts[item.Date] = actual;
                }
            }

            Dictionary<DateTime, Decimal>[] tmpParts = new Dictionary<DateTime, Decimal>[balanceParts.Count - 1];

            for (int i = 0; i < balanceParts.Count-1; i++)
            {
                tmpParts[i] = FillFreePlaces(
                     balanceParts.Keys.ElementAt(i),
                     balanceParts.Keys.ElementAt(i + 1),
                     balanceParts.Values.ElementAt(i),
                     balanceParts.Values.ElementAt(i + 1),
                     balanceParts);
            }

            for (int i = 0; i < tmpParts.Length; i++)
            {
                foreach (var item in tmpParts[i])
                {
                    balanceParts.Add(item.Key, item.Value);
                }
            }

            balanceParts = balanceParts.OrderBy
                (x => x.Key).ToDictionary(x => x.Key, x => x.Value);
            GraphWindow graphWindow = new GraphWindow(balanceParts);
            graphWindow.ShowDialog();
        }

        private Dictionary<DateTime, Decimal> FillFreePlaces(DateTime start, DateTime end, Decimal sValue, Decimal eValue, Dictionary<DateTime, Decimal> balParts)
        {
            Dictionary<DateTime, Decimal> balanceParts = new Dictionary<DateTime, decimal>();

            if (start.AddDays(1) < end)
            {
                Decimal step = sValue > eValue ? -1 : 1;

                step = step * (Math.Abs(sValue - eValue) / end.Subtract(start).Days);

                while (start.AddDays(1) < end)
                {
                    start = start.AddDays(1);
                    sValue += step;
                    balanceParts.Add(start, sValue);
                }
            }

            return balanceParts;
        }

        private void MainWindow_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ClosingProcess()) e.Cancel = true;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (tstripTextBoxFilter.Text.Length > 0)
            {
                ItemFilter f = new ItemFilter();
                f.Type = TypeEnum.Both;
                f.Category = null;
                f.TimeFrom = DateTime.Now;
                f.TimeTo = f.TimeFrom;
                f.MinValue = -1;
                f.MaxValue = -1;
                f.Description = tstripTextBoxFilter.Text;
                filter = f;
                FilterLVI();
            }
            else
            {
                ViewAllProcess();
            }

            timer1.Stop();
        }
    }
}
