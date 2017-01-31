using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SimpleClientWordProcessor
{
    [Serializable]
    public class MostUsedWord
    {
        public string word;
        public int count;


        public MostUsedWord(string word, int count)
        {
            this.word = word;
            this.count = count;
        }

    }
}
