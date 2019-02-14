namespace CS_Project_2
{
    partial class frmMainMenu
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
            this.lblBank = new System.Windows.Forms.Label();
            this.gboxSelect = new System.Windows.Forms.GroupBox();
            this.rdoExit = new System.Windows.Forms.RadioButton();
            this.rdoTransferFunds = new System.Windows.Forms.RadioButton();
            this.rdoCheckBalance = new System.Windows.Forms.RadioButton();
            this.rdoMakeWithdrawal = new System.Windows.Forms.RadioButton();
            this.rdoMakeDeposit = new System.Windows.Forms.RadioButton();
            this.btnSelect = new System.Windows.Forms.Button();
            this.gboxSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblBank
            // 
            this.lblBank.AutoSize = true;
            this.lblBank.Font = new System.Drawing.Font("Times New Roman", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBank.Location = new System.Drawing.Point(186, 49);
            this.lblBank.Name = "lblBank";
            this.lblBank.Size = new System.Drawing.Size(207, 34);
            this.lblBank.TabIndex = 0;
            this.lblBank.Text = "Big Bucks Bank";
            // 
            // gboxSelect
            // 
            this.gboxSelect.BackColor = System.Drawing.Color.Wheat;
            this.gboxSelect.Controls.Add(this.rdoExit);
            this.gboxSelect.Controls.Add(this.rdoTransferFunds);
            this.gboxSelect.Controls.Add(this.rdoCheckBalance);
            this.gboxSelect.Controls.Add(this.rdoMakeWithdrawal);
            this.gboxSelect.Controls.Add(this.rdoMakeDeposit);
            this.gboxSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gboxSelect.Location = new System.Drawing.Point(134, 110);
            this.gboxSelect.Name = "gboxSelect";
            this.gboxSelect.Size = new System.Drawing.Size(320, 230);
            this.gboxSelect.TabIndex = 1;
            this.gboxSelect.TabStop = false;
            this.gboxSelect.Text = "Select...";
            // 
            // rdoExit
            // 
            this.rdoExit.AutoSize = true;
            this.rdoExit.Location = new System.Drawing.Point(20, 180);
            this.rdoExit.Name = "rdoExit";
            this.rdoExit.Size = new System.Drawing.Size(53, 24);
            this.rdoExit.TabIndex = 4;
            this.rdoExit.TabStop = true;
            this.rdoExit.Text = "Exit";
            this.rdoExit.UseVisualStyleBackColor = true;
            this.rdoExit.CheckedChanged += new System.EventHandler(this.rdoExit_CheckedChanged);
            // 
            // rdoTransferFunds
            // 
            this.rdoTransferFunds.AutoSize = true;
            this.rdoTransferFunds.Location = new System.Drawing.Point(20, 140);
            this.rdoTransferFunds.Name = "rdoTransferFunds";
            this.rdoTransferFunds.Size = new System.Drawing.Size(135, 24);
            this.rdoTransferFunds.TabIndex = 3;
            this.rdoTransferFunds.TabStop = true;
            this.rdoTransferFunds.Text = "Transfer Funds";
            this.rdoTransferFunds.UseVisualStyleBackColor = true;
            // 
            // rdoCheckBalance
            // 
            this.rdoCheckBalance.AutoSize = true;
            this.rdoCheckBalance.Location = new System.Drawing.Point(20, 100);
            this.rdoCheckBalance.Name = "rdoCheckBalance";
            this.rdoCheckBalance.Size = new System.Drawing.Size(130, 24);
            this.rdoCheckBalance.TabIndex = 2;
            this.rdoCheckBalance.TabStop = true;
            this.rdoCheckBalance.Text = "CheckBalance";
            this.rdoCheckBalance.UseVisualStyleBackColor = true;
            // 
            // rdoMakeWithdrawal
            // 
            this.rdoMakeWithdrawal.AutoSize = true;
            this.rdoMakeWithdrawal.Location = new System.Drawing.Point(20, 60);
            this.rdoMakeWithdrawal.Name = "rdoMakeWithdrawal";
            this.rdoMakeWithdrawal.Size = new System.Drawing.Size(161, 24);
            this.rdoMakeWithdrawal.TabIndex = 1;
            this.rdoMakeWithdrawal.TabStop = true;
            this.rdoMakeWithdrawal.Text = "Make a Withdrawal";
            this.rdoMakeWithdrawal.UseVisualStyleBackColor = true;
            // 
            // rdoMakeDeposit
            // 
            this.rdoMakeDeposit.AutoSize = true;
            this.rdoMakeDeposit.Location = new System.Drawing.Point(20, 20);
            this.rdoMakeDeposit.Name = "rdoMakeDeposit";
            this.rdoMakeDeposit.Size = new System.Drawing.Size(125, 24);
            this.rdoMakeDeposit.TabIndex = 0;
            this.rdoMakeDeposit.TabStop = true;
            this.rdoMakeDeposit.Text = "Make Deposit";
            this.rdoMakeDeposit.UseVisualStyleBackColor = true;
            this.rdoMakeDeposit.CheckedChanged += new System.EventHandler(this.rdoMakeDeposit_CheckedChanged);
            // 
            // btnSelect
            // 
            this.btnSelect.BackColor = System.Drawing.Color.SkyBlue;
            this.btnSelect.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelect.Location = new System.Drawing.Point(256, 366);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(106, 35);
            this.btnSelect.TabIndex = 2;
            this.btnSelect.Text = "Select";
            this.btnSelect.UseVisualStyleBackColor = false;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // frmMainMenu
            // 
            this.AcceptButton = this.btnSelect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Wheat;
            this.ClientSize = new System.Drawing.Size(624, 442);
            this.ControlBox = false;
            this.Controls.Add(this.btnSelect);
            this.Controls.Add(this.gboxSelect);
            this.Controls.Add(this.lblBank);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "frmMainMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Menu";
            this.Load += new System.EventHandler(this.frmMainMenu_Load);
            this.gboxSelect.ResumeLayout(false);
            this.gboxSelect.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblBank;
        private System.Windows.Forms.GroupBox gboxSelect;
        private System.Windows.Forms.RadioButton rdoExit;
        private System.Windows.Forms.RadioButton rdoTransferFunds;
        private System.Windows.Forms.RadioButton rdoCheckBalance;
        private System.Windows.Forms.RadioButton rdoMakeWithdrawal;
        private System.Windows.Forms.RadioButton rdoMakeDeposit;
        private System.Windows.Forms.Button btnSelect;
    }
}