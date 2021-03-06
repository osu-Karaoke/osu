﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

namespace osu.Game.Rulesets.Karaoke.Objects.Localization.Types
{
    public interface IHasLyricVersion
    {
        /// <summary>
        ///     Get the version , for json decoder to select the class
        /// </summary>
        int Ver { get; }
    }
}
