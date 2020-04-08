using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LessonA
{
    class HumanResource
    {
        public static int 社員番号桁数 = 10;
        private string _社員番号;
        internal string 社員番号
        {
            get { return this._社員番号; }
            private set
            {
                if (value.Length > 社員番号桁数)
                {
                    throw new HumanResourceException("社員番号桁数超過");
                }
                if (value == "")
                {
                    throw new HumanResourceException("社員番号空");
                }
                this._社員番号 = value;
            }
        }

        public static int 氏名桁数 = 20;
        private string _氏名;
        internal string 氏名
        {
            get { return this._氏名; }
            private set
            {
                if (value.Length > 氏名桁数)
                {
                    throw new HumanResourceException("氏名桁数超過");
                }
                this._氏名 = value;
            }
        }

        private string _入社日;
        internal string 入社日
        {
            get { return this._入社日; }
            private set { this._入社日 = value; }
        }

        private string _退職日;
        internal string 退職日
        {
            get { return this._退職日; }
            private set
            {
                if (value != "")
                {
                    if (String.Compare(this.入社日, value) > 0)
                    {
                        throw new HumanResourceException("入社日 > 退職日");
                    }
                }
                this._退職日 = value;
            }
        }

        public HumanResource(string 社員番号, string 氏名, string 入社日, string 退職日)
        {
            this.社員番号 = 社員番号;
            this.氏名 = 氏名;
            this.入社日 = 入社日;
            this.退職日 = 退職日;
        }

        public class HumanResourceException : Exception
        {
            public HumanResourceException(string message) : base(message)
            {
            }
        }
    }
}
