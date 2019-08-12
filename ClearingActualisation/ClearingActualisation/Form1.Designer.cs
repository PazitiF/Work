using System;

namespace ClearingActualisation
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.clearingDataGrid = new System.Windows.Forms.DataGridView();
            this.comboBoxPartnerClearing = new System.Windows.Forms.ComboBox();
            this.AutoSaveButton = new System.Windows.Forms.Button();
            this.ManualSaveButton = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageTerminals = new System.Windows.Forms.TabPage();
            this.richTextBoxTerminals = new System.Windows.Forms.RichTextBox();
            this.progressBarTerminals = new System.Windows.Forms.ProgressBar();
            this.terminalsDataGrid = new System.Windows.Forms.DataGridView();
            this.AnyButton = new System.Windows.Forms.Button();
            this.tabPageClearing = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.clearingDataGrid)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageTerminals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsDataGrid)).BeginInit();
            this.tabPageClearing.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // clearingDataGrid
            // 
            this.clearingDataGrid.Location = new System.Drawing.Point(0, 0);
            this.clearingDataGrid.Name = "clearingDataGrid";
            this.clearingDataGrid.ReadOnly = true;
            this.clearingDataGrid.Size = new System.Drawing.Size(375, 547);
            this.clearingDataGrid.TabIndex = 0;
            // 
            // comboBoxPartnerClearing
            // 
            this.comboBoxPartnerClearing.Location = new System.Drawing.Point(381, 61);
            this.comboBoxPartnerClearing.Name = "comboBoxPartnerClearing";
            this.comboBoxPartnerClearing.Size = new System.Drawing.Size(206, 21);
            this.comboBoxPartnerClearing.TabIndex = 1;
            this.comboBoxPartnerClearing.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPartnerClearing_SelectedItemChanged);
            // 
            // AutoSaveButton
            // 
            this.AutoSaveButton.Enabled = false;
            this.AutoSaveButton.Location = new System.Drawing.Point(381, 3);
            this.AutoSaveButton.Name = "AutoSaveButton";
            this.AutoSaveButton.Size = new System.Drawing.Size(206, 23);
            this.AutoSaveButton.TabIndex = 2;
            this.AutoSaveButton.Text = "Аўтамацiчаскi";
            this.AutoSaveButton.UseVisualStyleBackColor = true;
            this.AutoSaveButton.Click += new System.EventHandler(this.AutoSaveButton_Click);
            // 
            // ManualSaveButton
            // 
            this.ManualSaveButton.Location = new System.Drawing.Point(381, 32);
            this.ManualSaveButton.Name = "ManualSaveButton";
            this.ManualSaveButton.Size = new System.Drawing.Size(206, 23);
            this.ManualSaveButton.TabIndex = 3;
            this.ManualSaveButton.Text = "Не аўтамацiчаскi";
            this.ManualSaveButton.UseVisualStyleBackColor = true;
            this.ManualSaveButton.Click += new System.EventHandler(this.ManualSaveButton_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageTerminals);
            this.tabControl1.Controls.Add(this.tabPageClearing);
            this.tabControl1.Location = new System.Drawing.Point(-2, -1);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(611, 573);
            this.tabControl1.TabIndex = 5;
            // 
            // tabPageTerminals
            // 
            this.tabPageTerminals.Controls.Add(this.label1);
            this.tabPageTerminals.Controls.Add(this.pictureBox1);
            this.tabPageTerminals.Controls.Add(this.richTextBoxTerminals);
            this.tabPageTerminals.Controls.Add(this.progressBarTerminals);
            this.tabPageTerminals.Controls.Add(this.terminalsDataGrid);
            this.tabPageTerminals.Controls.Add(this.AnyButton);
            this.tabPageTerminals.Location = new System.Drawing.Point(4, 22);
            this.tabPageTerminals.Name = "tabPageTerminals";
            this.tabPageTerminals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTerminals.Size = new System.Drawing.Size(603, 547);
            this.tabPageTerminals.TabIndex = 1;
            this.tabPageTerminals.Text = "Terminals";
            this.tabPageTerminals.UseVisualStyleBackColor = true;
            this.tabPageTerminals.Enter += new System.EventHandler(this.tabPageTerminals_Enter);
            // 
            // richTextBoxTerminals
            // 
            this.richTextBoxTerminals.Location = new System.Drawing.Point(381, 285);
            this.richTextBoxTerminals.Name = "richTextBoxTerminals";
            this.richTextBoxTerminals.ReadOnly = true;
            this.richTextBoxTerminals.Size = new System.Drawing.Size(214, 252);
            this.richTextBoxTerminals.TabIndex = 9;
            this.richTextBoxTerminals.Text = "";
            // 
            // progressBarTerminals
            // 
            this.progressBarTerminals.Location = new System.Drawing.Point(381, 6);
            this.progressBarTerminals.Name = "progressBarTerminals";
            this.progressBarTerminals.Size = new System.Drawing.Size(214, 23);
            this.progressBarTerminals.TabIndex = 8;
            // 
            // terminalsDataGrid
            // 
            this.terminalsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.terminalsDataGrid.Location = new System.Drawing.Point(0, 0);
            this.terminalsDataGrid.Name = "terminalsDataGrid";
            this.terminalsDataGrid.Size = new System.Drawing.Size(375, 547);
            this.terminalsDataGrid.TabIndex = 6;
            // 
            // AnyButton
            // 
            this.AnyButton.Location = new System.Drawing.Point(381, 35);
            this.AnyButton.Name = "AnyButton";
            this.AnyButton.Size = new System.Drawing.Size(214, 23);
            this.AnyButton.TabIndex = 5;
            this.AnyButton.Text = "Сделать хорошо";
            this.AnyButton.UseVisualStyleBackColor = true;
            this.AnyButton.Click += new System.EventHandler(this.AnyButton_Click);
            // 
            // tabPageClearing
            // 
            this.tabPageClearing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageClearing.Controls.Add(this.clearingDataGrid);
            this.tabPageClearing.Controls.Add(this.comboBoxPartnerClearing);
            this.tabPageClearing.Controls.Add(this.AutoSaveButton);
            this.tabPageClearing.Controls.Add(this.ManualSaveButton);
            this.tabPageClearing.Location = new System.Drawing.Point(4, 22);
            this.tabPageClearing.Name = "tabPageClearing";
            this.tabPageClearing.Size = new System.Drawing.Size(593, 547);
            this.tabPageClearing.TabIndex = 2;
            this.tabPageClearing.Text = "Clearing";
            this.tabPageClearing.UseVisualStyleBackColor = true;
            this.tabPageClearing.Enter += new System.EventHandler(this.tabPageClearing_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(381, 95);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(214, 184);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(384, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 26);
            this.label1.TabIndex = 11;
            this.label1.Text = "Принимаются Excel-документы \r\nследующего вида:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 569);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Terminals and Clearing Actualisation";
            ((System.ComponentModel.ISupportInitialize)(this.clearingDataGrid)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageTerminals.ResumeLayout(false);
            this.tabPageTerminals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsDataGrid)).EndInit();
            this.tabPageClearing.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView clearingDataGrid;
        private System.Windows.Forms.ComboBox comboBoxPartnerClearing;
        private System.Windows.Forms.Button AutoSaveButton;
        private System.Windows.Forms.Button ManualSaveButton;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageTerminals;
        private System.Windows.Forms.DataGridView terminalsDataGrid;
        private System.Windows.Forms.Button AnyButton;
        private System.Windows.Forms.ProgressBar progressBarTerminals;
        private System.Windows.Forms.RichTextBox richTextBoxTerminals;
        private System.Windows.Forms.TabPage tabPageClearing;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

