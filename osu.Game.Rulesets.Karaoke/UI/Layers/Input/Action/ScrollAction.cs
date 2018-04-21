﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Game.Rulesets.Karaoke.Input;

namespace osu.Game.Rulesets.Karaoke.UI.Layers.Input.Action
{
    public class ScrollAction : BaseAction
    {
        public KaraokeScrollAction KaraokeScrollAction { get; set; }

        public bool Touch { get; set; }

        public double TotalMovingPosition { get; set; }

        public double RelativeMovingPosition { get; set; }

        /// <summary>
        /// Copy
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public override T Copy<T>()
        {
            T result = new T();
            if (result is ScrollAction keyAction)
            {
                keyAction.KaraokeScrollAction = KaraokeScrollAction;
                keyAction.Touch = Touch;
                keyAction.TotalMovingPosition = TotalMovingPosition;
                keyAction.RelativeMovingPosition = RelativeMovingPosition;
                keyAction.Initialize();
            }
            return result;
        }
    }
}
