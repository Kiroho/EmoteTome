using System;
using System.Collections.Generic;
namespace EmoteTome
{
    class BadLocalization
    {
        public static readonly int ENGLISH = 0;
        public static readonly int FRENCH = 1;
        public static readonly int GERMAN = 2;
        public static readonly int SPANISH = 3;

        public static readonly List<String> WINDOWTITLE = new List<String> {
            "Emote Tome",
            "Emote Tome",
            "Emote Tome",
            "Emote Tome"
            };
        public static readonly List<String> UNLOCKABLEPANELTITLE = new List<String> {
            "Unlockable Emotes",
            "Emotes pour deverrouiller",
            "Freischaltbare Emotes",
            "Emotes desbloqueables"
            };
        public static readonly List<String> RANKPANELTITLE = new List<String> {
            "Rank Emotes",
            "Rang Emotes",
            "Rang Emotes",
            "Rango Emotes"
            };
        public static readonly List<String> COREPANELTITLE = new List<String> {
            "Core Emotes",
            "Emote de base",
            "Kern Emotes",
            "Emotes de base"
            };
        public static readonly List<String> NOEMOTEONKEYPRESSED = new List<String> {
            "Can't peform emotes while a key is pressed",
            "Impossible d'effectuer des emotes pendant qu'une touche est pressée",
            "Nicht möglich, während eine Taste gedrückt ist",
            "No se pueden realizar emotes mientras se pulsa una tecla"
            };
        public static readonly List<String> NOEMOTEWHENMOVING = new List<String> {
            "Can't peform emotes while moving",
            "Impossible d'effectuer des emotes en se déplaçant",
            "Während der Bewegung nicht möglich",
            "No se pueden realizar emotes en movimiento"
            };
        public static readonly List<String> NOEMOTEONMOUNT = new List<String> {
            "Can't peform emotes while on mount",
            "Impossible d'effectuer des emotes lorsque l'on est sur une monture",
            "Auf Mounts nicht möglich",
            "No se pueden realizar emotes mientras se está montado"
            };
        public static readonly List<String> NOEMOTEINCOMBAT = new List<String> {
            "Can't peform emotes while in combat",
            "Impossible d'effectuer des emotes pendant le combat",
            "Im Kampf nicht möglich",
            "No se pueden realizar emotes en combate"
            };
        public static readonly List<String> SYNCHRONCHECKBOXTEXT = new List<String> {
            "Synchronize emotes",
            "Synchroniser les emotes",
            "Emotes synchronisieren",
            "Sincronizar emotes"
            };
        public static readonly List<String> SYNCHRONCHECKBOXTOOLTIP = new List<String> {
            "Synchronizes your emotes with other players.",
            "Synchronise vos emotes avec celles des autres joueurs.",
            "Synchronisiert Dein Emote mit anderen Spielern.",
            "Sincroniza tus emotes con los de otros jugadores."
            };
        public static readonly List<String> TARGETCHECKBOXTEXT = new List<String> {
            "Enable Targeting",
            "Activer le ciblage",
            "Anvisieren aktivieren",
            "Activar objetivo"
            };
        public static readonly List<String> TARGETCHECKBOXTOOLTIP = new List<String> {
            "Peforme emote on target.\nSome emotes are not affected.",
            "Peforme emote on target.\nCertaines emotes ne sont pas affectées.",
            "Führt Emote an Ziel aus.\nBetrifft nicht alle Emotes.",
            "Peforme emote en target.\nAlgunos emotes no se ven afectados."
            };

