using NavalVessels.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavalVessels.Models
{
    public class Battleship : Vessel, IBattleship
    {
        private const double InitialArmorThickness = 300;
        private bool sonarMode = false;
        public Battleship(string name, double mainWeaponCaliber, double speed) 
            : base(name, mainWeaponCaliber, speed, InitialArmorThickness)
        {
        }

        public bool SonarMode => this.sonarMode;

        public void ToggleSonarMode()
        {
            if (this.SonarMode == false)
            {
                this.sonarMode = true;
                this.MainWeaponCaliber += 40;
                this.Speed -= 5;
            }
            else
            {
                this.sonarMode = false;
                this.MainWeaponCaliber -= 40;
                this.Speed += 5;
            }
        }
        public override void RepairVessel()
        {
            this.ArmorThickness = InitialArmorThickness;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine($" *Sonar mode: {(SonarMode == true ? "ON" : "OFF")}");
            return sb.ToString().TrimEnd();
        }
    }
}
