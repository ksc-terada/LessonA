using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LessonA
{
    interface IButtonState
    {
        void Execute();
    }

    internal class Insert : IButtonState
    {
        private HumanResource hr;
        private SqlConnection connection;

        internal Insert(HumanResource hr, SqlConnection connection)
        {
            this.hr = hr;
            this.connection = connection;
        }

        public void Execute()
        {
            using (var transaction = connection.BeginTransaction())
            using (var command = new SqlCommand() { Connection = connection, Transaction = transaction })
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"INSERT INTO").AppendLine()
                      .Append(@"  HumanResource").AppendLine()
                      .Append(@"VALUES").AppendLine()
                      .Append(@"(").AppendLine()
                      .Append(@"  '").Append(hr.社員番号).Append(@"',").AppendLine()
                      .Append(@"  '").Append(hr.氏名).Append(@"',").AppendLine()
                      .Append(@"  '").Append(hr.入社日).Append(@"',").AppendLine()
                      .Append(@"  '").Append(hr.退職日).Append(@"'").AppendLine()
                      .Append(@")");

                    // 実行するSQLの準備
                    command.CommandText = sb.ToString();

                    // SQLの実行
                    command.ExecuteNonQuery();

                    // コミット
                    transaction.Commit();

                    MessageBox.Show("登録しました");
                }
                catch (SqlException ex)
                {
                    // ロールバック
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
    internal class Update : IButtonState
    {
        private HumanResource hr;
        private SqlConnection connection;

        internal Update(HumanResource hr, SqlConnection connection)
        {
            this.hr = hr;
            this.connection = connection;
        }

        public void Execute()
        {
            using (var transaction = connection.BeginTransaction())
            using (var command = new SqlCommand() { Connection = connection, Transaction = transaction })
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"UPDATE").AppendLine()
                      .Append(@"  HumanResource").AppendLine()
                      .Append(@"SET").AppendLine()
                      .Append(@"  ""氏名"" = '").Append(hr.氏名).Append(@"',").AppendLine()
                      .Append(@"  ""入社日"" = '").Append(hr.入社日).Append(@"',").AppendLine()
                      .Append(@"  ""退職日"" = '").Append(hr.退職日).Append(@"'").AppendLine()
                      .Append(@"WHERE").AppendLine()
                      .Append(@"  ""社員番号"" = '").Append(hr.社員番号).Append(@"'");

                    // 実行するSQLの準備
                    command.CommandText = sb.ToString();

                    // SQLの実行
                    command.ExecuteNonQuery();

                    // コミット
                    transaction.Commit();

                    MessageBox.Show("登録しました");
                }
                catch (SqlException ex)
                {
                    // ロールバック
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }
    internal class Delete : IButtonState
    {
        private HumanResource hr;
        private SqlConnection connection;

        internal Delete(HumanResource hr, SqlConnection connection)
        {
            this.hr = hr;
            this.connection = connection;
        }
        internal Delete(string employeeNumber, SqlConnection connection)
        {
            this.hr = new HumanResource(employeeNumber, "","","");
            this.connection = connection;
        }

        public void Execute()
        {
            using (var transaction = connection.BeginTransaction())
            using (var command = new SqlCommand() { Connection = connection, Transaction = transaction })
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    sb.Append(@"DELETE FROM HumanResource WHERE ""社員番号"" = '").Append(hr.社員番号).Append(@"'");

                    // 実行するSQLの準備
                    command.CommandText = sb.ToString();

                    // SQLの実行
                    command.ExecuteNonQuery();

                    // コミット
                    transaction.Commit();

                    MessageBox.Show("削除しました");
                }
                catch (SqlException ex)
                {
                    // ロールバック
                    transaction.Rollback();
                    throw;
                }
            }
        }
    }

    /* ややこしくなるのでForm側で制御。
    internal class Cancel : IButtonState
    {
        private Form1 form;
        internal Cancel(Form1 form)
        {
            this.form = form;
        }

        public void Execute()
        {
            form.ClearControl();
        }
    }
    */
}
