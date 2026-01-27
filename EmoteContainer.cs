using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Image = Blish_HUD.Controls.Image;

namespace Blish_HUD.Controls
{
    public class EmoteContainer : Container
    {
        //Container that is used to organize image + label of an emote.

        private Image img;
        private Label label;
        private Label cooldownLabel;

        public EmoteContainer()
        {
        }

        public void setImage(Image newImage)
        {
            this.img = newImage;
        }
        public Image getImage()
        {
            return img;
        }

        public void setLabel(Label newLabel)
        {
            this.label = newLabel;
        }
        public Label getLabel()
        {
            return label;
        }

        public void setCooldownLabel(Label newLabel)
        {
            this.cooldownLabel = newLabel;
        }
        public Label getCooldownLabel()
        {
            return cooldownLabel;
        }

    }
}
