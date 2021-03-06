﻿// Copyright (c) 2007-2018 ppy Pty Ltd <contact@ppy.sh>.
// Licensed under the MIT Licence - https://raw.githubusercontent.com/ppy/osu/master/LICENCE

using System.Collections.Generic;
using osu.Framework.Graphics;
using osu.Framework.Graphics.Containers;
using osu.Game.Graphics.UserInterface;
using osu.Game.Overlays.Music;
using osu.Game.Rulesets.Karaoke.Configuration;
using osu.Game.Rulesets.Karaoke.Edit.Dialog.Pieces;
using osu.Game.Rulesets.Karaoke.Objects;
using osu.Game.Rulesets.Karaoke.Objects.Drawables.Types;
using OpenTK;

namespace osu.Game.Rulesets.Karaoke.Edit.Dialog
{
    public class ListKaraokeTranslateDialog : DialogContainer
    {
        public FilterControl.FilterTextBox Search;
        public TriangleButton AutoTranslateButton;
        protected KaraokeEditPlayfield PlayField;
        protected EnumDropdown<TranslateCode> Dropdown;
        protected ListTranslateScrollContainer ItemsScrollContainer { get; set; }

        public ListKaraokeTranslateDialog(KaraokeEditPlayfield playField)
        {
            Title = "Translate";
            PlayField = playField;

            //initial karaoke objects to set
            initialItemsScrollContainerItems();
        }

        public override void InitialDialog()
        {
            //add search bar and language selector
            MainContext.Add(new FillFlowContainer
            {
                RelativeSizeAxes = Axes.X,
                Height = 40,
                Direction = FillDirection.Horizontal,
                Spacing = new Vector2(0, 0),
                Depth = -10,
                Children = new Drawable[]
                {
                    Search = new FilterControl.FilterTextBox
                    {
                        //RelativeSizeAxes = Axes.X,
                        Width = 360,
                        Height = 40
                    },
                    Dropdown = new EnumDropdown<TranslateCode>
                    {
                        Position = new Vector2(20, 10),
                        Width = 150,
                        Scale = new Vector2(0.8f),

                        //MaximumSize=new OpenTK.Vector2(200,200)
                        Margin = new MarginPadding(5)
                    },
                    AutoTranslateButton = new TriangleButton
                    {
                        Width = 100,
                        Height = 30,
                        Text = "Auto Translate",
                        Margin = new MarginPadding(5),
                        Action = () =>
                        {
                            //TODO : auto translate and call update each cell
                        }
                    }
                }
            });

            //
            MainContext.Add(ItemsScrollContainer = new ListTranslateScrollContainer
            {
                Position = new Vector2(0, 40),
                Width = 600,
                Height = 260
            });

            //if search new word
            Search.Current.ValueChanged += newString => { ItemsScrollContainer.SearchTerm = newString; };
            //
            Dropdown.DropdownContainer.MaxHeight = 250;
            //
            Dropdown.Current.ValueChanged += translateCode =>
            {
                //TODO : value changed
                ItemsScrollContainer.SetCurrentLanguage(translateCode);
            };


            base.InitialDialog();
        }

        private void initialItemsScrollContainerItems()
        {
            var listObjects = PlayField?.KaraokeLyricPlayField.ListDrawableKaraokeObject ?? new List<IDrawableLyricParameter>();
            var listKaraokeObjects = new List<Lyric>();
            foreach (var single in listObjects)
                listKaraokeObjects.Add(single.Lyric);

            ItemsScrollContainer.Sets = listKaraokeObjects;
        }
    }

    public class ListTranslateScrollContainer : TableView<Lyric, TranslateCell>
    {
        public void SetCurrentLanguage(TranslateCode code)
        {
            //change show translage type
            foreach (var single in Items)
                single.ChangeLanguage(code);
        }
    }

    public class TranslateCell : KaraokeBaseTableViewCell<Lyric>
    {
        public RevertableTextbox LyricsTextbox { get; set; } //BaseLyric
        public RevertableTextbox TranslateTextbox { get; set; } //Translate

        public FillFlowContainer<Drawable> FillFlowContainer { get; set; }

        public override Lyric BeatmapSetInfo
        {
            get => base.BeatmapSetInfo;
            set
            {
                base.BeatmapSetInfo = value;
                LyricsTextbox.OldValue = BeatmapSetInfo?.Text;
            }
        }

        public TranslateCell()
        {
            Height = 40;
        }

        //change language code
        public void ChangeLanguage(TranslateCode langCode)
        {
            if (BeatmapSetInfo != null)
                foreach (var single in BeatmapSetInfo.Translates)
                    if (single.Key == langCode)
                        TranslateTextbox.OldValue = single.Value.Text;
        }

        protected override void InitialView()
        {
            //Initial view
            base.InitialView();
            //add
            Add(FillFlowContainer = new FillFlowContainer<Drawable>
            {
                Direction = FillDirection.Horizontal,
                Position = new Vector2(20, 0),
                Spacing = new Vector2(10, 0),
                Children = new Drawable[]
                {
                    LyricsTextbox = new RevertableTextbox
                    {
                        Width = 310,
                        Height = 35
                    },
                    TranslateTextbox = new RevertableTextbox
                    {
                        Width = 250,
                        Height = 35
                    }
                }
            });
        }
    }
}