        public static readonly List<String> SHOWNAMES = new List<String> {
            "Show Emote Names",
            "Afficher le nom de Emote",
            "Zeige Emote Namen",
            "Mostrar el nombre de Emote"
            };
        public static readonly List<String> SHOWNAMESTEXT = new List<String> {
            "Shows the name of the emote under it's icon.",
            "Affiche le nom de l'emote sous son icône.",
            "Zeigt den Namen eines Emotes unter dessen Icon an.",
            "Muestra el nombre del emote debajo de su icono."
            };
        public static readonly List<String> LARGERNAMELABELS = new List<String> {
            "Larger Name Labels",
            "Étiquettes de noms plus grandes",
            "Groeßere Namensfelder",
            "Etiquetas de nombres más grandes"
            };
        public static readonly List<String> LARGERNAMELABELSTEXT = new List<String> {
            "Some emote names are long, this setting will give them more space.",
            "Certains noms d'émoticônes sont longs, ce paramètre leur donnera plus d'espace.",
            "Manche Emotenamen sind lang, diese Option gibt ihnen mehr Platz.",
            "Algunos nombres de emoticonos son largos, esta configuración les dará más espacio."
            };
        public static readonly List<String> HALLOWEENMODE = new List<String> {
            "Halloween Mode",
            "Mode Halloween",
            "Halloween Modus",
            "Modo de Halloween"
            };
        public static readonly List<String> HALLOWEENMODETEXT = new List<String> {
            "Only shows those emotes in core panel that are used in 'Mad King Says'.\nSets all core emotes back to 'Show' when disabled.",
            "Affiche uniquement les émoticônes du noyau utilisés dans 'Mad King Says'.\nRétablit tous les émoticônes du noyau à 'Afficher' lorsqu'il est désactivé.",
            "Zeigt nur jene Emotes in der Kern-Kategorie, die für 'Der Verrueckte Koenig Sagt' gebraucht werden.\nSetzt alle Emotes auf 'Zeigen', wenn deaktiviert.",
            "Solo muestra los emoticonos en el panel principal que se utilizan en 'Mad King Says'.\nRestablece todos los emoticonos principales a 'Mostrar' cuando está desactivado."
            };

        public static readonly List<String> EMOTETEXT = new List<String> {
            "Shows/Hides this emote",
            "Affiche/Masque cet emote",
            "Zeigt/versteckt dieses Emote",
            "Muestra/Oculta este emote"
            };

        public static readonly List<String> HIDECOREEMOTE = new List<String> {
            "Hide Core Category",
            "Masque categorie de base",
            "Verstecke Kern Kategorie",
            "Oculta categoria de base"
            };

        public static readonly List<String> HIDEUNLOCKEMOTE = new List<String> {
            "Hide Unlockable Category",
            "Masque categorie deverrouiller",
            "Verstecke Freischaltbar Kategorie",
            "Oculta categoria desbloqueables"
            };

        public static readonly List<String> HIDERANKEMOTE = new List<String> {
            "Hide Rank Category",
            "Masque categorie rang",
            "Verstecke Rang Kategorie",
            "Oculta categoria rango"
            };

        public static readonly List<String> CHECKKEY = new List<String> {
            "Check keystrokes for emotes",
            "vérifier les touches enfoncées pour les émotes",
            "Prüfe Tastendruck bei Emotes",
            "Verifique las pulsaciones de teclas para ver emoticones"
            };
        public static readonly List<String> CHECKKEYTEXT = new List<String> {
            "Does not allow emotes when a key is pressed.\nIt's not recommended to disable this setting.",
            "N'autorise pas les émoticônes lorsqu'une touche est enfoncée.\nIl n'est pas recommandé de désactiver ce paramètre.",
            "Erlaubt keine Emotes, während eine Taste gedrückt wird.\nEs wird nicht empfohlen, diese Einstellung zu deaktivieren.",
            "No permite gestos cuando se presiona una tecla.\nNo se recomienda deshabilitar esta configuración.",
            };

