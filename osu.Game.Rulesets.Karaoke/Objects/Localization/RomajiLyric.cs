﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using System.Linq;
using osu.Game.Rulesets.Karaoke.Objects.Localization.Types;
using osu.Game.Rulesets.Karaoke.Objects.Types;

namespace osu.Game.Rulesets.Karaoke.Objects.Localization
{
    public class RomajiLyric : Lyric, IHasRomaji
    {
        /// <summary>
        ///     list romaji text
        /// </summary>
        // TODO : [set] cannot set here
        // TODO : [get] get the value is combine from list
        public RomajiTextList Romaji { get; set; } = new RomajiTextList();
    }

    public class RomajiTextList : LyricDictionary<int, RomajiText>
    {
        /// <summary>
        ///     collect all romaji in list
        /// </summary>
        public string Romaji
        {
            get
            {
                var list = this.Select(x => x.Value.Text);
                var result = string.Join(SeperateText, list);
                return result;
            }
        }

        public string SeperateText { get; set; }

        /// <summary>
        ///     collect list
        /// </summary>
        private List<int> listRomajiTextCount => this.Select(x => x.Value.Text.Length).ToList();

        /// <summary>
        ///     get romaji start position from main text's text index
        /// </summary>
        /// <param name="mainTextIndex"></param>
        /// <returns></returns>
        public int GetStartRomajiIndexFromMainTextIndex(int mainTextIndex)
        {
            return listRomajiTextCount.Take(mainTextIndex).Sum();
        }

        /// <summary>
        ///     get romaji start position from main text's text index
        /// </summary>
        /// <param name="mainTextIndex"></param>
        /// <returns></returns>
        public int GetEndRomajiIndexFromMainTextIndex(int mainTextIndex)
        {
            var take = mainTextIndex >= listRomajiTextCount.Count ? mainTextIndex + 1 : mainTextIndex;
            return listRomajiTextCount.Take(take).Sum() - 1;
        }
    }

    /// <summary>
    ///     use to record romaji
    /// </summary>
    public class RomajiText : IHasText, IHasEndIndex
    {
        /// <summary>
        ///     relativa to textIndex
        /// </summary>
        public int? Length { get; set; }

        public string Text { get; set; }

        public RomajiText()
        {
        }

        public RomajiText(string str)
        {
            Text = str;
        }
    }
}
