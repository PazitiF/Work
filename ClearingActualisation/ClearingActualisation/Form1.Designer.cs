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
            this.clearingPartnerComboBox = new System.Windows.Forms.ComboBox();
            this.clearingManualSaveButton = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageTerminals = new System.Windows.Forms.TabPage();
            this.terminalsOpenButton = new System.Windows.Forms.Button();
            this.terminalsLabel = new System.Windows.Forms.Label();
            this.terminalsPictureBox = new System.Windows.Forms.PictureBox();
            this.terminalsRichTextBox = new System.Windows.Forms.RichTextBox();
            this.terminalsProgressBar = new System.Windows.Forms.ProgressBar();
            this.terminalsDataGrid = new System.Windows.Forms.DataGridView();
            this.terminalsUpdateButton = new System.Windows.Forms.Button();
            this.tabPageClearing = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.clearingDataGrid)).BeginInit();
            this.tabControl.SuspendLayout();
            this.tabPageTerminals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsDataGrid)).BeginInit();
            this.tabPageClearing.SuspendLayout();
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
            // clearingPartnerComboBox
            // 
            this.clearingPartnerComboBox.Location = new System.Drawing.Point(381, 3);
            this.clearingPartnerComboBox.Name = "clearingPartnerComboBox";
            this.clearingPartnerComboBox.Size = new System.Drawing.Size(211, 21);
            this.clearingPartnerComboBox.TabIndex = 1;
            this.clearingPartnerComboBox.SelectionChangeCommitted += new System.EventHandler(this.comboBoxPartnerClearing_SelectedItemChanged);
            // 
            // clearingManualSaveButton
            // 
            this.clearingManualSaveButton.Location = new System.Drawing.Point(381, 30);
            this.clearingManualSaveButton.Name = "clearingManualSaveButton";
            this.clearingManualSaveButton.Size = new System.Drawing.Size(211, 23);
            this.clearingManualSaveButton.TabIndex = 3;
            this.clearingManualSaveButton.Text = "Сохранить";
            this.clearingManualSaveButton.UseVisualStyleBackColor = true;
            this.clearingManualSaveButton.Click += new System.EventHandler(this.ManualSaveButton_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageTerminals);
            this.tabControl.Controls.Add(this.tabPageClearing);
            this.tabControl.Location = new System.Drawing.Point(-2, -1);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(611, 573);
            this.tabControl.TabIndex = 5;
            // 
            // tabPageTerminals
            // 
            this.tabPageTerminals.Controls.Add(this.terminalsOpenButton);
            this.tabPageTerminals.Controls.Add(this.terminalsLabel);
            this.tabPageTerminals.Controls.Add(this.terminalsPictureBox);
            this.tabPageTerminals.Controls.Add(this.terminalsRichTextBox);
            this.tabPageTerminals.Controls.Add(this.terminalsProgressBar);
            this.tabPageTerminals.Controls.Add(this.terminalsDataGrid);
            this.tabPageTerminals.Controls.Add(this.terminalsUpdateButton);
            this.tabPageTerminals.Location = new System.Drawing.Point(4, 22);
            this.tabPageTerminals.Name = "tabPageTerminals";
            this.tabPageTerminals.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageTerminals.Size = new System.Drawing.Size(603, 547);
            this.tabPageTerminals.TabIndex = 1;
            this.tabPageTerminals.Text = "Terminals";
            this.tabPageTerminals.UseVisualStyleBackColor = true;
            this.tabPageTerminals.Enter += new System.EventHandler(this.tabPageTerminals_Enter);
            // 
            // terminalsOpenButton
            // 
            this.terminalsOpenButton.Location = new System.Drawing.Point(381, 35);
            this.terminalsOpenButton.Name = "terminalsOpenButton";
            this.terminalsOpenButton.Size = new System.Drawing.Size(104, 23);
            this.terminalsOpenButton.TabIndex = 12;
            this.terminalsOpenButton.Text = "Открыть";
            this.terminalsOpenButton.UseVisualStyleBackColor = true;
            this.terminalsOpenButton.Click += new System.EventHandler(this.TerminalsOpenButton_Click);
            // 
            // terminalsLabel
            // 
            this.terminalsLabel.AutoSize = true;
            this.terminalsLabel.Location = new System.Drawing.Point(384, 66);
            this.terminalsLabel.Name = "terminalsLabel";
            this.terminalsLabel.Size = new System.Drawing.Size(169, 26);
            this.terminalsLabel.TabIndex = 11;
            this.terminalsLabel.Text = "Принимаются Excel-документы \r\nследующего вида:";
            // 
            // terminalsPictureBox
            // 
            this.terminalsPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("terminalsPictureBox.Image")));
            this.terminalsPictureBox.Location = new System.Drawing.Point(381, 95);
            this.terminalsPictureBox.Name = "terminalsPictureBox";
            this.terminalsPictureBox.Size = new System.Drawing.Size(214, 184);
            this.terminalsPictureBox.TabIndex = 10;
            this.terminalsPictureBox.TabStop = false;
            // 
            // terminalsRichTextBox
            // 
            this.terminalsRichTextBox.Location = new System.Drawing.Point(381, 285);
            this.terminalsRichTextBox.Name = "terminalsRichTextBox";
            this.terminalsRichTextBox.ReadOnly = true;
            this.terminalsRichTextBox.Size = new System.Drawing.Size(214, 252);
            this.terminalsRichTextBox.TabIndex = 9;
            this.terminalsRichTextBox.Text = "";
            // 
            // terminalsProgressBar
            // 
            this.terminalsProgressBar.Location = new System.Drawing.Point(381, 6);
            this.terminalsProgressBar.Name = "terminalsProgressBar";
            this.terminalsProgressBar.Size = new System.Drawing.Size(214, 23);
            this.terminalsProgressBar.TabIndex = 8;
            // 
            // terminalsDataGrid
            // 
            this.terminalsDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.terminalsDataGrid.Location = new System.Drawing.Point(0, 0);
            this.terminalsDataGrid.Name = "terminalsDataGrid";
            this.terminalsDataGrid.Size = new System.Drawing.Size(375, 547);
            this.terminalsDataGrid.TabIndex = 6;
            // 
            // terminalsUpdateButton
            // 
            this.terminalsUpdateButton.Location = new System.Drawing.Point(491, 35);
            this.terminalsUpdateButton.Name = "terminalsUpdateButton";
            this.terminalsUpdateButton.Size = new System.Drawing.Size(104, 23);
            this.terminalsUpdateButton.TabIndex = 5;
            this.terminalsUpdateButton.Text = "Обновить";
            this.terminalsUpdateButton.UseVisualStyleBackColor = true;
            this.terminalsUpdateButton.Click += new System.EventHandler(this.TerminalsUpdateButton_Click);
            // 
            // tabPageClearing
            // 
            this.tabPageClearing.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.tabPageClearing.Controls.Add(this.clearingDataGrid);
            this.tabPageClearing.Controls.Add(this.clearingPartnerComboBox);
            this.tabPageClearing.Controls.Add(this.clearingManualSaveButton);
            this.tabPageClearing.Location = new System.Drawing.Point(4, 22);
            this.tabPageClearing.Name = "tabPageClearing";
            this.tabPageClearing.Size = new System.Drawing.Size(603, 547);
            this.tabPageClearing.TabIndex = 2;
            this.tabPageClearing.Text = "Clearing";
            this.tabPageClearing.UseVisualStyleBackColor = true;
            this.tabPageClearing.Enter += new System.EventHandler(this.tabPageClearing_Enter);
            // 
            // Form1
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(606, 569);
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "TerminalsID and Clearing Actualisation";
            ((System.ComponentModel.ISupportInitialize)(this.clearingDataGrid)).EndInit();
            this.tabControl.ResumeLayout(false);
            this.tabPageTerminals.ResumeLayout(false);
            this.tabPageTerminals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.terminalsDataGrid)).EndInit();
            this.tabPageClearing.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView clearingDataGrid;
        private System.Windows.Forms.ComboBox clearingPartnerComboBox;
        private System.Windows.Forms.Button clearingManualSaveButton;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageTerminals;
        private System.Windows.Forms.DataGridView terminalsDataGrid;
        private System.Windows.Forms.Button terminalsUpdateButton;
        private System.Windows.Forms.ProgressBar terminalsProgressBar;
        private System.Windows.Forms.RichTextBox terminalsRichTextBox;
        private System.Windows.Forms.TabPage tabPageClearing;
        private System.Windows.Forms.Label terminalsLabel;
        private System.Windows.Forms.PictureBox terminalsPictureBox;
        private System.Windows.Forms.Button terminalsOpenButton;
    }
}

