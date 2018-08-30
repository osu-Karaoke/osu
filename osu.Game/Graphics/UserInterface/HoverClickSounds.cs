﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Threading.Tasks;
using osu.Framework.Allocation;
using osu.Framework.Audio;
using osu.Framework.Audio.Sample;
using osu.Framework.Extensions;
using osu.Framework.Input.States;

namespace osu.Game.Graphics.UserInterface
{
    /// <summary>
    /// Adds hover and click sounds to a drawable.
    /// Does not draw anything.
    /// </summary>
    public class HoverClickSounds : HoverSounds
    {
        private SampleChannel sampleClick;

        public HoverClickSounds(HoverSampleSet sampleSet = HoverSampleSet.Normal) : base(sampleSet)
        {
        }

        protected override bool OnClick(InputState state)
        {
            sampleClick?.Play();
            return base.OnClick(state);
        }

        [BackgroundDependencyLoader]
        private async Task load(AudioManager audio)
        {
            sampleClick = await audio.Sample.GetAsync($@"UI/generic-select{SampleSet.GetDescription()}");
        }
    }
}
