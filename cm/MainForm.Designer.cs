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
            this.groupData = new System.Windows.Forms.GroupBox();
            this.listData = new System.Windows.Forms.ListBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDel = new System.Windows.Forms.Button();
            this.buttonSort = new System.Windows.Forms.Button();
            this.buttonDown = new System.Windows.Forms.Button();
            this.buttonUp = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this._header = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this._target = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this._build = new System.Windows.Forms.Button();
            this.groupData.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupData
            // 
            this.groupData.AccessibleRole = System.Windows.Forms.AccessibleRole.Border;
            this.groupData.Controls.Add(this.listData);
            this.groupData.Controls.Add(this.buttonAdd);
            this.groupData.Controls.Add(this.buttonDel);
            this.groupData.Controls.Add(this.buttonSort);
            this.groupData.Controls.Add(this.buttonDown);
            this.groupData.Controls.Add(this.buttonUp);
            this.groupData.Location = new System.Drawing.Point(12, 12);
            this.groupData.Name = "groupData";
            this.groupData.Size = new System.Drawing.Size(330, 270);
            this.groupData.TabIndex = 0;
            this.groupData.TabStop = false;
            this.groupData.Text = "Входные данные";
            // 
            // listData
            // 
            this.listData.FormattingEnabled = true;
            this.listData.Location = new System.Drawing.Point(6, 19);
            this.listData.Name = "listData";
            this.listData.Size = new System.Drawing.Size(318, 212);
            this.listData.TabIndex = 5;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(257, 241);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(70, 25);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.AddClick);
            // 
            // buttonDel
            // 
            this.buttonDel.Location = new System.Drawing.Point(181, 241);
            this.buttonDel.Name = "buttonDel";
            this.buttonDel.Size = new System.Drawing.Size(70, 25);
            this.buttonDel.TabIndex = 3;
            this.buttonDel.Text = "Убрать";
            this.buttonDel.UseVisualStyleBackColor = true;
            this.buttonDel.Click += new System.EventHandler(this.RemoveClick);
            // 
            // buttonSort
            // 
            this.buttonSort.Location = new System.Drawing.Point(72, 241);
            this.buttonSort.Name = "buttonSort";
            this.buttonSort.Size = new System.Drawing.Size(80, 25);
            this.buttonSort.TabIndex = 2;
            this.buttonSort.Text = "Сортировать";
            this.buttonSort.UseVisualStyleBackColor = true;
            this.buttonSort.Click += new System.EventHandler(this.SortClick);
            // 
            // buttonDown
            // 
            this.buttonDown.Location = new System.Drawing.Point(36, 241);
            this.buttonDown.Name = "buttonDown";
            this.buttonDown.Size = new System.Drawing.Size(30, 25);
            this.buttonDown.TabIndex = 1;
            this.buttonDown.Text = "dn";
            this.buttonDown.UseVisualStyleBackColor = true;
            this.buttonDown.Click += new System.EventHandler(this.DownClick);
            // 
            // buttonUp
            // 
            this.buttonUp.Location = new System.Drawing.Point(0, 241);
            this.buttonUp.Name = "buttonUp";
            this.buttonUp.Size = new System.Drawing.Size(30, 25);
            this.buttonUp.TabIndex = 0;
            this.buttonUp.Text = "up";
            this.buttonUp.UseVisualStyleBackColor = true;
            this.buttonUp.Click += new System.EventHandler(this.UpClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this._header);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(356, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(330, 90);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Файл-заголовок";
            // 
            // _header
            // 
            this._header.Location = new System.Drawing.Point(20, 19);
            this._header.Name = "_header";
            this._header.ReadOnly = true;
            this._header.Size = new System.Drawing.Size(304, 20);
            this._header.TabIndex = 6;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(254, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 25);
            this.button1.TabIndex = 5;
            this.button1.Text = "Найти";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.HeaderBrowseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this._target);
            this.groupBox3.Controls.Add(this.button4);
            this.groupBox3.Location = new System.Drawing.Point(355, 120);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(330, 90);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Результат";
            // 
            // _target
            // 
            this._target.Location = new System.Drawing.Point(20, 19);
            this._target.Name = "_target";
            this._target.ReadOnly = true;
            this._target.Size = new System.Drawing.Size(304, 20);
            this._target.TabIndex = 7;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(255, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(70, 25);
            this.button4.TabIndex = 6;
            this.button4.Text = "Указать";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.TargetBrowseClick);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(600, 253);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 25);
            this.button2.TabIndex = 5;
            this.button2.Text = "Программа";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // _build
            // 
            this._build.Location = new System.Drawing.Point(514, 253);
            this._build.Name = "_build";
            this._build.Size = new System.Drawing.Size(80, 25);
            this._build.TabIndex = 6;
            this._build.Text = "Собрать";
            this._build.UseVisualStyleBackColor = true;
            this._build.Click += new System.EventHandler(this.BuildClick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(692, 294);
            this.Controls.Add(this._build);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupData);
            this.Name = "MainForm";
            this.Text = "Сборник";
            this.groupData.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupData;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDel;
        private System.Windows.Forms.Button buttonSort;
        private System.Windows.Forms.Button buttonDown;
        private System.Windows.Forms.Button buttonUp;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox listData;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button _build;
        private System.Windows.Forms.TextBox _header;
        private System.Windows.Forms.TextBox _target;
    }
}

