﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System;
using osu.Game.Configuration;
using osu.Game.Rulesets.Configuration;
using osu.Game.Rulesets.Karaoke.Configuration.Types;

namespace osu.Game.Rulesets.Karaoke.Configuration
{
    public class BaseKaraokeConfigManager<T> : RulesetConfigManager<T> where T : struct
    {
        public BaseKaraokeConfigManager(SettingsStore settings, RulesetInfo ruleset, int variant)
            : base(settings, ruleset, variant)
        {
        }


        /// <summary>
        ///     serialize and set object
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="lookup"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public BindableObject<U> SetObject<U>(T lookup, U value) where U : class, IEquatable<U>, ICloneable, IJsonString, new()
        {
            var bindable = GetOriginalBindable<U>(lookup) as BindableObject<U>;

            if (bindable == null)
            {
                bindable = new BindableObject<U>(value);
                AddBindable(lookup, bindable);
            }
            else
            {
                bindable.Value = value;
            }

            bindable.Default = value;

            return bindable;
        }

        /// <summary>
        ///     get object bindable
        /// </summary>
        /// <typeparam name="U"></typeparam>
        /// <param name="lookup"></param>
        /// <returns></returns>
        public BindableObject<U> GetObjectBindable<U>(T lookup) where U : class, IEquatable<U>, ICloneable, IJsonString, new()
        {
            var bindable = GetOriginalBindable<U>(lookup) as BindableObject<U>;
            return bindable;
        }
    }
}
