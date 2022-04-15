using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAC_MAN
{
    public partial class PacMan : Form
    {
        int score;
        bool left, right, up, down;
        int speed = 8;
        int redSpeed = 8, orangeSpeed = 8, pinkSpeed = 8;

        public PacMan()
        {
            InitializeComponent();
            Game.Start();   
        }

        private void controls(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = true;
                
            }
            if (e.KeyCode == Keys.A)
            {
                left = true;
                
            }
            if (e.KeyCode == Keys.D)
            {
                right = true;
                
            }
            if (e.KeyCode == Keys.S)
            {
                down = true;
                
            }

        }

        private void AFK(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W)
            {
                up = false;
            }
            if (e.KeyCode == Keys.A)
            {
                left = false;
            }
            if (e.KeyCode == Keys.D)
            {
                right = false;
            }
            if (e.KeyCode == Keys.S)
            {
                down = false;
            }

        }

        private void GamePlay(object sender, EventArgs e)
        {
            scoreText.Text = $"Score: {score}";
            redGhost.Left += redSpeed;
            orangeGhost.Left += orangeSpeed;
            pinkGhost.Left += pinkSpeed;

            if (right == true)
            {
                pac_man.Left += speed;
                pac_man.Image = Properties.Resources.right;
                
            }
            if (left == true)
            {
                pac_man.Left -= speed;
                pac_man.Image = Properties.Resources.left;
            }
            if (up == true)
            {
                pac_man.Top -= speed;
                pac_man.Image = Properties.Resources.Up;
            }
            if (down == true)
            {
                pac_man.Top += speed;
                pac_man.Image = Properties.Resources.down;
            }

            foreach(Control hitbox in this.Controls)
            {
                if(hitbox is PictureBox)
                {
                    if((string)hitbox.Tag == "coin" && hitbox.Visible == true)
                    {
                        if (pac_man.Bounds.IntersectsWith(hitbox.Bounds))
                        {
                            score++;
                            hitbox.Visible = false;
                        } 
                    }
                    if((string)hitbox.Tag == "wall")
                    {
                        if (pac_man.Bounds.IntersectsWith(hitbox.Bounds))
                        {
                            GameOver();
                        }
                    }
                    
                    if ((string)hitbox.Tag == "ghost")
                    {
                        if (pac_man.Bounds.IntersectsWith(hitbox.Bounds))
                        {
                            GameOver();
                        }

                    }
                }
            }
            if (redGhost.Bounds.IntersectsWith(wall17.Bounds))    
            {
                redSpeed--;  
            }
            if (orangeGhost.Bounds.IntersectsWith(wall16.Bounds))
            {
                orangeSpeed--;
            }
            if (pinkGhost.Bounds.IntersectsWith(wall16.Bounds))
            {
                pinkSpeed--;
            }
            if (redGhost.Bounds.IntersectsWith(wall15.Bounds))
            {
                redSpeed++;
            }
            if (orangeGhost.Bounds.IntersectsWith(wall18.Bounds))
            {
                orangeSpeed++;
            }
            if (pinkGhost.Bounds.IntersectsWith(wall18.Bounds))
            {
                pinkSpeed++;
            }

            if(score == 43)
            {
                Game.Stop();
                EndGame.Text = $"Score: {score}" + "\nEASY WIN!";
            }
        }

        private void GameOver()
        {
            Game.Stop();
            EndGame.Text = $"Score: {score}" + "\nGAME OVER!";
        }
    }
}