        public static readonly List<String> CHECKMOVE = new List<String> {
            "Check movement for emotes",
            "Vérifiez le mouvement pour les émoticônes",
            "Prüfe Bewegung bei Emotes",
            "Comprueba el movimiento de los emoticones",
            };
        public static readonly List<String> CHECKMOVETEXT = new List<String> {
            "Does not allow emotes when player is moving.\nIt's not recommended to disable this setting.",
            "N'autorise pas les émoticônes lorsque le joueur se déplace.\nIl n'est pas recommandé de désactiver ce paramètre.",
            "Erlaubt keine Emotes, während sich der Spieler bewegt.\nEs wird nicht empfohlen, diese Einstellung zu deaktivieren.",
            "No permite gestos cuando el jugador está en movimiento.\nNo se recomienda deshabilitar esta configuración.",
            };
        public static readonly List<String> FAVORITESBAR = new List<String> {
            "Favorites Bar",
            "Bar des favoris",
            "Favoriten Leiste",
            "Barra de favoritos",
            };

        #region Core Emotes

        public static readonly List<String> BECKON = new List<String> {
            "Beckon",
            "Approcher",
            "Herbeiwinken",
            "Señas"
            };
        public static readonly List<String> BOW = new List<String> {
            "Bow",
            "Reverence",
            "Verbeugen",
            "Inclinarse"
            };
        public static readonly List<String> CHEER = new List<String> {
            "Cheer",
            "Encourager",
            "Jubeln",
            "Animar"
            };
        public static readonly List<String> COWER = new List<String> {
            "Cower",
            "Lache",
            "Ducken",
            "Cobarde"
            };
        public static readonly List<String> CROSSARMS = new List<String> {
            "Crossarms",
            "Brascroises",
            "Armekreuzen",
            "Cruzarse"
            };
        public static readonly List<String> CRY = new List<String> {
            "Cry",
            "Pleurer",
            "Weinen",
            "Llorar"
            };
        public static readonly List<String> DANCE = new List<String> {
            "Dance",
            "Danse",
            "Tanzen",
            "Bailar"
            };
        public static readonly List<String> FACEPALM = new List<String> {
           "Facepalm",
            "Fache",
            "Veraergert",
            "Disgustado"
            };
        public static readonly List<String> KNEEL = new List<String> {
            "Kneel",
            "Genoux",
            "Hinknien",
            "Arrodillarse"
            };
        public static readonly List<String> LAUGH = new List<String> {
            "Laugh",
            "Rire",
            "Lachen",
            "Reír"
            };
        public static readonly List<String> NO = new List<String> {
            "No",
            "Non",
            "Nein",
            "No"
            };
        public static readonly List<String> POINT = new List<String> {
            "Point",
            "Montrer",
            "Zeigen",
            "Señalar"
            };
        public static readonly List<String> PONDER = new List<String> {
            "Ponder",
            "Cogite",
            "Gruebeln",
            "Reflexionar"
            };
        public static readonly List<String> SAD = new List<String> {
            "Sad",
            "Triste",
            "Traurig",
            "Triste"
            };
        public static readonly List<String> SALUTE = new List<String> {
            "Salute",
            "Salut",
            "Salutieren",
            "Firmesr"
            };
        public static readonly List<String> SHRUG = new List<String> {
            "Shrug",
            "Epaules",
            "Schulterzucken",
            "Encogerse"
            };
        public static readonly List<String> SIT = new List<String> {
            "Sit",
            "Asseoir",
            "Hinsetzen",
            "Sentarse"
            };
        public static readonly List<String> SLEEP = new List<String> {
            "Sleep",
            "Dormir",
            "Schlafen",
            "Dormir"
            };
        public static readonly List<String> SURPRISED = new List<String> {
            "Surprised",
            "Surpris",
            "Ueberrascht",
            "Sorpresa"
            };
        public static readonly List<String> TALK = new List<String> {
            "Talk",
            "Parler",
            "Reden",
            "Hablar"
            };
        public static readonly List<String> THANKS = new List<String> {
            "Thanks",
            "Merci",
            "Danke",
            "Gracias"
            };
        public static readonly List<String> THREATEN = new List<String> {
            "Threaten",
            "Menace",
            "Drohen",
            "Amenaza"
            };
        public static readonly List<String> WAVE = new List<String> {
            "Wave",
            "Coucou",
            "Winken",
            "Saludar"
            };
        public static readonly List<String> YES = new List<String> {
            "Yes",
            "Oui",
            "Ja",
            "Si"
            };
        #endregion

