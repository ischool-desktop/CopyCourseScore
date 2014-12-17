namespace CopyCourseScore
{
    partial class AskForm
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
            this.lblAsk = new DevComponents.DotNetBar.LabelX();
            this.btnAlways = new DevComponents.DotNetBar.ButtonX();
            this.btnYes = new DevComponents.DotNetBar.ButtonX();
            this.btnNo = new DevComponents.DotNetBar.ButtonX();
            this.SuspendLayout();
            // 
            // lblAsk
            // 
            this.lblAsk.BackColor = System.Drawing.Color.Transparent;
            // 
            // 
            // 
            this.lblAsk.BackgroundStyle.Class = "";
            this.lblAsk.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.lblAsk.Location = new System.Drawing.Point(13, 13);
            this.lblAsk.Name = "lblAsk";
            this.lblAsk.Size = new System.Drawing.Size(297, 40);
            this.lblAsk.TabIndex = 0;
            // 
            // btnAlways
            // 
            this.btnAlways.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnAlways.BackColor = System.Drawing.Color.Transparent;
            this.btnAlways.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnAlways.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.btnAlways.Location = new System.Drawing.Point(13, 59);
            this.btnAlways.Name = "btnAlways";
            this.btnAlways.Size = new System.Drawing.Size(75, 23);
            this.btnAlways.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnAlways.TabIndex = 1;
            this.btnAlways.Text = "一律覆寫";
            this.btnAlways.Click += new System.EventHandler(this.btnAlways_Click);
            // 
            // btnYes
            // 
            this.btnYes.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnYes.BackColor = System.Drawing.Color.Transparent;
            this.btnYes.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnYes.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.btnYes.Location = new System.Drawing.Point(127, 59);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(75, 23);
            this.btnYes.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnYes.TabIndex = 2;
            this.btnYes.Text = "是";
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnNo
            // 
            this.btnNo.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.btnNo.BackColor = System.Drawing.Color.Transparent;
            this.btnNo.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.btnNo.DialogResult = System.Windows.Forms.DialogResult.No;
            this.btnNo.Location = new System.Drawing.Point(235, 59);
            this.btnNo.Name = "btnNo";
            this.btnNo.Size = new System.Drawing.Size(75, 23);
            this.btnNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.btnNo.TabIndex = 3;
            this.btnNo.Text = "否";
            this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
            // 
            // AskForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 94);
            this.Controls.Add(this.btnNo);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.btnAlways);
            this.Controls.Add(this.lblAsk);
            this.DoubleBuffered = true;
            this.Name = "AskForm";
            this.Text = "系統提示";
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.LabelX lblAsk;
        private DevComponents.DotNetBar.ButtonX btnAlways;
        private DevComponents.DotNetBar.ButtonX btnYes;
        private DevComponents.DotNetBar.ButtonX btnNo;
    }
}