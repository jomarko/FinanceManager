using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace FinanceManager
{
    public partial class GraphWindow : Form
    {
        IDictionary<DateTime, Decimal> timeBalance;
        DateTime startToShow;
        DateTime endToShow;
        DateTime minboundary;

        public GraphWindow(IDictionary<string, decimal> incomes, IDictionary<string, decimal> expenses)
        {
            InitializeComponent();
            labMonth.Visible = false;
            btnNext.Visible = false;
            btnPrev.Visible = false;

            chart.Series.Clear();
            Series s = new Series("Money");
            chart.Legends.Clear();
            s.Color = Color.Green;
            foreach (var i in incomes)
            {
                var dp = new DataPoint(0, (double)i.Value);
                dp.Name = i.Key;
                dp.AxisLabel = i.Key;
                dp.Color = Color.Green;
                s.Points.Add(dp);
            }
            
            foreach (var i in expenses)
            {
                var dp = new DataPoint(0, (double)i.Value);
                dp.Name = i.Key;
                dp.AxisLabel = i.Key;
                dp.Color = Color.DarkRed;
                s.Points.Add(dp);
            }
            chart.Series.Add(s);
            SetupChartArea();
            chart.DataBind();
        }

        public GraphWindow(IDictionary<DateTime, Decimal> balance)
        {
            InitializeComponent();
            timeBalance = balance;

            startToShow = DateTime.Now.Date;
            endToShow = new DateTime(startToShow.Year, startToShow.Month, 1);
            minboundary = new DateTime(
                balance.ElementAt(0).Key.Year,
                balance.ElementAt(0).Key.Month,
                1);

            ChangeDataByBoundaries();
            chart.Series[0].ChartType = SeriesChartType.Line;
            chart.Series[0].BorderWidth = 4;
            SetupChartArea();
            UpdateLabels();
        }

        private void SetupChartArea()
        {
            chart.ChartAreas[0].AxisY.Title = "EUR";
            chart.ChartAreas[0].AxisY.Interval = 20;
            chart.ChartAreas[0].AxisX.Interval = 1;
            chart.ChartAreas[0].AxisX.IsMarginVisible= false;
        }

        private void btnPrev_Click(object sender, EventArgs e)
        {
            while (startToShow.AddDays(-1).Month == startToShow.Month)
            {
                startToShow = startToShow.AddDays(-1);
            }
            startToShow = startToShow.AddDays(-1);
            endToShow = new DateTime(startToShow.Year, startToShow.Month, 1);

            if (endToShow == minboundary)
            {
                btnPrev.Enabled = false;
            }

            ChangeDataByBoundaries();
            UpdateLabels();
            btnNext.Enabled = true;
        }

        private enum Month { January, February, March, April, May, June, Jule, August, September, October, November, December}

        private void UpdateLabels()
        {
            Month month = (Month)startToShow.Month - 1;
            labMonth.Text = month.ToString() + " "  +  startToShow.Year;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            int next = (startToShow.Month % 12) + 1;
            while (startToShow.AddDays(1).Month == next && startToShow != DateTime.Now.Date)
            {
                startToShow = startToShow.AddDays(1);
            }

            if (startToShow == DateTime.Now.Date)
            {
                btnNext.Enabled = false;
            }
            
            endToShow = new DateTime(startToShow.Year, startToShow.Month, 1);

            ChangeDataByBoundaries();
            UpdateLabels();
            btnPrev.Enabled = true;
        }

        private void ChangeDataByBoundaries()
        {
            Decimal prev = 0, succ = 0;
            chart.Series[0].Points.Clear() ;
            chart.Series[0].Color = Color.Green;
            chart.Legends.Clear();
            foreach (var i in timeBalance)
            {
                if (i.Key <= startToShow)
                {
                    if (i.Key >= endToShow)
                    {
                        var dp = new DataPoint(0, (double)i.Value);
                        dp.Name = String.Format("{0} {1} {2}", i.Key.Day, i.Key.Month, i.Key.Year);
                        dp.AxisLabel = String.Format("{0}. {1}. {2}", i.Key.Day, i.Key.Month, i.Key.Year);
                        if (i.Value > 0) dp.Color = Color.Green;
                        if (i.Value < 0) dp.Color = Color.DarkRed;
                        chart.Series[0].Points.Add(dp);
                    }
                    else
                    {
                        if(prev == 0) prev = i.Value;
                    }
                }
                else
                {
                    if(succ == 0) succ = i.Value;
                }
            }

            
                if (prev != 0)
                {
                    var prevPoint = new DataPoint(0, (double)prev);
                    prevPoint.AxisLabel = "Previous month";
                    if (prev > 0) prevPoint.Color = Color.Green;
                    if (prev < 0) prevPoint.Color = Color.DarkRed;
                    chart.Series[0].Points.Insert(0, prevPoint);
                }

                if (succ != 0)
                {
                    var succPoint = new DataPoint(0, (double)succ);
                    succPoint.AxisLabel = "Next month";
                    if (prev > 0) succPoint.Color = Color.Green;
                    if (prev < 0) succPoint.Color = Color.DarkRed;
                    chart.Series[0].Points.Insert(chart.Series[0].Points.Count, succPoint);
                }

            chart.DataBind();
        }
    }
}