        #region Unlockable Emotes

        public static readonly List<String> BLESS = new List<String> {
            "Bless",
            "Bénir",
            "Segnen",
            "Bless"
            };
        public static readonly List<String> GEARGRIND = new List<String> {
            "Geargrind",
            "Coureur",
            "Endlos",
            "Corredor"
            };
        public static readonly List<String> HEROIC = new List<String> {
            "Heroic",
            "Heroic",
            "Heldenhaft",
            "Heroic"
            };
        public static readonly List<String> HISS = new List<String> {
            "Hiss",
            "Feule",
            "Zischen",
            "Bufar"
            };
        public static readonly List<String> MAGICJUGGLE = new List<String> {
            "Magicjuggle",
            "Jonglagemagique",
            "Magischesjonglieren",
            "Malabarmagico"
            };
        public static readonly List<String> PAPER = new List<String> {
            "Paper",
            "Feuille",
            "Papier",
            "Papel"
            };
        public static readonly List<String> PLAYDEAD = new List<String> {
            "Playdead",
            "Faitlemort",
            "Totstellen",
            "Yacer"
            };
        public static readonly List<String> POSSESSED = new List<String> {
            "Possessed",
            "Possede",
            "Besessen",
            "Poseido"
            };
        public static readonly List<String> READBOOK = new List<String> {
            "Readbook",
            "Lecture",
            "Buchlesen",
            "Leerlibro"
            };
        public static readonly List<String> ROCK = new List<String> {
            "Rock",
            "Pierre",
            "Stein",
            "Piedra"
            };
        public static readonly List<String> ROCKOUT = new List<String> {
            "Rockout",
            "Hardrock",
            "Abrocken",
            "Rockear"
            };
        public static readonly List<String> SCISSORS = new List<String> {
            "Scissors",
            "Ciseaux",
            "Schere",
            "Tijeras"
            };
        public static readonly List<String> SERVE = new List<String> {
            "Serve",
            "Servir",
            "Servieren",
            "Servir"
            };
        public static readonly List<String> SHIVER = new List<String> {
            "Shiver",
            "Tremble",
            "Zittern",
            "Tiritar"
            };
        public static readonly List<String> SHIVERPLUS = new List<String> {
            "Shiverplus",
            "Tremblefort",
            "Zitternplus",
            "Tiritarmucho"
            };
        public static readonly List<String> SHUFFLE = new List<String> {
            "Shuffle",
            "Shuffle",
            "Shuffle",
            "Mezclador"
            };
        public static readonly List<String> SIPCOFFEE = new List<String> {
            "Sipcoffee",
            "Boirecafe",
            "Kaffeeschluerf",
            "Sipcoffee"
            };
        public static readonly List<String> STEP = new List<String> {
            "Step",
            "Esquive",
            "Schritt",
            "Paso"
            };
        public static readonly List<String> STRETCH = new List<String> {
            "Stretch",
            "Étirement",
            "Dehnen",
            "Estirarse"
            };
        public static readonly List<String> UNLEASH = new List<String> {
            "Unleash",
            "Libere",
            "Entfesseln",
            "Desatar"
            };
        public static readonly List<String> PETALTHROW = new List<String> {
            "Petalthrow",
            "Lancerpetale",
            "Bluetenblaetterwerfen",
            "Lanzarpetalos"
            };
        public static readonly List<String> BREAKDANCE = new List<String> {
            "Breakdance",
            "Breakdance",
            "Breakdance",
            "Breakdance"
            };
        public static readonly List<String> BOOGIE = new List<String> {
            "Boogie",
            "Boogie",
            "Boogie",
            "Boogie"
            };
        public static readonly List<String> POSECOVER = new List<String> {
            "PoseCover",
            "PoseCover",
            "SchuechternePose",
            "PoseCover"
            };
        public static readonly List<String> POSEHIGH = new List<String> {
            "PoseHigh",
            "PoseHigh",
            "StolzePose",
            "PoseHigh"
            };
        public static readonly List<String> POSELOW = new List<String> {
            "PoseLow",
            "PoseLow",
            "UeberraschtePose",
            "PoseLow"
            };
        public static readonly List<String> POSETWIST = new List<String> {
            "PoseTwist",
            "PoseTwist",
            "HalbherzigePost",
            "BoPoseTwistogie"
            };
        public static readonly List<String> BLOWKISS = new List<String> {
            "BlowKiss",
            "BlowKiss",
            "LuftkussZuwerfen",
            "BlowKiss"
            };
        public static readonly List<String> MAGICTRICK = new List<String> {
            "Magic Trick",
            "Tourdemagie",
            "Zaubertrick",
            "Trucodemagia"
            };
        public static readonly List<String> CHANNEL = new List<String> {
            "Channel",
            "Canaliser",
            "Kanalisieren",
            "Canalizar"
            };
        public static readonly List<String> BARBECUE = new List<String> {
            "Barbecue",
            "Barbecue",
            "Grillen",
            "Barbacoa"
            };
        public static readonly List<String> DRINK = new List<String> {
            "Drink",
            "boire",
            "Trinken",
            "Beber"
            };
        public static readonly List<String> CRABDANCE = new List<String> {
            "Crabdance",
            "danseducrabe",
            "Krabbentanz",
            "bailedelcangrejo"
            };
        public static readonly List<String> SHOCKED = new List<String> {
            "Shocked",
            "Choque",
            "Schockiert",
            "Impactado"
            };
        public static readonly List<String> THUMBSUP = new List<String> {
            "ThumbsUp",
            "Poucehaut",
            "Daumenhoch",
            "Megusta"
            };
        public static readonly List<String> THUMBSDOWN = new List<String> {
            "ThumbsDown",
            "Poucebas",
            "Daumenrunter",
            "Nomegusta"
            };

