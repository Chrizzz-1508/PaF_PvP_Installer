using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PaF___PvP_Installer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }


        private void frmMain_Load(object sender, EventArgs e)
        {
            #region "Load Stuff"

            cbAttackAnimation.SelectedIndex = Properties.Settings.Default.AttackAnimation;
            cbPauseBaseGame.SelectedIndex = Properties.Settings.Default.PauseBaseGame;
            cbUsePokemonGifs.SelectedIndex = Properties.Settings.Default.UsePokemonGifs;
            cbShowAttackTypes.SelectedIndex = Properties.Settings.Default.ShowAttackTypes;
            cbShowAttacks.SelectedIndex = Properties.Settings.Default.ShowAttacks;
            cbLowSpecMode.SelectedIndex = Properties.Settings.Default.LowSpecMode;
            cbAllowLegendarys.SelectedIndex = Properties.Settings.Default.AllowLegendarys;
            cbChampShuffle.SelectedIndex = Properties.Settings.Default.ChampShuffle;
            cbDoSwitch.SelectedIndex = Properties.Settings.Default.DoSwitch;
            cbLimitPvPScenes.SelectedIndex = Properties.Settings.Default.LimitPvPScenes;
            cbFixedCoordinates.SelectedIndex = Properties.Settings.Default.FixedCoordinates;

            rtbAllowedScenes.Text = Properties.Settings.Default.AllowedScenes;

            txtSwitchName.Text = Properties.Settings.Default.SwitchName;
            txtPokemonSizeModifier.Text = Properties.Settings.Default.PokemonSizeModifier;
            txtAttackpowerMax.Text = Properties.Settings.Default.AttackpowerMax;
            txtAttackpowerMin.Text = Properties.Settings.Default.AttackpowerMin;
            txtAttackIncrease.Text = Properties.Settings.Default.AttackIncrease;
            txtCritChance.Text = Properties.Settings.Default.CritChance;
            txtDodgeChance.Text = Properties.Settings.Default.DodgeChance;
            txtSturdyChance.Text = Properties.Settings.Default.SturdyChance;
            txtChallengeTimer.Text = Properties.Settings.Default.ChallengeTimer;
            txtCooldownTimer.Text = Properties.Settings.Default.CooldownTimer;

            txtChamp.Text = Properties.Settings.Default.Champ;
            txtPriceChamp.Text = Properties.Settings.Default.PriceChamp;
            cbChamp.SelectedIndex = Properties.Settings.Default.UseChamp;

            txtNormal3v3.Text = Properties.Settings.Default.Normal3v3;
            txtPriceNormal3v3.Text = Properties.Settings.Default.PriceNormal3v3;
            cbNormal3v3.SelectedIndex = Properties.Settings.Default.UseNormal3v3;

            txtNormal6v6.Text = Properties.Settings.Default.Normal6v6;
            txtPriceNormal6v6.Text = Properties.Settings.Default.PriceNormal6v6;
            cbNormal6v6.SelectedIndex = Properties.Settings.Default.UseNormal6v6;

            txtRandom3v3.Text = Properties.Settings.Default.Random3v3;
            txtPriceRandom3v3.Text = Properties.Settings.Default.PriceRandom3v3;
            cbRandom3v3.SelectedIndex = Properties.Settings.Default.UseRandom3v3;

            txtRandom6v6.Text = Properties.Settings.Default.Random6v6;
            txtPriceRandom6v6.Text = Properties.Settings.Default.PriceRandom6v6;
            cbRandom6v6.SelectedIndex = Properties.Settings.Default.UseRandom6v6;

            txtRegion.Text = Properties.Settings.Default.Region;
            txtPriceRegion.Text = Properties.Settings.Default.PriceRegion;
            cbRegion.SelectedIndex = Properties.Settings.Default.UseRegion;

            txtBonusChamp.Text = Properties.Settings.Default.BonusChamp;

            txtSAMMI.Text = Properties.Settings.Default.SAMMILocation;
            cbAbsoluteSpeed.SelectedIndex = Properties.Settings.Default.AbsoluteSpeed;
            #endregion

            SetToolTips();
        }
        #region "Extra Stuff"
        private void btnSetItUpForMe_Click(object sender, EventArgs e)
        {
            MessageBox.Show("If you want, I can also do the complete Setup for you, for a small donation / tip.\n\nJust dm me on Discord (Chrizzz#0810) if you are interessted in this service.");
        }

        private void btnSupport_Click(object sender, EventArgs e)
        {
            frmChrizzz frm = new frmChrizzz();
            frm.Show();
        }

        private void btnGermanGuide_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://youtu.be/YcIZ3mIcfu0");
        }

        private void btnEnglishGuide_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://youtu.be/Ta_VgE-DO1o");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            Process.Start("Installation Guide.txt");
            if (DialogResult.Yes == MessageBox.Show("Need more help? Feel free to join my discord! Wanna join now?", "Help", MessageBoxButtons.YesNo))
            {
                Process.Start("https://discord.gg/dZ9ZVJKSJz");
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Please select your SAMMI folder.\nThe SAMMI folder should contain the SAMMI Core.exe and the Pokemon and Friends Folder from the base Game";

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    if (!File.Exists(fb.SelectedPath + "\\SAMMI Core.exe"))
                    {
                        MessageBox.Show("Migration failed.\nUnfortunately this is not the SAMMI folder.\nThe SAMMI folder must contain the SAMMI Core.exe.\nPlease try again and select the correct folder.");
                        btnSearch_Click(null, null);
                        return;
                    }
                    else
                    {
                        if (!Directory.Exists(fb.SelectedPath + @"\Pokemon and Friends\hdsprites240"))
                        {
                            MessageBox.Show("Unfortunately this folder does not contain the base game.\nPlease make sure to install it first.");
                            btnSearch_Click(null, null);
                            return;
                        }
                        txtSAMMI.Text = fb.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't access the file. Please close the .ini File and SAMMI first." + ex.ToString());
            }
        }

        private void cbLimitPvPScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLimitPvPScenes.SelectedIndex == 0)
            {
                lblAllowedScenes.Visible = true;
                rtbAllowedScenes.Visible = true;
            }
            else
            {
                lblAllowedScenes.Visible = false;
                rtbAllowedScenes.Visible = false;
            }
        }

        private void cbFixedCoordinates_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFixedCoordinates.SelectedIndex == 0)
            {
                lblPokemonSizeModifier.Visible = false;
                txtPokemonSizeModifier.Visible = false;
            }
            else
            {
                lblPokemonSizeModifier.Visible = true;
                txtPokemonSizeModifier.Visible = true;
            }
        }
        #endregion

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            Properties.Settings.Default.AttackAnimation = cbAttackAnimation.SelectedIndex;
            Properties.Settings.Default.PauseBaseGame = cbPauseBaseGame.SelectedIndex;
            Properties.Settings.Default.UsePokemonGifs = cbUsePokemonGifs.SelectedIndex;
            Properties.Settings.Default.ShowAttackTypes = cbShowAttackTypes.SelectedIndex;
            Properties.Settings.Default.ShowAttacks = cbShowAttacks.SelectedIndex;
            Properties.Settings.Default.LowSpecMode = cbLowSpecMode.SelectedIndex;
            Properties.Settings.Default.AllowLegendarys = cbAllowLegendarys.SelectedIndex;
            Properties.Settings.Default.ChampShuffle = cbChampShuffle.SelectedIndex;

            Properties.Settings.Default.DoSwitch = cbDoSwitch.SelectedIndex;
            Properties.Settings.Default.LimitPvPScenes = cbLimitPvPScenes.SelectedIndex;
            Properties.Settings.Default.FixedCoordinates = cbFixedCoordinates.SelectedIndex;
            
            Properties.Settings.Default.AllowedScenes = rtbAllowedScenes.Text;
            
            Properties.Settings.Default.SwitchName = txtSwitchName.Text;
            Properties.Settings.Default.PokemonSizeModifier = txtPokemonSizeModifier.Text;

            Properties.Settings.Default.AttackpowerMax = txtAttackpowerMax.Text;
            Properties.Settings.Default.AttackpowerMin = txtAttackpowerMin.Text;
            Properties.Settings.Default.AttackIncrease = txtAttackIncrease.Text;
            Properties.Settings.Default.CritChance = txtCritChance.Text;
            Properties.Settings.Default.DodgeChance = txtDodgeChance.Text;
            Properties.Settings.Default.SturdyChance = txtSturdyChance.Text;
            Properties.Settings.Default.ChallengeTimer = txtChallengeTimer.Text;
            Properties.Settings.Default.CooldownTimer = txtCooldownTimer.Text;
            
            Properties.Settings.Default.Champ = txtChamp.Text;
            Properties.Settings.Default.PriceChamp = txtPriceChamp.Text;
            Properties.Settings.Default.UseChamp = cbChamp.SelectedIndex;

            Properties.Settings.Default.Normal3v3 = txtNormal3v3.Text;
            Properties.Settings.Default.PriceNormal3v3 = txtPriceNormal3v3.Text;
            Properties.Settings.Default.UseNormal3v3 = cbNormal3v3.SelectedIndex;

            Properties.Settings.Default.Normal6v6 = txtNormal6v6.Text;
            Properties.Settings.Default.PriceNormal6v6 = txtPriceNormal6v6.Text;
            Properties.Settings.Default.UseNormal6v6 = cbNormal6v6.SelectedIndex;
            
            Properties.Settings.Default.Random3v3 = txtRandom3v3.Text;
            Properties.Settings.Default.PriceRandom3v3 = txtPriceRandom3v3.Text;
            Properties.Settings.Default.UseRandom3v3 = cbRandom3v3.SelectedIndex;

            Properties.Settings.Default.Random6v6 = txtRandom6v6.Text;
            Properties.Settings.Default.PriceRandom6v6 = txtPriceRandom6v6.Text;
            Properties.Settings.Default.UseRandom6v6 = cbRandom6v6.SelectedIndex;

            Properties.Settings.Default.Region = txtRegion.Text;
            Properties.Settings.Default.PriceRegion = txtPriceRegion.Text;
            Properties.Settings.Default.UseRegion = cbRegion.SelectedIndex;

            Properties.Settings.Default.BonusChamp = txtBonusChamp.Text;

            Properties.Settings.Default.SAMMILocation = txtSAMMI.Text;
            Properties.Settings.Default.AbsoluteSpeed = cbAbsoluteSpeed.SelectedIndex;

            Properties.Settings.Default.Save();
        }

        private void SetToolTips()
        {
            TTExplanation.SetToolTip(lblSAMMI, "Please select your SAMMI location.\n It needs to have the Pokemon and Friends Mod installed already.");
            TTExplanation.SetToolTip(lblAttackAnimation, "Select the kind of attack Movement which the Pokemons should make.");
            TTExplanation.SetToolTip(lblPauseBaseGame, "Pause the catching game when a PvP fight is running.");
            TTExplanation.SetToolTip(lblUsePokemonGifs, "Use Gifs for the Pokemons when they exist.\nElse PNG files will be used.");
            TTExplanation.SetToolTip(lblShowAttackTypes, "Show the type of attack that was used in the textbox.\nFor example fire, water, ice,...");
            TTExplanation.SetToolTip(lblShowAttacks, "Show Attack moves on the enemy\n(they play a video animation + attack sound)");
            TTExplanation.SetToolTip(lblLowSpecMode, "Enable this only when your PC is really bad");
            TTExplanation.SetToolTip(lblAllowLegendarys, "Allow legendary / mythical Pokemons to be used in the normal teams.");
            TTExplanation.SetToolTip(lblChampShuffle, "Shuffle the order of the Pokemons from the Champ each time he get's challenged.\nEnable this to make it harder for Challengers to counterpick the champ.");
            TTExplanation.SetToolTip(lblDoSwitch, "Automatically switch to a specific scene when a fight is redeemed.");
            TTExplanation.SetToolTip(lblSwitchName,"Enter the name of the scene where you want to switch.\nPlease make sure to spell the name correct.");
            TTExplanation.SetToolTip(lblFixedCoordinates,"Used fixed coordinates for the Pokemons.\nYou can still move the scene around.\nSelect only no if you want to redesign the battle scene.");
            TTExplanation.SetToolTip(lblPokemonSizeModifier,"Set's the size of the Pokemon (1 = x1 = normal size)");
            TTExplanation.SetToolTip(lblLimitPvPScenes,"Limits PvP Redemptions to specific scenes.");
            TTExplanation.SetToolTip(lblAllowedScenes,"Please enter a list of all the scenes where you want to allow the PvP Challenges.\nOne scene per Line.\nMake sure you spell them correctly.");
            TTExplanation.SetToolTip(lblAttackpowerMin, "Minimum Base Attack Power of Attacks.");
            TTExplanation.SetToolTip(lblAttackpowerMax,"Maximum Base Attack Power of Attacks.");
            TTExplanation.SetToolTip(lblAttackIncrease,"Get's added on top of the attack.\nIn the normal games this value is 2.");
            TTExplanation.SetToolTip(lblCritChance,"Chance in % to do a critical hit");
            TTExplanation.SetToolTip(lblDodgeChance,"Chance in % to dodge an attack.");
            TTExplanation.SetToolTip(lblSturdyChance,"Maximum chance in % of surviving a hit with 1HP.\nActual value depends on the likeability of the trainer.");
            TTExplanation.SetToolTip(lblChallengeTimer, "Time in seconds how long people can accept\nchallenges until they get canceled and refunded.");
            TTExplanation.SetToolTip(lblCooldownTimer,"Time in seconds of how long it takes after a battle until\nthe next Battle can be redeemed");
            TTExplanation.SetToolTip(lblChamp, "Channel Point Name for the Battle vs the Champ.\n It's a 6vs6 Battle with their own Pokemon.\nViewers will need to set their team first.\nIf they beat the champ, they will become the new one.");
            TTExplanation.SetToolTip(lblNormal3V3, "Channel Point Name for the 3vs3 Battle with their own Pokemon.\nViewers will need to set their team first.");
            TTExplanation.SetToolTip(lblNormal6vs6, "Channel Point Name for the 6vs6 Battle with their own Pokemon.\nViewers will need to set their team first.");
            TTExplanation.SetToolTip(lblRandom3v3, "Channel Point Name for the 3vs3 Battle with Random Pokemon.\nViewers will get random Pokemons which they don't need\nto have caught and fight with them.");
            TTExplanation.SetToolTip(lblRandom6v6,"Channel Point Name for the 6vs6 Battle with Random Pokemon.\nViewers will get random Pokemons which they don't need\nto have caught and fight with them.");
            TTExplanation.SetToolTip(lblRegion, "Channel Point Name for the Gym Battles.\nViewers will need to set their team first.\nDefeating all challengers of a region\nwill award a permanent bonus catchrate.");

            TTExplanation.SetToolTip(lblBonusChamp, "Amount in percent of the catchrate\nincrease for the current champ.");
            TTExplanation.SetToolTip(lblAbsoluteSpeed, "If you enable this option, the Pokemon\nwith higher Speed will always attack first.\nOtherwise it will only have an increased\nchance to go first.");
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            if (!CheckValues())
            {
                MessageBox.Show("Not all fields were filled out correctly. Please fill out all fields first.");
                return;
            }
            pbLoading.Visible = true;
            lblLoading.Parent = pbLoading;
            lblLoading.Visible = true;
            CreateSAMMIExtension();
            Thread t = new Thread(CopyFiles);
            t.Start();
            while (t.IsAlive)
            {
                Application.DoEvents();
                Thread.Sleep(100);
            }
            pbLoading.Visible = false;

            MessageBox.Show("Installation completed.\n\nNext please Install the PaF_PvP_AddOn.sef Extension from your \"SAMMI => Pokemon and Friends\" folder.");

        }

        private void CreateSAMMIExtension()
        {
            string VAR_ATTACK_ANIMATION_VAR = "";
            switch (cbAttackAnimation.SelectedIndex)
            {
                case 0:
                    VAR_ATTACK_ANIMATION_VAR = "random";
                    break;
                case 1:
                    VAR_ATTACK_ANIMATION_VAR = "hybrid";
                    break;
                case 2:
                    VAR_ATTACK_ANIMATION_VAR = "lunge";
                    break;
                case 3:
                    VAR_ATTACK_ANIMATION_VAR = "circle";
                    break;
                case 4:
                    VAR_ATTACK_ANIMATION_VAR = "none";
                    break;
                default:
                    break;
            }

            string VAR_CHAMP_USE_VAR = "true";
            if (cbChamp.SelectedIndex == 1) VAR_CHAMP_USE_VAR = "false";

            string VAR_3v3N_USE_VAR = "true";
            if (cbNormal3v3.SelectedIndex == 1) VAR_3v3N_USE_VAR = "false";

            string VAR_6v6N_USE_VAR = "true";
            if (cbNormal6v6.SelectedIndex == 1) VAR_6v6N_USE_VAR = "false";

            string VAR_3v3R_USE_VAR = "true";
            if (cbRandom3v3.SelectedIndex == 1) VAR_3v3R_USE_VAR = "false";

            string VAR_6v6R_USE_VAR = "true";
            if (cbRandom6v6.SelectedIndex == 1) VAR_6v6R_USE_VAR = "false";

            string VAR_REGION_USE_VAR = "true";
            if (cbRegion.SelectedIndex == 1) VAR_REGION_USE_VAR = "false";

            string VAR_STOP_BASE_GAME_VAR = "true";
            if (cbPauseBaseGame.SelectedIndex == 1) VAR_STOP_BASE_GAME_VAR = "false";

            string VAR_USE_POKEMON_GIFS_VAR = "true";
            if (cbUsePokemonGifs.SelectedIndex == 1) VAR_USE_POKEMON_GIFS_VAR = "false";

            string VAR_SHOW_ATTACK_TYPES_VAR = "true";
            if (cbShowAttackTypes.SelectedIndex == 1) VAR_SHOW_ATTACK_TYPES_VAR = "false";

            string VAR_SHOW_ATTACKS_VAR = "true";
            if (cbShowAttacks.SelectedIndex == 1) VAR_SHOW_ATTACKS_VAR = "false";

            string VAR_LOW_SPEC_VAR = "true";
            if (cbLowSpecMode.SelectedIndex == 1) VAR_LOW_SPEC_VAR = "false";

            string VAR_ALLOW_LEGENDARYS_VAR = "true";
            if (cbAllowLegendarys.SelectedIndex == 1) VAR_ALLOW_LEGENDARYS_VAR = "false";

            string VAR_SHUFFLE_CHAMP_VAR = "true";
            if (cbChampShuffle.SelectedIndex == 1) VAR_SHUFFLE_CHAMP_VAR = "false";

            string VAR_FIXED_COORDINATES_VAR = "true";
            if (cbFixedCoordinates.SelectedIndex == 1) VAR_FIXED_COORDINATES_VAR = "false";

            string VAR_ABSOLUTE_SPEED_VAR = "true";
            if (cbAbsoluteSpeed.SelectedIndex == 1) VAR_ABSOLUTE_SPEED_VAR = "false";

            StreamReader sr = new StreamReader(@"files\PaF_PvP_Unconverted");
            string s = sr.ReadToEnd();

            s = s.Replace("VAR_CHAMP_NAME_VAR", txtChamp.Text);
            s = s.Replace("VAR_CHAMP_PRICE_VAR", txtPriceChamp.Text);
            s = s.Replace("VAR_CHAMP_USE_VAR", VAR_CHAMP_USE_VAR);

            s = s.Replace("VAR_3V3N_NAME_VAR", txtNormal3v3.Text);
            s = s.Replace("VAR_3v3N_PRICE_VAR", txtPriceNormal3v3.Text);
            s = s.Replace("VAR_3v3N_USE_VAR", VAR_3v3N_USE_VAR);

            s = s.Replace("VAR_6v6N_NAME_VAR", txtNormal6v6.Text);
            s = s.Replace("VAR_6v6N_PRICE_VAR", txtPriceNormal6v6.Text);
            s = s.Replace("VAR_6v6N_USE_VAR", VAR_6v6N_USE_VAR);

            s = s.Replace("VAR_3v3R_NAME_VAR", txtRandom3v3.Text);
            s = s.Replace("VAR_3v3R_PRICE_VAR", txtPriceRandom3v3.Text);
            s = s.Replace("VAR_3v3R_USE_VAR", VAR_3v3R_USE_VAR);

            s = s.Replace("VAR_6v6R_NAME_VAR", txtRandom6v6.Text);
            s = s.Replace("VAR_6v6R_PRICE_VAR", txtPriceRandom6v6.Text);
            s = s.Replace("VAR_6v6R_USE_VAR", VAR_6v6R_USE_VAR);

            s = s.Replace("VAR_REGION_NAME_VAR", txtRegion.Text);
            s = s.Replace("VAR_REGION_PRICE_VAR", txtPriceRegion.Text);
            s = s.Replace("VAR_REGION_USE_VAR", VAR_REGION_USE_VAR);

            s = s.Replace("VAR_ATTACK_ANIMATION_VAR", VAR_ATTACK_ANIMATION_VAR);
            s = s.Replace("VAR_STOP_BASE_GAME_VAR", VAR_STOP_BASE_GAME_VAR);
            s = s.Replace("VAR_USE_POKEMON_GIFS_VAR", VAR_USE_POKEMON_GIFS_VAR);
            s = s.Replace("VAR_SHOW_ATTACK_TYPES_VAR", VAR_SHOW_ATTACK_TYPES_VAR);
            s = s.Replace("VAR_SHOW_ATTACKS_VAR", VAR_SHOW_ATTACKS_VAR);
            s = s.Replace("VAR_LOW_SPEC_VAR", VAR_LOW_SPEC_VAR);
            s = s.Replace("VAR_ALLOW_LEGENDARYS_VAR", VAR_ALLOW_LEGENDARYS_VAR);
            s = s.Replace("VAR_SHUFFLE_CHAMP_VAR", VAR_SHUFFLE_CHAMP_VAR);
            s = s.Replace("VAR_BONUS_CHAMP_VAR", txtBonusChamp.Text);

            s = s.Replace("VAR_CHALLENGE_TIMER_VAR", txtChallengeTimer.Text);
            s = s.Replace("VAR_COOLDOWN_TIMER_VAR", txtCooldownTimer.Text);

            s = s.Replace("VAR_ATTACK_MIN_VAR", txtAttackpowerMin.Text);
            s = s.Replace("VAR_ATTACK_MAX_VAR", txtAttackpowerMax.Text);
            s = s.Replace("VAR_ATTACK_INCREASE_VAR", txtAttackIncrease.Text);
            s = s.Replace("VAR_CRITCHANCE_VAR", txtCritChance.Text);
            s = s.Replace("VAR_DODGECHANCE_VAR", txtDodgeChance.Text);
            s = s.Replace("VAR_STURDYCHANCE_VAR", txtSturdyChance.Text);

            s = s.Replace("VAR_ABSOLUTE_SPEED_VAR", VAR_ABSOLUTE_SPEED_VAR);


            if (cbLimitPvPScenes.SelectedIndex == 0)
            {
               s = s.Replace("VAR_ALLOWED_SCENES_VAR", rtbAllowedScenes.Text.Replace("\n",","));
            }
            else
            {
                s = s.Replace("VAR_ALLOWED_SCENES_VAR", "");
            }

            if (cbDoSwitch.SelectedIndex == 0)
            {
                s = s.Replace("VAR_SWITCH_SCENE_VAR", txtSwitchName.Text);
            }
            else
            {
                s = s.Replace("VAR_SWITCH_SCENE_VAR", "");
            }
            
            s = s.Replace("VAR_FIXED_COORDINATES_VAR", VAR_FIXED_COORDINATES_VAR);

            if (cbFixedCoordinates.SelectedIndex == 1)
            {
                s = s.Replace("VAR_SIZE_MODIFIER_VAR", txtPokemonSizeModifier.Text.Replace(",", "."));
            }
            else
            {
                s = s.Replace("VAR_SIZE_MODIFIER_VAR", "1");
            }

            s = s.Replace("\"include_image\": { }", "\"include_image\": { } ,\"transmitter\":true, \"sammi_version\":\"2022.4.4\", \"extension_triggers\":[\"PVP_INSTALL\"], \"required_extension\":[\"PokemonAndFriend Mod\"] }");


            using (StreamWriter sw = new StreamWriter(txtSAMMI.Text + @"\Pokemon and Friends\PaF_PvP_AddOn.sef"))
            {
                sw.Write(s);
                sw.Flush();
                sw.Close();
            }
        }
    

        private void CopyFiles()
        {
            string sPAFPath = txtSAMMI.Text + @"\Pokemon and Friends";
            if (!Directory.Exists(sPAFPath + @"\attacks")) Directory.CreateDirectory(sPAFPath + @"\attacks");
            if (!Directory.Exists(sPAFPath + @"\battle_music")) Directory.CreateDirectory(sPAFPath + @"\battle_music");
            if (!Directory.Exists(sPAFPath + @"\cries")) Directory.CreateDirectory(sPAFPath + @"\cries");
            if (!Directory.Exists(sPAFPath + @"\hpbar")) Directory.CreateDirectory(sPAFPath + @"\hpbar");
            if (!Directory.Exists(sPAFPath + @"\trainers")) Directory.CreateDirectory(sPAFPath + @"\trainers");

            //Copy Attacks
            DirectoryInfo diAttacks = new DirectoryInfo(@"files\attacks");
            foreach (FileInfo f in diAttacks.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\attacks\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Copy Battle Music
            DirectoryInfo diBattle_Music = new DirectoryInfo(@"files\battle_music");
            foreach (FileInfo f in diBattle_Music.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\battle_music\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Create Array:
            List<string> lsGen9 = new List<string>();
            for (int i = 906; i <= 1008; i++)
            {
                lsGen9.Add(i.ToString() + ".wav");
            }

            //Copy Cries
            DirectoryInfo diCries = new DirectoryInfo(@"files\cries");
            foreach (FileInfo f in diCries.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\cries\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                    else
                    {
                        for (int i = 0; i < lsGen9.Count; i++)
                        {
                            if (f.FullName.Contains(lsGen9[i])) File.Copy(f.FullName, fptarget, true);
                        }
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Copy Database
            DirectoryInfo diDatabase = new DirectoryInfo(@"files\database");
            foreach (FileInfo f in diDatabase.GetFiles())
            {
                if (f.Name == "gym_database.csv")
                {
                    string fptarget = sPAFPath + @"\database\" + f.Name;
                    if (File.Exists(fptarget))
                    {
                        try
                        {
                            string sChamp = "";
                            using (StreamReader sr = new StreamReader(fptarget))
                            {
                                sr.ReadLine();
                                sChamp = sr.ReadLine();
                                sr.Close();
                            }
                            File.Copy(f.FullName, fptarget, true);

                            string sCSV = "";
                            using (StreamReader sr = new StreamReader(fptarget))
                            {
                                sCSV = sr.ReadToEnd().Replace("0,0,0,chrizzz_1508,chrizzz_1508,chrizzz_1508,chrizzz_1508,chrizzz_1508,3,6,9,149,150,130,30,4", sChamp);
                                sr.Close();
                            }
                            using (StreamWriter sw = new StreamWriter(fptarget, false))
                            {
                                sw.Write(sCSV);
                                sw.Close();
                            }
                        }
                        catch(Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else
                    {
                        try
                        {
                            File.Copy(f.FullName, fptarget, true);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                    }
                }
                else
                {
                    try
                    {
                        string fptarget = sPAFPath + @"\database\" + f.Name;
                        File.Copy(f.FullName, fptarget, true);
                    }
                    catch (Exception ex) { MessageBox.Show(ex.ToString()); }
                }
            }

            //Copy HP
            DirectoryInfo diHP = new DirectoryInfo(@"files\hpbar");
            foreach (FileInfo f in diHP.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\hpbar\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch(Exception e) { MessageBox.Show(e.ToString()); }
            }

            //Copy Trainers
            DirectoryInfo diTrainers = new DirectoryInfo(@"files\trainers");
            foreach (FileInfo f in diTrainers.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\trainers\" + f.Name;
                    File.Copy(f.FullName, fptarget, true);
                }
                catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            }

            //Copy Sources
            DirectoryInfo diSources = new DirectoryInfo(@"files\sources");
            foreach (FileInfo f in diSources.GetFiles())
            {
                try
                {
                    string fptarget = sPAFPath + @"\sources\" + f.Name;
                    if (!File.Exists(fptarget)) File.Copy(f.FullName, fptarget);
                }
                catch (Exception e) { MessageBox.Show(e.ToString()); }
            }
        }

        private bool CheckValues()
        {
            if (string.IsNullOrEmpty(txtSAMMI.Text)) return false;

            if (string.IsNullOrEmpty(txtAttackpowerMin.Text)) return false;
            if (string.IsNullOrEmpty(txtAttackpowerMax.Text)) return false;
            if (string.IsNullOrEmpty(txtAttackIncrease.Text)) return false;
            if (string.IsNullOrEmpty(txtCritChance.Text)) return false;
            if (string.IsNullOrEmpty(txtDodgeChance.Text)) return false;
            if (string.IsNullOrEmpty(txtSturdyChance.Text)) return false;
            if (string.IsNullOrEmpty(txtChallengeTimer.Text)) return false;
            if (string.IsNullOrEmpty(txtCooldownTimer.Text)) return false;

            if (string.IsNullOrEmpty(txtChamp.Text)) return false;
            if (string.IsNullOrEmpty(txtPriceChamp.Text)) return false;
            if (string.IsNullOrEmpty(txtNormal3v3.Text)) return false;
            if (string.IsNullOrEmpty(txtPriceNormal3v3.Text)) return false;
            if (string.IsNullOrEmpty(txtNormal6v6.Text)) return false;
            if (string.IsNullOrEmpty(txtPriceNormal6v6.Text)) return false;
            if (string.IsNullOrEmpty(txtRandom3v3.Text)) return false;
            if (string.IsNullOrEmpty(txtPriceRandom3v3.Text)) return false;
            if (string.IsNullOrEmpty(txtRandom6v6.Text)) return false;
            if (string.IsNullOrEmpty(txtPriceRandom6v6.Text)) return false;

            if (cbDoSwitch.SelectedIndex == 0 && String.IsNullOrEmpty(txtSwitchName.Text)) return false;
            if (cbLimitPvPScenes.SelectedIndex == 0 && String.IsNullOrEmpty(rtbAllowedScenes.Text)) return false;

            return true;
        }

        private void cbDoSwitch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbDoSwitch.SelectedIndex == 0)
            {
                lblSwitchName.Visible = true;
                txtSwitchName.Visible = true;
            }
            else
            {
                lblSwitchName.Visible = false;
                txtSwitchName.Visible = false;
            }
        }
    }
}
