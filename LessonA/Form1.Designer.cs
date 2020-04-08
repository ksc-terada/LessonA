namespace LessonA
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonRegister = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.label社員番号 = new System.Windows.Forms.Label();
            this.label退職日 = new System.Windows.Forms.Label();
            this.label入社日 = new System.Windows.Forms.Label();
            this.label氏名 = new System.Windows.Forms.Label();
            this.textBox氏名 = new LessonA.MaxByteLengthTextBox();
            this.textBox退職日 = new LessonA.DateTextBox();
            this.textBox入社日 = new LessonA.DateTextBox();
            this.textBox社員番号 = new LessonA.NumericTextBox();
            this.SuspendLayout();
            // 
            // buttonRegister
            // 
            this.buttonRegister.Enabled = false;
            this.buttonRegister.Location = new System.Drawing.Point(54, 127);
            this.buttonRegister.Name = "buttonRegister";
            this.buttonRegister.Size = new System.Drawing.Size(40, 23);
            this.buttonRegister.TabIndex = 4;
            this.buttonRegister.Text = "登録";
            this.buttonRegister.UseVisualStyleBackColor = true;
            this.buttonRegister.Click += new System.EventHandler(this.buttonRegister_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(148, 127);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(61, 23);
            this.buttonCancel.TabIndex = 6;
            this.buttonCancel.Text = "キャンセル";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Enabled = false;
            this.buttonDelete.Location = new System.Drawing.Point(102, 127);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(40, 23);
            this.buttonDelete.TabIndex = 5;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // label社員番号
            // 
            this.label社員番号.AutoSize = true;
            this.label社員番号.Location = new System.Drawing.Point(54, 30);
            this.label社員番号.Name = "label社員番号";
            this.label社員番号.Size = new System.Drawing.Size(53, 12);
            this.label社員番号.TabIndex = 7;
            this.label社員番号.Text = "社員番号";
            // 
            // label退職日
            // 
            this.label退職日.AutoSize = true;
            this.label退職日.Location = new System.Drawing.Point(54, 105);
            this.label退職日.Name = "label退職日";
            this.label退職日.Size = new System.Drawing.Size(41, 12);
            this.label退職日.TabIndex = 8;
            this.label退職日.Text = "退職日";
            // 
            // label入社日
            // 
            this.label入社日.AutoSize = true;
            this.label入社日.Location = new System.Drawing.Point(54, 80);
            this.label入社日.Name = "label入社日";
            this.label入社日.Size = new System.Drawing.Size(41, 12);
            this.label入社日.TabIndex = 9;
            this.label入社日.Text = "入社日";
            // 
            // label氏名
            // 
            this.label氏名.AutoSize = true;
            this.label氏名.Location = new System.Drawing.Point(54, 55);
            this.label氏名.Name = "label氏名";
            this.label氏名.Size = new System.Drawing.Size(29, 12);
            this.label氏名.TabIndex = 10;
            this.label氏名.Text = "氏名";
            // 
            // textBox氏名
            // 
            this.textBox氏名.Location = new System.Drawing.Point(109, 52);
            this.textBox氏名.MaxLength = HumanResource.氏名桁数;
            this.textBox氏名.Name = "textBox氏名";
            this.textBox氏名.ReadOnly = true;
            this.textBox氏名.Size = new System.Drawing.Size(100, 19);
            this.textBox氏名.TabIndex = 1;
            // 
            // textBox退職日
            // 
            this.textBox退職日.Location = new System.Drawing.Point(109, 102);
            this.textBox退職日.MaxLength = 8;
            this.textBox退職日.Name = "textBox退職日";
            this.textBox退職日.ReadOnly = true;
            this.textBox退職日.Size = new System.Drawing.Size(100, 19);
            this.textBox退職日.TabIndex = 3;
            // 
            // textBox入社日
            // 
            this.textBox入社日.Location = new System.Drawing.Point(109, 77);
            this.textBox入社日.MaxLength = 8;
            this.textBox入社日.Name = "textBox入社日";
            this.textBox入社日.ReadOnly = true;
            this.textBox入社日.Size = new System.Drawing.Size(100, 19);
            this.textBox入社日.TabIndex = 2;
            // 
            // textBox社員番号
            // 
            this.textBox社員番号.Location = new System.Drawing.Point(109, 27);
            this.textBox社員番号.MaxLength = HumanResource.社員番号桁数;
            this.textBox社員番号.Name = "textBox社員番号";
            this.textBox社員番号.Size = new System.Drawing.Size(100, 19);
            this.textBox社員番号.TabIndex = 0;
            this.textBox社員番号.Leave += new System.EventHandler(this.textBox社員番号_Leave);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 178);
            this.Controls.Add(this.textBox氏名);
            this.Controls.Add(this.label氏名);
            this.Controls.Add(this.label入社日);
            this.Controls.Add(this.label退職日);
            this.Controls.Add(this.label社員番号);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textBox退職日);
            this.Controls.Add(this.textBox入社日);
            this.Controls.Add(this.textBox社員番号);
            this.Controls.Add(this.buttonRegister);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "人事情報保守";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonRegister;
        private NumericTextBox textBox社員番号;
        private DateTextBox textBox入社日;
        private DateTextBox textBox退職日;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Label label社員番号;
        private System.Windows.Forms.Label label退職日;
        private System.Windows.Forms.Label label入社日;
        private System.Windows.Forms.Label label氏名;
        private MaxByteLengthTextBox textBox氏名;
    }
}

