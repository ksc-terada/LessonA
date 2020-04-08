using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonA
{
    class DateTextBox : NumericTextBox
    {
        private string prevText = "";

        public DateTextBox()
        {
            this.Enter += DateTextBox_Enter;
            this.Leave += DateTextBox_Leave;
            this.prevText = this.Text;
        }

        private void DateTextBox_Enter(object sender, EventArgs e)
        {
            prevText = this.Text;
            this.Text = this.Text.Replace("/", "");
        }
        private void DateTextBox_Leave(object sender, EventArgs e)
        {
            DateTextBox_Validated();
        }

        public void DateTextBox_Validated()
        {
            string text = this.Text;
            //空は許す
            if (text == "")
            {
                prevText = "";
                return;
            }
            //8桁以外は論外
            if (text.Length != 8)
            {
                //Enter時に退避していた値に戻す。
                this.Text = prevText;
                return;
            }

            //斜線を挟む
            text = text.Insert(6, "/");
            text = text.Insert(4, "/");

            //日付として正しいか確認する
            DateTime test = new DateTime();
            if (!DateTime.TryParse(text, out test))
            {
                //Enter時に退避していた値に戻す。
                this.Text = prevText;
                return;
            }

            this.Text = text;
        }
    }
}