        #endregion

        #region Rank Emotes
        public static readonly List<String> BEAR = new List<String> {
            "Bear",
            "Ours",
            "Baer",
            "Osa"
            };
        public static readonly List<String> DEER = new List<String> {
            "Deer",
            "Daim",
            "Hirsch",
            "Ciervo"
            };
        public static readonly List<String> DOLYAK = new List<String> {
            "Dolyak",
            "Dolyak",
            "Dolyak",
            "Dolyak"
            };
        public static readonly List<String> DRAGON = new List<String> {
            "Dragon",
            "Dragon",
            "Drache",
            "Dragón"
            };
        public static readonly List<String> PHOENIX = new List<String> {
            "Phoenix",
            "Phénix",
            "Phoenix",
            "Fénix"
            };
        public static readonly List<String> RABBIT = new List<String> {
            "Rabbit",
            "Lapin",
            "Kaninchen",
            "Conejo"
            };
        public static readonly List<String> SHARK = new List<String> {
            "Shark",
            "Requin",
            "Hai",
            "Tiburón"
            };
        public static readonly List<String> TIGER = new List<String> {
            "Tiger",
            "Tigre",
            "Tiger",
            "Tigre"
            };
        public static readonly List<String> WOLF = new List<String> {
            "Wolf",
            "Loup",
            "Wolf",
            "Lobo"
            };
        public static readonly List<String> YOURRANK = new List<String> {
            "Your Rank",
            "Ton Rang",
            "Dein Rang",
            "Su Rango"
            };

        #endregion






    }
}
