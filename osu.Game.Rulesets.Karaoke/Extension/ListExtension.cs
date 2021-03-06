﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Linq;

namespace osu.Game.Rulesets.Karaoke.Extension
{
    public static class ListExtension
    {
        /// <summary>
        ///     Split
        ///     http://www.jscto.net/html/31946.html
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="splitNumber"></param>
        /// <returns></returns>
        public static List<List<T>> Split<T>(this List<T> list, int splitNumber)
        {
            var listGroup = new List<List<T>>();
            var j = splitNumber;
            for (var i = 0; i < list.Count; i += splitNumber)
            {
                var cList = new List<T>();
                cList = list.Take(j).Skip(i).ToList();
                j += splitNumber;
                listGroup.Add(cList);
            }

            return listGroup;
        }

        /// <summary>
        ///     Get previous
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetPrevious<T>(this IEnumerable<T> list, T value) where T : class
        {
            return list.TakeWhile(i => !i.Equals(value)).LastOrDefault();
        }

        /// <summary>
        ///     Get next
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static T GetNext<T>(this IEnumerable<T> list, T value) where T : class
        {
            return list.SkipWhile(i => !i.Equals(value)).Skip(1).FirstOrDefault();
        }
    }
}
