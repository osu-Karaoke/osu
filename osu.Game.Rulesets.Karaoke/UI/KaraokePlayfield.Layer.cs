﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Framework.Timing;
using osu.Game.Rulesets.Karaoke.Mods.Types;
using osu.Game.Rulesets.Karaoke.UI.Layers.ControlPanel.Desktop;
using osu.Game.Rulesets.Karaoke.UI.Layers.Input;
using osu.Game.Rulesets.Karaoke.UI.Layers.Lyric;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.UI
{
    public partial class KaraokePlayfield
    {
        private KaraokePanelOverlay karaokePanelOverlay;

        /// <summary>
        /// Frontend
        /// </summary>
        public override void InitialFrontendLayer()
        {
            //panel
            KaraokeRulesetContainer.Add(karaokePanelOverlay = new KaraokePanelOverlay(this)
            {
                Clock = new FramedClock(new StopwatchClock(true)),
                RelativeSizeAxes = Axes.X,
                Origin = Anchor.BottomCentre,
                Anchor = Anchor.BottomCentre,
                Scale = new Vector2(1.0f),
                Depth = 10f,
            });

            //Input layer
            KaraokeRulesetContainer.Add(new InputLayer(karaokePanelOverlay)
            {
                RelativeSizeAxes = Axes.Both,
                Depth = -2,
                Clock = new FramedClock(new StopwatchClock(true)),
            });
        }

        /// <summary>
        /// Ruleset
        /// </summary>
        public override void InitialRulesetLayer()
        {
            base.InitialRulesetLayer();

            //layer
            Add(KaraokeLyricPlayField = new KaraokeLyricPlayField()
            {
                KaraokeRulesetContainer = KaraokeRulesetContainer
            });
        }

        /// <summary>
        /// Backend
        /// </summary>
        public override void InitialBackendLayer()
        {
            //create all layer if contains in mod
            foreach (var singleMod in WorkingBeatmap.Mods.Value)
            {
                if (singleMod is IHasLayer iHasLayer)
                {
                    Add(iHasLayer.CreateNewLayer());
                    break;
                }
            }
        }
    }
}
