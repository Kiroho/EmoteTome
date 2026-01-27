using Blish_HUD.Modules.Managers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace EmoteTome
{
    //[Export(typeof(Blish_HUD.Modules.Module))]
    class EmoteLibrary //: Blish_HUD.Modules.Module
    {
        ContentsManager contentsManager;
        private static readonly String CORELIST = "Emotes/Core/Json/emotelist.txt";
        private static readonly String COREJSON = "Emotes/Core/Json/";
        private static readonly String UNLOCKLIST = "Emotes/Unlock/Json/emotelist.txt";
        private static readonly String UNLOCKJSON = "Emotes/Unlock/Json/";
        private static readonly String RANKLIST = "Emotes/Rank/Json/emotelist.txt";
        private static readonly String RANKJSON = "Emotes/Rank/Json/";
        public const String CORECODE = "core";
        public const String UNLOCKCODE = "unlock";
        public const String RANKCODE = "rank";
        public EmoteLibrary(ContentsManager manager)
        {
            this.contentsManager = manager;
        }

        private List<Emote> loadEmoteFiles(String listpath, String jsonPath)
        {
            List<Emote> emoteList = new List<Emote>();
            Stream emoteListStream;
            //Read emotelist
            try
            {
                emoteListStream = contentsManager.GetFileStream(listpath);
                int filesize = (int)emoteListStream.Length;
                var buffer = new byte[filesize];
                emoteListStream.Position = 0;
                emoteListStream.Read(buffer, 0, filesize);
                emoteListStream.Close();
                //String[] emoteStreamString = Encoding.UTF8.GetString(buffer).Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
                List<String> emoteStreamString = new List<string>();
                using (StringReader reader = new StringReader(Encoding.UTF8.GetString(buffer)))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        emoteStreamString.Add(line);
                    }
                }

                ;

                //Read Jsons
                foreach (String name in emoteStreamString)
                {
                    try
                    {
                        //Name zeigt alle namen an
                        Stream jsonStream = contentsManager.GetFileStream(jsonPath + name + ".json");
                        Debug.WriteLine("name: " + name);
                        filesize = (int)jsonStream.Length;
                        buffer = new byte[filesize];
                        jsonStream.Position = 0;
                        jsonStream.Read(buffer, 0, filesize);
                        jsonStream.Close();
                        emoteList.Add(JsonConvert.DeserializeObject<Emote>(Encoding.UTF8.GetString(buffer)));

                    }
                    catch (Exception e)
                    {
                        Debug.WriteLine("Error Occoured: " + e.StackTrace);
                    }

                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Error Occoured: " + e.StackTrace);
            }

            return emoteList;
        }

        public List<Emote> loadCoreEmotes()
        {
            return loadEmoteFiles(CORELIST, COREJSON);
        }
        public List<Emote> loadUnlockEmotes()
        {
            return loadEmoteFiles(UNLOCKLIST, UNLOCKJSON);
        }
        public List<Emote> loadRankEmotes()
        {
            return loadEmoteFiles(RANKLIST, RANKJSON);
        }



    }
}
