﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Allocation;
using osu.Framework.Graphics;
using osu.Game.Beatmaps;
using osu.Game.Rulesets.Karaoke.Configuration;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Lyric;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Note;
using osu.Game.Rulesets.Karaoke.UI.Interface;
using osu.Game.Rulesets.Objects.Drawables;
using osu.Game.Rulesets.UI;
using OpenTK;
using OpenTK.Graphics;

namespace osu.Game.Rulesets.Karaoke.UI
{
    /// <summary>
    ///     Karaoke base panel
    ///     the design should be like that :
    ///     |                   |                       |   Kaeakoe Mobile
    ///     |                   |  [playable Playfield] |   Karaoke Ipad
    ///     |                   |                       |   Karaoke Desktop
    ///     |   base Playfield  |-----------------------|-------------
    ///     |                   |  [editor playField]
    ///     |                   |
    /// </summary>
    public partial class KaraokeBasePlayfield : Playfield, IAmKaraokeField
    {
        public static readonly Vector2 BASE_SIZE = new Vector2(512, 384);

        /// <summary>
        ///     Default height of a <see cref="KaraokeBasePlayfield" /> when inside a <see cref="KaraokeRulesetContainer" />.
        /// </summary>
        public const float DEFAULT_HEIGHT = 384;

        public Ruleset Ruleset { get; set; }
        public WorkingBeatmap WorkingBeatmap { get; set; }
        public KaraokeRulesetContainer KaraokeRulesetContainer { get; set; }

        public KaraokeConfigManager KaraokeConfigManager { get; set; }

        /// <summary>
        ///     Ctor
        /// </summary>
        /// <param name="ruleset"></param>
        /// <param name="beatmap"></param>
        /// <param name="container"></param>
        public KaraokeBasePlayfield(Ruleset ruleset, WorkingBeatmap beatmap, KaraokeRulesetContainer container)
        {
            Ruleset = ruleset;
            WorkingBeatmap = beatmap;
            KaraokeRulesetContainer = container;

            Anchor = Anchor.Centre;
            Origin = Anchor.Centre;
        }

        /*
        protected override void LoadComplete()
        {
            base.LoadComplete();
        }
        */

        /// <summary>
        ///     Add HitObject
        /// </summary>
        /// <param name="h"></param>
        public override void Add(DrawableHitObject h)
        {
            //Add MainLyric
            KaraokeLyricPlayField.Add(h as DrawableLyric);

            //Add note
            if (KaraokeTonePlayfield != null)
            {
                var drawableNote = new DrawableNotes(h.HitObject as Lyric)
                {
                    AccentColour = Color4.BlueViolet
                };
                KaraokeTonePlayfield.Add(drawableNote);
            }
        }

        //post process
        public override void PostProcess()
        {
            base.PostProcess();
        }

        /// <summary>
        ///     Load
        /// </summary>
        /// <param name="manager"></param>
        [BackgroundDependencyLoader(true)]
        private void load(KaraokeConfigManager manager)
        {
            KaraokeConfigManager = manager;

            //Dialog
            InitialDialogLayer();
            //Frontend
            InitialFrontendLayer();
            //Ruleset
            InitialRulesetLayer();
            //Backend
            InitialBackendLayer();
            //post process
            PostProcessLayer(manager);
        }

        #region Input

        /*
        protected override bool OnKeyDown(InputState state, KeyDownEventArgs args)
        {
            foreach (var single in state.Keyboard.Keys)
            {
                if (single == Key.S)
                {
                    OpenLoadSaveDialog();
                }
            }
            return base.OnKeyDown(state, args);
        }
        */

        #endregion
    }
}
