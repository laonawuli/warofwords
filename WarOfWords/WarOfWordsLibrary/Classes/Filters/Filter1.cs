﻿using System.Collections.Generic;
using WarOfWordsLibrary.Classes.Interfaces;
using WarOfWordsLibrary.Classes.Objects;

namespace WarOfWordsLibrary.Classes.Filters
{
    public class Filter1 : BaseFilter, IFilter
    {
        public string Rank
        {
            get
            {
                return "B";
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
                return "word->words";
            }
        }

        public int MaxPrecision
        {
            get
            {
                return 0;
            }
        }

        public int SortID
        {
            get
            {
                return 1;
            }
        }

        public int GetFilterElements(string keyWord)
        {
            FilterElements = new List<FilterElement>();
            FilterElement filterElement = new FilterElement();
            filterElement.BaseSortID = 1;
            filterElement.QueryFromDataBase = true;
            filterElement.Filter = "WORD LIKE '" + keyWord + "%' AND LENGTH(WORD) > " + keyWord.Length;
            FilterElements.Add(filterElement);
            return FilterElements.Count;
        }
    }
}
