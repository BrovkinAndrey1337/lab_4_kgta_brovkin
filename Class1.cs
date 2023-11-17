using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practic_1_Degtev
{
    public class Encryption
    {
        private string key;
        private string text;
        public Encryption(string txt)
        {
            txt = txt.ToUpper();
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ+-=*&?^%$#@!;:()";
            bool engAlpha = false;
            for (int i = 0; i < txt.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (txt[i] == alpha[j])
                    {
                        engAlpha = true;
                        break;
                    }
                }
            }
            if (txt.Length < 4)
                throw new ArgumentException("Текст пуст или недостаточно большой");
            if (engAlpha == true)
                throw new ArgumentException("Текст содержит недопустимые символы");
            text = txt;
            createKey();
            Encode();
        }

        public Encryption(string txt, string key)
        {
            txt = txt.ToUpper();
            string alpha = "ABCDEFGHIJKLMNOPQRSTUVWXYZ+-=*&?^%$#@!;:()";
            bool engAlpha = false;
            for (int i = 0; i < txt.Length; i++)
            {
                for (int j = 0; j < alpha.Length; j++)
                {
                    if (txt[i] == alpha[j])
                    {
                        engAlpha = true;
                        break;
                    }
                }
            }
            if (txt.Length < 4)
                throw new ArgumentException("Текст пуст или недостаточно большой");
            if (engAlpha == true)
                throw new ArgumentException("Текст содержит недопустимые символы");
            text = txt;
            text = txt;
            this.key = key;
        }

        private void createKey()
        {
            Random rand = new Random();
            int n = text.Length;
            for (int i = 0; i < n; i++)
            {
                char tmp = (char)rand.Next('А', 'Я' + 1);
                key += tmp.ToString();
            }
        }

        private void Encode()
        {
            text = text.ToUpper();
            key = key.ToUpper();
            char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                             'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                             'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                             'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                              '8', '9', '0'};
            int N = characters.Length;
            string result = "";
            int keyIndex = 0;
            foreach (char symbol in text)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, key[keyIndex])) % N;
                result += characters[c];
                keyIndex++;
                if ((keyIndex + 1) == key.Length)
                    keyIndex = 0;
            }
            text = result;
        }
        public string Decode()
        {
            char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                'Э', 'Ю', 'Я', ' ', '1', '2', '3', '4', '5', '6', '7',
                                                '8', '9', '0' };
            int N = characters.Length;
            string result = "";

            int keyword_index = 0;

            foreach (char symbol in text)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, key[keyword_index])) % N;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == key.Length)
                    keyword_index = 0;
            }
            return result;
        }

        public string getKey()
        {
            return key;
        }

        public string getEncodeText()
        {
            return text;
        }
    }

}
