using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace LessonA
{
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private IModeState state;

        public Form1(SqlConnection connection)
        {
            InitializeComponent();

            this.connection = connection;
            this.state = new Default(this);
        }

        public void ClearControl()
        {
            this.textBox氏名.ReadOnly = true;
            this.textBox入社日.ReadOnly = true;
            this.textBox退職日.ReadOnly = true;
            this.buttonRegister.Enabled = false;
            this.buttonDelete.Enabled = false;

            this.textBox社員番号.Text = "";
            this.textBox氏名.Text = "";
            this.textBox入社日.Text = "";
            this.textBox退職日.Text = "";
        }

        /// <summary>
        /// 入力内容からHRインスタンス作成。
        /// </summary>
        /// <returns>入力内容が不正の場合、nullを返します。</returns>
        private HumanResource GetHumanResource()
        {
            //ここでthrowしてプログラムを終了したくないのでcatch。
            try
            {
                return new HumanResource(
                    this.textBox社員番号.Text
                    , this.textBox氏名.Text
                    , this.textBox入社日.Text.Replace("/", "")
                    , this.textBox退職日.Text.Replace("/", "")
                );
            }
            catch (HumanResource.HumanResourceException ex)
            {
                MessageBox.Show(ex.Message, "入力内容不正");
                return null;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            HumanResource hr = GetHumanResource();
            if (null == hr) return;

            //社員がいたら更新
            state.Register(hr, connection);

            state = new Default(this);
            state.EnableControl();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //削除時に不正チェックをする必要はない。
            //HumanResource hr = GetHumanResource();
            //if (null == hr) return;
            HumanResource hr = new HumanResource(this.textBox社員番号.Text, "", "", "");

            var yesno = MessageBox.Show("削除してよろしいですか", "削除確認", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (yesno != DialogResult.Yes) return;

            state.Delete(hr, connection);

            state = new Default(this);
            state.EnableControl();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            state.Cancel();
        }

        private void textBox社員番号_Leave(object sender, EventArgs e)
        {
            string text = textBox社員番号.Text;
            //空の場合補正しない。
            if (text == "") return;

            textBox社員番号.Text = String.Format("{0," + textBox社員番号.MaxLength.ToString() + "}", text).Replace(' ', '0');

            //0埋めしたあと、その社員がいるかいないか探しに行く。
            SearchEmployee(this.textBox社員番号.Text);
        }

        private void SearchEmployee(string employeeNumber)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(@"select * from HumanResource where ""社員番号"" = '").Append(employeeNumber).Append(@"'");
            using (var command = new SqlCommand() { Connection = connection ,CommandText = sb.ToString() })
            using (var reader = command.ExecuteReader())
            {
                try
                {
                    // SQLの実行
                    if (reader.Read())
                    {
                        HumanResource hr = new HumanResource(
                            reader["社員番号"].ToString(),
                            reader["氏名"].ToString(),
                            reader["入社日"].ToString(),
                            reader["退職日"].ToString()
                        );
                        state = new IsExistEmployee(this, hr);
                    }
                    else
                    {
                        state = new NotExistEmployee(this);
                    }
                    state.EnableControl();
                }
                catch (SqlException ex)
                {
                    throw;
                }
            }
        }

        #region Form1制御interface

        /// <summary>
        /// 初期状態、登録、更新・削除の３状態を管理。
        /// それぞれボタン押下時の挙動について定義する。
        /// </summary>
        interface IModeState
        {
            /// <summary>
            /// UIの制御を行う。
            /// </summary>
            void EnableControl();

            /// <summary>
            /// 登録ボタン押下
            /// </summary>
            /// <param name="hr"></param>
            /// <param name="connection"></param>
            void Register(HumanResource hr, SqlConnection connection);

            /// <summary>
            /// 削除ボタン押下
            /// </summary>
            /// <param name="hr"></param>
            /// <param name="connection"></param>
            void Delete(HumanResource hr, SqlConnection connection);

            /// <summary>
            /// キャンセルボタン押下
            /// </summary>
            void Cancel();
        }

        /// <summary>
        /// 初期状態
        /// </summary>
        private class Default : IModeState
        {
            private Form1 form;
            public Default(Form1 form)
            {
                this.form = form;
            }

            public void EnableControl()
            {
                Cancel();
            }

            public void Register(HumanResource hr, SqlConnection connection)
            {
                return;
            }
            public void Delete(HumanResource hr, SqlConnection connection)
            {
                return;
            }
            public void Cancel()
            {
                form.ClearControl();
            }
        }

        /// <summary>
        /// 社員がいない状態。登録。
        /// </summary>
        private class NotExistEmployee : IModeState
        {
            private Form1 form;
            public NotExistEmployee(Form1 form)
            {
                this.form = form;
            }

            public void EnableControl()
            {
                form.textBox氏名.ReadOnly = false;
                form.textBox入社日.ReadOnly = false;
                form.textBox退職日.ReadOnly = false;
                form.buttonRegister.Enabled = true; //★
                form.buttonDelete.Enabled = false;

                form.textBox氏名.Text = "";
                form.textBox入社日.Text = "";
                form.textBox退職日.Text = "";
            }
            public void Register(HumanResource hr, SqlConnection connection)
            {
                Insert button = new Insert(hr, connection);
                button.Execute();
            }
            public void Delete(HumanResource hr, SqlConnection connection)
            {
                return;
            }
            public void Cancel()
            {
                form.ClearControl();
            }
        }

        /// <summary>
        /// 社員がいる状態。
        /// </summary>
        private class IsExistEmployee : IModeState
        {
            private Form1 form;
            private HumanResource hr;
            public IsExistEmployee(Form1 form, HumanResource hr)
            {
                this.form = form;
                this.hr = hr;
            }

            /// <summary>
            /// DBから読み込んだ社員情報をテキストボックスに埋めていく。
            /// </summary>
            public void EnableControl()
            {
                form.textBox氏名.ReadOnly = false;
                form.textBox入社日.ReadOnly = false;
                form.textBox退職日.ReadOnly = false;
                form.buttonRegister.Enabled = true;
                form.buttonDelete.Enabled = true;

                form.textBox氏名.Text = hr.氏名;
                form.textBox入社日.Text = hr.入社日;
                form.textBox入社日.DateTextBox_Validated();
                form.textBox退職日.Text = hr.退職日;
                form.textBox退職日.DateTextBox_Validated();
            }
            public void Register(HumanResource hr, SqlConnection connection)
            {
                Update button = new Update(hr, connection);
                button.Execute();
            }
            public void Delete(HumanResource hr, SqlConnection connection)
            {
                Delete button = new Delete(hr, connection);
                button.Execute();
            }
            public void Cancel()
            {
                form.ClearControl();
            }
        }

        #endregion
    }
}
