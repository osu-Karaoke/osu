﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using osu.Framework.Graphics;
using osu.Game.Graphics;
using osu.Game.Graphics.UserInterface;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.UI.Layers.ControlPanel.Desktop.Pieces
{
    public class KaraokePlayPauseButton : KaraokeButton
    {
        /// <summary>
        ///     if is pause , show pause icon
        /// </summary>
        public KaraokePlayState KaraokeShowingState
        {
            set
            {
                _state = value;
                switch (value)
                {
                    case KaraokePlayState.Play:
                        playButton.Icon = FontAwesome.fa_play;
                        TooltipText = "Play";
                        break;
                    case KaraokePlayState.Pause:
                        playButton.Icon = FontAwesome.fa_pause;
                        TooltipText = "Pause";
                        break;
                }
            }
            get => _state;
        }

        //use as show icon
        //From MusicController.cs
        private readonly IconButton playButton;

        private KaraokePlayState _state;

        public KaraokePlayPauseButton()
        {
            Add(playButton = new IconButton
            {
                Anchor = Anchor.Centre,
                Origin = Anchor.Centre,
                Scale = new Vector2(1.0f),
                IconScale = new Vector2(1.0f),
                //HoverColour = Color4.Yellow.Opacity(0.2f)
                //Action = play,
            });
        }
    }

    public enum KaraokePlayState
    {
        Play,
        Pause
    }
}
