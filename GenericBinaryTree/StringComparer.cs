using System.Collections.Generic;

namespace BinaryTreeLibrary
{
    /// <summary>
    /// Class is a comparer for string type instances
    /// </summary>
    public class StringComparer : IComparer<string>
    {
        /// <summary>
        /// Method allows to compare two instances
        /// </summary>
        /// <param name="arg1">First instance</param>
        /// <param name="arg2">Second instance</param>
        /// <returns>(-1)(arg1 less than arg2) or (0) (arg1 == arg2) or (1)(arg1 > arg2)</returns>
        public int Compare(string arg1, string arg2)
        {
            return arg1.CompareTo(arg2);           
        }
    }
}