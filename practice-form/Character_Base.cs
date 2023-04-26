using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practice_form
{
    internal class Character_Base
    {
        public Character_Base()
        {
            var num0 = "0010001010100010000000000".ToCharArray();
            var num1 = "0000000000100010101000100".ToCharArray();
            var num2 = "0010000010111110001000100".ToCharArray();
            var num3 = "0010000100001000000000100".ToCharArray();
            var num4 = "1010001010100010000000000".ToCharArray();
            var num5 = "0100000000100010101000100".ToCharArray();
            var num6 = "0011000010111110001000100".ToCharArray();
            var num7 = "0010100100001000000000100".ToCharArray();
            var num8 = "0000010000100010101000100".ToCharArray();
            var num9 = "0010001010111110001000100".ToCharArray();
            var num10 = "0010001100001000000000100".ToCharArray();

            char[][] base_nums = { num0, num1, num2, num3, num4, num5, num6, num7, num8, num9, num10 };
        }
        public static char[][] base_nums { get; set; }
    }
}
