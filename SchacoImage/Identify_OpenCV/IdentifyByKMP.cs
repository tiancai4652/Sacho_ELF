using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImageIdentify
{
    /// <summary>
    /// KMP算法，没试验过
    /// </summary>
    public class IdentifyByKMP
    {
        /// <summary>
        /// 串的模式匹配 KMP算法
        /// </summary>
        /// <param name="str"></param>
        /// <param name="model"></param>
        /// <param name="pos"></param>
        /// <returns></returns>
        private static int KmpMatch(char[] str, char[] model, int pos)
        {
            int loc = -1;
            if (pos < 1 || pos > str.Length)
            {
                return loc;
            }

            int i = pos - 1;
            int j = 0;
            int[] next = GetNext(model);

            while (i < str.Length && j < model.Length)
            {
                if (j == -1 || str[i] == model[j])
                {
                    i++;
                    j++;
                }
                else
                    j = next[j];
            }
            if (j >= model.Length)
                loc = i - model.Length;

            return loc;
        }

        /// <summary>
        /// 求next[]
        /// </summary>
        /// <param name="T"></param>
        /// <returns></returns>
        private static int[] GetNext(char[] T)
        {
            int[] next = new int[T.Length];
            next[0] = -1;


            int i = 0, j = -1;

            while (i < T.Length - 1)
            {
                if (j == -1 || T[i] == T[j])
                {
                    ++i; ++j;
                    if (T[i] != T[j])
                        next[i] = j;
                    else
                        next[i] = next[j];
                }
                else
                    j = next[j];
            }

            return next;
        }
    }
}
