namespace FinanceManager
{
    partial class FilterWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.rbtnIncome = new System.Windows.Forms.RadioButton();
            this.rbtnOutgo = new System.Windows.Forms.RadioButton();
            this.rbtnBoth = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.categComboBox = new System.Windows.Forms.ComboBox();
            this.pickerFrom = new System.Windows.Forms.DateTimePicker();
            this.pickerTo = new System.Windows.Forms.DateTimePicker();
            this.numUpDownMinValue = new System.Windows.Forms.NumericUpDown();
            this.numUpDownMaxValue = new System.Windows.Forms.NumericUpDown();
            this.min = new System.Windows.Forms.Label();
            this.max = new System.Windows.Forms.Label();
            this.btnToday = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnYear = new System.Windows.Forms.Button();
            this.btnLastMonth = new System.Windows.Forms.Button();
            this.btnMin10 = new System.Windows.Forms.Button();
            this.btnMin100 = new System.Windows.Forms.Button();
            this.btnMin1000 = new System.Windows.Forms.Button();
            this.btnMax10 = new System.Windows.Forms.Button();
            this.btnMax100 = new System.Windows.Forms.Button();
            this.btnMax1000 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMinValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMaxValue)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Time from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Time to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 273);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Min value";
            // 
            // rbtnIncome
            // 
            this.rbtnIncome.AutoSize = true;
            this.rbtnIncome.Location = new System.Drawing.Point(91, 30);
            this.rbtnIncome.Name = "rbtnIncome";
            this.rbtnIncome.Size = new System.Drawing.Size(60, 17);
            this.rbtnIncome.TabIndex = 4;
            this.rbtnIncome.Text = "Income";
            this.rbtnIncome.UseVisualStyleBackColor = true;
            this.rbtnIncome.CheckedChanged += new System.EventHandler(this.rbtnIncome_CheckedChanged);
            // 
            // rbtnOutgo
            // 
            this.rbtnOutgo.AutoSize = true;
            this.rbtnOutgo.Location = new System.Drawing.Point(92, 53);
            this.rbtnOutgo.Name = "rbtnOutgo";
            this.rbtnOutgo.Size = new System.Drawing.Size(54, 17);
            this.rbtnOutgo.TabIndex = 5;
            this.rbtnOutgo.Text = "Outgo";
            this.rbtnOutgo.UseVisualStyleBackColor = true;
            this.rbtnOutgo.CheckedChanged += new System.EventHandler(this.rbtnOutgo_CheckedChanged);
            // 
            // rbtnBoth
            // 
            this.rbtnBoth.AutoSize = true;
            this.rbtnBoth.Checked = true;
            this.rbtnBoth.Location = new System.Drawing.Point(91, 7);
            this.rbtnBoth.Name = "rbtnBoth";
            this.rbtnBoth.Size = new System.Drawing.Size(47, 17);
            this.rbtnBoth.TabIndex = 6;
            this.rbtnBoth.TabStop = true;
            this.rbtnBoth.Text = "Both";
            this.rbtnBoth.UseVisualStyleBackColor = true;
            this.rbtnBoth.CheckedChanged += new System.EventHandler(this.rbtnBoth_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 339);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Max value";
            // 
            // btnOk
            // 
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(116, 406);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(70, 23);
            this.btnOk.TabIndex = 12;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(192, 406);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 23);
            this.btnCancel.TabIndex = 13;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 93);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Category";
            // 
            // categComboBox
            // 
            this.categComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.categComboBox.FormattingEnabled = true;
            this.categComboBox.Location = new System.Drawing.Point(92, 90);
            this.categComboBox.Name = "categComboBox";
            this.categComboBox.Size = new System.Drawing.Size(172, 21);
            this.categComboBox.TabIndex = 15;
            // 
            // pickerFrom
            // 
            this.pickerFrom.Location = new System.Drawing.Point(91, 137);
            this.pickerFrom.Name = "pickerFrom";
            this.pickerFrom.Size = new System.Drawing.Size(173, 20);
            this.pickerFrom.TabIndex = 16;
            this.pickerFrom.Validating += new System.ComponentModel.CancelEventHandler(this.pickerFrom_Validating);
            // 
            // pickerTo
            // 
            this.pickerTo.Location = new System.Drawing.Point(91, 170);
            this.pickerTo.Name = "pickerTo";
            this.pickerTo.Size = new System.Drawing.Size(173, 20);
            this.pickerTo.TabIndex = 17;
            this.pickerTo.Validating += new System.ComponentModel.CancelEventHandler(this.pickerTo_Validating);
            // 
            // numUpDownMinValue
            // 
            this.numUpDownMinValue.DecimalPlaces = 2;
            this.numUpDownMinValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDownMinValue.Location = new System.Drawing.Point(92, 271);
            this.numUpDownMinValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDownMinValue.Name = "numUpDownMinValue";
            this.numUpDownMinValue.Size = new System.Drawing.Size(143, 20);
            this.numUpDownMinValue.TabIndex = 18;
            this.numUpDownMinValue.ValueChanged += new System.EventHandler(this.numUpDownMinValue_ValueChanged);
            // 
            // numUpDownMaxValue
            // 
            this.numUpDownMaxValue.DecimalPlaces = 2;
            this.numUpDownMaxValue.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numUpDownMaxValue.Location = new System.Drawing.Point(91, 337);
            this.numUpDownMaxValue.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.numUpDownMaxValue.Name = "numUpDownMaxValue";
            this.numUpDownMaxValue.Size = new System.Drawing.Size(144, 20);
            this.numUpDownMaxValue.TabIndex = 19;
            this.numUpDownMaxValue.ValueChanged += new System.EventHandler(this.numUpDownMinValue_ValueChanged);
            // 
            // min
            // 
            this.min.AutoSize = true;
            this.min.Location = new System.Drawing.Point(241, 273);
            this.min.Name = "min";
            this.min.Size = new System.Drawing.Size(23, 13);
            this.min.TabIndex = 20;
            this.min.Text = "Eur";
            // 
            // max
            // 
            this.max.AutoSize = true;
            this.max.Location = new System.Drawing.Point(241, 339);
            this.max.Name = "max";
            this.max.Size = new System.Drawing.Size(23, 13);
            this.max.TabIndex = 21;
            this.max.Text = "Eur";
            // 
            // btnToday
            // 
            this.btnToday.Location = new System.Drawing.Point(91, 197);
            this.btnToday.Name = "btnToday";
            this.btnToday.Size = new System.Drawing.Size(80, 23);
            this.btnToday.TabIndex = 22;
            this.btnToday.Text = "Today";
            this.btnToday.UseVisualStyleBackColor = true;
            this.btnToday.Click += new System.EventHandler(this.btnToday_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(184, 197);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(80, 23);
            this.btnMonth.TabIndex = 23;
            this.btnMonth.Text = "This month";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnYear
            // 
            this.btnYear.Location = new System.Drawing.Point(184, 226);
            this.btnYear.Name = "btnYear";
            this.btnYear.Size = new System.Drawing.Size(80, 23);
            this.btnYear.TabIndex = 25;
            this.btnYear.Text = "This year";
            this.btnYear.UseVisualStyleBackColor = true;
            this.btnYear.Click += new System.EventHandler(this.btnYear_Click);
            // 
            // btnLastMonth
            // 
            this.btnLastMonth.Location = new System.Drawing.Point(91, 226);
            this.btnLastMonth.Name = "btnLastMonth";
            this.btnLastMonth.Size = new System.Drawing.Size(80, 23);
            this.btnLastMonth.TabIndex = 24;
            this.btnLastMonth.Text = "Last month";
            this.btnLastMonth.UseVisualStyleBackColor = true;
            this.btnLastMonth.Click += new System.EventHandler(this.btnLastMonth_Click);
            // 
            // btnMin10
            // 
            this.btnMin10.Location = new System.Drawing.Point(92, 298);
            this.btnMin10.Name = "btnMin10";
            this.btnMin10.Size = new System.Drawing.Size(31, 23);
            this.btnMin10.TabIndex = 26;
            this.btnMin10.Text = "10";
            this.btnMin10.UseVisualStyleBackColor = true;
            this.btnMin10.Click += new System.EventHandler(this.btnMin10_Click);
            // 
            // btnMin100
            // 
            this.btnMin100.Location = new System.Drawing.Point(129, 298);
            this.btnMin100.Name = "btnMin100";
            this.btnMin100.Size = new System.Drawing.Size(57, 23);
            this.btnMin100.TabIndex = 27;
            this.btnMin100.Text = "100";
            this.btnMin100.UseVisualStyleBackColor = true;
            this.btnMin100.Click += new System.EventHandler(this.btnMin100_Click);
            // 
            // btnMin1000
            // 
            this.btnMin1000.Location = new System.Drawing.Point(192, 298);
            this.btnMin1000.Name = "btnMin1000";
            this.btnMin1000.Size = new System.Drawing.Size(72, 23);
            this.btnMin1000.TabIndex = 28;
            this.btnMin1000.Text = "1000";
            this.btnMin1000.UseVisualStyleBackColor = true;
            this.btnMin1000.Click += new System.EventHandler(this.btnMin1000_Click);
            // 
            // btnMax10
            // 
            this.btnMax10.Location = new System.Drawing.Point(92, 363);
            this.btnMax10.Name = "btnMax10";
            this.btnMax10.Size = new System.Drawing.Size(31, 23);
            this.btnMax10.TabIndex = 29;
            this.btnMax10.Text = "10";
            this.btnMax10.UseVisualStyleBackColor = true;
            this.btnMax10.Click += new System.EventHandler(this.btnMax10_Click);
            // 
            // btnMax100
            // 
            this.btnMax100.Location = new System.Drawing.Point(129, 363);
            this.btnMax100.Name = "btnMax100";
            this.btnMax100.Size = new System.Drawing.Size(57, 23);
            this.btnMax100.TabIndex = 30;
            this.btnMax100.Text = "100";
            this.btnMax100.UseVisualStyleBackColor = true;
            this.btnMax100.Click += new System.EventHandler(this.btnMax100_Click);
            // 
            // btnMax1000
            // 
            this.btnMax1000.Location = new System.Drawing.Point(192, 363);
            this.btnMax1000.Name = "btnMax1000";
            this.btnMax1000.Size = new System.Drawing.Size(72, 23);
            this.btnMax1000.TabIndex = 31;
            this.btnMax1000.Text = "1000";
            this.btnMax1000.UseVisualStyleBackColor = true;
            this.btnMax1000.Click += new System.EventHandler(this.btnMax1000_Click);
            // 
            // FilterWindow
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(293, 441);
            this.Controls.Add(this.btnMax1000);
            this.Controls.Add(this.btnMax100);
            this.Controls.Add(this.btnMax10);
            this.Controls.Add(this.btnMin1000);
            this.Controls.Add(this.btnMin100);
            this.Controls.Add(this.btnMin10);
            this.Controls.Add(this.btnYear);
            this.Controls.Add(this.btnLastMonth);
            this.Controls.Add(this.btnMonth);
            this.Controls.Add(this.btnToday);
            this.Controls.Add(this.max);
            this.Controls.Add(this.min);
            this.Controls.Add(this.numUpDownMaxValue);
            this.Controls.Add(this.numUpDownMinValue);
            this.Controls.Add(this.pickerTo);
            this.Controls.Add(this.pickerFrom);
            this.Controls.Add(this.categComboBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rbtnBoth);
            this.Controls.Add(this.rbtnOutgo);
            this.Controls.Add(this.rbtnIncome);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FilterWindow";
            this.Text = "FilterWindow";
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMinValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numUpDownMaxValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rbtnIncome;
        private System.Windows.Forms.RadioButton rbtnOutgo;
        private System.Windows.Forms.RadioButton rbtnBoth;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ErrorProvider errorProvider1;
        private System.Windows.Forms.ComboBox categComboBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label max;
        private System.Windows.Forms.Label min;
        private System.Windows.Forms.NumericUpDown numUpDownMaxValue;
        private System.Windows.Forms.NumericUpDown numUpDownMinValue;
        private System.Windows.Forms.DateTimePicker pickerTo;
        private System.Windows.Forms.DateTimePicker pickerFrom;
        private System.Windows.Forms.Button btnYear;
        private System.Windows.Forms.Button btnLastMonth;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnToday;
        private System.Windows.Forms.Button btnMax1000;
        private System.Windows.Forms.Button btnMax100;
        private System.Windows.Forms.Button btnMax10;
        private System.Windows.Forms.Button btnMin1000;
        private System.Windows.Forms.Button btnMin100;
        private System.Windows.Forms.Button btnMin10;
    }
}