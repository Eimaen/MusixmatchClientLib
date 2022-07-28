using System;
using System.Collections.Generic;
using System.Text;

namespace MusixmatchClientLib.Utils
{
    public class GenericTypeConversion<F, T>
    {
        public List<T> MergeToList(List<F> inputList, Action<F, List<T>> action)
        {
            List<T> convertToList = new List<T>();

            for (int i = 0; i < inputList.Count; i++)
            {
                F input = inputList[i];
                action(input, convertToList);
            }

            return convertToList;
        }
    }
}
