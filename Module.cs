using Blish_HUD;
using static Blish_HUD.GameService;
using Blish_HUD.Controls;
using Blish_HUD.Controls.Extern;
using Blish_HUD.Modules;
using Blish_HUD.Modules.Managers;
using Blish_HUD.Settings;
using Gw2Sharp.WebApi.V2.Models;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using WindowsInput;
using Color = Microsoft.Xna.Framework.Color;
using Image = Blish_HUD.Controls.Image;
using Point = Microsoft.Xna.Framework.Point;
using Rectangle = Microsoft.Xna.Framework.Rectangle;
using Microsoft.Xna.Framework.Input;
using System.Windows.Input;

namespace EmoteTome
{
    [Export(typeof(Blish_HUD.Modules.Module))]
    public class Module : Blish_HUD.Modules.Module
    {
        private CornerIcon tomeCornerIcon;
        private StandardWindow tomeWindow;
        private int language = BadLocalization.ENGLISH;
        private Vector3 currentPositionA;
        private Vector3 currentPositionB;
        private Vector3 currentPositionC;
        private int checkPositionSwitch = 0;
        private List<Emote> coreEmoteList = new List<Emote>();
        private List<Emote> unlockEmoteList = new List<Emote>();
        private List<Emote> rankEmoteList = new List<Emote>();
        private Color activatedColor = new Color(250, 250, 250);
        private Color lockedColor = new Color(30, 30, 30);
        private Color noTargetColor = new Color(130, 130, 130);
        private Color cooldownColor = new Color(50, 50, 50);
        private bool checkedAPIForUnlock = false;
        private EventHandler<Blish_HUD.Input.MouseEventArgs> coreEmoteClickEvent = delegate { };
        private EventHandler<Blish_HUD.Input.MouseEventArgs> unlockEmoteClickEvent = delegate { };
        private EventHandler<Blish_HUD.Input.MouseEventArgs> rankEmoteClickEvent = delegate { };
        private EventHandler<Blish_HUD.Input.MouseEventArgs> testEmoteClickEvent = delegate { };
        private SettingEntry<bool> _showEmoteNames;
        private SettingEntry<bool> _adjustLabelLength;
        private SettingEntry<bool> _halloweenMode;
        private SettingEntry<bool> _checkForKeyPress;
        private SettingEntry<bool> _checkForMovement;

        //bools for core emotes
        private SettingEntry<string> _coreEmoteSeparator;
        private SettingEntry<bool> _showBeckon;
        private SettingEntry<bool> _showBow;
        private SettingEntry<bool> _showCheer;
        private SettingEntry<bool> _showCower;
        private SettingEntry<bool> _showCrossarms;
        private SettingEntry<bool> _showCry;
        private SettingEntry<bool> _showDance;
        private SettingEntry<bool> _showFacepalm;
        private SettingEntry<bool> _showKneel;
        private SettingEntry<bool> _showLaugh;
        private SettingEntry<bool> _showNo;
        private SettingEntry<bool> _showPoint;
        private SettingEntry<bool> _showPonder;
        private SettingEntry<bool> _showSad;
        private SettingEntry<bool> _showSalute;
        private SettingEntry<bool> _showShrug;
        private SettingEntry<bool> _showSit;
        private SettingEntry<bool> _showSleep;
        private SettingEntry<bool> _showSurprised;
        private SettingEntry<bool> _showTalk;
        private SettingEntry<bool> _showThanks;
        private SettingEntry<bool> _showThreaten;
        private SettingEntry<bool> _showWave;
        private SettingEntry<bool> _showYes;
        private List<Tuple<SettingEntry<bool>, Emote>> coreEmoteSettingMap = new List<Tuple<SettingEntry<bool>, Emote>>();

        //bools for unlockable emotes
        private SettingEntry<string> _unlockEmoteSeparator;
        private SettingEntry<bool> _showBless;
        private SettingEntry<bool> _showGeargrind;
        private SettingEntry<bool> _showHeroic;
        private SettingEntry<bool> _showHiss;
        private SettingEntry<bool> _showMagicjuggle;
        private SettingEntry<bool> _showPaper;
        private SettingEntry<bool> _showPlaydead;
        private SettingEntry<bool> _showPossessed;
        private SettingEntry<bool> _showReadbook;
        private SettingEntry<bool> _showRock;
        private SettingEntry<bool> _showRockout;
        private SettingEntry<bool> _showScissors;
        private SettingEntry<bool> _showServe;
        private SettingEntry<bool> _showShiver;
        private SettingEntry<bool> _showShiverplus;
        private SettingEntry<bool> _showShuffle;
        private SettingEntry<bool> _showSipcoffee;
        private SettingEntry<bool> _showStep;
        private SettingEntry<bool> _showStretch;
        private SettingEntry<bool> _showUnleash;
        private SettingEntry<bool> _showPetalthrow;
        private SettingEntry<bool> _showBreakdance;
        private SettingEntry<bool> _showBoogie;
        private SettingEntry<bool> _showPoseCover;
        private SettingEntry<bool> _showPoseHigh;
        private SettingEntry<bool> _showPoseLow;
        private SettingEntry<bool> _showPoseTwist;
        private SettingEntry<bool> _showBlowKiss;
        private SettingEntry<bool> _showMagicTrick;
        private SettingEntry<bool> _showChannel;
        private SettingEntry<bool> _showBarbecue;
        private SettingEntry<bool> _showDrink;
        private SettingEntry<bool> _showCrabDance;
        private SettingEntry<bool> _showShocked;
        private SettingEntry<bool> _showThumbsUp;
        private SettingEntry<bool> _showThumbsDown;
        private List<Tuple<SettingEntry<bool>, Emote>> unlockEmoteSettingMap = new List<Tuple<SettingEntry<bool>, Emote>>();

        //bools for rank emotes
        private SettingEntry<string> _rankEmoteSeparator; 
        private SettingEntry<bool> _showYourRank;
        private SettingEntry<bool> _showRankRabbit;
        private SettingEntry<bool> _showRankDeer;
        private SettingEntry<bool> _showRankDolyak;
        private SettingEntry<bool> _showRankWolf;
        private SettingEntry<bool> _showRankTiger;
        private SettingEntry<bool> _showRankBear;
        private SettingEntry<bool> _showRankShark;
        private SettingEntry<bool> _showRankPhoenix;
        private SettingEntry<bool> _showRankDragon;
        private List<Tuple<SettingEntry<bool>, Emote>> rankEmoteSettingMap = new List<Tuple<SettingEntry<bool>, Emote>>();

        private int size = 64;
        private int labelSize = 16;
        private int labelWidth = 120;


        private static readonly Logger Logger = Logger.GetLogger<Module>();

        internal SettingsManager SettingsManager => this.ModuleParameters.SettingsManager;
        internal ContentsManager ContentsManager => this.ModuleParameters.ContentsManager;
        internal DirectoriesManager DirectoriesManager => this.ModuleParameters.DirectoriesManager;
        internal Gw2ApiManager Gw2ApiManager => this.ModuleParameters.Gw2ApiManager;

