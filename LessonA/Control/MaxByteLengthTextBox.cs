
using System.Windows.Forms;
using System.ComponentModel;

namespace LessonA
{
    public class MaxByteLengthTextBox : TextBox
    {
        public MaxByteLengthTextBox()
        {
            this.KeyPress += MaxByteLengthTextBox_KeyPress;
        }

        private void MaxByteLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ( e.KeyChar == '\b') return;

            if (char.IsControl(e.KeyChar)) {
                e.Handled = true;
                return;
            }

            System.Text.Encoding sJis = System.Text.Encoding.GetEncoding("Shift_JIS");
            int textByteCount = sJis.GetByteCount(this.Text);
            int inputByteCount = sJis.GetByteCount(e.KeyChar.ToString());
            int selectedTextByteCount = sJis.GetByteCount(this.SelectedText);

            if ((textByteCount + inputByteCount - selectedTextByteCount) > this.MaxLength)
            {
                e.Handled = true;
                return;
            }
        }

        //右クリック禁止用。コピペ対策。
        private const int WM_CONTEXTMENU = 0x7B;
        protected override void WndProc(ref Message m)
        {
            //WM_CONTEXTMENUメッセージの時は何もしないようにする
            if (m.Msg == WM_CONTEXTMENU)
            {
                return;
            }
            base.WndProc(ref m);
        }
    }
}
