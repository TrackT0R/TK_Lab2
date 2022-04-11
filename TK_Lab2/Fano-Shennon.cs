using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace TK_Lab2
{
    class item : IComparable<item>
    {
        public char symbol;
        public int cnt;

        public item(KeyValuePair<char, int> elem)
        {
            symbol = elem.Key;
            cnt = elem.Value;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public int CompareTo(item other)
        {
            return other.cnt.CompareTo(cnt);
        }
    }

    public static class Fano_Shennon
    {
        public static string EncryptFile(string filename)
        {
            var CodesList = new List<KeyValuePair<char, string>>();
            var codes = new Dictionary<char, string>();

            //считаем все символы и их частоту
            var SymbolsList = BuildSymbolsList(filename);
            
            if (SymbolsList.Count == 0)
                return "Файл не содержит текста";
            BuildCodesList(SymbolsList, ref CodesList, "");

            foreach (KeyValuePair<char, string> elem in CodesList)
                codes[elem.Key] = elem.Value;

            return Encryption(filename, codes);
        }

        public static string DecryptFile(string filename)
        {
            var sr = new StreamReader(filename);
            //чтение списка кодов, инвертирования дял быстрого и удобного поиска по словарю
            var codes = (Dictionary<char, string>)JsonSerializer.Deserialize(sr.ReadLine(), typeof(Dictionary<char, string>));
            var symbols = new Dictionary<string, char>();
            foreach(KeyValuePair<char, string> elem in codes)
                symbols.Add(elem.Value, elem.Key);

            var sb = new StringBuilder();
            var answer = new StringBuilder();
            foreach (char c in sr.ReadToEnd()) {
                sb.Append(c);
                if (symbols.ContainsKey(sb.ToString())) {
                    answer.Append(symbols[sb.ToString()]);
                    sb.Clear();
                }
            }
            sr.Close();
            return answer.ToString();
        }


        private static string Encryption(string filename, Dictionary<char, string> codes)
        {
            double SourceCharCnt = 0, EncryptedBitsCnt = 0;
            var sr = new StreamReader(filename);
            var sb = new StringBuilder();

            //кодирование последовательно каждого символа
            foreach (char c in sr.ReadToEnd()) {
                sb.Append(codes[c]);
                SourceCharCnt++;
                EncryptedBitsCnt += (double)codes[c].Length;
            }
            //расчёты
            var SourceBitsCnt = SourceCharCnt * 8;
            var CompressRatio = Math.Truncate((1.0 - (EncryptedBitsCnt / SourceBitsCnt)) * 100);

            //сохранение в файл
            var newfilename = filename.Insert(filename.Length-3, "e");
            var sw = new StreamWriter(newfilename);
            sw.WriteLine(JsonSerializer.Serialize(codes));
            sw.WriteLine(sb.ToString());
            sw.Close();
            
            //информационный вывод
            return $"Исходный текст занимал {SourceBitsCnt} бит.\r\n" +
                $"Закодированный текст занимает {EncryptedBitsCnt} бит.\r\n" +
                $"Степень сжатия составила {CompressRatio}%" +
                $"\r\nЗакодированный текст сохранён в файле {newfilename}";
        }

        private static List<item> BuildSymbolsList(string filename)
        {
            var sr = new StreamReader(filename);
            var dict = new Dictionary<char, int>();

            //при чтении символы для скорости заносятся в словарь
            foreach (char c in sr.ReadToEnd()) {
                dict[c] = dict.ContainsKey(c) ? dict[c] + 1 : 1;
            }
            sr.Close();

            //символы для удобства переносятся в лист и сортируются
            var list = new List<item>();
            foreach (KeyValuePair<char, int> elem in dict) {
                list.Add(new item(elem));
            }

            list.Sort();

            return list;
        }

        private static void BuildCodesList(List<item>                           SymbolsList,
                                           ref List<KeyValuePair<char, string>> CodesList,
                                           string                               currentCode)
        {
            //нашли код для символа
            if (SymbolsList.Count == 1) {
                if (currentCode.ToString().Equals(""))
                    currentCode = "0";
                CodesList.Add(new KeyValuePair<char, string>(SymbolsList[0].symbol, currentCode.ToString()));
                return;
            }
            
            //делим список символов поровну по частоте и распределяем между ними коды
            var listMid = ListMiddle(SymbolsList);
            BuildCodesList(SymbolsList.GetRange(0, listMid),                         ref CodesList, currentCode + '0');
            BuildCodesList(SymbolsList.GetRange(listMid, SymbolsList.Count-listMid), ref CodesList, currentCode + '1');
        }

        private static int ListMiddle (List<item> list)
        {
            //поиск середины, если считать по частоте символов
            int sum = list.Sum(item => item.cnt), sum_temp = list[0].cnt, i;
            
            for (i = 1; i < list.Count; i++) {
                if (sum_temp >= sum/2)
                    break;
                sum_temp += list[i].cnt;
            }

            return i;
        }
    }
}
