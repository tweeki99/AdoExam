namespace ExamWork
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dataGridViewCities = new System.Windows.Forms.DataGridView();
            this.buttonAddCity = new System.Windows.Forms.Button();
            this.buttonAddCountry = new System.Windows.Forms.Button();
            this.dataGridViewCountries = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.dataGridViewStreets = new System.Windows.Forms.DataGridView();
            this.buttonAddStreet = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountries)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStreets)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(284, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 17;
            this.label2.Text = "Города";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 16;
            this.label1.Text = "Страны";
            // 
            // dataGridViewCities
            // 
            this.dataGridViewCities.AllowUserToAddRows = false;
            this.dataGridViewCities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCities.Location = new System.Drawing.Point(284, 43);
            this.dataGridViewCities.MultiSelect = false;
            this.dataGridViewCities.Name = "dataGridViewCities";
            this.dataGridViewCities.ReadOnly = true;
            this.dataGridViewCities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCities.Size = new System.Drawing.Size(240, 351);
            this.dataGridViewCities.TabIndex = 15;
            this.dataGridViewCities.SelectionChanged += new System.EventHandler(this.DataGridViewCitiesSelectionChanged); 
            // 
            // buttonAddCity
            // 
            this.buttonAddCity.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddCity.Location = new System.Drawing.Point(284, 400);
            this.buttonAddCity.Name = "buttonAddCity";
            this.buttonAddCity.Size = new System.Drawing.Size(124, 36);
            this.buttonAddCity.TabIndex = 14;
            this.buttonAddCity.Text = "Добавить";
            this.buttonAddCity.UseVisualStyleBackColor = true;
            this.buttonAddCity.Click += new System.EventHandler(this.ButtonAddCityClick);
            // 
            // buttonAddCountry
            // 
            this.buttonAddCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddCountry.Location = new System.Drawing.Point(12, 400);
            this.buttonAddCountry.Name = "buttonAddCountry";
            this.buttonAddCountry.Size = new System.Drawing.Size(124, 35);
            this.buttonAddCountry.TabIndex = 13;
            this.buttonAddCountry.Text = "Добавить группу";
            this.buttonAddCountry.UseVisualStyleBackColor = true;
            this.buttonAddCountry.Click += new System.EventHandler(this.ButtonAddCountryClick);
            // 
            // dataGridViewCountries
            // 
            this.dataGridViewCountries.AllowUserToAddRows = false;
            this.dataGridViewCountries.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCountries.Location = new System.Drawing.Point(12, 43);
            this.dataGridViewCountries.MultiSelect = false;
            this.dataGridViewCountries.Name = "dataGridViewCountries";
            this.dataGridViewCountries.ReadOnly = true;
            this.dataGridViewCountries.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewCountries.Size = new System.Drawing.Size(240, 351);
            this.dataGridViewCountries.TabIndex = 12;
            this.dataGridViewCountries.SelectionChanged += new System.EventHandler(this.DataGridViewCountriesSelectionChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(548, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 25);
            this.label3.TabIndex = 19;
            this.label3.Text = "Улицы";
            // 
            // dataGridViewStreets
            // 
            this.dataGridViewStreets.AllowUserToAddRows = false;
            this.dataGridViewStreets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewStreets.Location = new System.Drawing.Point(548, 43);
            this.dataGridViewStreets.MultiSelect = false;
            this.dataGridViewStreets.Name = "dataGridViewStreets";
            this.dataGridViewStreets.ReadOnly = true;
            this.dataGridViewStreets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewStreets.Size = new System.Drawing.Size(240, 351);
            this.dataGridViewStreets.TabIndex = 18;
            // 
            // buttonAddStreet
            // 
            this.buttonAddStreet.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonAddStreet.Location = new System.Drawing.Point(548, 402);
            this.buttonAddStreet.Name = "buttonAddStreet";
            this.buttonAddStreet.Size = new System.Drawing.Size(124, 36);
            this.buttonAddStreet.TabIndex = 20;
            this.buttonAddStreet.Text = "Добавить";
            this.buttonAddStreet.UseVisualStyleBackColor = true;
            this.buttonAddStreet.Click += new System.EventHandler(this.ButtonAddStreetClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonAddStreet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dataGridViewStreets);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridViewCities);
            this.Controls.Add(this.buttonAddCity);
            this.Controls.Add(this.buttonAddCountry);
            this.Controls.Add(this.dataGridViewCountries);
            this.Name = "MainForm";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCountries)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewStreets)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewCities;
        private System.Windows.Forms.Button buttonAddCity;
        private System.Windows.Forms.Button buttonAddCountry;
        private System.Windows.Forms.DataGridView dataGridViewCountries;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dataGridViewStreets;
        private System.Windows.Forms.Button buttonAddStreet;
    }
}

