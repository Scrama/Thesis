﻿namespace cm
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
            System.Windows.Forms.TableLayoutPanel layout;
            System.Windows.Forms.Panel left;
            System.Windows.Forms.Panel right;
            this.groupData = new System.Windows.Forms.GroupBox();
            this._listData = new System.Windows.Forms.ListBox();
            this._buttonAdd = new System.Windows.Forms.Button();
            this._buttonRemove = new System.Windows.Forms.Button();
            this._buttonSort = new System.Windows.Forms.Button();
            this._buttonDown = new System.Windows.Forms.Button();
            this._buttonUp = new System.Windows.Forms.Button();
            this._build = new System.Windows.Forms.Button();
            this._about = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._target = new System.Windows.Forms.TextBox();
            this._browseTarget = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._header = new System.Windows.Forms.TextBox();
            this._browseHeader = new System.Windows.Forms.Button();
            layout = new System.Windows.Forms.TableLayoutPanel();
            left = new System.Windows.Forms.Panel();
            right = new System.Windows.Forms.Panel();
            layout.SuspendLayout();
            left.SuspendLayout();
            this.groupData.SuspendLayout();
            right.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // layout
            // 
            layout.ColumnCount = 2;
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layout.Controls.Add(right, 0, 0);
            layout.Controls.Add(left, 0, 0);
            layout.Dock = System.Windows.Forms.DockStyle.Fill;
            layout.Location = new System.Drawing.Point(0, 0);
            layout.Name = "layout";
            layout.RowCount = 1;
            layout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            layout.Size = new System.Drawing.Size(797, 478);
            layout.TabIndex = 9;
            // 
            // left
            // 
            left.Controls.Add(this.groupData);
            left.Dock = System.Windows.Forms.DockStyle.Fill;
            left.Location = new System.Drawing.Point(3, 3);
            left.Name = "left";
            left.Padding = new System.Windows.Forms.Padding(8);
            left.Size = new System.Drawing.Size(392, 472);
            left.TabIndex = 8;
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
            this.groupData.Size = new System.Drawing.Size(376, 456);
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
            this._listData.Size = new System.Drawing.Size(362, 381);
            this._listData.TabIndex = 5;
            // 
            // _buttonAdd
            // 
            this._buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonAdd.Location = new System.Drawing.Point(300, 423);
            this._buttonAdd.Name = "_buttonAdd";
            this._buttonAdd.Size = new System.Drawing.Size(70, 25);
            this._buttonAdd.TabIndex = 4;
            this._buttonAdd.Text = "Добавить";
            this._buttonAdd.UseVisualStyleBackColor = true;
            // 
            // _buttonRemove
            // 
            this._buttonRemove.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._buttonRemove.Location = new System.Drawing.Point(224, 423);
            this._buttonRemove.Name = "_buttonRemove";
            this._buttonRemove.Size = new System.Drawing.Size(70, 25);
            this._buttonRemove.TabIndex = 3;
            this._buttonRemove.Text = "Убрать";
            this._buttonRemove.UseVisualStyleBackColor = true;
            // 
            // _buttonSort
            // 
            this._buttonSort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonSort.Location = new System.Drawing.Point(80, 423);
            this._buttonSort.Name = "_buttonSort";
            this._buttonSort.Size = new System.Drawing.Size(80, 25);
            this._buttonSort.TabIndex = 2;
            this._buttonSort.Text = "Сортировать";
            this._buttonSort.UseVisualStyleBackColor = true;
            // 
            // _buttonDown
            // 
            this._buttonDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonDown.Location = new System.Drawing.Point(44, 423);
            this._buttonDown.Name = "_buttonDown";
            this._buttonDown.Size = new System.Drawing.Size(30, 25);
            this._buttonDown.TabIndex = 1;
            this._buttonDown.Text = "dn";
            this._buttonDown.UseVisualStyleBackColor = true;
            // 
            // _buttonUp
            // 
            this._buttonUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this._buttonUp.Location = new System.Drawing.Point(8, 423);
            this._buttonUp.Name = "_buttonUp";
            this._buttonUp.Size = new System.Drawing.Size(30, 25);
            this._buttonUp.TabIndex = 0;
            this._buttonUp.Text = "up";
            this._buttonUp.UseVisualStyleBackColor = true;
            // 
            // right
            // 
            right.Controls.Add(this._build);
            right.Controls.Add(this._about);
            right.Controls.Add(this.groupBox3);
            right.Controls.Add(this.groupBox2);
            right.Dock = System.Windows.Forms.DockStyle.Fill;
            right.Location = new System.Drawing.Point(401, 3);
            right.Name = "right";
            right.Padding = new System.Windows.Forms.Padding(8);
            right.Size = new System.Drawing.Size(393, 472);
            right.TabIndex = 9;
            // 
            // _build
            // 
            this._build.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._build.Location = new System.Drawing.Point(214, 431);
            this._build.Name = "_build";
            this._build.Size = new System.Drawing.Size(80, 25);
            this._build.TabIndex = 8;
            this._build.Text = "Собрать";
            this._build.UseVisualStyleBackColor = true;
            // 
            // _about
            // 
            this._about.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._about.Location = new System.Drawing.Point(300, 431);
            this._about.Name = "_about";
            this._about.Size = new System.Drawing.Size(80, 25);
            this._about.TabIndex = 7;
            this._about.Text = "Программа";
            this._about.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._target);
            this.groupBox3.Controls.Add(this._browseTarget);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(8, 98);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(377, 90);
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
            this._target.Size = new System.Drawing.Size(352, 20);
            this._target.TabIndex = 7;
            // 
            // _browseTarget
            // 
            this._browseTarget.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._browseTarget.Location = new System.Drawing.Point(302, 59);
            this._browseTarget.Name = "_browseTarget";
            this._browseTarget.Size = new System.Drawing.Size(70, 25);
            this._browseTarget.TabIndex = 6;
            this._browseTarget.Text = "Указать";
            this._browseTarget.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._header);
            this.groupBox2.Controls.Add(this._browseHeader);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(377, 90);
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
            this._header.Size = new System.Drawing.Size(352, 20);
            this._header.TabIndex = 6;
            // 
            // _browseHeader
            // 
            this._browseHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this._browseHeader.Location = new System.Drawing.Point(302, 59);
            this._browseHeader.Name = "_browseHeader";
            this._browseHeader.Size = new System.Drawing.Size(70, 25);
            this._browseHeader.TabIndex = 5;
            this._browseHeader.Text = "Найти";
            this._browseHeader.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 478);
            this.Controls.Add(layout);
            this.MinimumSize = new System.Drawing.Size(640, 400);
            this.Name = "MainForm";
            this.Text = "Сборник";
            layout.ResumeLayout(false);
            left.ResumeLayout(false);
            this.groupData.ResumeLayout(false);
            right.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button _build;
        private System.Windows.Forms.Button _about;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox _target;
        private System.Windows.Forms.Button _browseTarget;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox _header;
        private System.Windows.Forms.Button _browseHeader;
        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.ListBox _listData;
        private System.Windows.Forms.Button _buttonAdd;
        private System.Windows.Forms.Button _buttonRemove;
        private System.Windows.Forms.Button _buttonSort;
        private System.Windows.Forms.Button _buttonDown;
        private System.Windows.Forms.Button _buttonUp;
    }
}

