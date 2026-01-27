using Blish_HUD.Controls;
using System;
using System.Collections.Generic;

namespace EmoteTome
{
    public class Emote
    {
        private String imagePath;
        private List<String> toolTipp;
        private String chatCode;
        private bool canTarget;
        //private Image img = new Image();
        private EmoteContainer emoCon = new EmoteContainer();
        private EmoteContainer favCon;
        private String category;
        private bool deactivatedByTargeting = false;
        private bool deactivatedByLocked = false;
        private bool deactivatedByCooldown = false;

        public Emote(String imagePath, List<String> toolTipp, String chatCode, bool canTarget, String category)
        {
            this.imagePath = imagePath;
            this.toolTipp = toolTipp;
            this.chatCode = chatCode;
            this.canTarget = canTarget;
            this.category = category;
        }

        //getter / setter        
        public String getImagePath()
        {
            return imagePath;
        }

        public List<String> getToolTipp()
        {
            return toolTipp;
        }

        public String getChatCode()
        {
            return chatCode;
        }

        public bool hasTarget()
        {
            return canTarget;
        }

        //public void setImg(Image img)
        //{
        //    this.img = img;
        //}
        //public Image getImg()
        //{
        //    return img;
        //}

        public void setContainer(EmoteContainer container)
        {
            this.emoCon = container;
        }
        public EmoteContainer getContainer()
        {
            return emoCon;
        }
        public void setFavContainer(EmoteContainer container)
        {
            favCon = new EmoteContainer();
            favCon = container;
        }
        public EmoteContainer getFavContainer()
        {
            return favCon;
        }


        public String getCategory()
        {
            return category;
        }

        public bool isDeactivatedByTargeting()
        {
            return deactivatedByTargeting;
        }

        public void isDeactivatedByTargeting(bool newBool)
        {
            deactivatedByTargeting = newBool;
        }

        public bool isDeactivatedByLocked()
        {
            return deactivatedByLocked;
        }

        public void isDeactivatedByLocked(bool newBool)
        {
            deactivatedByLocked = newBool;
        }
        public bool isDeactivatedByCooldown()
        {
            return deactivatedByCooldown;
        }

        public void isDeactivatedByCooldown(bool newBool)
        {
            deactivatedByCooldown = newBool;
        }

    }
}
