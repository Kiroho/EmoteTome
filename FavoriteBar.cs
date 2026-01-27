using Blish_HUD.Controls;
using Microsoft.Xna.Framework;
using Blish_HUD.Modules.Managers;
using Blish_HUD;
using System.Collections.Generic;
using System;
using System.Timers;

namespace EmoteTome
{
    public class FavoriteBar : StandardWindow
    {
        ContentsManager contents;
        Module module;
        private List<Emote> coreEmoteList;
        private List<Emote> unlockEmoteList;
        private List<Emote> rankEmoteList;
        private FlowPanel mainPanel;
        private ContextMenuStrip coreMenu;
        private ContextMenuStrip unlockMenu;
        private ContextMenuStrip rankMenu;
        public Checkbox targetCheckbox;
        public Checkbox synchronCheckbox;

        //private Dictionary<Emote, EmoteContainer> favoriteEmoteDict = new Dictionary<Emote, EmoteContainer>();

        public FavoriteBar(Module module, ContentsManager contents , List<Emote> coreEmoteList, List<Emote> unlockEmoteList, List<Emote> rankEmoteList)
            : base(
                contents.GetTexture("WindowBackground.png"),
                new Rectangle(40, 26, 913, 750),
                new Rectangle(40, 26, 913, 750)
            )
        {
            this.contents = contents;
            this.module = module;
            this.coreEmoteList = coreEmoteList;
            this.unlockEmoteList = unlockEmoteList;
            this.rankEmoteList = rankEmoteList;
            Parent = GameService.Graphics.SpriteScreen;
            Size = new Point(730, 190);
            Location = new Point(680, 950);
            SavesPosition = true;
            SavesSize = true;
            CanResize = true;
            Title = "";



            mainPanel = new FlowPanel()
            {
                ShowBorder = false,
                Size = new Point(this.ContentRegion.Width, this.ContentRegion.Height),
                Location = new Point(0, 35),
                FlowDirection = ControlFlowDirection.SingleLeftToRight,
                Parent = this,
                ControlPadding = new Vector2(15, 5),
                OuterControlPadding = new Vector2(15, 5)

            };

            module.createEmoteContainer(coreEmoteList, mainPanel, EmoteLibrary.CORECODE, true);
            module.createEmoteContainer(unlockEmoteList, mainPanel, EmoteLibrary.UNLOCKCODE, true);
            module.createEmoteContainer(rankEmoteList, mainPanel, EmoteLibrary.RANKCODE, true);

            var coreMenuImage = new Image(GameService.Content.GetTexture("155052"))
            {
                Parent = this,
                Location = new Point(this.ContentRegion.Left + 10, 0),
                Size = new Point(32, 32)
            }; 
            coreMenu = new ContextMenuStrip()
            {
                Parent = this,
                Size = new Point(150, 50),
                Visible = false
            };
            coreMenu.ClearChildren();
            generateEmoteMenus(coreMenu, coreEmoteList);


            var unlockMenuImage = new Image(GameService.Content.GetTexture("155052"))
            {
                Parent = this,
                Location = new Point(this.ContentRegion.Left + 50, 0),
                Size = new Point(32, 32)
            };
            unlockMenu = new ContextMenuStrip()
            {
                Parent = this,
                Size = new Point(150, 50),
                Visible = false
            };
            unlockMenu.ClearChildren();
            generateEmoteMenus(unlockMenu, unlockEmoteList);


            var rankMenuImage = new Image(GameService.Content.GetTexture("155052"))
            {
                Parent = this,
                Location = new Point(this.ContentRegion.Left + 90, 0),
                Size = new Point(32, 32)
            };
            rankMenu = new ContextMenuStrip()
            {
                Parent = this,
                Size = new Point(150, 50),
                Visible = false
            };
            rankMenu.ClearChildren();
            generateEmoteMenus(rankMenu, rankEmoteList);

            coreMenuImage.Click += (s, e) =>
            {
                coreMenu.Show(coreMenuImage);
            };
            unlockMenuImage.Click += (s, e) =>
            {
                unlockMenu.Show(unlockMenuImage);
            };
            rankMenuImage.Click += (s, e) =>
            {
                rankMenu.Show(rankMenuImage);
            };

            targetCheckbox = new Checkbox()
            {
                Text = BadLocalization.TARGETCHECKBOXTEXT[module.language],
                Location = new Point(140, 5),
                BasicTooltipText = BadLocalization.TARGETCHECKBOXTOOLTIP[module.language],
                Parent = this
            };

            targetCheckbox.CheckedChanged += (_, e) =>
            {
                module.setTargetCheckbox();
                module.targetCheckbox.Checked = targetCheckbox.Checked;
            };

            synchronCheckbox = new Checkbox()
            {
                Text = BadLocalization.SYNCHRONCHECKBOXTEXT[module.language],
                Location = new Point(320, 5),
                BasicTooltipText = BadLocalization.SYNCHRONCHECKBOXTOOLTIP[module.language],
                Parent = this
            };

            synchronCheckbox.CheckedChanged += (_, e) =>
            {
                module.synchronCheckbox.Checked = synchronCheckbox.Checked;
            };



            this.Resized += (_, e) =>
            {
                mainPanel.Width = this.ContentRegion.Width;
                this.Height = 190;
            };

        }

        protected override Point HandleWindowResize(Point newSize)
        {
            var screen = GameService.Graphics.SpriteScreen.Size;

            return new Point(
                MathHelper.Clamp(newSize.X, 600, screen.X),
                MathHelper.Clamp(newSize.Y, 190, 190)
            );
        }


        private void generateEmoteMenus(ContextMenuStrip menu, List<Emote> emoteList)
        {
            foreach (var emote in emoteList)
            {
                var menuitem = menu.AddMenuItem(emote.getToolTipp()[module.language]);
                if (module.getFavoriteList().Contains(emote.getToolTipp()[module.language]))
                {
                    menuitem.Text = emote.getToolTipp()[module.language] + " *";
                    emote.getFavContainer().Visible = true;
                }
                menuitem.Click += (s, e) => {
                    if (module.getFavoriteList().Contains(emote.getToolTipp()[module.language]))
                    {
                        menuitem.Text = emote.getToolTipp()[module.language];
                        module.removeFromFavoriteSetting(emote.getToolTipp()[module.language]);
                        //onFavoriteEmote(emote);
                        emote.getFavContainer().Visible = false;
                    }
                    else
                    {
                        menuitem.Text = emote.getToolTipp()[module.language] + " *";
                        module.addToFavoriteSetting(emote.getToolTipp()[module.language]);
                        //onFavoriteEmote(emote);
                        emote.getFavContainer().Visible = true;
                    }
                    mainPanel.RecalculateLayout();
                };
            }
            mainPanel.RecalculateLayout();
        }


        public void unload()
        {
        }

        

    }

}
