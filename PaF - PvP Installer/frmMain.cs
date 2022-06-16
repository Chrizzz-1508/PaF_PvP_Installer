using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PaF___PvP_Installer
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            try
            {
                FolderBrowserDialog fb = new FolderBrowserDialog();
                fb.Description = "Select your LB2 folder\nIt should contain the LioranBoard 2.0.exe and the Pokemon and Friends Folder from the base Game";

                if (fb.ShowDialog() == DialogResult.OK)
                {
                    if (!Directory.Exists(fb.SelectedPath + "\\transmitter") || !File.Exists(fb.SelectedPath + "\\LioranBoard 2.0.exe"))
                    {
                        MessageBox.Show("Unfortunately this is not the LB2 folder.\nThe LB2 folder contains a transmitter folder and the Lioranboard 2.0.exe.\nPlease select the correct folder.");
                        btnSearch_Click(null, null);
                    }
                    else
                    {
                        if (!Directory.Exists(fb.SelectedPath + "\\Pokemon and Friends"))
                        {
                            MessageBox.Show("Unfortunately this folder does not contain the base game.\nPlease make sure to install it first.");
                            btnSearch_Click(null, null);
                        }
                        txtLB2.Text = fb.SelectedPath;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Can't access the file. Please close the .ini File and Lioaran Board first." + ex.ToString());
            }
        }

        private void cbLimitPvPScenes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbLimitPvPScenes.SelectedIndex == 0)
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
            if(cbFixedCoordinates.SelectedIndex == 0)
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

        private void frmMain_Load(object sender, EventArgs e)
        {

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
            Process.Start(@"https://www.twitch.tv/chrizzz_1508");
        }

        private void btnEnglishGuide_Click(object sender, EventArgs e)
        {
            Process.Start(@"https://www.twitch.tv/chrizzz_1508");
        }

        private void btnHelp_Click(object sender, EventArgs e)
        {
            //Process.Start("Pokemon and Friends Mod V1.0.pdf");
            if (DialogResult.Yes == MessageBox.Show("Need more help? Feel free to join my discord! Wanna join now?", "Help", MessageBoxButtons.YesNo))
            {
                Process.Start("https://discord.gg/A3VF9kW");
            }
        }
        #endregion
    }
}
