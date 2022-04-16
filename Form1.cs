using System;
using System.Media;
using System.Windows.Forms;

namespace PAC_MAN
{
    public partial class PacMan : Form
    {
        int score;
        bool left, right, up, down;
        int speed = 7;
        int redSpeed = 10, orangeSpeed = 9, pinkSpeed = 10, vulnerableSpeed = 11;
        bool gameOver;

        public PacMan()
        {
            InitializeComponent();
            Game.Start();
            SoundTrack();
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
            if(e.KeyCode == Keys.R)
            {
                Reset();
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
            redGhost.Left -= redSpeed;
            orangeGhost.Left += orangeSpeed;
            pinkGhost.Left -= pinkSpeed;
            vulnerableGhost.Left += vulnerableSpeed;

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
                redSpeed++;  
            }
            if (orangeGhost.Bounds.IntersectsWith(wall16.Bounds))
            {
                orangeSpeed--;
            }
            if (pinkGhost.Bounds.IntersectsWith(wall16.Bounds))
            {
                pinkSpeed++;
            }
            if (redGhost.Bounds.IntersectsWith(wall15.Bounds))
            {
                redSpeed--;
            }
            if (orangeGhost.Bounds.IntersectsWith(wall18.Bounds))
            {
                orangeSpeed++;
            }
            if (pinkGhost.Bounds.IntersectsWith(wall18.Bounds))
            {
                pinkSpeed--;
            }
            if (vulnerableGhost.Bounds.IntersectsWith(wall2.Bounds))
            {
                vulnerableSpeed--;
            }
            if (vulnerableGhost.Bounds.IntersectsWith(wall1.Bounds))
            {
                vulnerableSpeed++;
            }

            if (score == 43)
            {
                Game.Stop();
                EndGame.Text = $"Score: {score}" + "\nEASY WIN!" + "\nPress R to reset";
            }
        }

        private void Reset()
        {
            Game.Start();
            EndGame.Text = null;
            gameOver = false;
            score = 0;
            speed = 7;
            redSpeed = 8;
            orangeSpeed = 8; 
            pinkSpeed = 8;
            vulnerableSpeed = 11;

            pac_man.Left = 29;
            pac_man.Top = 186;

            redGhost.Left = 460;
            redGhost.Top = 396;

            orangeGhost.Left = 544;
            orangeGhost.Top = 12;

            pinkGhost.Left = 482;
            pinkGhost.Top = 98;

            vulnerableGhost.Left = 432;
            vulnerableGhost.Top = 290;
            foreach (Control GIF in this.Controls)
            {
                if(GIF is PictureBox)
                {
                    GIF.Visible = true;
                }
            }
        }
        private void SoundTrack()
        {
            SoundPlayer soundtrack = new SoundPlayer(@"C:\Users\mezeimark01\Documents\PAC-MAN\PAC-MAN\Resources\pac man original theme.wav");
            soundtrack.PlayLooping();
        }
        private void GameOver()
        {
            gameOver = true;
            Game.Stop();
            EndGame.Text = $"Score: {score}" + "\nGAME OVER!" + "\nPress R to reset";
        }
    }
}