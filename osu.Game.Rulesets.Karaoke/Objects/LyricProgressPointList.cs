﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using System.Linq;

namespace osu.Game.Rulesets.Karaoke.Objects
{
    /// <summary>
    /// list Progress point
    /// [Note : key is mapped in Char index, not Dictionary's index]
    /// </summary>
    public class LyricProgressPointList : Dictionary<int,LyricProgressPoint>
    {
        [JsonIgnore]
        public double MinimumTime { get; set; } = 100;

        public KeyValuePair<int, LyricProgressPoint>? Find(int key)
        {
            return this.FirstOrDefault(x => x.Key == key);
        }

        /// <summary>
        /// find previous by key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public KeyValuePair<int, LyricProgressPoint>? FindPrevioud(int key)
        {
            var previousKey = this.Keys.Where(x=>x < key).Max();
            return Find(previousKey);
        }

        /// <summary>
        /// find next from key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public KeyValuePair<int, LyricProgressPoint>? FindNext(int key)
        {
            var nextKey = this.Keys.Where(x => x > key).Min();
            return Find(nextKey);
        }

        /// <summary>
        /// get first progress point by time
        /// </summary>
        /// <param name="nowRelativeTime"></param>
        /// <returns></returns>
        public KeyValuePair<int, LyricProgressPoint>? GetFirstProgressPointByTime(double nowRelativeTime)
        {
            var result = this.Where(x => x.Value.RelativeTime <= nowRelativeTime).Max();

            if(result.Equals(default(KeyValuePair<string, int>)))
                return new KeyValuePair<int, LyricProgressPoint>(-1, new LyricProgressPoint(0));

            return result;

        }

        /// <summary>
        /// get last progress point by time
        /// </summary>
        /// <param name="lyric"></param>
        /// <param name="nowRelativeTime"></param>
        /// <returns></returns>
        public KeyValuePair<int, LyricProgressPoint>? GetLastProgressPointByTime(double nowRelativeTime)
        {
            if (this.Count == 0)
                return null;

            var result = this.Where(x => x.Value.RelativeTime > nowRelativeTime).Max();

            if (result.Equals(default(KeyValuePair<string, int>)))
            {
                var key = this.Keys.Max();
                return Find(key);
            }  

            return result;

        }

        /// <summary>
        /// get first Progress by char index
        /// </summary>
        /// <param name="charIndex"></param>
        /// <returns></returns>
        public KeyValuePair<int, LyricProgressPoint> GetFirstProgressPointByIndex(int charIndex)
        {
            var index = this.FirstOrDefault(x => x.Key > charIndex).Key;

            LyricProgressPoint result;
            this.TryGetValue(index - 1, out result);

            if (result == null)
                return new KeyValuePair<int, LyricProgressPoint>(-1, new LyricProgressPoint(0));

            return new KeyValuePair<int, LyricProgressPoint>(index - 1, result);
        }

        /// <summary>
        /// get last Progress by char index
        /// </summary>
        /// <param name="charIndex"></param>
        /// <returns></returns>
        public KeyValuePair<int, LyricProgressPoint> GetLastProgressPointByIndex(int charIndex)
        {
            var point = this.FirstOrDefault(x => x.Key > charIndex);
            return point; //?? lyric.ProgressPoints.Last();
        }

        /// <summary>
        /// will check if this progress point is valid
        /// </summary>
        /// <returns><c>true</c>, if progress point was added, <c>false</c> otherwise.</returns>
        /// <param name="karaokeObject">Karaoke object.</param>
        public new void Add(int key,LyricProgressPoint point)
        {
            //TODO : filter
            if (this.Any(x => x.Key == key))
                return ;
            if (this.Any(x => x.Value.RelativeTime == point.RelativeTime))
                return ;

            base.Add(key,point);
            //SortProgressPoint();
            FixTime();
        }

        /*
        /// <summary>
        /// sorting by position and time should be higher
        /// </summary>
        public void SortProgressPoint()
        {
            // from small to large
            var orderByRelativeTimeList = this.OrderBy(x => x.RelativeTime).ToList();
            Clear();
            AddRange(orderByRelativeTimeList);
            //sort
            var orderByCharList = this.OrderBy(x => x.CharIndex).ToList();
            Clear();
            AddRange(orderByCharList);
        }
        */

        /// <summary>
        /// fix the delta time
        /// </summary>
        public void FixTime()
        {
            double time = 0;
            foreach (var single in this)
            {
                if (single.Value.RelativeTime < time + MinimumTime)
                {
                    single.Value.RelativeTime = time + MinimumTime;
                }

                time = single.Value.RelativeTime;
            }
        }
    }
}
