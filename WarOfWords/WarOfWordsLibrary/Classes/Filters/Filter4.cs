﻿using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Classes.Filters
{
    public class Filter4 : BaseFilter, IFilter
    {
        public string Rank
        {
            get
            {
                return "C";
            }
        }

        public string FilterName
        {
            get { throw new System.NotImplementedException(); }
        }

        public string FilterDescription
        {
            get { throw new System.NotImplementedException(); }
        }

        public string FilterExample
        {
            get
            {
                return "sword->word";
            }
        }

        public int MaxPrecision
        {
            get
            {
                return 9;
            }
        }

        public int SortID
        {
            get
            {
                return 4;
            }
        }

        public int GetFilterElements(string keyWord)
        {
            FilterElements = new List<FilterElement>();
            if (keyWord.Length < 3)
            {
                return FilterElements.Count;
            }
            for (int i = 1; i < keyWord.Length; i++)
            {
                FilterElement filterElement = new FilterElement();
                filterElement.BaseSortID = i;
                filterElement.WordLength = keyWord.Length - i;
                float portion = (float)filterElement.WordLength / keyWord.Length;
                if (portion < 0.1f*Precision)
                {
                    break;
                }
                if (!WordLengthList.Contains(filterElement.WordLength))
                {
                    continue;
                }
                filterElement.Filter = "WORD = '" + keyWord.Substring(i, filterElement.WordLength) + "'";
                FilterElements.Add(filterElement);
            }
            return FilterElements.Count;
        }
    }
}
