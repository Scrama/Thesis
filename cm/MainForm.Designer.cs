namespace cm
{
    partial class MainForm
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupData = new System.Windows.Forms.GroupBox();
            this._listData = new System.Windows.Forms.ListBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonRemove = new System.Windows.Forms.Button();
            this._buttonSort = new System.Windows.Forms.Button();
            this._buttonDown = new System.Windows.Forms.Button();
            this._buttonUp = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._header = new System.Windows.Forms.TextBox();
            this._browseHeader = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._target = new System.Windows.Forms.TextBox();
            this._browseTarget = new System.Windows.Forms.Button();
            this._build = new System.Windows.Forms.Button();
            this._about = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.groupData.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.groupData);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(8);
            this.panel1.Size = new System.Drawing.Size(522, 473);
            this.panel1.TabIndex = 7;
            // 
            // groupData
            // 
            this.groupData.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.groupData.Controls.Add(this._listData);
            this.groupData.Controls.Add(this._buttonAdd);
            this.groupData.Controls.Add(this._buttonRemove);
            this.groupData.Controls.Add(this._buttonSort);
            this.groupData.Controls.Add(this._buttonDown);
            this.groupData.Controls.Add(this._buttonUp);
            this.groupData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupData.Location = new System.Drawing.Point(8, 8);
            this.groupData.Margin = new System.Windows.Forms.Padding(10);
            this.groupData.Name = "groupData";
            this.groupData.Size = new System.Drawing.Size(506, 457);
            this.groupData.TabIndex = 1;
            this.groupData.TabStop = false;
            this.groupData.Text = "Входные данные";
            // 
            // _listData
            // 
            this._listData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._listData.FormattingEnabled = true;
            this._listData.Location = new System.Drawing.Point(8, 19);
            this._listData.Margin = new System.Windows.Forms.Padding(8);
            this._listData.Name = "_listData";
            this._listData.Size = new System.Drawing.Size(492, 394);
            this._listData.TabIndex = 5;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonAdd.Location = new System.Drawing.Point(430, 424);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(70, 25);
            this._buttonAdd.TabIndex = 4;
            this._buttonAdd.Text = "Добавить";
            this._buttonAdd.UseVisualStyleBackColor = true;
            // 
            // _buttonRemove
            // 
            this._buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonRemove.Location = new System.Drawing.Point(354, 424);
            this._buttonRemove.Name = "_buttonRemove";
            this._buttonRemove.Size = new System.Drawing.Size(70, 25);
            this._buttonRemove.TabIndex = 3;
            this._buttonRemove.Text = "Убрать";
            this._buttonRemove.UseVisualStyleBackColor = true;
            // 
            // _buttonSort
            // 
            this._buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonSort.Location = new System.Drawing.Point(80, 424);
            this._buttonSort.Name = "_buttonSort";
            this._buttonSort.Size = new System.Drawing.Size(80, 25);
            this._buttonSort.TabIndex = 2;
            this._buttonSort.Text = "Сортировать";
            this._buttonSort.UseVisualStyleBackColor = true;
            // 
            // _buttonDown
            // 
            this._buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonDown.Location = new System.Drawing.Point(44, 424);
            this._buttonDown.Name = "_buttonDown";
            this._buttonDown.Size = new System.Drawing.Size(30, 25);
            this._buttonDown.TabIndex = 1;
            this._buttonDown.Text = "dn";
            this._buttonDown.UseVisualStyleBackColor = true;
            // 
            // _buttonUp
            // 
            this._buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonUp.Location = new System.Drawing.Point(8, 424);
            this._buttonUp.Name = "_buttonUp";
            this._buttonUp.Size = new System.Drawing.Size(30, 25);
            this._buttonUp.TabIndex = 0;
            this._buttonUp.Text = "up";
            this._buttonUp.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this._build);
            this.panel2.Controls.Add(this._about);
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Controls.Add(this.groupBox2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(522, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(8);
            this.panel2.Size = new System.Drawing.Size(568, 473);
            this.panel2.TabIndex = 8;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._header);
            this.groupBox2.Controls.Add(this._browseHeader);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(552, 90);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Файл-заголовок";
            // 
            // _header
            // 
            this._header.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._header.Location = new System.Drawing.Point(20, 19);
            this._header.Name = "_header";
            this._header.ReadOnly = true;
            this._header.Size = new System.Drawing.Size(527, 20);
            this._header.TabIndex = 6;
            // 
            // _browseHeader
            // 
            this._browseHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._browseHeader.Location = new System.Drawing.Point(477, 59);
            this._browseHeader.Name = "_browseHeader";
            this._browseHeader.Size = new System.Drawing.Size(70, 25);
            this._browseHeader.TabIndex = 5;
            this._browseHeader.Text = "Найти";
            this._browseHeader.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._target);
            this.groupBox3.Controls.Add(this._browseTarget);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(8, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(552, 90);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результат";
            // 
            // _target
            // 
            this._target.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this._target.Location = new System.Drawing.Point(20, 19);
            this._target.Name = "_target";
            this._target.ReadOnly = true;
            this._target.Size = new System.Drawing.Size(527, 20);
            this._target.TabIndex = 7;
            // 
            // _browseTarget
            // 
            this._browseTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._browseTarget.Location = new System.Drawing.Point(477, 59);
            this._browseTarget.Name = "_browseTarget";
            this._browseTarget.Size = new System.Drawing.Size(70, 25);
            this._browseTarget.TabIndex = 6;
            this._browseTarget.Text = "Указать";
            this._browseTarget.UseVisualStyleBackColor = true;
            // 
            // _build
            // 
            this._build.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._build.Location = new System.Drawing.Point(389, 432);
            this._build.Name = "_build";
            this._build.Size = new System.Drawing.Size(80, 25);
            this._build.TabIndex = 8;
            this._build.Text = "Собрать";
            this._build.UseVisualStyleBackColor = true;
            // 
            // _about
            // 
            this._about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._about.Location = new System.Drawing.Point(475, 432);
            this._about.Name = "_about";
            this._about.Size = new System.Drawing.Size(80, 25);
            this._about.TabIndex = 7;
            this._about.Text = "Программа";
            this._about.UseVisualStyleBackColor = true;
            this._about.Click += new System.EventHandler(this.AboutClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1090, 473);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "MainForm";
            this.Text = "Сборник";
            this.panel1.ResumeLayout(false);
            this.groupData.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.ListBox _listData;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.Button _buttonRemove;
        private System.Windows.Forms.Button _buttonSort;
        private System.Windows.Forms.Button _buttonDown;
        private System.Windows.Forms.Button _buttonUp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button _build;
        private System.Windows.Forms.Button _about;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _target;
        private System.Windows.Forms.Button _browseTarget;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _header;
        private System.Windows.Forms.Button _browseHeader;
    }
}