        // Ideally you should keep the constructor as is (empty). Instead use LoadAsync() to handle initializing the module.
        [ImportingConstructor]
        public Module([Import("ModuleParameters")] ModuleParameters moduleParameters) : base(moduleParameters)
        {
            
        }

        // Define the settings you would like to use in your module.  Settings are persistent
        // between updates to both Blish HUD and your module.
        protected override void DefineSettings(SettingCollection settings)
        {
            _checkForKeyPress = settings.DefineSetting(
                "Check for Key Press",
                true,
                () => BadLocalization.CHECKKEY[language],
                () => BadLocalization.CHECKKEYTEXT[language]);

            _checkForMovement = settings.DefineSetting(
                "Check for Movement",
                true,
                () => BadLocalization.CHECKMOVE[language],
                () => BadLocalization.CHECKMOVETEXT[language]);

            _showEmoteNames = settings.DefineSetting(
                "Show Names",
                false,
                () => BadLocalization.SHOWNAMES[language],
                () => BadLocalization.SHOWNAMESTEXT[language]);

            _adjustLabelLength = settings.DefineSetting(
                "Larger Name Labels",
                false,
                () => BadLocalization.LARGERNAMELABELS[language],
                () => BadLocalization.LARGERNAMELABELSTEXT[language]);

            _halloweenMode = settings.DefineSetting(
                "Halloween Mode",
                false,
                () => BadLocalization.HALLOWEENMODE[language],
                () => BadLocalization.HALLOWEENMODETEXT[language]);

            #region Show/Hide Core Emotes

            _coreEmoteSeparator = settings.DefineSetting(
                "Core Separator",
                "",
                () => BadLocalization.COREPANELTITLE[language],
                () => "");

            _showBeckon = settings.DefineSetting(
                "Show Beckon",
                true,
                () => BadLocalization.BECKON[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showBow = settings.DefineSetting(
                "Show Bow",
                true,
                () => BadLocalization.BOW[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showCheer = settings.DefineSetting(
                "Show Cheer",
                true,
                () => BadLocalization.CHEER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showCower = settings.DefineSetting(
                "Show Cower",
                true,
                () => BadLocalization.COWER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showCrossarms = settings.DefineSetting(
                "Show Crossarms",
                true,
                () => BadLocalization.CROSSARMS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showCry = settings.DefineSetting(
                "Show Cry",
                true,
                () => BadLocalization.CRY[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showDance = settings.DefineSetting(
                "Show Dance",
                true,
                () => BadLocalization.DANCE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showFacepalm = settings.DefineSetting(
                "Show Facepalm",
                true,
                () => BadLocalization.FACEPALM[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showKneel = settings.DefineSetting(
                "Show Kneel",
                true,
                () => BadLocalization.KNEEL[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showLaugh = settings.DefineSetting(
                "Show Laugh",
                true,
                () => BadLocalization.LAUGH[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showNo = settings.DefineSetting(
                "Show No",
                true,
                () => BadLocalization.NO[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPoint = settings.DefineSetting(
                "Show Point",
                true,
                () => BadLocalization.POINT[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPonder = settings.DefineSetting(
                "Show Ponder",
                true,
                () => BadLocalization.PONDER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showSad = settings.DefineSetting(
                "Show Sad",
                true,
                () => BadLocalization.SAD[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showSalute = settings.DefineSetting(
                "Show Salute",
                true,
                () => BadLocalization.SALUTE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showShrug = settings.DefineSetting(
                "Show Shrug",
                true,
                () => BadLocalization.SHRUG[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showSit = settings.DefineSetting(
                "Show Sit",
                true,
                () => BadLocalization.SIT[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showSleep = settings.DefineSetting(
                "Show Sleep",
                true,
                () => BadLocalization.SLEEP[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showSurprised = settings.DefineSetting(
                "Show Surprised",
                true,
                () => BadLocalization.SURPRISED[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showTalk = settings.DefineSetting(
                "Show Talk",
                true,
                () => BadLocalization.TALK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showThanks = settings.DefineSetting(
                "Show Thanks",
                true,
                () => BadLocalization.THANKS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showThreaten = settings.DefineSetting(
                "Show Threaten",
                true,
                () => BadLocalization.THREATEN[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showWave = settings.DefineSetting(
                "Show Wave",
                true,
                () => BadLocalization.WAVE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showYes = settings.DefineSetting(
                "Show Yes",
                true,
                () => BadLocalization.YES[language],
                () => BadLocalization.EMOTETEXT[language]);

            #endregion

            #region Show/Hide Unlockable Emotes
            _unlockEmoteSeparator = settings.DefineSetting(
                "Unlock Separator",
                "",
                () => BadLocalization.UNLOCKABLEPANELTITLE[language],
                () => "");
            _showBless = settings.DefineSetting(
                "Show Bless",
                true,
                () => BadLocalization.BLESS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showGeargrind = settings.DefineSetting(
                "Show Geargrind",
                true,
                () => BadLocalization.GEARGRIND[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showHeroic = settings.DefineSetting(
                "Show Heroic",
                true,
                () => BadLocalization.HEROIC[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showHiss = settings.DefineSetting(
                "Show Hiss",
                true,
                () => BadLocalization.HISS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showMagicjuggle = settings.DefineSetting(
                "Show Magicjuggle",
                true,
                () => BadLocalization.MAGICJUGGLE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPaper = settings.DefineSetting(
                "Show Paper",
                true,
                () => BadLocalization.PAPER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPlaydead = settings.DefineSetting(
                "Show Playdead",
                true,
                () => BadLocalization.PLAYDEAD[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPossessed = settings.DefineSetting(
                "Show Possessed",
                true,
                () => BadLocalization.POSSESSED[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showReadbook = settings.DefineSetting(
                "Show Readbook",
                true,
                () => BadLocalization.READBOOK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRock = settings.DefineSetting(
                "Show Rock",
                true,
                () => BadLocalization.ROCK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRockout = settings.DefineSetting(
                "Show Rockout",
                true,
                () => BadLocalization.ROCKOUT[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showScissors = settings.DefineSetting(
                "Show Scissors",
                true,
                () => BadLocalization.SCISSORS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showServe = settings.DefineSetting(
                "Show Serve",
                true,
                () => BadLocalization.SERVE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showShiver = settings.DefineSetting(
                "Show Shiver",
                true,
                () => BadLocalization.SHIVER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showShiverplus = settings.DefineSetting(
                "Show Shiverplus",
                true,
                () => BadLocalization.SHIVERPLUS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showShuffle = settings.DefineSetting(
                "Show Shuffle",
                true,
                () => BadLocalization.SHUFFLE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showSipcoffee = settings.DefineSetting(
                "Show Sipcoffee",
                true,
                () => BadLocalization.SIPCOFFEE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showStep = settings.DefineSetting(
                "Show Step",
                true,
                () => BadLocalization.STEP[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showStretch = settings.DefineSetting(
                "Show Stretch",
                true,
                () => BadLocalization.STRETCH[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showUnleash = settings.DefineSetting(
                "Show Unleash",
                true,
                () => BadLocalization.UNLEASH[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPetalthrow = settings.DefineSetting(
                "Show Petalthrow",
                true,
                () => BadLocalization.PETALTHROW[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showBreakdance = settings.DefineSetting(
                "Show Breakdance",
                true,
                () => BadLocalization.BREAKDANCE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showBoogie = settings.DefineSetting(
                "Show Boogie",
                true,
                () => BadLocalization.BOOGIE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPoseCover = settings.DefineSetting(
                "Show PoseCover",
                true,
                () => BadLocalization.POSECOVER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPoseHigh = settings.DefineSetting(
                "Show PoseHigh",
                true,
                () => BadLocalization.POSEHIGH[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPoseLow = settings.DefineSetting(
                "Show PoseLow",
                true,
                () => BadLocalization.POSELOW[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showPoseTwist = settings.DefineSetting(
                "Show PoseTwist",
                true,
                () => BadLocalization.POSETWIST[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showBlowKiss = settings.DefineSetting(
                "Show BlowKiss",
                true,
                () => BadLocalization.BLOWKISS[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showMagicTrick = settings.DefineSetting(
                "Show MagicTrick",
                true,
                () => BadLocalization.MAGICTRICK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showChannel = settings.DefineSetting(
                "Show Channel",
                true,
                () => BadLocalization.CHANNEL[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showBarbecue = settings.DefineSetting(
                "Show Barbecue",
                true,
                () => BadLocalization.BARBECUE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showDrink = settings.DefineSetting(
                "Show Drink",
                true,
                () => BadLocalization.DRINK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showCrabDance = settings.DefineSetting(
                "Show CrabDance",
                true,
                () => BadLocalization.CRABDANCE[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showShocked = settings.DefineSetting(
                "Show Shocked",
                true,
                () => BadLocalization.SHOCKED[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showThumbsUp = settings.DefineSetting(
                "Show ThumbsUp",
                true,
                () => BadLocalization.THUMBSUP[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showThumbsDown = settings.DefineSetting(
                "Show ThumbsDown",
                true,
                () => BadLocalization.THUMBSDOWN[language],
                () => BadLocalization.EMOTETEXT[language]);

            #endregion

            #region Show/Hide Rank Emotes
            _rankEmoteSeparator = settings.DefineSetting(
                "Rank Separator",
                "",
                () => BadLocalization.RANKPANELTITLE[language],
                () => "");

            _showYourRank = settings.DefineSetting(
                "Show Your Rank",
                true,
                () => BadLocalization.YOURRANK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankRabbit = settings.DefineSetting(
                "Show Rank Rabbit",
                true,
                () => BadLocalization.RABBIT[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankDeer = settings.DefineSetting(
                "Show Rank Deer",
                true,
                () => BadLocalization.DEER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankDolyak = settings.DefineSetting(
                "Show Rank Dolyak",
                true,
                () => BadLocalization.DOLYAK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankWolf = settings.DefineSetting(
                "Show Rank Wolf",
                true,
                () => BadLocalization.WOLF[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankTiger = settings.DefineSetting(
                "Show Rank Tiger",
                true,
                () => BadLocalization.TIGER[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankBear = settings.DefineSetting(
                "Show Rank Bear",
                true,
                () => BadLocalization.BEAR[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankShark = settings.DefineSetting(
                "Show Rank Shark",
                true,
                () => BadLocalization.SHARK[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankPhoenix = settings.DefineSetting(
                "Show Rank Phoenix",
                true,
                () => BadLocalization.PHOENIX[language],
                () => BadLocalization.EMOTETEXT[language]);
            _showRankDragon = settings.DefineSetting(
                "Show Rank Dragon",
                true,
                () => BadLocalization.DRAGON[language],
                () => BadLocalization.EMOTETEXT[language]);
            #endregion


        }


        // blish Load Async
        protected override async Task LoadAsync()
        {
            // Localization
            switch (Overlay.UserLocale.Value)
            {
                case Gw2Sharp.WebApi.Locale.English:
                    language = BadLocalization.ENGLISH;
                    break;
                case Gw2Sharp.WebApi.Locale.French:
                    language = BadLocalization.FRENCH;
                    break;
                case Gw2Sharp.WebApi.Locale.German:
                    language = BadLocalization.GERMAN;
                    break;
                case Gw2Sharp.WebApi.Locale.Spanish:
                    language = BadLocalization.SPANISH;
                    break;
                default:
                    language = BadLocalization.ENGLISH;
                    break;
            };

            // Add a corner icon in the top left next to the other icons in guild wars 2 (e.g. inventory icon, Mail icon)
            tomeCornerIcon = new CornerIcon()
            {
                Icon = ContentsManager.GetTexture("CornerIcon.png"),
                Priority = 61747774,
                Parent = GameService.Graphics.SpriteScreen,
                Visible = false
            };

            // On click listener for corner icon
            tomeCornerIcon.Click += delegate
            {
                tomeWindow.ToggleWindow();
                if (tomeWindow.Visible && checkedAPIForUnlock == false)
                {
                    _ = checkUnlockedEmotesByAPI();
                    checkedAPIForUnlock = true;
                }
            };


            //Main Window
            tomeWindow = new StandardWindow(
                ContentsManager.GetTexture("WindowBackground.png"),
                new Rectangle(40, 26, 913, 691),
                new Rectangle(70, 71, 839, 605))
            {
                Parent = GameService.Graphics.SpriteScreen,
                Title = BadLocalization.WINDOWTITLE[language],
                SavesPosition = true,
                SavesSize = true,
                Id = "0001",
                CanResize = true
            };

            var targetCheckbox = new Checkbox()
            {
                Text = BadLocalization.TARGETCHECKBOXTEXT[language],
                Location = new Point(0, 0),
                BasicTooltipText = BadLocalization.TARGETCHECKBOXTOOLTIP[language],
                Parent = tomeWindow
            };

            var synchronCheckbox = new Checkbox()
            {
                Text = BadLocalization.SYNCHRONCHECKBOXTEXT[language],
                Location = new Point(0, 20),
                BasicTooltipText = BadLocalization.SYNCHRONCHECKBOXTOOLTIP[language],
                Parent = tomeWindow
            };

            //Mainpanel
            var mainPanel = new FlowPanel()
            {
                Size = new Point(tomeWindow.ContentRegion.Width, tomeWindow.ContentRegion.Height),
                Location = new Point(0, 50),
                FlowDirection = ControlFlowDirection.SingleTopToBottom,
                Parent = tomeWindow,
                CanScroll = true,
                Padding = new Thickness(20)
            };

            EmoteLibrary library = new EmoteLibrary(ContentsManager);

            //Create Core Emotes______________________________________________________________________________
            #region Create Core Emotes
            coreEmoteList = library.loadCoreEmotes();
            List<EmoteContainer> coreEmoteContainers = new List<EmoteContainer>();

            //Panel for core emotes
            var corePanel = new FlowPanel()
            {
                ShowBorder = true,
                Title = BadLocalization.COREPANELTITLE[language],
                Size = new Point(mainPanel.ContentRegion.Width, mainPanel.ContentRegion.Height),
                Parent = mainPanel,
                CanCollapse = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                HeightSizingMode = SizingMode.AutoSize,
                AutoSizePadding = new Point(5, 5),
                ControlPadding = new Vector2(5, 5),
                OuterControlPadding = new Vector2(5, 5)
            };
            

            //Create Emote Images
            foreach (Emote emote in coreEmoteList)
            {
                if (emote.getCategory().Equals(EmoteLibrary.CORECODE))
                {

                    var emoteContainer = new EmoteContainer()
                    {
                        Size = new Point(size, size),
                        BasicTooltipText = emote.getToolTipp()[language],
                        Parent = corePanel
                    };

                    var emoteImage = new Image(ContentsManager.GetTexture(emote.getImagePath()))
                    {
                        Size = new Point(size, size),
                        BasicTooltipText = emote.getToolTipp()[language],
                        ZIndex = 1,
                        Parent = emoteContainer
                    };

                    var emoteLabel = new Label
                    {
                        Text = emote.getToolTipp()[language],
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = new Point(size, labelSize),
                        ZIndex = 2,
                        Parent = emoteContainer,
                        AutoSizeWidth = false,
                        Visible = false,
                        BackgroundColor = Color.Black,
                        Location = new Point(0, size-1)
                    };

                    ////Add controls to container
                    emoteContainer.setImage(emoteImage);
                    emoteContainer.setLabel(emoteLabel);

                    //OnClick Listener
                    coreEmoteClickEvent = delegate
                    {
                        if (emoteAllowed())
                        {
                            //ScreenNotification.ShowNotification(emote.getToolTipp()[language]);
                            //Activate Emote
                            activateEmote(emote.getChatCode(), targetCheckbox.Checked, synchronCheckbox.Checked);
                        }
                    };
                    emoteContainer.Click += coreEmoteClickEvent;
                    //coreEmoteImages.Add(emoteImage);
                    coreEmoteContainers.Add(emoteContainer);
                    //emote.setImg(emoteImage);
                    emote.setContainer(emoteContainer);

                }
            }
            #endregion


            //Create Unlockable Emotes______________________________________________________________________________
            #region Create Unlockable Emotes
            unlockEmoteList = library.loadUnlockEmotes();
            //List<Image> unlockEmoteImages = new List<Image>();
            List<EmoteContainer> unlockEmoteContainers = new List<EmoteContainer>();

            //Panel for unlockable Emotes
            var unlockablePanel = new FlowPanel()
            {
                ShowBorder = true,
                Title = BadLocalization.UNLOCKABLEPANELTITLE[language],
                Size = new Point(mainPanel.ContentRegion.Width, mainPanel.ContentRegion.Height),
                Parent = mainPanel,
                CanCollapse = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                HeightSizingMode = SizingMode.AutoSize,
                AutoSizePadding = new Point(5, 5),
                ControlPadding = new Vector2(5, 5),
                OuterControlPadding = new Vector2(5, 5)
            };


            //Create Emote Images
            foreach (Emote emote in unlockEmoteList)
            {
                if (emote.getCategory().Equals(EmoteLibrary.UNLOCKCODE))
                {
                    var emoteContainer = new EmoteContainer()
                    {
                        Size = new Point(size, size),
                        BasicTooltipText = emote.getToolTipp()[language],
                        Parent = unlockablePanel
                    };

                    var emoteImage = new Image(ContentsManager.GetTexture(emote.getImagePath()))
                    {
                        Size = new Point(size, size),
                        BasicTooltipText = emote.getToolTipp()[language],
                        ZIndex = 1,
                        Parent = emoteContainer,
                        Tint = lockedColor,
                        Enabled = false
                    };

                    var emoteLabel = new Label
                    {
                        Text = emote.getToolTipp()[language],
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = new Point(size, labelSize),
                        ZIndex = 2,
                        Parent = emoteContainer,
                        AutoSizeWidth = false,
                        Visible = false,
                        BackgroundColor = Color.Black,
                        Location = new Point(0, size - 1)
                    };

                    ////Add controls to container
                    emoteContainer.setImage(emoteImage);
                    emoteContainer.setLabel(emoteLabel);


                    //OnClick Listener
                    unlockEmoteClickEvent = delegate
                    {
                        if (emoteAllowed())
                        {
                            //ScreenNotification.ShowNotification(emote.getToolTipp()[language]);
                            //Activate Emote
                            activateEmote(emote.getChatCode(), targetCheckbox.Checked, synchronCheckbox.Checked);
                        }
                    };
                    emoteContainer.Click += unlockEmoteClickEvent;
                    unlockEmoteContainers.Add(emoteContainer);
                    emote.setContainer(emoteContainer);
                    emote.isDeactivatedByLocked(true);
                }
            }
            #endregion


            //Create Rank Emotes______________________________________________________________________________
            #region Create Rank Emotes
            rankEmoteList = library.loadRankEmotes();
            List<EmoteContainer> cooldownEmoteContainers = new List<EmoteContainer>();

            //Panel for Rank Emotes
            var rankPanel = new FlowPanel()
            {
                ShowBorder = true,
                Title = BadLocalization.RANKPANELTITLE[language],
                Size = new Point(mainPanel.ContentRegion.Width, mainPanel.ContentRegion.Height),
                Parent = mainPanel,
                CanCollapse = true,
                FlowDirection = ControlFlowDirection.LeftToRight,
                HeightSizingMode = SizingMode.AutoSize,
                AutoSizePadding = new Point(5, 5),
                ControlPadding = new Vector2(5, 5),
                OuterControlPadding = new Vector2(5, 5),
            };

            //Create Emote Images
            foreach (Emote emote in rankEmoteList)
            {
                if (emote.getCategory().Equals(EmoteLibrary.RANKCODE))
                {
                    var emoteContainer = new EmoteContainer()
                    {
                        Size = new Point(size, size),
                        BasicTooltipText = emote.getToolTipp()[language],
                        Parent = rankPanel
                    };

                    var emoteImage = new Image(ContentsManager.GetTexture(emote.getImagePath()))
                    {
                        Size = new Point(size, size),
                        BasicTooltipText = emote.getToolTipp()[language],
                        ZIndex = 1,
                        Parent = emoteContainer,
                        Tint = lockedColor,
                        Enabled = false
                    };

                    var emoteLabel = new Label
                    {
                        Text = emote.getToolTipp()[language],
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = new Point(size, labelSize),
                        ZIndex = 2,
                        Parent = emoteContainer,
                        AutoSizeWidth = false,
                        Visible = false,
                        BackgroundColor = Color.Black,
                        Location = new Point(0, size - 1)
                    };

                    var cooldownLabel = new Label
                    {
                        Text = "60",
                        HorizontalAlignment = HorizontalAlignment.Center,
                        Size = new Point(size, size),
                        ZIndex = 3,
                        Font = GameService.Content.DefaultFont32,
                        Parent = emoteContainer,
                        AutoSizeWidth = false,
                        Visible = false
                    };

                    ////Add controls to container
                    emoteContainer.setImage(emoteImage);
                    emoteContainer.setLabel(emoteLabel);
                    emoteContainer.setCooldownLabel(cooldownLabel);

                    //OnClick Listener
                    rankEmoteClickEvent = delegate
                    {
                        if (emoteAllowed())
                        {
                            //ScreenNotification.ShowNotification(emote.getToolTipp()[language]);
                            //Activate Emote
                            activateEmote(emote.getChatCode(), targetCheckbox.Checked, synchronCheckbox.Checked);
                            activateCooldown();
                        }
                    };
                    emoteContainer.Click += rankEmoteClickEvent;
                    cooldownEmoteContainers.Add(emoteContainer); 
                    emote.setContainer(emoteContainer);
                    emote.isDeactivatedByLocked(true);
                }
            }
            #endregion

            //Spacer for bottom
            var spacePanel = new Panel()
            {
                Size = new Point(mainPanel.ContentRegion.Width, 50),
                Parent = mainPanel
            };


            #region Settings
            //Settings___________________________________________________________________________________________________________
            //Check Settings on Launch
            #region Settings on Launch
            if (_showEmoteNames.Value)
            {
                activateNameLabel(coreEmoteList);
                activateNameLabel(unlockEmoteList);
                activateNameLabel(rankEmoteList);
            }

            if (_adjustLabelLength.Value)
            {
                activateLongLabel(coreEmoteList);
                activateLongLabel(unlockEmoteList);
                activateLongLabel(rankEmoteList);
            }

            #region core emote settings
            //add core emote setting into list for processing
            List<SettingEntry<bool>> coreSettingList = new List<SettingEntry<bool>>();
            coreSettingList.Add(_showBeckon);
            coreSettingList.Add(_showBow);
            coreSettingList.Add(_showCheer);
            coreSettingList.Add(_showCower);
            coreSettingList.Add(_showCrossarms);
            coreSettingList.Add(_showCry);
            coreSettingList.Add(_showDance);
            coreSettingList.Add(_showFacepalm);
            coreSettingList.Add(_showKneel);
            coreSettingList.Add(_showLaugh);
            coreSettingList.Add(_showNo);
            coreSettingList.Add(_showPoint);
            coreSettingList.Add(_showPonder);
            coreSettingList.Add(_showSad);
            coreSettingList.Add(_showSalute);
            coreSettingList.Add(_showShrug);
            coreSettingList.Add(_showSit);
            coreSettingList.Add(_showSleep);
            coreSettingList.Add(_showSurprised);
            coreSettingList.Add(_showTalk);
            coreSettingList.Add(_showThanks);
            coreSettingList.Add(_showThreaten);
            coreSettingList.Add(_showWave);
            coreSettingList.Add(_showYes);

            try
            {
                int count = Math.Min(coreSettingList.Count, coreEmoteList.Count); // takes the lower count. may not load all emotes, if emote and settings are different
                for (int i = 0; i < count; i++)
                {
                    //System.Diagnostics.Debug.WriteLine("Haaaaiiiiii_______________________");
                    //System.Diagnostics.Debug.WriteLine("item1: " + coreSettingList[i].DisplayName + "item2: " + coreEmoteList[i].getToolTipp()[0]);
                    coreEmoteSettingMap.Add(new Tuple<SettingEntry<bool>, Emote>(coreSettingList[i], coreEmoteList[i]));
                }

                foreach (Tuple<SettingEntry<bool>, Emote> tuple in coreEmoteSettingMap)
                {

                    if (!tuple.Item1.Value)
                    {
                        tuple.Item2.getContainer().Visible = false;
                    }
                }
            }
            catch (Exception e)
            {
                ScreenNotification.ShowNotification("Emote Tome: Some Error occured on loading core emotes.");
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }

            corePanel.Collapse();
            await Task.Delay(75);
            corePanel.Expand();
            #endregion

            #region unlockable emote settings
            //add unlockable emote setting into list for processing
            List<SettingEntry<bool>> unlockSettingList = new List<SettingEntry<bool>>();
            unlockSettingList.Add(_showBless);
            unlockSettingList.Add(_showGeargrind);
            unlockSettingList.Add(_showHeroic);
            unlockSettingList.Add(_showHiss);
            unlockSettingList.Add(_showMagicjuggle);
            unlockSettingList.Add(_showPaper);
            unlockSettingList.Add(_showPlaydead);
            unlockSettingList.Add(_showPossessed);
            unlockSettingList.Add(_showReadbook);
            unlockSettingList.Add(_showRock);
            unlockSettingList.Add(_showRockout);
            unlockSettingList.Add(_showScissors);
            unlockSettingList.Add(_showServe);
            unlockSettingList.Add(_showShiver);
            unlockSettingList.Add(_showShiverplus);
            unlockSettingList.Add(_showShuffle);
            unlockSettingList.Add(_showSipcoffee);
            unlockSettingList.Add(_showStep);
            unlockSettingList.Add(_showStretch);
            unlockSettingList.Add(_showUnleash);
            unlockSettingList.Add(_showPetalthrow);
            unlockSettingList.Add(_showBreakdance);
            unlockSettingList.Add(_showBoogie);
            unlockSettingList.Add(_showPoseCover);
            unlockSettingList.Add(_showPoseHigh);
            unlockSettingList.Add(_showPoseLow);
            unlockSettingList.Add(_showPoseTwist);
            unlockSettingList.Add(_showBlowKiss);
            unlockSettingList.Add(_showMagicTrick);
            unlockSettingList.Add(_showChannel);
            unlockSettingList.Add(_showBarbecue);
            unlockSettingList.Add(_showDrink);
            unlockSettingList.Add(_showCrabDance);
            unlockSettingList.Add(_showShocked);
            unlockSettingList.Add(_showThumbsUp);
            unlockSettingList.Add(_showThumbsDown);

            try
            {
                int count = Math.Min(unlockEmoteList.Count, unlockSettingList.Count); // takes the lower count. may not load all emotes, if emote and settings are different
                for (int i = 0; i < count; i++)
                {
                    //System.Diagnostics.Debug.WriteLine("item1: " + coreSettingList[i].DisplayName + "item2: " + coreEmoteList[i].getToolTipp()[0]);
                    unlockEmoteSettingMap.Add(new Tuple<SettingEntry<bool>, Emote>(unlockSettingList[i], unlockEmoteList[i]));
                }

                foreach (Tuple<SettingEntry<bool>, Emote> tuple in unlockEmoteSettingMap)
                {

                    if (!tuple.Item1.Value)
                    {
                        tuple.Item2.getContainer().Visible = false;
                    }
                }
            }
            catch (Exception e)
            {
                ScreenNotification.ShowNotification("Emote Tome: Some Error occured on loading unlockable emotes.");
                System.Diagnostics.Debug.WriteLine(e.StackTrace);

            }

            unlockablePanel.Collapse();
            await Task.Delay(75);
            unlockablePanel.Expand();
            #endregion

            #region rank emote settings
            //add core emote setting into list for processing
            List<SettingEntry<bool>> rankSettingList = new List<SettingEntry<bool>>();
            rankSettingList.Add(_showYourRank);
            rankSettingList.Add(_showRankRabbit);
            rankSettingList.Add(_showRankDeer);
            rankSettingList.Add(_showRankDolyak);
            rankSettingList.Add(_showRankWolf);
            rankSettingList.Add(_showRankTiger);
            rankSettingList.Add(_showRankBear);
            rankSettingList.Add(_showRankShark);
            rankSettingList.Add(_showRankPhoenix);
            rankSettingList.Add(_showRankDragon);

            try
            {
                int count = Math.Min(rankEmoteList.Count, rankSettingList.Count); // takes the lower count. may not load all emotes, if emote and settings are different
                for (int i = 0; i < rankEmoteList.Count; i++)
                {
                    //System.Diagnostics.Debug.WriteLine("item1: " + coreSettingList[i].DisplayName + "item2: " + coreEmoteList[i].getToolTipp()[0]);
                    rankEmoteSettingMap.Add(new Tuple<SettingEntry<bool>, Emote>(rankSettingList[i], rankEmoteList[i]));
                }

                foreach (Tuple<SettingEntry<bool>, Emote> tuple in rankEmoteSettingMap)
                {

                    if (!tuple.Item1.Value)
                    {
                        tuple.Item2.getContainer().Visible = false;
                    }
                }
            }catch(Exception e) {
                ScreenNotification.ShowNotification("Emote Tome: Some Error occured on loading rank emotes.");
                System.Diagnostics.Debug.WriteLine(e.StackTrace);
            }

            rankPanel.Collapse();
            await Task.Delay(75);
            rankPanel.Expand();
            #endregion

            #endregion

            //When Setting changes
            #region On Setting Change
            _showEmoteNames.PropertyChanged += (_, e) =>
            {
                if (_showEmoteNames.Value)
                {
                    activateNameLabel(coreEmoteList);
                    activateNameLabel(unlockEmoteList);
                    activateNameLabel(rankEmoteList);
                }
                else
                {
                    deactivateNameLabel(coreEmoteList);
                    deactivateNameLabel(unlockEmoteList);
                    deactivateNameLabel(rankEmoteList);
                }

            };
            _adjustLabelLength.PropertyChanged += (_, e) =>
            {
                if (_adjustLabelLength.Value)
                {
                    activateLongLabel(coreEmoteList);
                    activateLongLabel(unlockEmoteList);
                    activateLongLabel(rankEmoteList);
                }
                else
                {
                    deactivateLongLabel(coreEmoteList);
                    deactivateLongLabel(unlockEmoteList);
                    deactivateLongLabel(rankEmoteList);
                }
            };

            _halloweenMode.PropertyChanged += (_, e) =>
            {
                if (_halloweenMode.Value)
                {
                    halloweenMode(_halloweenMode, true);
                }
                else
                {
                    halloweenMode(_halloweenMode, false);
                }
                
            };

            #region Show/Hide Core Emotes
            showHideEmotes(coreEmoteSettingMap, corePanel);
            showHideEmotes(unlockEmoteSettingMap, unlockablePanel);
            showHideEmotes(rankEmoteSettingMap, rankPanel);
            #endregion


            #endregion

            #endregion

            //Resizing_______________________________________________________________________________________________
            #region Windows Resizing
            //Window
            tomeWindow.Resized += (_, e) =>
            {
                mainPanel.Width = tomeWindow.ContentRegion.Width;
                mainPanel.Height = tomeWindow.ContentRegion.Height;
                corePanel.Width = mainPanel.ContentRegion.Width;
                unlockablePanel.Width = mainPanel.ContentRegion.Width;
                rankPanel.Width = mainPanel.ContentRegion.Width;
                spacePanel.Width = mainPanel.ContentRegion.Width;

            };

            //When target checkbox is clicked
            targetCheckbox.CheckedChanged += (_, e) =>
            {
                if (targetCheckbox.Checked)
                {
                    foreach (Emote emote in coreEmoteList)
                    {
                        if (!emote.hasTarget())
                        {
                            emote.getContainer().getImage().Tint = noTargetColor;
                            emote.isDeactivatedByTargeting(true);
                        }
                    }
                    foreach (Emote emote in unlockEmoteList)
                    {
                        if (!emote.hasTarget() && !emote.isDeactivatedByLocked())
                        {
                            emote.getContainer().getImage().Tint = noTargetColor;
                            emote.isDeactivatedByTargeting(true);
                        }
                    }
                    foreach (Emote emote in rankEmoteList)
                    {
                        if (!emote.hasTarget() && !emote.isDeactivatedByLocked())
                        {
                            if (!emote.isDeactivatedByCooldown())
                            {
                                emote.getContainer().getImage().Tint = noTargetColor;
                            }
                            emote.isDeactivatedByTargeting(true);
                        }
                    }
                }
                else
                {
                    foreach (Emote emote in coreEmoteList)
                    {
                        emote.getContainer().getImage().Tint = activatedColor;
                        emote.isDeactivatedByTargeting(false);
                    }
                    foreach (Emote emote in unlockEmoteList)
                    {
                        if (!emote.isDeactivatedByLocked())
                        {
                            emote.getContainer().getImage().Tint = activatedColor;
                        }
                        emote.isDeactivatedByTargeting(false);
                    }
                    foreach (Emote emote in rankEmoteList)
                    {
                        if (!emote.isDeactivatedByCooldown() && !emote.isDeactivatedByLocked())
                        {
                            emote.getContainer().getImage().Tint = activatedColor;
                        }
                        emote.isDeactivatedByTargeting(false);

                    }
                }
            };
            #endregion

            //Set Cooldown for Rank Emotes
            #region Rank Emotes Cooldown
            void activateCooldown()
            {
                int cooldown = 60;
                foreach (Emote emote in rankEmoteList)
                {
                    if (!emote.isDeactivatedByLocked())
                    {
                        emote.getContainer().getImage().Tint = cooldownColor;
                        emote.getContainer().Enabled = false;
                        emote.isDeactivatedByCooldown(true);

                        emote.getContainer().getCooldownLabel().Text = cooldown.ToString();
                        emote.getContainer().getCooldownLabel().Visible = true;
                    }

                }

                System.Timers.Timer aTimer = new System.Timers.Timer();
                aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
                //aTimer.Interval = 60000;
                aTimer.Interval = 1000;
                aTimer.Enabled = true;
                void OnTimedEvent(object source, ElapsedEventArgs e)
                {
                    if (cooldown >= 1)
                    {
                        cooldown--;
                        foreach (Emote emote in rankEmoteList)
                        {
                            emote.getContainer().getCooldownLabel().Text = cooldown.ToString();
                        }
                    }
                    else
                    {
                        cooldown = 60;
                        aTimer.Enabled = false;
                        foreach (Emote emote in rankEmoteList)
                        {
                            emote.getContainer().getCooldownLabel().Visible = false;
                            if (!emote.isDeactivatedByLocked())
                            {
                                if (emote.isDeactivatedByTargeting())
                                {
                                    emote.getContainer().getImage().Tint = noTargetColor;
                                }
                                else
                                {
                                    emote.getContainer().getImage().Tint = activatedColor;
                                }
                                emote.getContainer().Enabled = true;
                                emote.isDeactivatedByCooldown(false);
                            }
                        }
                    }
                    
                }
            }
            #endregion
            tomeCornerIcon.Visible = true;
        }
        

        private void showHideEmotes(List<Tuple<SettingEntry<bool>, Emote>> tupleList, Panel panel)
        {
            foreach (Tuple<SettingEntry<bool>, Emote> tuple in tupleList)
            {
                tuple.Item1.PropertyChanged += async (_, e) =>
                {
                    if (tuple.Item1.Value)
                    {
                        tuple.Item2.getContainer().Visible = true;
                    }
                    else
                    {
                        tuple.Item2.getContainer().Visible = false;
                    }
                    panel.Collapse();
                    await Task.Delay(75);
                    panel.Expand();
                };
            }
        }

        private void halloweenMode(SettingEntry<bool> setting, bool value)
        {
            //used emotes
            _showBeckon.Value = true;
            _showBow.Value = true;
            _showCheer.Value = true;
            _showCower.Value = true;
            _showDance.Value = true;
            _showKneel.Value = true;
            _showLaugh.Value = true;
            _showNo.Value = true;
            _showPoint.Value = true;
            _showPonder.Value = true;
            _showSalute.Value = true;
            _showShrug.Value = true;
            _showSit.Value = true;
            _showSleep.Value = true;
            _showSurprised.Value = true;
            _showThreaten.Value = true;
            _showWave.Value = true;
            _showYes.Value = true;

            //not used emotes
            _showCrossarms.Value = !value;
            _showCry.Value = !value;
            _showFacepalm.Value = !value;
            _showSad.Value = !value;
            _showTalk.Value = !value;
            _showThanks.Value = !value;
        }

        protected override void Update(GameTime gameTime)
        {
            //Check if player is moving, when emote window is opened
            if (tomeWindow.Visible)
            {
                switch (checkPositionSwitch)
                {
                    case 0:
                        currentPositionA = GameService.Gw2Mumble.PlayerCharacter.Position;
                        break;
                    case 1:
                        currentPositionB = GameService.Gw2Mumble.PlayerCharacter.Position;
                        break;
                    case 2:
                        currentPositionC = GameService.Gw2Mumble.PlayerCharacter.Position;
                        break;
                }
                if (checkPositionSwitch >= 2)
                    checkPositionSwitch = 0;
                else
                    checkPositionSwitch++;
            }
        }

        
        protected override void Unload()
        {
            foreach (var emote in coreEmoteList)
            {
                emote.getContainer().Click -= coreEmoteClickEvent;
                emote.getContainer()?.Dispose();
            }
            foreach (var emote in unlockEmoteList)
            {
                emote.getContainer().Click -= unlockEmoteClickEvent;
                emote.getContainer()?.Dispose();
            }
            foreach (var emote in rankEmoteList)
            {
                emote.getContainer().Click -= rankEmoteClickEvent;
                emote.getContainer()?.Dispose();
            }
            tomeWindow?.Dispose();
            tomeCornerIcon?.Dispose();
        }




        private void activateLongLabel(List<Emote> emoteList)
        {
            foreach (Emote emote in emoteList)
            {
                emote.getContainer().WidthSizingMode = SizingMode.AutoSize;
                emote.getContainer().Size = new Point(size, size + labelSize);
                emote.getContainer().getLabel().Width = labelWidth;
                emote.getContainer().getImage().Location = new Point(labelWidth / 2 - size / 2, 0);
                if (emote.getContainer().getCooldownLabel() != null)
                {
                    emote.getContainer().getCooldownLabel().Location = emote.getContainer().getImage().Location;
                }

            }
            _showEmoteNames.Value = true;
        }
        
        private void deactivateLongLabel(List<Emote> emoteList)
        {
            foreach (Emote emote in emoteList)
            {
                emote.getContainer().WidthSizingMode = SizingMode.Standard;
                emote.getContainer().getLabel().Width = size;
                emote.getContainer().getImage().Location = new Point(0, 0);
                if (_showEmoteNames.Value)
                {
                    emote.getContainer().Size = new Point(size, size + labelSize);
                    emote.getContainer().getLabel().AutoSizeWidth = false;
                }
                else
                {
                    emote.getContainer().Size = new Point(size, size);
                }
                if (emote.getContainer().getCooldownLabel() != null)
                {
                    emote.getContainer().getCooldownLabel().Location = emote.getContainer().getImage().Location;
                }
            }
        }
        private void activateNameLabel(List<Emote> emoteList)
        {
            foreach (Emote emote in emoteList)
            {
                emote.getContainer().getLabel().Visible = true;
                emote.getContainer().Size = new Point(size, size + labelSize);
            }
        }

        private void deactivateNameLabel(List<Emote> emoteList)
        {
            foreach (Emote emote in emoteList)
            {
                emote.getContainer().getLabel().Visible = false;
                emote.getContainer().Size = new Point(size, size);
            }
            _adjustLabelLength.Value = false;
        }



        private bool emoteAllowed()
        {
            if (IsAnyKeyDown())
            {
                ScreenNotification.ShowNotification(BadLocalization.NOEMOTEONKEYPRESSED[language]);
                return false;
            }
            else if (isPlayerMoving())
            {
                ScreenNotification.ShowNotification(BadLocalization.NOEMOTEWHENMOVING[language]);
                return false;
            }
            else if (GameService.Gw2Mumble.PlayerCharacter.IsInCombat)
            {
                ScreenNotification.ShowNotification(BadLocalization.NOEMOTEINCOMBAT[language]);
                return false;
            }
            else if (!GameService.Gw2Mumble.PlayerCharacter.CurrentMount.ToString().Equals("None"))
            {
                ScreenNotification.ShowNotification(BadLocalization.NOEMOTEONMOUNT[language]);
                return false;
            }
            else
            {
                return true;
            }

        }
        private async void activateEmote(String emote, bool targetChecked, bool synchronChecked)
        {
            String chatCommand = "/" + emote;
            if (targetChecked)
            {
                chatCommand = chatCommand + " @";
            }
            if (synchronChecked)
            {
                chatCommand = chatCommand + " *";
            }

            if (!GameService.Gw2Mumble.UI.IsTextInputFocused)
            {
                Blish_HUD.Controls.Intern.Keyboard.Stroke(VirtualKeyShort.RETURN);
                //Thread.Sleep(25);
                await Task.Delay(25);
            }
            Blish_HUD.Controls.Intern.Keyboard.Press(VirtualKeyShort.CONTROL, true);
            Blish_HUD.Controls.Intern.Keyboard.Stroke(VirtualKeyShort.KEY_A, true);
            //Thread.Sleep(25);
            await Task.Delay(25);
            Blish_HUD.Controls.Intern.Keyboard.Release(VirtualKeyShort.CONTROL, true);
            Blish_HUD.Controls.Intern.Keyboard.Release(VirtualKeyShort.KEY_A);
            Blish_HUD.Controls.Intern.Keyboard.Release(VirtualKeyShort.KEY_D);
            InputSimulator sim = new InputSimulator();
            sim.Keyboard.TextEntry(chatCommand);
            //Thread.Sleep(50);
            await Task.Delay(50);
            Blish_HUD.Controls.Intern.Keyboard.Stroke(VirtualKeyShort.RETURN);


        }

        private bool isPlayerMoving()
        {
            if (_checkForMovement.Value)
            {
                if (currentPositionA.Equals(currentPositionB) && currentPositionA.Equals(currentPositionC))
                    return false;
                else
                    return true;
            }
            else
                return false;
        }

        public bool IsAnyKeyDown()
        {
            if (_checkForKeyPress.Value == true)
            {
                var values = Enum.GetValues(typeof(Key));

                foreach (var v in values)
                    if (((Key)v) != Key.None && Keyboard.GetState().IsKeyDown((Keys)(Key)v))
                        return true;

                return false;
            }
            else
                return false;
            
        }


        private async Task checkUnlockedEmotesByAPI()
        {
            var apiKeyPermissions = new List<TokenPermission>
                        {
                            TokenPermission.Account, // this permission can be used to check if your module got a token at all because every api key has this persmission.
                            TokenPermission.Progression,
                            TokenPermission.Unlocks,
                            TokenPermission.Pvp
                        };
            try
            {
                System.Diagnostics.Debug.WriteLine("_______________________________________________");
                if (Gw2ApiManager.HasPermissions(apiKeyPermissions))
                {
                    System.Diagnostics.Debug.WriteLine("Permission");
                    // load unlocked emotes
                    var finisherList = await Gw2ApiManager.Gw2ApiClient.V2.Account.Finishers.GetAsync();
                    var ranks = await Gw2ApiManager.Gw2ApiClient.V2.Pvp.Stats.GetAsync();

                    foreach (Emote emote in rankEmoteList)
                    {
                        if (emote.getChatCode().Equals("rank"))
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 1"))
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 10") && ranks.PvpRank >= 10)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 20") && ranks.PvpRank >= 20)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 30") && ranks.PvpRank >= 30)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 40") && ranks.PvpRank >= 40)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 50") && ranks.PvpRank >= 50)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 60") && ranks.PvpRank >= 60)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 70") && ranks.PvpRank >= 70)
                        {
                            enableRankEmote(emote);
                        }
                        else if (emote.getChatCode().Equals("rank 80") && ranks.PvpRank >= 80)
                        {
                            enableRankEmote(emote);
                        }
                    }
                    void enableRankEmote(Emote emote)
                    {
                        emote.getContainer().getImage().Tint = activatedColor;
                        emote.getContainer().Enabled = true;
                        emote.isDeactivatedByLocked(false);
                    }



                    var unlockedEmotes = new List<string>(await Gw2ApiManager.Gw2ApiClient.V2.Account.Emotes.GetAsync());
                    unlockedEmotes = unlockedEmotes.ConvertAll(d => d.ToLower());
                    foreach (Emote emote in unlockEmoteList)
                    {
                        //Deactivate all unlockable emotes
                        //Exceptions for Emotes that are not yet included in API_____________
                        if (//emote.getChatCode().Equals("bless") ||
                            //emote.getChatCode().Equals("heroic") ||
                            emote.getChatCode().Equals("hiss") ||
                            emote.getChatCode().Equals("magicjuggle") ||
                            //emote.getChatCode().Equals("paper") ||
                            //emote.getChatCode().Equals("possessed") ||
                            emote.getChatCode().Equals("readbook") ||
                            //emote.getChatCode().Equals("rock") ||
                            //emote.getChatCode().Equals("scissors") ||
                            emote.getChatCode().Equals("serve") ||
                            emote.getChatCode().Equals("sipcoffee") ||
                            emote.getChatCode().Equals("unleash") ||
                            emote.getChatCode().Equals("petalthrow") ||
                            emote.getChatCode().Equals("breakdance") ||
                            emote.getChatCode().Equals("boogie") ||
                            emote.getChatCode().Equals("posecover") ||
                            emote.getChatCode().Equals("posehigh") ||
                            emote.getChatCode().Equals("poselow") ||
                            emote.getChatCode().Equals("posetwist") ||
                            emote.getChatCode().Equals("blowkiss") ||
                            emote.getChatCode().Equals("magictrick") ||
                            emote.getChatCode().Equals("channel") ||
                            emote.getChatCode().Equals("barbecue")||
                            emote.getChatCode().Equals("drink")||
                            emote.getChatCode().Equals("crabdance")||
                            emote.getChatCode().Equals("shocked")||
                            emote.getChatCode().Equals("thumbsup") ||
                            emote.getChatCode().Equals("thumbsdown"))
                        {
                            emote.getContainer().Enabled = true;
                            emote.getContainer().getImage().Tint = activatedColor;
                            emote.isDeactivatedByLocked(false);
                        }

                        //System.Diagnostics.Debug.WriteLine("All Emotes: " + unlocked);
                        //System.Diagnostics.Debug.WriteLine("Unlocked Emotes: " + unlocked);

                        //Activate unlocked emotes
                        if (unlockedEmotes.Contains(emote.getChatCode()))
                        {
                            System.Diagnostics.Debug.WriteLine("_______________________________________________");
                            System.Diagnostics.Debug.WriteLine("Freigeschalten: " + emote.getChatCode());

                            emote.getContainer().Enabled = true;
                            emote.getContainer().getImage().Tint = activatedColor;
                            emote.isDeactivatedByLocked(false);
                        }
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("No permissions");
                    foreach (Emote emote in unlockEmoteList)
                    {
                        enableLockedEmote(emote);
                    }
                    foreach (Emote emote in rankEmoteList)
                    {
                        enableLockedEmote(emote);
                    }
                    void enableLockedEmote(Emote emote)
                    {
                        emote.getContainer().getImage().Tint = activatedColor;
                        emote.getContainer().Enabled = true;
                        emote.isDeactivatedByLocked(false);
                    }
                }
            }
            catch (Exception)
            {
                System.Diagnostics.Debug.WriteLine("No Permissions via exception");
                foreach (Emote emote in unlockEmoteList)
                {
                    enableLockedEmote(emote);
                }
                foreach (Emote emote in rankEmoteList)
                {
                    enableLockedEmote(emote);
                }
                void enableLockedEmote(Emote emote)
                {
                    emote.getContainer().getImage().Tint = activatedColor;
                    emote.getContainer().Enabled = true;
                    emote.isDeactivatedByLocked(false);
                }
            }
        }


    }
}
