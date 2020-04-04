﻿namespace forecast_accuracy
{
    partial class Form1
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
            this.lbxCities = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.labelId = new System.Windows.Forms.Label();
            this.labelCountry = new System.Windows.Forms.Label();
            this.labelTimezoneShift = new System.Windows.Forms.Label();
            this.labelNameValue = new System.Windows.Forms.Label();
            this.labelIdValue = new System.Windows.Forms.Label();
            this.labelCountryValue = new System.Windows.Forms.Label();
            this.labelTimzoneShiftValue = new System.Windows.Forms.Label();
            this.tableLayoutPanelCity = new System.Windows.Forms.TableLayoutPanel();
            this.labelName = new System.Windows.Forms.Label();
            this.tableLayoutPanelCurrent = new System.Windows.Forms.TableLayoutPanel();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTemperature = new System.Windows.Forms.Label();
            this.labelWindSpeed = new System.Windows.Forms.Label();
            this.labelWindDegree = new System.Windows.Forms.Label();
            this.labelHumidityValue = new System.Windows.Forms.Label();
            this.labelHumidity = new System.Windows.Forms.Label();
            this.labelPressureValue = new System.Windows.Forms.Label();
            this.labelPressure = new System.Windows.Forms.Label();
            this.labelWindDegreeValue = new System.Windows.Forms.Label();
            this.labelTimeValue = new System.Windows.Forms.Label();
            this.labelWindSpeedValue = new System.Windows.Forms.Label();
            this.labelTemperatureValue = new System.Windows.Forms.Label();
            this.dataGridViewForecasts = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanelCity.SuspendLayout();
            this.tableLayoutPanelCurrent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForecasts)).BeginInit();
            this.SuspendLayout();
            // 
            // lbxCities
            // 
            this.lbxCities.FormattingEnabled = true;
            this.lbxCities.Location = new System.Drawing.Point(12, 12);
            this.lbxCities.Name = "lbxCities";
            this.lbxCities.Size = new System.Drawing.Size(195, 303);
            this.lbxCities.TabIndex = 0;
            this.lbxCities.SelectedIndexChanged += new System.EventHandler(this.lbxCities_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(659, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "btnTest";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // labelId
            // 
            this.labelId.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelId.AutoSize = true;
            this.labelId.Location = new System.Drawing.Point(3, 26);
            this.labelId.Name = "labelId";
            this.labelId.Size = new System.Drawing.Size(112, 13);
            this.labelId.TabIndex = 0;
            this.labelId.Text = "OpenWeatherMap ID:";
            // 
            // labelCountry
            // 
            this.labelCountry.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelCountry.AutoSize = true;
            this.labelCountry.Location = new System.Drawing.Point(3, 48);
            this.labelCountry.Name = "labelCountry";
            this.labelCountry.Size = new System.Drawing.Size(144, 13);
            this.labelCountry.TabIndex = 0;
            this.labelCountry.Text = "Country (ISO3166-1 alpha 2):";
            // 
            // labelTimezoneShift
            // 
            this.labelTimezoneShift.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTimezoneShift.AutoSize = true;
            this.labelTimezoneShift.Location = new System.Drawing.Point(3, 71);
            this.labelTimezoneShift.Name = "labelTimezoneShift";
            this.labelTimezoneShift.Size = new System.Drawing.Size(94, 13);
            this.labelTimezoneShift.TabIndex = 0;
            this.labelTimezoneShift.Text = "Timezone Shift (s):";
            // 
            // labelNameValue
            // 
            this.labelNameValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelNameValue.AutoSize = true;
            this.labelNameValue.Location = new System.Drawing.Point(230, 4);
            this.labelNameValue.Name = "labelNameValue";
            this.labelNameValue.Size = new System.Drawing.Size(16, 13);
            this.labelNameValue.TabIndex = 0;
            this.labelNameValue.Text = "...";
            this.labelNameValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelIdValue
            // 
            this.labelIdValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelIdValue.AutoSize = true;
            this.labelIdValue.Location = new System.Drawing.Point(230, 26);
            this.labelIdValue.Name = "labelIdValue";
            this.labelIdValue.Size = new System.Drawing.Size(16, 13);
            this.labelIdValue.TabIndex = 0;
            this.labelIdValue.Text = "...";
            this.labelIdValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelCountryValue
            // 
            this.labelCountryValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelCountryValue.AutoSize = true;
            this.labelCountryValue.Location = new System.Drawing.Point(230, 48);
            this.labelCountryValue.Name = "labelCountryValue";
            this.labelCountryValue.Size = new System.Drawing.Size(16, 13);
            this.labelCountryValue.TabIndex = 0;
            this.labelCountryValue.Text = "...";
            this.labelCountryValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTimzoneShiftValue
            // 
            this.labelTimzoneShiftValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTimzoneShiftValue.AutoSize = true;
            this.labelTimzoneShiftValue.Location = new System.Drawing.Point(230, 71);
            this.labelTimzoneShiftValue.Name = "labelTimzoneShiftValue";
            this.labelTimzoneShiftValue.Size = new System.Drawing.Size(16, 13);
            this.labelTimzoneShiftValue.TabIndex = 0;
            this.labelTimzoneShiftValue.Text = "...";
            this.labelTimzoneShiftValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // tableLayoutPanelCity
            // 
            this.tableLayoutPanelCity.ColumnCount = 2;
            this.tableLayoutPanelCity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 151F));
            this.tableLayoutPanelCity.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelCity.Controls.Add(this.labelTimzoneShiftValue, 1, 3);
            this.tableLayoutPanelCity.Controls.Add(this.labelName, 0, 0);
            this.tableLayoutPanelCity.Controls.Add(this.labelCountryValue, 1, 2);
            this.tableLayoutPanelCity.Controls.Add(this.labelIdValue, 1, 1);
            this.tableLayoutPanelCity.Controls.Add(this.labelNameValue, 1, 0);
            this.tableLayoutPanelCity.Controls.Add(this.labelId, 0, 1);
            this.tableLayoutPanelCity.Controls.Add(this.labelTimezoneShift, 0, 3);
            this.tableLayoutPanelCity.Controls.Add(this.labelCountry, 0, 2);
            this.tableLayoutPanelCity.Location = new System.Drawing.Point(213, 12);
            this.tableLayoutPanelCity.Name = "tableLayoutPanelCity";
            this.tableLayoutPanelCity.RowCount = 4;
            this.tableLayoutPanelCity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCity.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelCity.Size = new System.Drawing.Size(249, 89);
            this.tableLayoutPanelCity.TabIndex = 3;
            // 
            // labelName
            // 
            this.labelName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(3, 4);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(38, 13);
            this.labelName.TabIndex = 0;
            this.labelName.Text = "Name:";
            // 
            // tableLayoutPanelCurrent
            // 
            this.tableLayoutPanelCurrent.ColumnCount = 2;
            this.tableLayoutPanelCurrent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55.02008F));
            this.tableLayoutPanelCurrent.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 44.97992F));
            this.tableLayoutPanelCurrent.Controls.Add(this.labelTime, 0, 0);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelTemperature, 0, 1);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelWindSpeed, 0, 2);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelWindDegree, 0, 3);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelHumidityValue, 1, 5);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelHumidity, 0, 5);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelPressureValue, 1, 4);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelPressure, 0, 4);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelWindDegreeValue, 1, 3);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelTimeValue, 1, 0);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelWindSpeedValue, 1, 2);
            this.tableLayoutPanelCurrent.Controls.Add(this.labelTemperatureValue, 1, 1);
            this.tableLayoutPanelCurrent.Location = new System.Drawing.Point(213, 123);
            this.tableLayoutPanelCurrent.Name = "tableLayoutPanelCurrent";
            this.tableLayoutPanelCurrent.RowCount = 6;
            this.tableLayoutPanelCurrent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelCurrent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelCurrent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelCurrent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelCurrent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelCurrent.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tableLayoutPanelCurrent.Size = new System.Drawing.Size(249, 164);
            this.tableLayoutPanelCurrent.TabIndex = 4;
            // 
            // labelTime
            // 
            this.labelTime.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(3, 7);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(131, 13);
            this.labelTime.TabIndex = 0;
            this.labelTime.Text = "Time of Calculation (UTC):";
            // 
            // labelTemperature
            // 
            this.labelTemperature.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelTemperature.AutoSize = true;
            this.labelTemperature.Location = new System.Drawing.Point(3, 34);
            this.labelTemperature.Name = "labelTemperature";
            this.labelTemperature.Size = new System.Drawing.Size(90, 13);
            this.labelTemperature.TabIndex = 0;
            this.labelTemperature.Text = "Temperature (°C):";
            // 
            // labelWindSpeed
            // 
            this.labelWindSpeed.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWindSpeed.AutoSize = true;
            this.labelWindSpeed.Location = new System.Drawing.Point(3, 61);
            this.labelWindSpeed.Name = "labelWindSpeed";
            this.labelWindSpeed.Size = new System.Drawing.Size(96, 13);
            this.labelWindSpeed.TabIndex = 0;
            this.labelWindSpeed.Text = "Wind Speed (m/s):";
            // 
            // labelWindDegree
            // 
            this.labelWindDegree.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelWindDegree.AutoSize = true;
            this.labelWindDegree.Location = new System.Drawing.Point(3, 88);
            this.labelWindDegree.Name = "labelWindDegree";
            this.labelWindDegree.Size = new System.Drawing.Size(93, 13);
            this.labelWindDegree.TabIndex = 0;
            this.labelWindDegree.Text = "Wind Direction (°):";
            // 
            // labelHumidityValue
            // 
            this.labelHumidityValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelHumidityValue.AutoSize = true;
            this.labelHumidityValue.Location = new System.Drawing.Point(230, 143);
            this.labelHumidityValue.Name = "labelHumidityValue";
            this.labelHumidityValue.Size = new System.Drawing.Size(16, 13);
            this.labelHumidityValue.TabIndex = 0;
            this.labelHumidityValue.Text = "...";
            this.labelHumidityValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelHumidity
            // 
            this.labelHumidity.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelHumidity.AutoSize = true;
            this.labelHumidity.Location = new System.Drawing.Point(3, 143);
            this.labelHumidity.Name = "labelHumidity";
            this.labelHumidity.Size = new System.Drawing.Size(67, 13);
            this.labelHumidity.TabIndex = 0;
            this.labelHumidity.Text = "Humidity (%):";
            // 
            // labelPressureValue
            // 
            this.labelPressureValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelPressureValue.AutoSize = true;
            this.labelPressureValue.Location = new System.Drawing.Point(230, 115);
            this.labelPressureValue.Name = "labelPressureValue";
            this.labelPressureValue.Size = new System.Drawing.Size(16, 13);
            this.labelPressureValue.TabIndex = 0;
            this.labelPressureValue.Text = "...";
            this.labelPressureValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelPressure
            // 
            this.labelPressure.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPressure.AutoSize = true;
            this.labelPressure.Location = new System.Drawing.Point(3, 115);
            this.labelPressure.Name = "labelPressure";
            this.labelPressure.Size = new System.Drawing.Size(79, 13);
            this.labelPressure.TabIndex = 0;
            this.labelPressure.Text = "Pressure (hPa):";
            // 
            // labelWindDegreeValue
            // 
            this.labelWindDegreeValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWindDegreeValue.AutoSize = true;
            this.labelWindDegreeValue.Location = new System.Drawing.Point(230, 88);
            this.labelWindDegreeValue.Name = "labelWindDegreeValue";
            this.labelWindDegreeValue.Size = new System.Drawing.Size(16, 13);
            this.labelWindDegreeValue.TabIndex = 0;
            this.labelWindDegreeValue.Text = "...";
            this.labelWindDegreeValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTimeValue
            // 
            this.labelTimeValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTimeValue.AutoSize = true;
            this.labelTimeValue.Location = new System.Drawing.Point(230, 7);
            this.labelTimeValue.Name = "labelTimeValue";
            this.labelTimeValue.Size = new System.Drawing.Size(16, 13);
            this.labelTimeValue.TabIndex = 0;
            this.labelTimeValue.Text = "...";
            this.labelTimeValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelWindSpeedValue
            // 
            this.labelWindSpeedValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelWindSpeedValue.AutoSize = true;
            this.labelWindSpeedValue.Location = new System.Drawing.Point(230, 61);
            this.labelWindSpeedValue.Name = "labelWindSpeedValue";
            this.labelWindSpeedValue.Size = new System.Drawing.Size(16, 13);
            this.labelWindSpeedValue.TabIndex = 0;
            this.labelWindSpeedValue.Text = "...";
            this.labelWindSpeedValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelTemperatureValue
            // 
            this.labelTemperatureValue.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.labelTemperatureValue.AutoSize = true;
            this.labelTemperatureValue.Location = new System.Drawing.Point(230, 34);
            this.labelTemperatureValue.Name = "labelTemperatureValue";
            this.labelTemperatureValue.Size = new System.Drawing.Size(16, 13);
            this.labelTemperatureValue.TabIndex = 0;
            this.labelTemperatureValue.Text = "...";
            this.labelTemperatureValue.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // dataGridViewForecasts
            // 
            this.dataGridViewForecasts.AllowUserToAddRows = false;
            this.dataGridViewForecasts.AllowUserToDeleteRows = false;
            this.dataGridViewForecasts.AllowUserToResizeColumns = false;
            this.dataGridViewForecasts.AllowUserToResizeRows = false;
            this.dataGridViewForecasts.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewForecasts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewForecasts.Location = new System.Drawing.Point(574, 12);
            this.dataGridViewForecasts.Name = "dataGridViewForecasts";
            this.dataGridViewForecasts.ReadOnly = true;
            this.dataGridViewForecasts.RowHeadersVisible = false;
            this.dataGridViewForecasts.Size = new System.Drawing.Size(685, 383);
            this.dataGridViewForecasts.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1283, 450);
            this.Controls.Add(this.dataGridViewForecasts);
            this.Controls.Add(this.tableLayoutPanelCurrent);
            this.Controls.Add(this.tableLayoutPanelCity);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.lbxCities);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Weather";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tableLayoutPanelCity.ResumeLayout(false);
            this.tableLayoutPanelCity.PerformLayout();
            this.tableLayoutPanelCurrent.ResumeLayout(false);
            this.tableLayoutPanelCurrent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewForecasts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelTimzoneShiftValue;
        private System.Windows.Forms.Label labelIdValue;
        private System.Windows.Forms.Label labelNameValue;
        private System.Windows.Forms.Label labelCountryValue;
        private System.Windows.Forms.Label labelId;
        private System.Windows.Forms.Label labelTimezoneShift;
        private System.Windows.Forms.Label labelCountry;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCity;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelCurrent;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTemperature;
        private System.Windows.Forms.Label labelWindSpeed;
        private System.Windows.Forms.Label labelWindDegree;
        private System.Windows.Forms.Label labelHumidityValue;
        private System.Windows.Forms.Label labelHumidity;
        private System.Windows.Forms.Label labelPressureValue;
        private System.Windows.Forms.Label labelPressure;
        private System.Windows.Forms.Label labelWindDegreeValue;
        private System.Windows.Forms.Label labelTimeValue;
        private System.Windows.Forms.Label labelWindSpeedValue;
        private System.Windows.Forms.Label labelTemperatureValue;
        private System.Windows.Forms.DataGridView dataGridViewForecasts;
        private System.Windows.Forms.ListBox lbxCities;
    }
}

